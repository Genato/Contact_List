using Contact_List.DbContext;
using Contact_List.Models;
using Contact_List.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Contact_List.BusinessLogic
{
    public class ContactLogic
    {
        #region Database functions

        public int GetTotalNumberOfContacts(DbConnection conn, string searchBy, string searchByValue)
        {
            conn.SqlCommand.CommandText = "NumberOfContacts";
            conn.SqlCommand.CommandType = CommandType.StoredProcedure;
            conn.SqlCommand.Parameters.Add("@NumberOfContacts", SqlDbType.Int).Direction = ParameterDirection.Output;
            conn.SqlCommand.Parameters.Add("@searchBy", SqlDbType.VarChar).Value = searchBy;
            conn.SqlCommand.Parameters.Add("@searchByValue", SqlDbType.VarChar).Value = searchByValue;

            conn.SqlCommand.ExecuteNonQuery();

            return (int)conn.SqlCommand.Parameters["@NumberOfContacts"].Value;
        }

        public SqlDataReader GetListOfContactsWithPagination(DbConnection conn, int pageNumber, string orderBy, string order, string searchBy, string searchByValue)
        {
            conn.SqlCommand.CommandText = "ListOfContactsWithPagination";
            conn.SqlCommand.CommandType = CommandType.StoredProcedure;
            conn.SqlCommand.Parameters.Add("@PageNumber", SqlDbType.Int).Value = pageNumber;
            conn.SqlCommand.Parameters.Add("@OrderBy", SqlDbType.VarChar).Value = orderBy;
            conn.SqlCommand.Parameters.Add("@Order", SqlDbType.VarChar).Value = order;
            conn.SqlCommand.Parameters.Add("@searchBy", SqlDbType.VarChar).Value = searchBy;
            conn.SqlCommand.Parameters.Add("@searchByValue", SqlDbType.VarChar).Value = searchByValue;

            return conn.SqlCommand.ExecuteReader();
        }

        public bool CreateNewContact(DbConnection conn, string name, string surname, string phone, string email)
        {
            conn.SqlCommand.CommandText = "CreateNewContact";
            conn.SqlCommand.CommandType = CommandType.StoredProcedure;
            conn.SqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
            conn.SqlCommand.Parameters.Add("@Surname", SqlDbType.VarChar).Value = surname;
            conn.SqlCommand.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            conn.SqlCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

            return conn.SqlCommand.ExecuteNonQuery() == 1 ? true : false;
        }

        public bool UpdateContact(DbConnection conn, string name, string surname, string phone, string email, int contactID)
        {
            conn.SqlCommand.CommandText = "UpdateContact";
            conn.SqlCommand.CommandType = CommandType.StoredProcedure;
            conn.SqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
            conn.SqlCommand.Parameters.Add("@Surname", SqlDbType.VarChar).Value = surname;
            conn.SqlCommand.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            conn.SqlCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            conn.SqlCommand.Parameters.Add("@contactID", SqlDbType.Int).Value = contactID;

            return conn.SqlCommand.ExecuteNonQuery() == 1 ? true : false;
        }

        public bool DeleteContact(DbConnection conn, int contactID)
        {
            conn.SqlCommand.CommandText = "DeleteContact";
            conn.SqlCommand.CommandType = CommandType.StoredProcedure;
            conn.SqlCommand.Parameters.Add("@contactID", SqlDbType.Int).Value = contactID;

            return conn.SqlCommand.ExecuteNonQuery() == 1 ? true : false;
        }

        public SqlDataReader GetContactByID(DbConnection conn, int contactID)
        {
            Contact contact = new Contact();

            conn.SqlCommand.CommandText = "GetContactByID";
            conn.SqlCommand.CommandType = CommandType.StoredProcedure;
            conn.SqlCommand.Parameters.Add("@contactID", SqlDbType.Int).Value = contactID;

            return conn.SqlCommand.ExecuteReader();
        }

        #endregion

        #region Model and View functions

        public List<Contact> GenerateListOfContactsFromSqlDataReader(SqlDataReader reader)
        {
            List<Contact> contacts = new List<Contact>();

            while (reader.Read())
            {
                Contact contact = new Contact();
                contact.Id = (int)reader["id"];
                contact.Name = (string)reader["name"];
                contact.Surname = (string)reader["surname"];
                contact.Phone = (string)reader["phone"];
                contact.Email = (string)reader["email"];
                contact.CreatedOn = Convert.ToDateTime(reader["createon"]);
                contact.ModifiedOn = Convert.ToDateTime(reader["modifiedon"]);

                contacts.Add(contact);
            }

            return contacts;
        }

        public Contact GetContactFromSqlDataReader(SqlDataReader reader)
        {
            Contact contact = new Contact();

            if (reader.Read())
            {
                contact.Id = (int)reader["id"];
                contact.Name = (string)reader["name"];
                contact.Surname = (string)reader["surname"];
                contact.Phone = (string)reader["phone"];
                contact.Email = (string)reader["email"];
                contact.CreatedOn = Convert.ToDateTime(reader["createon"]);
                contact.ModifiedOn = Convert.ToDateTime(reader["modifiedon"]);
            }

            return contact;
        }

        public List<int> GenerateNumberOfPaginationPagesFromTotalNumberOfContacts(int currentPage, int totalNumberOfContacts)
        {
            int maxNumberOfPages = 10;
            int lastIndexInList = 9;
            int firstIndexInList = 0;
            List<int> listOfPages = Enumerable.Repeat(0, maxNumberOfPages).ToList();
            int _currentPage = currentPage;

            while (true)
            {
                if ((_currentPage % maxNumberOfPages) == 0)
                {
                    listOfPages[lastIndexInList] = _currentPage;
                    break;
                }
                ++_currentPage;
            }

            for (int i = (lastIndexInList - 1); i >= firstIndexInList; --i)
            {
                --_currentPage;
                listOfPages[i] = _currentPage;
            }

            decimal totalNumberOfPages;

            if (totalNumberOfContacts % 10 != 0)
                totalNumberOfPages = ((decimal)totalNumberOfContacts / maxNumberOfPages) + 1;
            else
                totalNumberOfPages = ((decimal)totalNumberOfContacts / maxNumberOfPages);

            if (totalNumberOfPages > listOfPages.First() && totalNumberOfPages < listOfPages.Last())
            {
                int numberOfPagesOnLastView = (int)totalNumberOfPages % maxNumberOfPages;
                listOfPages.RemoveRange(numberOfPagesOnLastView, maxNumberOfPages - numberOfPagesOnLastView);
            }

            return listOfPages;
        }

        #endregion
    }
}