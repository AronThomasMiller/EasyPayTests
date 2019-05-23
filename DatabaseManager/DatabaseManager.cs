using Npgsql;
using System;
using System.Configuration;

namespace DatabaseManagerNamespace
{
    public class DatabaseManager : IDisposable
    {
        NpgsqlConnection conn;
        public void Dispose()
        {
            conn.Close();
        }

        public DatabaseManager()
        {
            var Server = ConfigurationManager.AppSettings.Get("Server");
            var Port = ConfigurationManager.AppSettings.Get("Port");
            var Username = ConfigurationManager.AppSettings.Get("Username");
            var Password = ConfigurationManager.AppSettings.Get("Password");
            var Database = ConfigurationManager.AppSettings.Get("Database");

            Init(Server, Port, Username, Password, Database);
        }

        private void Init(string server, string port, string user, string password, string database)
        {
            string conn_param = "Server=" + server + ";Port=" + port + ";User Id= " + user +";Password=" + password + ";Database="+ database +";";
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