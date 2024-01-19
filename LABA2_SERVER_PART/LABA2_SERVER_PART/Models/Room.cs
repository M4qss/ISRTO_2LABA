using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LABA2_SERVER_PART.Models
{
    public class Room
    {
        public int ID { get; set; }
        public int? BEDS { get; set; }
        public int? FLOOR { get; set; }
        public string CLASS { get; set; }
    }
}