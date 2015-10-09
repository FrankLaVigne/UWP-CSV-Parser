using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace CSVParserWinRT.ParserEngines
{
    public sealed class BasicParserEngine : IParserEngine 
    {
        public IAsyncOperation<IList<string>> ExtractFields(char delimiter, char quote, string csvLine)
        {

            return Task.Run<IList<string>>(async () => {

                var fieldValues = csvLine.Split(delimiter);

                var fieldValuesList = new List<string>(fieldValues);

                return fieldValuesList;

            }).AsAsyncOperation();

        }

        public IAsyncOperation<IList<string>> ExtractRecords(char lineDelimiter, string csvText)
        {
            return Task.Run<IList<string>>(async () =>
            {

                throw new NotImplementedException();

            }).AsAsyncOperation();

        }
    }
}
