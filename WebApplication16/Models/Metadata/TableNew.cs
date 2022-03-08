using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication16.Models.Metadata
{
    public class TableNew
    {
        public int UserId { get; set; }
        [DisplayName(" Username")]
        [Required(ErrorMessage = "requried")]
        public string UserName { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "requried")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "requried")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "requried")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "must be identical")]
        public string ConfirmPassword { get; set; }
    }
}