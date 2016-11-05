using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BdcModelEvents.BdcModel1
{
    /// <summary>
    /// All the methods for retrieving, updating and deleting data are implemented in this class file.
    /// The samples below show the finder and specific finder method for BdcModel1.
    /// </summary>
    public class EventService
    {

        static SqlConnection getSqlConnection()
        {
            SqlConnection sqlConn = new SqlConnection("Data Source=DAVE-PC3; Initial Catalog=Events;User ID=eventreader; Password=events; Integrated Security=SSPI ");
            return (sqlConn);
        }
        /// <summary>
        /// This is a sample specific finder method for BdcModel1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity1</returns>
        public static Event ReadItem(int id)
        {
            Event event1 = new Event();
            using (SqlConnection conn = getSqlConnection())
            {
                conn.Open();
                string sqlCmd = "SELECT * FROM Events WHERE EventID = " + id.ToString();
                using (SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = sqlCmd;
                    SqlDataReader rdr = com.ExecuteReader(CommandBehavior.CloseConnection);
                    if (rdr.Read())
                    {
                        event1.EventID = Int32.Parse(rdr["EventID"].ToString());
                        event1.EventName = rdr["EventName"].ToString();
                        event1.EventDescription = rdr["EventDescription"].ToString();
                        event1.EventVenue = rdr["EventVenue"].ToString();
                        event1.EventDate = DateTime.Parse(rdr["EventDate"].ToString());

                    }
                    else
                    {
                        event1.EventID = -1;
                        event1.EventName = "Event not found";
                        event1.EventDescription = "";
                    }
                }
            }
            return event1;

        }
        /// <summary>
        /// This is a sample finder method for BdcModel1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <returns>IEnumerable of Entities</returns>
        public static IEnumerable<Event> ReadList()
        {
            List<Event> allEvents = new List<Event>();
            using (SqlConnection conn = getSqlConnection())
            {
                conn.Open();
                string sqlCmd = "SELECT * FROM Events";
                using (SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = sqlCmd;
                    SqlDataReader rdr = com.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rdr.Read())
                    {
                        Event event1 = new Event();
                        event1.EventID = Int32.Parse(rdr["EventID"].ToString());
                        event1.EventName = rdr["EventName"].ToString();
                        event1.EventDescription = rdr["EventDescription"].ToString();
                        event1.EventVenue = rdr["EventVenue"].ToString();
                        event1.EventDate = DateTime.Parse(rdr["EventDate"].ToString());
                        allEvents.Add(event1);
                    }
                }
            }
            Event[] eventList = new Event[allEvents.Count];
            for (int i = 0; i < allEvents.Count; i++)
            {
                eventList[i] = allEvents[i];
            }
            return eventList;
        }

        public static void Delete(int eventID)
        {
            using (SqlConnection conn = getSqlConnection())
            {
                conn.Open();
                string sqlCmd = "DELETE FROM Events WHERE EventID = " + eventID;
                using (SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = sqlCmd;
                    object result = com.ExecuteScalar();
                }
            }
        }

        public static void Update(Event eventEntity)
        {
            using (SqlConnection conn = getSqlConnection())
            {
                conn.Open();
                string sqlCmd = "Update Events SET EventName = " + eventEntity.EventName + 
                    ", EventDescription = " + eventEntity.EventDescription + 
                    ", EventVenue = " + eventEntity.EventVenue + 
                    ", EventDate = " + eventEntity.EventDate.ToShortDateString() + 
                    "WHERE EventID = " + eventEntity.EventID.ToString();
                using (SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = sqlCmd;
                    object result = com.ExecuteNonQuery();
                }
            }
        }

        public static Event Create(Event newEventEntity)
        {
            using (SqlConnection conn = getSqlConnection())
            {
                conn.Open();
                string sqlCmd = "INSERT INTO Events (EventName, EventDescription, EventVenue, EventDate) VALUES ("
                    + newEventEntity.EventName + ", "
                    + newEventEntity.EventDescription + ", "
                    + newEventEntity.EventVenue + ", "
                    + newEventEntity.EventDate.ToShortDateString() + ")";
                using (SqlCommand com = conn.CreateCommand())
                {
                    com.CommandText = sqlCmd;
                    object result = com.ExecuteNonQuery();
                }
            }
            return newEventEntity;
        }
    }
}
