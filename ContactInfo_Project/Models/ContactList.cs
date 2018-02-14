using System;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ContactInfo_Project.Models
{
    public class ContactLists
    {
        public int SNo { get; set; }
        [Display(Name = "FName")]
        public string FName { get; set; }
        [Display(Name = "LName")]
        public string LName { get; set; }
        [Display(Name = "EmailId")]
        public string EmailId { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNum { get;set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}