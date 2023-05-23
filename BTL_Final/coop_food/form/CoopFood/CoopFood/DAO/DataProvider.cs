using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopFood.DAO
{
    public class DataProvider
    {
        // cấu trúc design patern Singleton
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        private DataProvider() { }

        // mã kết nối với sql
        private string _connectionSTR = @"Data Source=LAPTOP-6EA8ABAQ\SQLEXPRESS;Initial Catalog=COOP_FOOD;Integrated Security=True";


        // hàm trả về bảng kết quả từ sql
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using(SqlConnection connection = new SqlConnection(_connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query,connection);
                if(parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach(string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
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

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(_connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();

                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(_connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();

                connection.Close();
            }
            return data;
        }

        public string convertDataTableToString(DataTable dataTable)
        {
            string data = string.Empty;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    data += row[j];
                    if (j == dataTable.Columns.Count - 1)
                    {
                        if (i != (dataTable.Rows.Count - 1))
                            data += "$";
                    }
                    else
                        data += "|";
                }
            }
            return data;
        }

        public async Task<List<T>> SqlQueryAsync<T>(string sql) where T : new()
        {
            var connection = new SqlConnection(_connectionSTR);
            try
            {
                connection.Open();

                using (var reader = await new SqlCommand(sql, connection).ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        return DataTableToList<T>(dt);
                    }
                    else
                        return new List<T>();
                }
            }
            finally
            {
                connection.Close();
            }
        }

        private static List<T> DataTableToList<T>(DataTable table) where T : new()
        {
            var list = new List<T>();

            var typeProperties = typeof(T)
                .GetProperties()
                .Select(propertyInfo => new
                {
                    PropertyInfo = propertyInfo,
                    Type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType
                })
                .ToList();

            foreach (var row in table.Rows.Cast<DataRow>())
            {
                var obj = new T();

                foreach (var typeProperty in typeProperties)
                {
                    if (row.Table.Columns.Contains(typeProperty.PropertyInfo.Name))
                    {
                        object value = row[typeProperty.PropertyInfo.Name];
                        var safeValue = value == null || DBNull.Value.Equals(value)
                            ? null
                            : Convert.ChangeType(value, typeProperty.Type);

                        typeProperty.PropertyInfo.SetValue(obj, safeValue, null);
                    }
                }
                list.Add(obj);
            }

            return list;
        }
    }
}


