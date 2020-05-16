using System;
using System.Collections.Generic;
using System.Text;

namespace XFCovidTrack.Models
{
    public class Country
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
            public double casesPerOneMillion { get; set; }
            public double deathsPerOneMillion { get; set; }
            public int tests { get; set; }
            public double testsPerOneMillion { get; set; }
            public string continent { get; set; }
        }
    
        public class Countryinfo
        {
            public int id { get; set; }
            public string iso2 { get; set; }
            public string iso3 { get; set; }
            public double lat { get; set; }
            public double _long { get; set; }
            public string flag { get; set; }
        }

    }
