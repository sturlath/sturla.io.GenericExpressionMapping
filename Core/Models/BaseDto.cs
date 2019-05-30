using System.Runtime.Serialization;

namespace Core.Models
{
	[DataContract]
	public abstract class BaseDto
	{
		/// <summary>
		/// Gets or Sets Id
		/// </summary>
		[DataMember(Name = "id")]
		public int Id { get; set; }
	}
}
