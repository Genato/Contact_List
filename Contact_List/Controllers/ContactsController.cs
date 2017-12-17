using Contact_List.BusinessLogic;
using Contact_List.Models;
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

            List<Contact> listOfContacts = new List<Contact>();

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
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}