using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataAccessLayer.Providers
{
    public class SqlDataProvider
    {
        #region Constructor Instance
        private static SqlDataProvider instance;

        public static SqlDataProvider Instance
        {
            get { if (instance == null) instance = new SqlDataProvider(); return instance; }
            private set { instance = value; }
        }
        #endregion

        private string connectionString = @"" + Properties.Resources.SqlConnectionString;

        /// <summary>
        /// This function used to execute normally queries (select).
        /// Not change data.
        /// Return query result cast to DataTable.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameterArray"></param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteQuery(string query, object[] parameterArray = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameterArray != null)
                {
                    TransmitParametersToCommand(command, query, parameterArray);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        /// <summary>
        /// This function used to execute queries that changes data (insert, update, delete). 
        /// Return number of data rows that excuted. 
        /// Cast to integer. 
        /// If returned result = 0, failed excute, data is not changed. 
        /// Else, data is changed but it isn't synonymous with success execute. 
        /// This thing depend on how many changed data lines are there.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameterArray"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string query, object[] parameterArray = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameterArray != null)
                {
                    TransmitParametersToCommand(command, query, parameterArray);
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        /// <summary>
        /// This function is used to execute cell queries (select). 
        /// This function is used when you want to get a specific value in a data row. 
        /// Return first row of first column (in other words the first cell) of query result (in the result set). 
        /// Cast to object.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameterArray"></param>
        /// <returns></returns>
        public object ExecuteScalar(string query, object[] parameterArray = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameterArray != null)
                {
                    TransmitParametersToCommand(command, query, parameterArray);
                }
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }

        private void TransmitParametersToCommand(SqlCommand command, string query, object[] parameterArray)
        {
            string[] parameterList = query.Split(' ');
            int i = 0;
            foreach (string item in parameterList)
            {
                if (item.Contains('@'))
                {
                    command.Parameters.AddWithValue(item, parameterArray[i]);
                    i++;
                }
            }
        }
    }
}
