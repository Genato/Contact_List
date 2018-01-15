using Contact_List.LanguageResources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Contact_List.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Display(Name = nameof(Default.Contact_Name), ResourceType = typeof(Default))]
        [MaxLength(50, ErrorMessageResourceName = "Max_Length", ErrorMessageResourceType = typeof(ErrorMessages))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName  = "Please_provide_a_name", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Name { get; set; }

        [Display(Name = nameof(Default.Contact_Surname), ResourceType = typeof(Default))]
        [MaxLength(50, ErrorMessageResourceName = "Max_Length", ErrorMessageResourceType = typeof(ErrorMessages))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Please_provide_a_surname", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Surname { get; set; }

        [Display(Name = nameof(Default.Contact_Phone), ResourceType = typeof(Default))]
        [MaxLength(50, ErrorMessageResourceName = "Max_Length", ErrorMessageResourceType = typeof(ErrorMessages))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Please_provide_a_phone", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Phone { get; set; }

        [EmailAddress]
        [Display(Name = nameof(Default.Contact_Email), ResourceType = typeof(Default))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Please_provide_email", ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Email { get; set; }

        [Display(Name = nameof(Default.Contact_CreatedOn), ResourceType = typeof(Default))]
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public bool Checked { get; set; }
    }
}