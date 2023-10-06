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
    }
}
