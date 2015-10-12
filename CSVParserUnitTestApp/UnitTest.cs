using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using CSVParserWinRT;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CSVParserUnitTestApp
{
    [TestClass]
    public class UnitTest1
    {
        string _testCSVFragment = @"Title,Category,Date,Hits
25 Creative Under Construction Page Designs,Design,10/8/2015,40
Basics of Electricity,IoT,10/8/2015,64
Internet of Treats (IoT),IoT,10/8/2015,74
Talking to Your Organization about Cortana Analytics,Developer,10/8/2015,82
Session Downloader Reloaded,Developer,10/7/2015,159
Node.js support for Azure Mobile Apps,NodeJS,9/25/2015,319
4000th Post!, Site Updates,9/23/2015,104
""ZoomData Makes Everyone a Data Scientist, 5 DCTech Startups to Watch, and NAB Partners with 1776"",""DCTech,DCTech Minute"",9/23/2015,103
Nuking Mars,""Science,Space"",9/22/2015,78
""Pope Francis Comes to Town, Papal Surge Pricing, and Startup Weekend DC"",""DCTech, DCTech Minute"",9/22/2015,54
Top 15 Mistakes Beginner Filmmakers Make, Video Production,9/21/2015,65";

        [TestMethod]
        public async Task CSVParsingRecordCountTest()
        {
            // Setup
            var expectedRecordCount = this._testCSVFragment.Split('\n').Length - 1;

            // Test
            CsvParser csvParser = new CsvParser();
            csvParser.RawText = this._testCSVFragment;
            var results = await csvParser.Parse() as List<Dictionary<string,string>>;

            // Assert
            Assert.AreEqual(expectedRecordCount, results.Count);

        }
        
        [TestMethod]
        public async Task CSVParsingCommaTest()
        {
            // Setup
            var expectedRecord7Title = "ZoomData Makes Everyone a Data Scientist, 5 DCTech Startups to Watch, and NAB Partners with 1776";
            var expectedRecord9Title = "Pope Francis Comes to Town, Papal Surge Pricing, and Startup Weekend DC";

            // Test
            CsvParser csvParser = new CsvParser();
            csvParser.RawText = this._testCSVFragment;
            var results = await csvParser.Parse() as List<Dictionary<string, string>>;

            var actualRecord7Title = results[7]["Title"];
            var actualRecord9Title = results[9]["Title"];

            // Assert
            Assert.AreEqual(expectedRecord7Title, actualRecord7Title);
            Assert.AreEqual(expectedRecord9Title, actualRecord9Title);

        }

    }
}
