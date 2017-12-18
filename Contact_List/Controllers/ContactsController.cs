using Contact_List.BusinessLogic;
using Contact_List.Models;
using Contact_List.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Contact_List.Controllers
{
    public class ContactsController : Controller
    {
        public ActionResult Contacts()
        {
            DbConnection conn = new DbConnection();
            conn.SqlCommand.CommandText = "ListOfContactsWithPagination";
            conn.SqlCommand.CommandType = CommandType.StoredProcedure;
            conn.SqlCommand.Connection.Open();
            conn.Reader = conn.SqlCommand.ExecuteReader();

            ContactsViewModel listOfContacts = new ContactsViewModel();
            listOfContacts.Contacts = new List<Models.Contact>();

            while (conn.Reader.Read())
            {
                Contact contact = new Contact();
                contact.Id = (int)conn.Reader["id"];
                contact.Name = (string)conn.Reader["name"];
                contact.Surname = (string)conn.Reader["surname"];
                contact.Phone = (string)conn.Reader["phone"];
                contact.Email = (string)conn.Reader["email"];
                contact.CreatedOn = Convert.ToDateTime(conn.Reader["createon"]);
                contact.ModifiedOn = Convert.ToDateTime(conn.Reader["modifiedon"]);

                listOfContacts.Contacts.Add(contact);
            }

            return View(listOfContacts);
        }

        public ActionResult CreateNewContact()
        {
            ViewBag.Message = "Create new contact";

            return View();
        }
    }
}