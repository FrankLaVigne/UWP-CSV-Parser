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
using System.Text;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CSV_Parser_Test_Harness_Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string SAMPLE_CSV_DATA_URL = "https://data.cityofnewyork.us/api/views/jb7j-dtam/rows.csv?accessType=DOWNLOAD";

        public IEnumerable<Dictionary<string, string>> Data { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            DownloadAndParseData();
        }

        private void BuildPivotContent()
        {
            // TODO: use DataBinding instead of generating controls by code

            var uniqueYears =
                (from data in this.Data
                 select data["Year"]).Distinct().OrderBy(x => x).ToList();
            
            uniqueYears.ForEach(x => {

                var pivotItem = new PivotItem() { Header = x };
                var grid = new Grid();

                var dataForYear =
                (from data in this.Data
                 select data)
                 .Where(y => y["Year"] == x)
                 .Distinct()
                 .OrderBy(z => z["Count"]);

                StringBuilder causes = new StringBuilder();

            dataForYear.ToList()
            .ForEach(line =>
                    {
                        var lineString = string.Format("{0} ({1}, {2})", line["Cause of Death"], line["Sex"], line["Ethnicity"]);
                        causes.AppendLine(lineString);
                    }
                );

                var textBlock = new TextBlock()
                    {
                        Text = causes.ToString()
                    };

                ScrollViewer sv = new ScrollViewer();
                sv.Content = textBlock;

                grid.Children.Add(sv);

                pivotItem.Content = grid;
                pvtPivot.Items.Add(pivotItem);


            } );




        }

        private async void DownloadAndParseData()
        {
            CsvParser csvParser = new CsvParser();
            var rawText = await DownloadCsvData();
            csvParser.RawText = rawText;

            this.Data = await csvParser.Parse() as IEnumerable<Dictionary<string, string>>;

            BuildPivotContent();


        }

        private Task<string> DownloadCsvData()
        {
            HttpClient client = new HttpClient();
            Task<string> csvData = client.GetStringAsync(SAMPLE_CSV_DATA_URL);

            return csvData;
        }
    }
}
