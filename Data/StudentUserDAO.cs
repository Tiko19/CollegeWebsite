using CollegeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CollegeWebsite.Data
{
    internal class StudentUserDAO
    {
        private string connectionString = @"Data Source=ENVY\SQLEXPRESS;Initial Catalog=IIEPortDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public StudentUserModel FetchOne(string id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.StudentUsers WHERE StudentID = @StudentID";

                SqlCommand cmd = new SqlCommand(loadQuery, con);
                cmd.Parameters.Add("@StudentID", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                StudentUserModel result = new StudentUserModel();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        result.ID = rdr.GetInt32(0);
                        result.StudentID = rdr.GetString(1);
                        result.Email = rdr.GetString(2);
                        result.Password = rdr.GetString(3);
                    }
                }
                con.Close();
                return result;
            }
        }

        public StudentUserModel FetchOne(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.StudentUsers WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(loadQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                StudentUserModel result = new StudentUserModel();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        result.ID = rdr.GetInt32(0);
                        result.StudentID = rdr.GetString(1);
                        result.Email = rdr.GetString(2);
                        result.Password = rdr.GetString(3);
                    }
                }
                con.Close();
                return result;
            }
        }

        //Account management
        public bool CheckStudent(StudentUserModel studentUserModel)
        {
            bool result;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string checkQuery = "SELECT * from dbo.Students WHERE StudentID = @id";

                SqlCommand cmd = new SqlCommand(checkQuery, con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = studentUserModel.StudentID;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                con.Close();
            }
            return result;
        }

        internal bool CheckUser(StudentUserModel studentUserModel)
        {
            bool result;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string checkQuery = "SELECT * from dbo.StudentUsers WHERE StudentID = @StudentID";

                SqlCommand cmd = new SqlCommand(checkQuery, con);
                cmd.Parameters.Add("@StudentID", System.Data.SqlDbType.NVarChar).Value = studentUserModel.StudentID;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                con.Close();
            }
            return result;
        }

        internal bool CheckPass(StudentUserModel studentUserModel)
        {
            bool result;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string checkQuery = "SELECT * from dbo.StudentUsers WHERE StudentID = @StudentID AND Password = @Password";

                SqlCommand cmd = new SqlCommand(checkQuery, con);
                cmd.Parameters.Add("@StudentID", System.Data.SqlDbType.NVarChar).Value = studentUserModel.StudentID;
                cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar).Value = studentUserModel.Password;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                con.Close();
            }
            return result;
        }

        public int CreateRecord(StudentUserModel studentUserModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO dbo.StudentUsers Values(@StudentID, @Email, @Password)";

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.NVarChar, 50).Value = studentUserModel.ID;
                cmd.Parameters.Add("@StudentID", System.Data.SqlDbType.NVarChar, 50).Value = studentUserModel.StudentID;
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 50).Value = studentUserModel.Email;
                cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = studentUserModel.Password;

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
        }

        public int UpdateRecord(StudentUserModel studentUserModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string insertQuery = "UPDATE dbo.StudentUsers SET Email = @Email, Password = @Password WHERE StudentID = @StudentID";

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.Add("@StudentID", System.Data.SqlDbType.NVarChar, 50).Value = studentUserModel.StudentID;
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 50).Value = studentUserModel.Email;
                cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = studentUserModel.Password;

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
        }

        //Delete Record
        internal int DeleteRecord(string id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM dbo.Users WHERE StudentID = @StudentID";

                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.Add("@StudentID", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
        }
    }
}