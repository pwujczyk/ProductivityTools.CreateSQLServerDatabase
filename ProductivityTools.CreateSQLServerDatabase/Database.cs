using System;
using System.Data.SqlClient;

namespace ProductivityTools.CreateSQLServerDatabase
{
    public class Database
    {
        private readonly string Name;
        private readonly string DataSourceConnectionString;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the database</param>
        /// <param name="dataSourceConnectionString">Connection string which has server name and authentication method like Server=.\\SQL2017;Trusted_Connection=True;</param>
        public Database(string name, string dataSourceConnectionString)
        {
            this.Name = name;
            this.DataSourceConnectionString = dataSourceConnectionString;
        }

        /// <summary>
        /// Creates database, if exists throws exception
        /// </summary>
        public void Create()
        {
            InvokeQuery($"CREATE DATABASE {this.Name}");
        }

        /// <summary>
        /// Create database if not exists if exists it to nothing
        /// </summary>
        public void CreateSilent()
        {
            if (Exists()==false)
            {
                Create();
            }
        }

        /// <summary>
        /// Check if database exists
        /// </summary>
        /// <returns></returns>
        public bool Exists()
        {
            var result=InvokeReader($"SELECT Count(1) FROM sys.databases WHERE [name] = '{this.Name}'");
            return result == "1";
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

        private string InvokeReader(string query)
        {
            var result=InvokeReader(this.DataSourceConnectionString, query);
            return result;
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