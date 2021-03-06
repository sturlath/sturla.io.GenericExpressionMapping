﻿using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Core.Interfaces;
using Core.Mappers;
using DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer;
using System;

namespace sturla.io.GenericExpressionMapping
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// This was my problem! All works when I swap it out for the code after it
			//services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			//// Auto Mapper Configurations
			//AutoMapper.Mapper.Initialize(cfg =>
			//{
			//	cfg.DisableConstructorMapping();
			//	cfg.AddExpressionMapping();
			//	cfg.AddProfile<CompanyProfile>();
			//});

			// Thanks to Ivan this solves my problem https://stackoverflow.com/a/56407651/1187583
			services.AddAutoMapper(cfg =>
			{
				cfg.DisableConstructorMapping();
				cfg.AddExpressionMapping();
				cfg.AddProfile<CompanyProfile>();
			}, AppDomain.CurrentDomain.GetAssemblies());

#if DEBUG
			// Validates the mapping
			//AutoMapper.Mapper.AssertConfigurationIsValid();
#endif

			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddTransient<ICompanyService, CompanyService>();
			services.AddTransient<ICompanyRepository, CompanyRepository>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
