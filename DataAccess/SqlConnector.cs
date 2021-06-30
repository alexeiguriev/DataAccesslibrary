﻿using DataAccesslibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccesslibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        string connString;
        public SqlConnector(string connString)
        {
            this.connString = connString;
        }
        public void ChangeConnectionString(string connString)
        {
            this.connString = connString;
        }
        public USER CreaUSER(USER model)
        {
            model.Id = GetLastInsertedId() + 1;
            string query = "INSERT INTO userTable Values('" + (model.Id + 1) + "','" + model.FirstName + "','" + model.LastName + "','" + model.EmailAddress + "','" + model.Password + "')";


            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
            da.Dispose();
            return model;
        }

        public USER DeleteUSER(USER model)
        {
            using (var sc = new SqlConnection(connString))
            using (var cmd = sc.CreateCommand())
            {
                sc.Open();
                cmd.CommandText = "DELETE FROM userTable WHERE (FirstName = @FirstName AND LastName = @LastName AND EmailAddress = @EmailAddress AND Password = @Password)";
                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@EmailAddress", model.EmailAddress);
                cmd.Parameters.AddWithValue("@Password", model.Password);
                cmd.ExecuteNonQuery();
                sc.Close();
            }
            return model;
        }

        public List<USER> GetUSER_All()
        {
            List<USER> output = new List<USER>();
            DataTable outputTable = new DataTable();

            string query = "select * from userTable";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(outputTable);
            conn.Close();
            da.Dispose();
            foreach (DataRow row in outputTable.Rows)
            {
                USER intermetiateUser = new USER();
                intermetiateUser.FirstName = row["FirstName"].ToString();
                intermetiateUser.LastName = row["LastName"].ToString();
                intermetiateUser.EmailAddress = row["EmailAddress"].ToString();
                intermetiateUser.Password = row["Password"].ToString();
                output.Add(intermetiateUser);
            }
            return output;
        }

        public int GetLastInsertedId()
        {
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("SELECT TOP(1) Id FROM userTable ORDER BY 1 DESC", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            //won't need a while, since it will only retrieve one row
            reader.Read();

            //here is your data
            int data = Convert.ToInt32(reader["Id"]);

            reader.Close();
            connection.Close();
            return data;

        }
    }
}
