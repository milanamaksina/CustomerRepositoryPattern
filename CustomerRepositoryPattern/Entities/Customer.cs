using System.ComponentModel.DataAnnotations;

namespace CustomerRepositoryPattern.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [MaxLength(50, ErrorMessage = "The length can't be more than 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required"), MaxLength(50, ErrorMessage = "The length can't be more than 50 characters")]
        public string LastName { get; set; }
        [MaxLength(15, ErrorMessage = "Invalid Phone")]
        public string PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Notes are required")]
        public string Notes { get; set; }
        public decimal? TotalPurchasesAmount { get; set; }
    }
}
