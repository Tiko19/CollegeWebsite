using CollegeWebsite.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CollegeWebsite.Data
{
    internal class DeadlineDAO
    {
        private string connectionString = @"Data Source=ENVY\SQLEXPRESS;Initial Catalog=IIEPortDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Perform all database CRUD operations

        public List<DeadlineModel> FetchAll()
        {
            List<DeadlineModel> tableData = new List<DeadlineModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.DatesDeadlines";
                SqlCommand cmd = new SqlCommand(loadQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        DeadlineModel result = new DeadlineModel();
                        result.ID = rdr.GetInt32(0);
                        result.Intake = rdr.GetString(1);
                        result.StartDate = rdr.GetString(2);
                        result.CloseDate = rdr.GetString(3);
                        result.RegistrationDates = rdr.GetString(4);

                        tableData.Add(result);
                    }
                }
                con.Close();
                return tableData;
            }
        }

        public DeadlineModel FetchOne(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.DatesDeadlines WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(loadQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                DeadlineModel result = new DeadlineModel();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        result.ID = rdr.GetInt32(0);
                        result.Intake = rdr.GetString(1);
                        result.StartDate = rdr.GetString(2);
                        result.CloseDate = rdr.GetString(3);
                        result.RegistrationDates = rdr.GetString(4);
                    }
                }
                con.Close();
                return result;
            }
        }

        //Create record
        public int CreateOrUpdateRecord(DeadlineModel deadlineModel)
        {
            string insertQuery = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if(deadlineModel.ID <= 0)
                {
                    insertQuery = "INSERT INTO dbo.DatesDeadlines Values(@Intake, @StartDate, @CloseDate, @RegristrationDates)";
                }
                else
                {
                    insertQuery = "UPDATE dbo.DatesDeadlines SET Intake = @Intake, StartDate = @StartDate, CloseDate = @CloseDate, RegistrationDates = @RegristrationDates WHERE Id = @Id";
                }
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = deadlineModel.ID;
                cmd.Parameters.Add("@Intake", System.Data.SqlDbType.NVarChar, 50).Value = deadlineModel.Intake;
                cmd.Parameters.Add("@StartDate", System.Data.SqlDbType.NVarChar, 50).Value = deadlineModel.StartDate;
                cmd.Parameters.Add("@CloseDate", System.Data.SqlDbType.NVarChar, 50).Value = deadlineModel.CloseDate;
                cmd.Parameters.Add("@RegistrationDates", System.Data.SqlDbType.NVarChar, 50).Value = deadlineModel.RegistrationDates;

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
                string deleteQuery = "DELETE FROM dbo.DatesDeadlines WHERE Id = @id";

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