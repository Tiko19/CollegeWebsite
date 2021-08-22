using CollegeWebsite.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CollegeWebsite.Data
{
    internal class NonDegreeDAO
    {
        private string connectionString = @"Data Source=ENVY\SQLEXPRESS;Initial Catalog=IIEPortDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Perform all database CRUD operations

        public List<ProgramsModel> FetchAll()
        {
            List<ProgramsModel> tableData = new List<ProgramsModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.NonDegreePrograms";
                SqlCommand cmd = new SqlCommand(loadQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ProgramsModel result = new ProgramsModel();
                        result.ID = rdr.GetInt32(0);
                        result.Program = rdr.GetString(1);
                        result.Intake = rdr.GetString(2);
                        result.Duration = rdr.GetString(3);
                        result.Language = rdr.GetString(4);
                        result.Tuition = rdr.GetDecimal(5);

                        tableData.Add(result);
                    }
                }
                con.Close();
                return tableData;
            }
        }

        public ProgramsModel FetchOne(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.NonDegreePrograms WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(loadQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                ProgramsModel result = new ProgramsModel();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        result.ID = rdr.GetInt32(0);
                        result.Program = rdr.GetString(1);
                        result.Intake = rdr.GetString(2);
                        result.Duration = rdr.GetString(3);
                        result.Language = rdr.GetString(4);
                        result.Tuition = rdr.GetDecimal(5);
                    }
                }
                con.Close();
                return result;
            }
        }

        //Create or Update record
        public int CreateOrUpdateRecord(ProgramsModel programsModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string insertQuery = null;
                if (programsModel.ID <= 0)
                {
                    insertQuery = "INSERT INTO dbo.NonDegreePrograms Values(@Program, @Intake, @Duration, @Language, @Tuition)";
                }
                else
                {
                    insertQuery = "Update dbo.NonDegreePrograms SET Program = @Program, Intake = @Intake, Duration = @Duration, Language = @Language, Tuition = @Tuition WHERE Id = @Id";
                }
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = programsModel.ID;
                cmd.Parameters.Add("@Program", System.Data.SqlDbType.NVarChar, 50).Value = programsModel.Program;
                cmd.Parameters.Add("@Intake", System.Data.SqlDbType.NVarChar, 50).Value = programsModel.Intake;
                cmd.Parameters.Add("@Duration", System.Data.SqlDbType.NVarChar, 50).Value = programsModel.Duration;
                cmd.Parameters.Add("@Language", System.Data.SqlDbType.NVarChar, 50).Value = programsModel.Language;
                cmd.Parameters.Add("@Tuition", System.Data.SqlDbType.Decimal, 18).Value = programsModel.Tuition;

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
                string deleteQuery = "DELETE FROM dbo.NonDegreePrograms WHERE Id = @id";

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