using Contact_List.BusinessLogic;
using Contact_List.DbContext;
using Contact_List.LanguageResources;
using Contact_List.Models;
using Contact_List.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Contact_List.Controllers
{
    public class ContactsController : Controller
    {
        [HttpGet]
        public ActionResult Contacts(int currentPage = 1, string orderBy = "id", string order = "asc", string searchBy = "name", string searchByValue = "")
        {
            DbConnection conn = new DbConnection();
            conn.SqlCommand.Connection.Open();

            ContactLogic contactlogic = new ContactLogic();
            int numberOfContacts = contactlogic.GetTotalNumberOfContacts(conn, searchBy, searchByValue);

            conn.SqlCommand.Parameters.Clear();

            searchByValue = searchByValue == "undefined" ? "" : searchByValue;
            searchBy = searchBy == "undefined" ? "name" : searchBy;
            conn.Reader = contactlogic.GetListOfContactsWithPagination(conn, currentPage, orderBy, order, searchBy, searchByValue);

            ContactsViewModel listOfContacts = new ContactsViewModel
            {
                Contacts = contactlogic.GenerateListOfContactsFromSqlDataReader(conn.Reader),
                NumberOfPaginationPages = contactlogic.GenerateNumberOfPaginationPagesFromTotalNumberOfContacts(currentPage, numberOfContacts),
                CurrentPage = currentPage,
                CurrentOrder = order,
                OrderBy = orderBy,
                TotalNumberOfContacts = numberOfContacts,
                SearchBy = searchBy,
                SearchByValue = searchByValue
            };

            conn.SqlCommand.Connection.Close();

            return View(listOfContacts);
        }

        [HttpGet]
        public ActionResult CreateNewContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewContact(Contact newContact)
        {
            DbConnection conn = new DbConnection();
            conn.SqlCommand.Connection.Open();

            ContactLogic logic = new ContactLogic();
            int contactID = -1;

            try
            {
                contactID = logic.CreateNewContact(conn, newContact.Name, newContact.Surname, newContact.Phone, newContact.Email);
                newContact.Id = contactID;
            }
            catch(Exception e)
            {
                ViewData["Message"] = ErrorMessages.CreateNewContact;

                return View("Messages");
            }
            finally
            {
                conn.SqlCommand.Connection.Close();
            }

            return View("EditContact", newContact);
        }

        [HttpGet]
        public ActionResult EditContact(int contactID)
        {
            DbConnection conn = new DbConnection();
            conn.SqlCommand.Connection.Open();

            ContactLogic contactlogic = new ContactLogic();

            conn.Reader = contactlogic.GetContactByID(conn, contactID);

            if(!conn.Reader.HasRows)
            {
                ViewData["Message"] = String.Format("Contact with ID {0} does not exist", contactID);

                return View("Messages");
            }

            Contact contact = contactlogic.GetContactFromSqlDataReader(conn.Reader);

            conn.SqlCommand.Connection.Close();

            return View(contact);
        }

        [HttpPost]
        public ActionResult EditContact(Contact editedContact)
        {
            DbConnection conn = new DbConnection();
            conn.SqlCommand.Connection.Open();

            ContactLogic contactlogic = new ContactLogic();
            bool success = contactlogic.UpdateContact(conn, editedContact.Name, editedContact.Surname, editedContact.Phone, editedContact.Email, editedContact.Id);

            if (success)
                ViewData["Message"] = ErrorMessages.EditContact_Success;
            else
                ViewData["Message"] = ErrorMessages.EditContact_Error;

            conn.SqlCommand.Connection.Close();

            return View("Messages");
        }

        [HttpGet]
        public ActionResult DeleteContact(int contactID)
        {
            DbConnection conn = new DbConnection();
            conn.SqlCommand.Connection.Open();

            ContactLogic contactlogic = new ContactLogic();
            bool success = contactlogic.DeleteContact(conn, contactID);

            if (success)
                ViewData["Message"] = ErrorMessages.DeleteContact_Success;
            else
                ViewData["Message"] = ErrorMessages.DeleteContact_Error;

            conn.SqlCommand.Connection.Close();

            return View("Messages");
        }

        [HttpGet]
        public ActionResult ChangeLanguage(string SelectedLanguage)
        {
            if (SelectedLanguage != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(SelectedLanguage);
                Thread.CurrentThread.CurrentUICulture =  new CultureInfo(SelectedLanguage);

                var cookie = new HttpCookie("Language");
                cookie.Value = SelectedLanguage;

                Response.Cookies.Add(cookie);
            }

            ViewData["Message"] = Default.Languages_Changed;

            return View("Messages");
        }
    }
}