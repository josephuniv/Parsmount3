using Parsmount3.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parsmount3.DataAccess
{
    public static class MemberDA
    {
        static string connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Parsmount;Integrated Security=True";        
        static SqlConnection cnn;

        public static String LogIn(Member mem)
        {
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql;
            sql = $"select * from member where email='{mem.email}' and password='{mem.password}'";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();
                return dataReader.GetValue(5).ToString();
            }
            else
                return "-1";
        }


    }
}