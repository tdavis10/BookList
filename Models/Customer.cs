using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public class Customer
    {
        [Key]
        [BindNever]
        public int UserId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please Enter First Name:")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter the First Address Line:")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required(ErrorMessage = "Please Enter City:")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter State:")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please Enter Country:")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Zip:")]
        public int Zip { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Number:")]
        public string Phone { get; set; }


    }
}
