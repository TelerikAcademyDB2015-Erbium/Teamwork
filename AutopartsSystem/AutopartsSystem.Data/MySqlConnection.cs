using System;
using System.ComponentModel.Design.Serialization;
using System.Data;
using AutopartsSystem.Models;
using MySql.Data.MySqlClient;

namespace AutopartsSystem.Data
{
    using MySql.Data;

    public class MySqlConnectionProvider
    {
        private MySqlConnection connection;
        private const string MyConnectionString = "Server=localhost;Database=telerikdb;Uid=root;Pwd=;";

        public MySqlConnectionProvider()
        {
            connection = new MySqlConnection(MyConnectionString);
        }

        public void AddContent(AutoPart entry)
        {
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Autoparts (Name,Description,Price) VALUES (@Name,@Description,Price)";
                cmd.Parameters.AddWithValue("@Name", entry.Name);
                cmd.Parameters.AddWithValue("@Description", entry.Description);
                cmd.Parameters.AddWithValue("@Price", entry.Price);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    
                }
            }
        }
    }
}
