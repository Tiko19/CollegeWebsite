using CollegeWebsite.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CollegeWebsite.Data
{
    internal class FacultyDAO
    {
        private string connectionString = @"Data Source=ENVY\SQLEXPRESS;Initial Catalog=IIEPortDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Perform all database CRUD operations

        public List<FacultyModel> FetchAll()
        {
            List<FacultyModel> tableData = new List<FacultyModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.Faculty";
                SqlCommand cmd = new SqlCommand(loadQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        FacultyModel result = new FacultyModel();
                        result.ID = rdr.GetInt32(0);
                        result.Name = rdr.GetString(1);
                        result.Position = rdr.GetString(2);
                        result.Telephone = rdr.GetString(3);
                        result.WeChat = rdr.GetString(4);
                        result.Email = rdr.GetString(5);

                        tableData.Add(result);
                    }
                }
                con.Close();
                return tableData;
            }
        }

        public FacultyModel FetchOne(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.Faculty WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(loadQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                FacultyModel result = new FacultyModel();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        result.ID = rdr.GetInt32(0);
                        result.Name = rdr.GetString(1);
                        result.Position = rdr.GetString(2);
                        result.Telephone = rdr.GetString(3);
                        result.WeChat = rdr.GetString(4);
                        result.Email = rdr.GetString(5);
                    }
                }
                con.Close();
                return result;
            }
        }

        //Create or Update record
        public int CreateOrUpdateRecord(FacultyModel facultyModel)
        {
            string insertQuery = null;

            if(facultyModel.ID <= 0)
            {
                insertQuery = "INSERT INTO dbo.Faculty Values(@Name, @Position, @Telephone, @WeChat, @Email)";
            }
            else
            {
                insertQuery = "Update dbo.Faculty SET Name = @Name, Position = @Position, Telephone = @Telephone, WeChat = @WeChat, Email = @Email WHERE Id = @Id)";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = facultyModel.ID;
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 50).Value = facultyModel.Name;
                cmd.Parameters.Add("@Position", System.Data.SqlDbType.NVarChar, 50).Value = facultyModel.Position;
                cmd.Parameters.Add("@Telephone", System.Data.SqlDbType.NVarChar, 50).Value = facultyModel.Telephone;
                cmd.Parameters.Add("@WeChat", System.Data.SqlDbType.NVarChar, 50).Value = facultyModel.WeChat;
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 50).Value = facultyModel.Email;

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
                string deleteQuery = "DELETE FROM dbo.Faculty WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
        }
    }
}