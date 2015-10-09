using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using CSVParserWinRT;


namespace CSVParserTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public async Task HeaderRowBasicParsingTest()
        {
            var csvText = GenerateBasicCsvTextWithHeaderRow();

            CsvParser csvParser = new CsvParser();

            csvParser.RawText = csvText;

            var results = await csvParser.Parse();

            var lineCount = csvText.Split('\n').Length;


            Assert.AreEqual(lineCount -2, results.Count() );
            Assert.AreEqual(10, results.First().Keys.Count);
            Assert.IsTrue(results.First().Keys.Contains("Depth"));
            Assert.IsTrue(results.First().Keys.Contains("Region"));
            Assert.IsTrue(results.First().Keys.Contains("Lat"));


        }

        [TestMethod]
        public async Task HeaderRowParsingTest()
        {
            var csvText = GenerateCsvTextWithHeaderRow();

            IParserEngine parserEngine = new CSVParserWinRT.ParserEngines.BetterParserEngine();

            CsvParser csvParser = new CsvParser(parserEngine);

            csvParser.RawText = csvText;

            var results = await csvParser.Parse();

            var lineCount = csvText.Split('\n').Length;


            Assert.AreEqual(lineCount -2, results.Count());
            Assert.AreEqual(10, results.First().Keys.Count);
            Assert.IsTrue(results.First().Keys.Contains("Depth"));
            Assert.IsTrue(results.First().Keys.Contains("Region"));
            Assert.IsTrue(results.First().Keys.Contains("Lat"));


        }




        private string GenerateBasicCsvTextWithHeaderRow()
        {
            StringBuilder csvBuilder = new StringBuilder();

            csvBuilder.AppendLine("Src,Eqid,Version,Datetime,Lat,Lon,Magnitude,Depth,NST,Region");
            csvBuilder.AppendLine("ci,15196921,0,Wednesday August 22 2012 20:49:19 UTC,36.0780,-117.7738,1.3,3.90,15,Central California");

            return csvBuilder.ToString();

        }

        private string GenerateBasicCsvTextWithoutHeaderRow()
        {
            StringBuilder csvBuilder = new StringBuilder();

            csvBuilder.AppendLine("ci,15196921,0,Wednesday August 22 2012 20:49:19 UTC,36.0780,-117.7738,1.3,3.90,15,Central California");

            return csvBuilder.ToString();

        }


        private string GenerateCsvTextWithHeaderRow(int repeatCount = 1)
        {
            StringBuilder csvBuilder = new StringBuilder();

            csvBuilder.AppendLine("Src,Eqid,Version,Datetime,Lat,Lon,Magnitude,Depth,NST,Region");

            //csvBuilder.AppendLine("ab,\"ny, ny\",\"he said, \", 4,5,6,7,8,9,0");

            for (int i = 0; i < repeatCount; i++)
            {

                csvBuilder.AppendLine("ci,15196921,0,\"Wednesday, August 22, 2012 20:49:19 UTC\",36.0780,-117.7738,1.3,3.90,15,\"Central California\"");
                csvBuilder.AppendLine("ci,15196905,0,\"Wednesday, August 22, 2012 20:47:54 UTC\",36.0068,-117.6208,1.4,7.00,22,\"Central California\"");
                csvBuilder.AppendLine("ci,15196897,0,\"Wednesday, August 22, 2012 20:39:37 UTC\",32.5878,-116.9897,1.9,2.20,34,\"San Diego County urban area, California\"");
                csvBuilder.AppendLine("ak,10544576,1,\"Wednesday, August 22, 2012 20:36:00 UTC\",63.1124,-151.6145,2.7,0.40,27,\"Central Alaska\"");
                csvBuilder.AppendLine("hv,60385556,1,\"Wednesday, August 22, 2012 20:32:04 UTC\",19.4983,-155.4920,1.8,3.20,10,\"Island of Hawaii, Hawaii\"");
                csvBuilder.AppendLine("ci,15196889,0,\"Wednesday, August 22, 2012 20:31:33 UTC\",34.3310,-116.8690,1.3,0.20,19,\"Southern California\"");
                csvBuilder.AppendLine("ci,15196881,0,\"Wednesday, August 22, 2012 20:28:15 UTC\",33.4820,-116.9327,1.2,6.70,28,\"Southern California\"");
                csvBuilder.AppendLine("hv,60385546,1,\"Wednesday, August 22, 2012 20:16:13 UTC\",19.7308,-155.3772,1.7,3.20,44,\"Island of Hawaii, Hawaii\"");
                csvBuilder.AppendLine("ci,15196865,0,\"Wednesday, August 22, 2012 19:58:32 UTC\",32.8203,-117.0697,1.1,0.90,26,\"San Diego County urban area, California\"");
                csvBuilder.AppendLine("nc,71835741,0,\"Wednesday, August 22, 2012 19:43:55 UTC\",37.3237,-122.0817,1.6,2.00, 8,\"San Francisco Bay area, California\"");
                csvBuilder.AppendLine("nc,71835736,0,\"Wednesday, August 22, 2012 19:43:38 UTC\",38.8243,-122.7607,1.1,1.10, 8,\"Northern California\"");
                csvBuilder.AppendLine("hv,60385521,1,\"Wednesday, August 22, 2012 19:41:08 UTC\",19.3720,-154.9995,1.8,0.20,34,\"Hawaii region, Hawaii\"");
                csvBuilder.AppendLine("ak,10544545,1,\"Wednesday, August 22, 2012 19:28:53 UTC\",62.9982,-150.5274,1.2,68.20,16,\"Central Alaska\"");
                csvBuilder.AppendLine("ak,10544543,1,\"Wednesday, August 22, 2012 19:27:10 UTC\",60.6117,-144.6995,1.3,0.00,11,\"Southern Alaska\"");
                csvBuilder.AppendLine("ak,10544541,1,\"Wednesday, August 22, 2012 19:23:36 UTC\",61.1127,-146.8972,1.3,0.00, 8,\"Southern Alaska\"");
                csvBuilder.AppendLine("ci,15196841,0,\"Wednesday, August 22, 2012 18:55:48 UTC\",35.0328,-118.3255,1.9,2.40,13,\"Southern California\"");
                csvBuilder.AppendLine("ci,15196825,0,\"Wednesday, August 22, 2012 18:29:06 UTC\",35.8363,-117.5490,1.0,9.80,18,\"Central California\"");
                csvBuilder.AppendLine("ak,10544529,1,\"Wednesday, August 22, 2012 18:27:04 UTC\",62.1336,-149.4174,1.1,32.90, 8,\"Central Alaska\"");
                csvBuilder.AppendLine("ak,10544516,1,\"Wednesday, August 22, 2012 18:07:58 UTC\",61.6367,-150.7190,2.8,62.80,66,\"Southern Alaska\"");
                csvBuilder.AppendLine("ci,15196809,0,\"Wednesday, August 22, 2012 18:03:58 UTC\",34.3368,-116.8815,1.6,0.10,44,\"Southern California\"");
                csvBuilder.AppendLine("ak,10544498,1,\"Wednesday, August 22, 2012 17:29:08 UTC\",62.2027,-149.7771,1.2,12.00,10,\"Central Alaska\"");

            }


            return csvBuilder.ToString();

        }

    }



}
