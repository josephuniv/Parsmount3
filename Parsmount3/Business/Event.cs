using Parsmount3.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parsmount3.Business
{
    public class Event
    {
        public int Event_Id { get; set; }
        public string Name { get; set; }

        public DateTime DateTime { get; set; }
        public string Category { get; set; }

        public string Max_Number { get; set; }

        public string Description { get; set; }

        public Event search(string col, int eve)
        {
            return EventDA.search(col, eve);
        }

        public List<Event> searchMany(string col, string eve)
        {
            return EventDA.searchMany(col, eve);
        }

        public void insert(Event eve)
        {
            EventDA.insert(eve);
        }

        public void update(int id, Event evNew)
        {
            EventDA.update(id, evNew);
        }

        public void delete(int id)
        {
            EventDA.delete(id);
        }
    }
}