using Contact_List.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contact_List.ViewModels
{
    public class ContactsViewModel
    {
        public List<Contact> Contacts { get; set; }
        public List<int> NumberOfPaginationPages { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentOrder { get; set; }
    }
}