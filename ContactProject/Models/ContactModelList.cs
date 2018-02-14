using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ContactProject.Models
{
    public class ContactModelList
    {
        public int SNo { get; set; }

        [StringLength(30)]
        [DataType(DataType.Text,ErrorMessage = "Please enter First Name")]
        [Required]
        public string FName { get; set; }

        [Required(ErrorMessage ="Please enter Last Name")]
        [StringLength(30)]
        public string LName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string PhoneNum { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}