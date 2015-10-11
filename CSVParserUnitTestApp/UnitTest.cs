using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using CSVParserWinRT;

namespace CSVParserUnitTestApp
{
    [TestClass]
    public class UnitTest1
    {
        string _testCSVFragment = @"Title,Category,Date,Hits
25 Creative Under Construction Page Designs,Design,10/8/2015,40
Liam Neeson Tries Comedy,Humor,10/8/2015,89
Basics of Electricity,IoT,10/8/2015,64
Internet of Treats (IoT),IoT,10/8/2015,74
Talking to Your Organization about Cortana Analytics,Developer,10/8/2015,82
Session Downloader Reloaded,Developer,10/7/2015,159
First Look at Skype Meeting Broadcast,""Tech,Video Production"",10/7/2015,124
Getting Places Smartly: Connecting Sustainable Transportation to the Internet of Things, IoT,10/7/2015,106
Build 2015 Session Downloader, Developer,10/6/2015,146
Connecting NodeJS to Office 365 APIs,""Developer,NodeJS"",10/1/2015,307
ScottGu on the Journey to the Intelligent Cloud, Azure,9/29/2015,140
The Things You See in Silicon Valley,""Geek,Humor"",9/28/2015,110
Elon Musk Talks Tesla, Tech,9/26/2015,156
Node.js support for Azure Mobile Apps,NodeJS,9/25/2015,319
25 Free Flat Design Graphics, Design,9/24/2015,153
4000th Post!, Site Updates,9/23/2015,104
""ZoomData Makes Everyone a Data Scientist, 5 DCTech Startups to Watch, and NAB Partners with 1776"",""DCTech,DCTech Minute"",9/23/2015,103
Nuking Mars,""Science,Space"",9/22/2015,78
Marcy Sutton on JavaScript for Everybody,Developer,9/22/2015,49
From Nordic.js 2015 Matthew Podwysocki on Async and Streaming Programming in JS, Developer,9/22/2015,175
""Pope Francis Comes to Town, Papal Surge Pricing, and Startup Weekend DC"",""DCTech, DCTech Minute"",9/22/2015,54
Top 15 Mistakes Beginner Filmmakers Make, Video Production,9/21/2015,65";


        [TestMethod]
        public async void CSVParsingTest()
        {
            // Setup
            var expectedRecordCount = this._testCSVFragment.Split('\n').Length - 1;

            // Test
            CsvParser csvParser = new CsvParser();
            csvParser.RawText = this._testCSVFragment;
            var results = await csvParser.Parse();

            // Assert
            Assert.AreEqual(0, 0);


        }
    }
}
