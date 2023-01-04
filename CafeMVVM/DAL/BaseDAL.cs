using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CafeMVVM.DAL
{
    public class BaseDAL
    {
        private string ConnectionString = @"Data Source=localhost;Initial Catalog=Cafe_MVVM_DB;Integrated Security=True";
        public DataTable LoadData(string sql)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public DataTable LoadDataParameter(string sql, string[] name, object[] values, int parameter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parameter; i++)
                {
                    cmd.Parameters.AddWithValue(name[i], values[i]);
                }
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
        }
        public bool Execute(string sql, string[] name, object[] values, int parameter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parameter; i++)
                {
                    cmd.Parameters.AddWithValue(name[i], values[i]);
                }
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        public object GetOneValue(string sql, string[] name, object[] values, int parameter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parameter; i++)
                {
                    cmd.Parameters.AddWithValue(name[i], values[i]);
                }
                return cmd.ExecuteScalar();
            }
        }
    }
}
