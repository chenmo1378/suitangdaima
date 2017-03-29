using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace HRMSys.DAL
{
    static class SqlHelper
    {
        //app.config文件的继承：

        public static readonly string connstr = 
            ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;

        public static int ExecuteNonQuery(string sql, 
            params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql,
            params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static DataTable ExecuteDataTable(string sql,
            params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);

                    DataSet dataset = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }

            //try
            //{
                
            //}
            //catch
            //{
            //    DataTable dt = new DataTable();
            //    return dt;
            //}
        }

        public static object FromDbValue(object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
            {
                return value;
            }
        }

        public static object ToDbValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }
    }
}
