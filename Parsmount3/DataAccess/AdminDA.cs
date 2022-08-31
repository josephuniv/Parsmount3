using Parsmount3.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parsmount3.DataAccess
{
    public static class AdminDA
    {
        static string connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Parsmount;Integrated Security=True";
        static SqlConnection cnn;

        public static String LogIn(Admin ad)
        {
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql;
            sql = $"select * from admin where email='{ad.email}' and password='{ad.password}'";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();
                return dataReader.GetValue(4).ToString();
            }
            else
                return "-1";
        }
    }


}