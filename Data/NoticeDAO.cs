using CollegeWebsite.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CollegeWebsite.Data
{
    public class NoticeDAO
    {
        private string connectionString = @"Data Source=ENVY\SQLEXPRESS;Initial Catalog=IIEPortDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<NoticeModel> FetchAll()
        {
            List<NoticeModel> tableData = new List<NoticeModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.Notices";
                SqlCommand cmd = new SqlCommand(loadQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        NoticeModel result = new NoticeModel();
                        result.ID = rdr.GetInt32(0);
                        result.Notice = rdr.GetString(1);
                        result.PostDate = rdr.GetDateTime(2);

                        tableData.Add(result);
                    }
                }
                con.Close();
                return tableData;
            }
        }

        public NoticeModel FetchOne(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.Notices WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(loadQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                NoticeModel result = new NoticeModel();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        result.ID = rdr.GetInt32(0);
                        result.Notice = rdr.GetString(1);
                        result.PostDate = rdr.GetDateTime(2);
                    }
                }
                con.Close();
                return result;
            }
        }

        //Create or Update record
        public int CreateOrUpdateRecord(NoticeModel noticeModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string insertQuery = null;

                if(noticeModel.ID <= 0)
                {
                    insertQuery = "INSERT INTO dbo.Notices Values(@Notice, @PostDate)";
                }
                else
                {
                    insertQuery = "UPDATE dbo.Notices SET Notice = @Notice, PostDate = @PostDate)";
                }

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = noticeModel.ID;
                cmd.Parameters.Add("@Notice", System.Data.SqlDbType.NVarChar, 50).Value = noticeModel.Notice;
                cmd.Parameters.Add("@PostDate", System.Data.SqlDbType.DateTime).Value = noticeModel.PostDate;

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
                string deleteQuery = "DELETE FROM dbo.Notices WHERE Id = @id";

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