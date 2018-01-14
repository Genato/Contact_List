using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contact_List.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length of name is 50")]
        [DisplayName("Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length of surnamename is 50")]
        [DisplayName("Surname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a surname")]
        public string Surname { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length of phone is 50")]
        [DisplayName("Phone")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a phone")]
        public string Phone { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length of email is 50")]
        [EmailAddress]
        [DisplayName("Email address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("CreatedOn")]
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public bool Checked { get; set; }
    }
}