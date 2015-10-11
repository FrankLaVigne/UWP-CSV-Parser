using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CSVParserWinRT;
using System.Net.Http;
using System.Threading.Tasks;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CSV_Parser_Test_Harness_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string SAMPLE_CSV_DATA_URL = "https://data.cityofnewyork.us/api/views/jb7j-dtam/rows.csv?accessType=DOWNLOAD";

        public MainPage()
        {
            this.InitializeComponent();

            ParseData();

        }

        private async void ParseData()
        {
            CsvParser csvParser = new CsvParser();
            var rawText = await DownloadCsvData();
            csvParser.RawText = rawText;

            var parsedResults = await csvParser.Parse();

            var queryAgainstResults = parsedResults
                .Where(x => x["Year"] == "2010" && x["Sex"] == "MALE")
                .ToList();
                ;

        }

        private Task<string> DownloadCsvData()
        {
            HttpClient client = new HttpClient();
            Task<string> csvData = client.GetStringAsync(SAMPLE_CSV_DATA_URL);

            return csvData;
        }
    }
}
