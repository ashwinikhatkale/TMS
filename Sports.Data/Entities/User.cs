using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Sports.Data.Entities
{
    public class User : Entity
    {
        [Required]
        public string FirstName { get; set; }
     
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName => FirstName + (MiddleName != null ? " " + MiddleName : "") + (LastName != null ? " " + LastName : "");
        
        [Required(ErrorMessage = "Email Address is required.")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter valid email address.")]
        //[CustomEmailValidator]
        public string Email { get; set; }

        [StringLength(10, MinimumLength = 0, ErrorMessage = "Password must be less than 10 digits.")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime BirthDate { get; set; }
        [StringLength(10, MinimumLength = 0, ErrorMessage = "Phone Number must be less than 10 digits.")]
        public string PhoneNumber { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
        public ICollection<TeamMember> Teams { get; set; }
    }

    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.HasRequired(s => s.Role)
                .WithMany()
                .HasForeignKey(s => s.RoleId)
                .WillCascadeOnDelete(false);
        }
    }
}
