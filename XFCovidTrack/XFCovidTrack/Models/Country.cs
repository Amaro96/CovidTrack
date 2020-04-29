using System;
using System.Collections.Generic;
using System.Text;

namespace XFCovidTrack.Models
{
   public class Country
    {
        public long updated { get; set; }
        public string country { get; set; }
        public int cases { get; set; }
        public int recovered { get; set; }
        public int deaths { get; set; }
        public int? countryRecords { get; set; }
        public int moreCases { get; set; }
    }
}
