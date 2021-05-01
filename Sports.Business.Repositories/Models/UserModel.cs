using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sports.Business.Repositories.Models
{
  public  class UserModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }
       
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
        public string FullName => FirstName + (MiddleName != null ? " " + MiddleName : "") + (LastName != null ? " " + LastName : "");
        [Required(ErrorMessage = "Email Address is required.")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter valid email address.")]
        [Remote("IsEmailExist", "Players", "TeamCoach", AdditionalFields = "Id", ErrorMessage = "User with same email address already exists.")]
        //[CustomEmailValidator]
        public string Email { get; set; }
        [Required(ErrorMessage = "Passward is required.")]
        [StringLength(10, MinimumLength = 0, ErrorMessage = "Password must be less than 10 digits.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Passward is required.")]
        public string ConfirmPassword { get; set; }
        public DateTime BirthDate { get; set; }
        [StringLength(10, MinimumLength = 0, ErrorMessage = "Phone Number must be less than 10 digits.")]
        public string PhoneNumber { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public long TeamId { get; set; }
        public string TeamName { get; set; }
        public bool IsSelected { get; set; }
        


    }
    
}
