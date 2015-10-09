using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using CSVParserWinRT;

namespace CSVParserTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void EmptyConstructorTest()
        {
            CsvParser csvParser = new CsvParser();

            Assert.AreEqual(true, csvParser.HasHeaderRow);
            Assert.AreEqual(',', csvParser.Delimiter);
            Assert.AreEqual(string.Empty, csvParser.RawText);

        }

        [TestMethod]
        public void RawTextConstructorTest()
        {
            string rawText = "Simple Raw Text";

            CsvParser csvParser = new CsvParser();
            csvParser.RawText = rawText;

            Assert.AreEqual(true, csvParser.HasHeaderRow);
            Assert.AreEqual(',', csvParser.Delimiter);
            Assert.AreEqual(rawText, csvParser.RawText);
        }

        [TestMethod]
        public void RawTextAndDelimiterConstructorTest()
        {
            string rawText = "Simple Raw Text";
            char delimiter = '\t';

            CsvParser csvParser = new CsvParser();
            csvParser.RawText = rawText;
            csvParser.Delimiter = delimiter;


            Assert.AreEqual(true, csvParser.HasHeaderRow);
            Assert.AreEqual(delimiter, csvParser.Delimiter);
            Assert.AreEqual(rawText, csvParser.RawText);
        }


        [TestMethod]
        public void FullConstructorTest()
        {
            string rawText = "Simple Raw Text";
            char delimiter = '\t';

            CsvParser csvParser = new CsvParser();
            csvParser.RawText = rawText;
            csvParser.Delimiter = delimiter;
            csvParser.HasHeaderRow = false;

            Assert.AreEqual(false, csvParser.HasHeaderRow);
            Assert.AreEqual(delimiter, csvParser.Delimiter);
            Assert.AreEqual(rawText, csvParser.RawText);
        }


    }
}
