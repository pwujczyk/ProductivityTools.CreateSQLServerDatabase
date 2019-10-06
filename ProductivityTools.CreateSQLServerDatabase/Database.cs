using System;
using System.Data.SqlClient;

namespace ProductivityTools.CreateSQLServerDatabase
{
    public class Database
    {
        private readonly string Name;
        private readonly string DataSourceConnectionString;

        public Database(string name, string dataSourceConnectionString)
        {
            this.Name = name;
            this.DataSourceConnectionString = dataSourceConnectionString;
        }

        public void Create()
        {
            InvokeQuery($"CREATE DATABASE {this.Name}");
        }


        public bool Exists()
        {
            InvokeReader($"SELECT [Name] FROM sys.databases WHERE [name] = '{this.Name}'");
            return true;
        }

        private void InvokeQuery(string query)
        {
            InvokeQuery(this.DataSourceConnectionString, query);
        }



        private void InvokeQuery(string connectionString, string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void InvokeReader(string query)
        {
            InvokeReader(this.DataSourceConnectionString, query);
        }

        private string InvokeReader(string connectionString, string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string result = string.Empty;
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = reader[0].ToString();

                }
                return result;
            }
        }
    }
}