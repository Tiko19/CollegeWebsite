using CollegeWebsite.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CollegeWebsite.Data
{
    internal class StudentDAO
    {
        private string connectionString = @"Data Source=ENVY\SQLEXPRESS;Initial Catalog=IIEPortDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Perform all database CRUD operations

        //Fetch
        public List<StudentModel> FetchAll()
        {
            List<StudentModel> tableData = new List<StudentModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.Students";
                SqlCommand cmd = new SqlCommand(loadQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        StudentModel result = new StudentModel();
                        result.ID = rdr.GetInt32(0);
                        result.StudentID = rdr.GetString(1);
                        result.FirstName = rdr.GetString(2);
                        result.LastName = rdr.GetString(3);
                        result.Gender = rdr.GetString(4);
                        result.BirthDate = rdr.GetDateTime(5);
                        result.Nationality = rdr.GetString(6);
                        result.Passport = rdr.GetString(7);
                        result.Email = rdr.GetString(8);
                        result.ApplicationType = rdr.GetString(9);
                        result.Major = rdr.GetString(10);
                        result.StudyDuration = rdr.GetString(11);

                        tableData.Add(result);
                    }
                }
                con.Close();
                return tableData;
            } 
        }

        public StudentModel FetchOne(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.Students WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(loadQuery, con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                StudentModel result = new StudentModel();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        result.ID = rdr.GetInt32(0);
                        result.StudentID = rdr.GetString(1);
                        result.FirstName = rdr.GetString(2);
                        result.LastName = rdr.GetString(3);
                        result.Gender = rdr.GetString(4);
                        result.BirthDate = rdr.GetDateTime(5);
                        result.Nationality = rdr.GetString(6);
                        result.Passport = rdr.GetString(7);
                        result.Email = rdr.GetString(8);
                        result.ApplicationType = rdr.GetString(9);
                        result.Major = rdr.GetString(10);
                        result.StudyDuration = rdr.GetString(11);
                    }
                }
                con.Close();
                return result;
            }
        }

        public StudentModel FetchOne(string id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.Students WHERE StudentID = @id";

                SqlCommand cmd = new SqlCommand(loadQuery, con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                StudentModel result = new StudentModel();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        result.ID = rdr.GetInt32(0);
                        result.StudentID = rdr.GetString(1);
                        result.FirstName = rdr.GetString(2);
                        result.LastName = rdr.GetString(3);
                        result.Gender = rdr.GetString(4);
                        result.BirthDate = rdr.GetDateTime(5);
                        result.Nationality = rdr.GetString(6);
                        result.Passport = rdr.GetString(7);
                        result.Email = rdr.GetString(8);
                        result.ApplicationType = rdr.GetString(9);
                        result.Major = rdr.GetString(10);
                        result.StudyDuration = rdr.GetString(11);
                    }
                }
                con.Close();
                return result;
            }
        }

        //Create or Update record
        public int CreateOrUpdateRecord(StudentModel studentModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string insertQuery = null;

                if(studentModel.ID <= 0)
                {
                    insertQuery = "INSERT INTO dbo.Students Values(@StudentID, @FirstName, @LastName, @Gender, @BirthDate, @Nationality, @Passport, @ApplicationType, @StudyDuration, @Major, @Email)";
                }
                else
                {
                    insertQuery = "Update dbo.Students SET FirstName = @FirstName, LastName = @LastName, Gender = @Gender, BirthDate = @BirthDate, Nationality = @Nationality, Passport = @Passport, ApplicationType = @ApplicationType, StudyDuration = @StudyDuration, Major = @Major, Email = @Email WHERE Id = @Id";
                }

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.NVarChar, 50).Value = studentModel.ID;
                cmd.Parameters.Add("@StudentID", System.Data.SqlDbType.NVarChar, 50).Value = studentModel.StudentID;
                cmd.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar, 50).Value = studentModel.FirstName;
                cmd.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar, 50).Value = studentModel.LastName;
                cmd.Parameters.Add("@Gender", System.Data.SqlDbType.NVarChar, 50).Value = studentModel.Gender;
                cmd.Parameters.Add("@BirthDate", System.Data.SqlDbType.DateTime).Value = studentModel.BirthDate;
                cmd.Parameters.Add("@Nationality", System.Data.SqlDbType.NVarChar, 50).Value = studentModel.Nationality;
                cmd.Parameters.Add("@Passport", System.Data.SqlDbType.NVarChar, 10).Value = studentModel.Passport;
                cmd.Parameters.Add("@ApplicationType", System.Data.SqlDbType.NVarChar, 50).Value = studentModel.ApplicationType;
                cmd.Parameters.Add("@StudyDuration", System.Data.SqlDbType.NVarChar, 50).Value = studentModel.StudyDuration;
                cmd.Parameters.Add("@Major", System.Data.SqlDbType.NVarChar, 50).Value = studentModel.Major;
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 50).Value = studentModel.Email;

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
                string deleteQuery = "DELETE FROM dbo.Accomodation WHERE Id = @id";

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