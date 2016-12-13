///Created by David Klumpenhower
///created Dec 12, 2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameStore.Models;

namespace VideoGameStore.Models
{
     public partial class AverageGameRating
    {
        public int game_id { get; set; }
        public string game_name { get; set; }
        public string description { get; set; }
        public decimal cost { get; set; }
        public decimal list_price { get; set; }
        public int on_hand { get; set; }
        public string developer_name { get; set; }
        public string publisher_name { get; set; }
        public string genre { get; set; }
        public System.DateTime release_date { get; set; }
        public bool is_on_sale { get; set; }
        public bool is_discontinued { get; set; }
        public bool is_downloadable { get; set; }
        public bool is_physical_copy { get; set; }
        public string image_location { get; set; }
        public string averageRating { get; set; }
    }
}