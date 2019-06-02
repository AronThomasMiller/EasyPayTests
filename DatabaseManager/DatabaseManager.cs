using Npgsql;
using System;
using System.Configuration;

namespace DatabaseManipulation
{
    public class DatabaseMaster:IDisposable
    {
        NpgsqlConnection conn;

        public DatabaseMaster() : this(ConfigurationManager.AppSettings.Get("Server"),
            ConfigurationManager.AppSettings.Get("Port"),
            ConfigurationManager.AppSettings.Get("Username"),
            ConfigurationManager.AppSettings.Get("Password"),
            ConfigurationManager.AppSettings.Get("Database"))
        {

        }

        public DatabaseMaster(string server, string port, string username, string password, string database)
        {
            string conn_param = $"Server={server};Port={port};User Id= {username};Password={password};Database={database};";
            conn = new NpgsqlConnection(conn_param);
        }

        public string TakeFromDB(string sql)
        {
            var comm = new NpgsqlCommand(sql, conn);
            return comm.ExecuteScalar().ToString();
        }

        public void ChangeInDB(string sql)
        {
            var comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
        }

        public void Open()
        {
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
        }
    }
}