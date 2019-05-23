using Npgsql;
using System;
using System.Configuration;

namespace DatabaseManipulation
{
    public class DatabaseMaster : IDisposable
    {
        NpgsqlConnection conn;
        public void Dispose()
        {
            conn.Close();
        }

        public DatabaseMaster()
        {
            var server = ConfigurationManager.AppSettings.Get("Server");
            var port = ConfigurationManager.AppSettings.Get("Port");
            var username = ConfigurationManager.AppSettings.Get("Username");
            var password = ConfigurationManager.AppSettings.Get("Password");
            var database = ConfigurationManager.AppSettings.Get("Database");

            Init(server, port, username, password, database);
        }

        public DatabaseMaster(string server, string port, string username, string password, string database)
        {
            Init(server, port, username, password, database);
        }

        private void Init(string server, string port, string username, string password, string database)
        {
            string conn_param = "Server=" + server + ";Port=" + port + ";User Id= " + username +";Password=" + password + ";Database="+ database +";";
            conn = new NpgsqlConnection(conn_param);
            conn.Open();
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
    }
}