using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParserHarness.Common
{
//    Src,Eqid,Version,Datetime,Lat,Lon,Magnitude,Depth,NST,Region
//nc,71834345,1,"Tuesday, August 28, 2012 19:13:55 UTC",38.8363,-122.8103,2.0,2.70,34,"Northern California"


    public class EarthQuakeData
    {
        public string Source { get; set; }

        public string Eqid { get; set; }

        public DateTime TimeStamp { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Magnitude { get; set; }

        public double Depth { get; set; }

        public string NST { get; set; }

        public string Region { get; set; }
    }
}
