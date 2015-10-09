using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace CSVParserWinRT
{
    /// <summary>
    /// Interface to abstract away the particulars of CSV Parsing
    /// </summary>
    public interface IParserEngine
    {

        IAsyncOperation<IList<string>> ExtractRecords(char lineDelimiter, string csvText);

        IAsyncOperation<IList<string>> ExtractFields(char delimiter, char quote, string csvLine);
    }
}
