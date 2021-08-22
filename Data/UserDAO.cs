using CollegeWebsite.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CollegeWebsite.Controllers
{
    internal class UserDAO
    {
        private string connectionString = @"Data Source=ENVY\SQLEXPRESS;Initial Catalog=IIEPortDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Perform all database CRUD operations

        public List<UserModel> FetchAll()
        {
            List<UserModel> tableData = new List<UserModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.Users";
                SqlCommand cmd = new SqlCommand(loadQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        UserModel result = new UserModel();
                        result.ID = rdr.GetInt32(0);
                        result.UserID = rdr.GetString(1);
                        result.Password = rdr.GetString(2);

                        tableData.Add(result);
                    }
                }
                con.Close();
                return tableData;
            }
        }

        public UserModel FetchOne(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.Users WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(loadQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                UserModel result = new UserModel();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        result.ID = rdr.GetInt32(0);
                        result.UserID = rdr.GetString(1);
                        result.Password = rdr.GetString(2);
                    }
                }
                con.Close();
                return result;
            }
        }

        //Create or Update record
        public int CreateOrUpdateRecord(UserModel userModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string insertQuery = null;

                if (userModel.ID <= 0)
                {
                    insertQuery = "INSERT INTO dbo.Users Values(@UserID, @Password)";
                }
                else
                {
                    insertQuery = "UPDATE dbo.Users SET UserID = @UserID, Password = @Password WHERE Id = @Id";
                }
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = userModel.ID;
                cmd.Parameters.Add("@UserID", System.Data.SqlDbType.NVarChar, 50).Value = userModel.UserID;
                cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = userModel.Password;

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
        }

        //Delete Record
        internal int DeleteRecord(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM dbo.Users WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
        }

        //User check
        internal bool CheckPass(UserModel user)
        {
            bool result;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string checkQuery = "SELECT * FROM dbo.Users WHERE UserID = @UserID AND Password = @Password";

                SqlCommand cmd = new SqlCommand(checkQuery, con);
                cmd.Parameters.Add("@UserID", System.Data.SqlDbType.NVarChar).Value = user.UserID;
                cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar).Value = user.Password;
                
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
    }
}