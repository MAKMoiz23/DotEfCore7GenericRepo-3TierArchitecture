using System.ComponentModel.DataAnnotations;
using DAL.Data;

namespace DAL.Models
{
    public class Customer : BaseEntity
	{
		public int? CountryID { get; set; }
		public int? CityID { get; set; }
		public int? UserID { get; set; }
		public string? FullName { get; set; }

		[EmailAddress]
		public string? Email { get; set; }
		public DateTime? DOB { get; set; }
		public string? Gender { get; set; }

		[Phone]
		public string? Mobile { get; set; }
		public bool? IsEmail { get; set; }
		public bool? IsSms { get; set; }
		public bool? IsActive { get; set; }
		public string? Address { get; set; }

		[Range(1, 3)]
		public decimal? RedeemPoints { get; set; }
		public decimal? CurrentPoint { get; set; }
		public int? LocationID { get; set; }
	}
}
