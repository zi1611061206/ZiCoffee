using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.DataAccessLayer.Providers
{
    public class DataProvider
    {
        private string connectionString = @"" + Properties.Resources.connectionStrDefault;

        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        #region (dùng khi truy vấn thông thường)
        public DataTable ExecuteQuery(string query, object[] parameterArray = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameterArray != null)
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
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        #endregion

        #region (dùng khi INSERT-DELETE-UPDATE)
        public int ExecuteNonQuery(string query, object[] parameterArray = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameterArray != null)
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
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        #endregion

        #region (dùng khi lấy một dữ liệu có kiểu bất kỳ)
        public object ExecuteScalar(string query, object[] parameterArray = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameterArray != null)
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
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
        #endregion
    }
}
