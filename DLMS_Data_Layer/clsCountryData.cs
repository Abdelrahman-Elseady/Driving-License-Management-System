using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMS_Data_Layer
{
    public static class clsCountryData
    { 
        public static DataTable GetAllCountries()
        {
            DataTable dt=new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "exec GetAllCountries";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static int AddNewCountry(string CountryName)
        {
            int insertedID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "exec AddNewCountry @countryName";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@countryName", CountryName);
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int value))
                {
                    insertedID = value;
                }
            }
            catch
            {
                insertedID = -1;
            }
            finally
            {
                connection.Close();
            }
            return insertedID;
        }
        public static bool UpdateCountry(int CountryID, string CountryName)
        {
            bool IsUpdated = false;
            SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "exec UpdateCountry @CountryID,@CountryName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    IsUpdated = true;
                }
            }
            catch
            {
                IsUpdated = false;
            }
            finally
            {
                connection.Close();
            }
            return IsUpdated;
        }
        public static bool GetCountryInfo(int CountryID,ref string CountryName)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "exec GetCountryInfoByID @CountryID";
            SqlCommand command= new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    IsFound = true;
                    CountryName = (string)reader["CountryName"];
                    reader.Close();
                }
            }
            catch
            {
                IsFound= false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
        public static bool GetCountryInfo(string CountryName, ref int CountryID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "exec GetCountryInfoByName @CountryName";
            SqlCommand cmd= new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    IsFound = true;
                    CountryID = (int)reader["CountryID"];
                }
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
    }
}
