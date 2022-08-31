using Parsmount3.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace Parsmount3.DataAccess
{
    public static class EventDA
    {
        static string connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Parsmount;Integrated Security=True";
        static SqlConnection cnn;        
        public static Event search(string col, int eve)        
        {
            Event ev = new Event();
            cnn = new SqlConnection(connetionString);
            cnn.Open();            
            SqlCommand command;
            SqlDataReader dataReader;
            String sql;            
            //sql = $"select * from event where event_id={eve}";
            sql = $"select * from event where {col}={eve}";
            //sql = $"select * from event where {col}='{eve}'";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            bool found = false;
            while (dataReader.Read())
            {                
                ev.Event_Id = Convert.ToInt32(dataReader.GetValue(0));
                ev.Name = Convert.ToString(dataReader.GetValue(1));
                if (dataReader.GetValue(2) != null && dataReader.GetValue(2) != DBNull.Value)
                    ev.DateTime = Convert.ToDateTime(dataReader.GetValue(2));
                ev.Category = Convert.ToString(dataReader.GetValue(3));
                ev.Max_Number = Convert.ToString(dataReader.GetValue(4));
                found = true;             
            }
            cnn.Close(); 
            if (found)
                return ev;
            else
                return null;
        }

        public static List<Event> searchMany(string col, string eve)
        {
            List<Event> listEvent = new List<Event>();
            //Event ev = new Event();  
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql;
            //sql = $"select * from event where event_id={eve}";
            //sql = $"select * from event where {col}={eve}";
            sql = $"select * from event where {col}='{eve}'";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            bool found = false;
            while (dataReader.Read())
            {
                Event ev = new Event();
                ev.Event_Id = Convert.ToInt32(dataReader.GetValue(0));
                ev.Name = Convert.ToString(dataReader.GetValue(1));
                if (dataReader.GetValue(2) != null && dataReader.GetValue(2) != DBNull.Value)
                    ev.DateTime = Convert.ToDateTime(dataReader.GetValue(2));
                ev.Category = Convert.ToString(dataReader.GetValue(3));
                ev.Max_Number = Convert.ToString(dataReader.GetValue(4));
                found = true;
                listEvent.Add(ev); 
            } 
            cnn.Close();
            if (found)
                return listEvent;
            else
                return null;
        }

        public static void insert(Event eve)
        {            
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql;
            sql = $"insert into event (name, category) values('{eve.Name}', '{eve.Category}')";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();           
            cnn.Close();            
        }

        public static void update(int id, Event eveNew)
        {
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql;
            sql = $"update event set name='{eveNew.Name}', category='{eveNew.Category}'" +
                $"where event_id={id}";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            cnn.Close();
        }

        public static void delete(int id)
        {
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql;
            sql = $"delete from event where event_id={id}";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            cnn.Close();
        }

    }
}