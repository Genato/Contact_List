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
        [HttpGet]
        public ActionResult Contacts(int currentPage = 1, string orderBy = "id", string order = "asc")
        {
            DbConnection conn = new DbConnection();
            conn.SqlCommand.Connection.Open();

            ContactLogic contactlogic = new ContactLogic();
            int numberOfContacts = contactlogic.GetTotalNumberOfContacts(conn);

            conn.SqlCommand.Parameters.Clear();
            conn.Reader = contactlogic.GetListOfContactsWithPagination(conn, currentPage, orderBy, order);

            ContactsViewModel listOfContacts = new ContactsViewModel
            {
                Contacts = contactlogic.GenerateListOfContactsFromSqlDataReader(conn.Reader),
                NumberOfPaginationPages = contactlogic.GenerateNumberOfPaginationPagesFromTotalNumberOfContacts(currentPage, numberOfContacts),
                CurrentPage = currentPage,
                CurrentOrder = order
            };

            conn.SqlCommand.Connection.Close();

            return View(listOfContacts);
        }

        [HttpGet]
        public ActionResult CreateNewContact(ContactsViewModel contactsViewModel)
        {
            //TODO: Return view so user can create new contact

            ViewBag.Message = "Create new contact";

            return View();
        }

        [HttpGet]
        public ActionResult EditContact(int contactID)
        {
            //TODO: Get contact from DB and return it for user to edit it

            ViewBag.Message = "Edit contact";

            return View();
        }

        [HttpGet]
        public ActionResult DeleteContact(int contactID)
        {
            //TODO: Get contact from DB and return it for user to confirm deleting contact

            ViewBag.Message = "Delete contact";

            return View();
        }

    }
}