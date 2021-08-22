using CollegeWebsite.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CollegeWebsite.Data
{
    internal class AssociationsDAO
    {
        private string connectionString = @"Data Source=ENVY\SQLEXPRESS;Initial Catalog=IIEPortDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Perform all database CRUD operations

        public List<AssociationsModel> FetchAll()
        {
            List<AssociationsModel> tableData = new List<AssociationsModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.StudentAssociations";
                SqlCommand cmd = new SqlCommand(loadQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        AssociationsModel result = new AssociationsModel();
                        result.ID = rdr.GetInt32(0);
                        result.Association = rdr.GetString(1);
                        result.Description = rdr.GetString(2);

                        tableData.Add(result);
                    }
                }
                con.Close();
                return tableData;
            }
        }

        public AssociationsModel FetchOne(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.StudentAssociations WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(loadQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                AssociationsModel result = new AssociationsModel();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        result.ID = rdr.GetInt32(0);
                        result.Association = rdr.GetString(1);
                        result.Description = rdr.GetString(2);
                    }
                }
                con.Close();
                return result;
            }
        }

        //Create record
        public int CreateOrUpdateRecord(AssociationsModel associationsModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string insertQuery = null;

                if(associationsModel.ID <= 0)
                {
                    insertQuery = "INSERT INTO dbo.StudentAssociations Values(@Association, @Description)";
                }
                else
                {
                    insertQuery = "UPDATE dbo.StudentAssociations SET Association = @Association, Description = @Description WHERE Id = @Id";
                }

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = associationsModel.ID;
                cmd.Parameters.Add("@Association", System.Data.SqlDbType.NVarChar, 50).Value = associationsModel.Association;
                cmd.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 1000).Value = associationsModel.Description;

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
                string deleteQuery = "DELETE FROM dbo.StudentAssociations WHERE Id = @id";

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