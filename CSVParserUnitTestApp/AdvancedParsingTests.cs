using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using CSVParserWinRT;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CSVParserUnitTestApp
{
    [TestClass]
    public class AdvancedParsingTests
    {
        string _complexCsvFragment = @"Quote,Author
""""""Don't blink,"""" said the Doctor"", the Doctor
"""""""" double quotes"",Random Text
"""""""""" """""""" two sets of double quotes"", More Random Text
";

        [TestMethod]
        public async Task AdvancedParserTest()
        {

            //"Don't blink," said the Doctor    the Doctor 
            //"" double quotes                  Random Text
            //"" "" two sets of double quotes   More Random Text

            // Setup
            string expectedQuote1 = "\"Don't blink,\" said the Doctor";
            string expectedQuote2 = "\"\" double quotes";
            string expectedQuote3 = "\"\" \"\" two sets of double quotes";

            string expectedAuthor1 = "the Doctor";
            string expectedAuthor2 = "Random Text";
            string expectedAuthor3 = "More Random Text";


            // Test
            CsvParser csvParser = new CsvParser();
            csvParser.RawText = this._complexCsvFragment;
            var results = await csvParser.Parse() as List<Dictionary<string, string>>;

            // Assert
            Assert.IsTrue(results.Count == 3);
            Assert.AreEqual(expectedQuote1, results[0]["Quote"]);


        }
    }
}
