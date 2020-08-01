using System;
using System.Configuration;
using System.Data.SqlClient;

namespace KnorishBoatProject.DAO
{
    public class BoatDAO : IBoatDAO
    {
        public bool CheckIfBoatAlreadyRegistred(string boatName)
        {
            string connectionString = GetConnectionString();
            using (var conn = new SqlConnection(connectionString))
            {
                string commandText = $"SELECT RegistrationID FROM Boat WHERE BoatName = {boatName})";
                using (var cmd = new SqlCommand(commandText, conn))
                {
                    try
                    {
                        conn.Open();
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public Guid RegisterBoat(string boatName, Int32 hourlyRate)
        {
            string connectionString = GetConnectionString();
            var registrationID = Guid.NewGuid();
            using (var conn = new SqlConnection(connectionString))
            {
                string commandText = $"INSERT INTO Boat (RegistrationID, BoatName, HourlyRate) VALUES ({registrationID}, {boatName}, {hourlyRate})";
                using (var cmd = new SqlCommand(commandText, conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            return registrationID;
        }

        public bool BookBoat(Guid boatNumber, string customerName)
        {
            string connectionString = GetConnectionString();
            using (var conn = new SqlConnection(connectionString))
            {
                string commandText = $"UPDATE Boat SET BookedBy = {customerName}, BookedDate = {DateTime.Now}, IsBooked = {1} WHERE  RegistrationID = {boatNumber}";
                using (var cmd = new SqlCommand(commandText, conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["BoatDB"].ConnectionString;
        }
    }
}
