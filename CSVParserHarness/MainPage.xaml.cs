using CSVParserWinRT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Data.Json;
using CSVParserHarness.Common;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CSVParserHarness
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<EarthQuakeData> _earthQuakeDataList;

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            HttpClient client = new HttpClient();
            string earthQuakeData = await client.GetStringAsync("https://data.consumerfinance.gov/api/views/s6ew-h6mp/rows.csv?accessType=DOWNLOAD");

            CsvParser csvParser = new CsvParser();
            csvParser.RawText = earthQuakeData;

            var results = await csvParser.Parse();

            ConvertDictionaryToViewModel(results);

            this.lbxEarthquake.ItemsSource = this._earthQuakeDataList;

        }

        private void ConvertDictionaryToViewModel(IEnumerable<IDictionary<string, string>> results)
        {
            this._earthQuakeDataList = new List<EarthQuakeData>();

            foreach (var item in results)
            {

                EarthQuakeData earthquakeDataPoint = new EarthQuakeData();

                //Src,Eqid,Version,Datetime,Lat,Lon,Magnitude,Depth,NST,Region

                earthquakeDataPoint.Source = item["Src"];
                earthquakeDataPoint.NST = item["NST"];
                earthquakeDataPoint.Region = item["Region"];

                earthquakeDataPoint.Latitude = double.Parse(item["Lat"]);
                earthquakeDataPoint.Longitude = double.Parse(item["Lon"]);
                earthquakeDataPoint.Depth = double.Parse(item["Depth"]);
                earthquakeDataPoint.Magnitude = double.Parse(item["Magnitude"]);

                this._earthQuakeDataList.Add(earthquakeDataPoint);
            }

        }
    }
}
