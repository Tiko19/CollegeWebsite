using CollegeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CollegeWebsite.Data
{
    internal class AccomodationDAO
    {
        private string connectionString = @"Data Source=ENVY\SQLEXPRESS;Initial Catalog=IIEPortDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Perform all database CRUD operations

        public List<AccomodationModel> FetchAll()
        {
            List<AccomodationModel> tableData = new List<AccomodationModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.Accomodation";
                SqlCommand cmd = new SqlCommand(loadQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        AccomodationModel result = new AccomodationModel();
                        result.ID = rdr.GetInt32(0);
                        result.RoomType = rdr.GetString(1);
                        result.Bathroom = rdr.GetString(2);
                        result.Price = rdr.GetDecimal(3);

                        tableData.Add(result);
                    }
                }
                con.Close();
                return tableData;
            }
        }

        public AccomodationModel FetchOne(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string loadQuery = "SELECT * FROM dbo.Accomodation WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(loadQuery, con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                AccomodationModel result = new AccomodationModel();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        result.ID = rdr.GetInt32(0);
                        result.RoomType = rdr.GetString(1);
                        result.Bathroom = rdr.GetString(2);
                        result.Price = rdr.GetDecimal(3);
                    }
                }
                con.Close();
                return result;
            }
        }


        //Create or Update record
        public int CreateOrUpdateRecord(AccomodationModel accomodationModel)
        {
            string insertQuery = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (accomodationModel.ID <= 0)
                {
                    insertQuery = "INSERT INTO dbo.Accomodation Values(@RoomType, @Bathroom, @Price)";
                }
                else
                {
                    insertQuery = "UPDATE dbo.Accomodation SET RoomType = @RoomType, Bathroom = @Bathroom, Price = @Price WHERE Id = @id";
                }

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = accomodationModel.ID;
                cmd.Parameters.Add("@RoomType", System.Data.SqlDbType.NVarChar, 50).Value = accomodationModel.RoomType;
                cmd.Parameters.Add("@Bathroom", System.Data.SqlDbType.NVarChar, 50).Value = accomodationModel.Bathroom;
                cmd.Parameters.Add("@Price", System.Data.SqlDbType.Decimal, 18).Value = accomodationModel.Price;

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
        }

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