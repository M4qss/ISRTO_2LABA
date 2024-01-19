using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LABA2_SERVER_PART.Models
{
    public class Clients
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public string PHONE_NUMBER { get; set; }
        public int? AGE { get; set; }
    }
}