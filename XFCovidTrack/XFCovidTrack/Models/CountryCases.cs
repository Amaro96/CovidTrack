using System;
using System.Collections.Generic;
using System.Text;

namespace XFCovidTrack.Models
{
    public class CountryCases
    {

        public long updated { get; set; }
        public string country { get; set; }
        public Countryinfo countryInfo { get; set; }
        public int cases { get; set; }
        public int todayCases { get; set; }
        public int deaths { get; set; }
        public int todayDeaths { get; set; }
        public int recovered { get; set; }
        public int active { get; set; }
        public int critical { get; set; }
        public int casesPerOneMillion { get; set; }
        public int deathsPerOneMillion { get; set; }
        public int tests { get; set; }
        public int testsPerOneMillion { get; set; }
        public string continent { get; set; }
    }
}
        public class Countryinfo
        {
            public int _id { get; set; }
            public string iso2 { get; set; }
            public string iso3 { get; set; }
            public int lat { get; set; }
            public int _long { get; set; }
            public string flag { get; set; }
        }
    

