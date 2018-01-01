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
        public int GetTotalNumberOfContacts(DbConnection conn)
        {
            conn.SqlCommand.CommandText = "NumberOfContacts";
            conn.SqlCommand.CommandType = CommandType.StoredProcedure;
            conn.SqlCommand.Parameters.Add("@NumberOfContacts", SqlDbType.Int).Direction = ParameterDirection.Output;

            conn.SqlCommand.ExecuteNonQuery();

            return (int)conn.SqlCommand.Parameters["@NumberOfContacts"].Value;
        }

        public SqlDataReader GetListOfContactsWithPagination(DbConnection conn, int pageNumber, string orderBy, string order)
        {
            conn.SqlCommand.CommandText = "ListOfContactsWithPagination";
            conn.SqlCommand.CommandType = CommandType.StoredProcedure;
            conn.SqlCommand.Parameters.Add("@PageNumber", SqlDbType.Int).Value = pageNumber;
            conn.SqlCommand.Parameters.Add("@OrderBy", SqlDbType.VarChar).Value = orderBy;
            conn.SqlCommand.Parameters.Add("@Order", SqlDbType.VarChar).Value = order;

            return conn.SqlCommand.ExecuteReader();
        }

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
    }
}