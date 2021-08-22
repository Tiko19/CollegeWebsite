using CollegeWebsite.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CollegeWebsite.Data
{
    internal class ResultDAO
    {
        private string connectionString = @"Data Source=ENVY\SQLEXPRESS;Initial Catalog=IIEPortDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<ResultModel> FetchSelect(string id)
        {
            List<ResultModel> tableData = new List<ResultModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.Results WHERE StudentID = @StudentID";
                SqlCommand cmd = new SqlCommand(loadQuery, con);
                cmd.Parameters.Add("@StudentID", System.Data.SqlDbType.NVarChar).Value = id;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ResultModel result = new ResultModel();
                        result.Id = rdr.GetInt32(0);
                        result.StudentID = rdr.GetString(1);
                        result.CourseName = rdr.GetString(2);
                        result.Grade = rdr.GetInt32(3);
                        result.GradePoint = rdr.GetDecimal(4);

                        tableData.Add(result);
                    }
                }
                con.Close();
                return tableData;
            }
        }

        public List<ResultModel> FetchAll()
        {
            List<ResultModel> tableData = new List<ResultModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.Results";
                SqlCommand cmd = new SqlCommand(loadQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ResultModel result = new ResultModel();
                        result.Id = rdr.GetInt32(0);
                        result.StudentID = rdr.GetString(1);
                        result.CourseName = rdr.GetString(2);
                        result.Grade = rdr.GetInt32(3);
                        result.GradePoint = rdr.GetDecimal(4);

                        tableData.Add(result);
                    }
                }
                con.Close();
                return tableData;
            }
        }

        public ResultModel FetchOne(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.Results WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(loadQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                ResultModel result = new ResultModel();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        result.Id = rdr.GetInt32(0);
                        result.StudentID = rdr.GetString(1);
                        result.CourseName = rdr.GetString(2);
                        result.Grade = rdr.GetInt32(3);
                        result.GradePoint = rdr.GetDecimal(4);
                    }
                }
                con.Close();
                return result;
            }
        }

        //Create or update record
        public int CreateOrUpdateRecord(ResultModel resultModel)
        {
            string insertQuery = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (resultModel.Id <= 0)
                {
                    insertQuery = "INSERT INTO dbo.Results Values(@StudentID, @CourseName, @Grade, @GradePoint)";
                }
                else
                {
                    insertQuery = "UPDATE dbo.Results SET StudentID = @StudentID, CourseName = @CourseName, Grade = @Grade, GradePoint = @GradePoint WHERE Id = @Id";
                }
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = resultModel.Id;
                cmd.Parameters.Add("@StudentID", System.Data.SqlDbType.NVarChar, 50).Value = resultModel.StudentID;
                cmd.Parameters.Add("@CourseName", System.Data.SqlDbType.NVarChar, 50).Value = resultModel.CourseName;
                cmd.Parameters.Add("@Grade", System.Data.SqlDbType.Int).Value = resultModel.Grade;
                cmd.Parameters.Add("@GradePoint", System.Data.SqlDbType.Decimal, 3).Value = resultModel.GradePoint;

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
                string deleteQuery = "DELETE FROM dbo.Results WHERE Id = @id";

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