using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookService
{
    public static class AddressBookOperations
    {
        public static void CreateDatabase()
        {
            SqlConnection con = new SqlConnection("data source = (localdB)\\MSSQLLocalDB; initial catalog = master; integrated security = true");

            string query = "create database AddressBookService";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            cmd.ExecuteNonQuery();

            Console.WriteLine("Database created successfully");

            con.Close();
        }

        public static SqlConnection con = new SqlConnection("data source = (localdB)\\MSSQLLocalDB; initial catalog = AddressBookService; integrated security = true");
        public static void CreateTable()
        {
            string query = "create table AddressBook(Id int primary key identity(1, 1), FirstName varchar(20) not null, LastName varchar(20), Address varchar(100) not null, City varchar(30) not null, State varchar(30) not null, Zip bigint not null, PhoneNumber bigint not null, Email varchar(50) not null);";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table created successfully");
            con.Close();
        }

        public static void InsertIntoTable()
        {
            string query = "Insert into AddressBook values('Kavitha', 'Hegde', 'Ramateertha', 'Shimoga', 'Karnataka', 577421, 8431042981, 'kavitharamaswamy26@gmail.com')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data inserted successfully");
            con.Close();
        }

        public static void EditInfoByName()
        {
            string query = "Update AddressBook set LastName = 'Ramaswamy' where FirstName = 'Kavitha'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data updated successfully");
            con.Close();
        }

        public static void DeleteInfoByName()
        {
            string query = "DELETE FROM AddressBook where FirstName = 'Dhanya'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data deleted successfully");
            con.Close();
        }

        public static void RetriveDataBasedOnCity()
        {
            AddressBookModel model = new AddressBookModel();
            string query = "Select * from AddressBook where City='Shimoga'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                Console.WriteLine("------Data------");
                while (sqlDataReader.Read())
                {
                    model.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    model.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
                    model.LastName = Convert.ToString(sqlDataReader["LastName"]);
                    model.Address = Convert.ToString(sqlDataReader["Address"]);
                    model.City = Convert.ToString(sqlDataReader["City"]);
                    model.State = Convert.ToString(sqlDataReader["State"]);
                    model.Zip = Convert.ToInt32(sqlDataReader["Zip"]);
                    model.PhoneNumber = Convert.ToInt64(sqlDataReader["PhoneNumber"]);
                    model.Email = Convert.ToString(sqlDataReader["Email"]);

                    Console.WriteLine("Id : {0}\nFirstName : {1}\nLastName : {2}\nAddress : {3}\nCity : {4}\nState : {5}\nZip : {6}\nPhoneNumber : {7}\nEmail : {8}", model.Id, model.FirstName, model.LastName, model.Address, model.City, model.State, model.Zip, model.PhoneNumber, model.Email);
                }
            }
            con.Close();
        }

    }
}
