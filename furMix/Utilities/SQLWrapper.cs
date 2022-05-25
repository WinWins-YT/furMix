using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace furMix.Utilities
{
    internal class SQLWrapper
    {
        static SqlConnection sql;
        internal static void Connect()
        {
            if (sql != null) sql.Dispose();
            SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
            sql = new SqlConnection(scb.ToString());
            sql.Open();
        }

        internal static DataTable GetActivationData()
        {
            DataSet ds = new DataSet();
            SqlCommand sc = new SqlCommand("SELECT", sql);
            using (SqlDataAdapter sda = new SqlDataAdapter(sc))
            {
                sda.Fill(ds);
            }
            sql.Dispose();
            return ds.Tables[0];
        }

        internal static void WriteLogFile(string name, FileStream fs)
        {
            SqlCommand sc = new SqlCommand("INSERT", sql);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.InsertCommand = sc;
            sda.InsertCommand.ExecuteNonQuery();
            sql.Dispose();
        }
    }
}
