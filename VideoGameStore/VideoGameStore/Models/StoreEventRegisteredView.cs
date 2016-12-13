using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameStore.Models
{
    public class StoreEventRegisteredView
    {
        public int store_event_user_id { get; set; }
        public int store_event_id { get; set; }
        public int user_id { get; set; }
        public string street_address { get; set; }
        public bool is_registered { get; set; }
        public virtual Store_Event Store_Event { get; set; }
        public virtual User User { get; set; }
        public string store_event_name { get; set; }
        public string description { get; set; }
        public int address_id { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public int max_registrants { get; set; }
        public bool is_full { get; set; }
        public bool is_members_only { get; set; }
        public bool is_cancelled { get; set; }
    }
}