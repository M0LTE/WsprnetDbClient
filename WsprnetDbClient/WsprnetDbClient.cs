using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WsprnetDbClientLib
{
    public class WsprnetDbClient
    {
        public async Task<WsprnetSpot[]> GetSpots(WsprnetBand band, int numberOfSpots = 10000, string searchForCall = null, string showSpotsHeardBy = null, bool findUniqueCalls = false, bool findUniqueReporters = false)
        {
            var url = $"http://wsprnet.org/olddb?mode=html&band={band}&limit={Math.Min(10000, numberOfSpots)}&findcall={searchForCall}&findreporter={showSpotsHeardBy}{(findUniqueCalls ? "&unique=on" : "")}{(findUniqueReporters ? "&uniquereporters=on" : "")}";
            var htmlWeb = new HtmlWeb();
            var doc = await htmlWeb.LoadFromWebAsync(url);

            var rows = doc.DocumentNode.SelectNodes("/body[1]/table[3]/tr").Skip(2);

            var spots = new List<WsprnetSpot>();

            foreach (var row in rows)
            {
                var spot = new WsprnetSpot();
                spot.Timestamp = DateTime.ParseExact(StripNbsp(row.ChildNodes[0].InnerText), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                spot.Call = StripNbsp(row.ChildNodes[1].InnerText);
                spot.Frequency = (long)(double.Parse(StripNbsp(row.ChildNodes[2].InnerText)) * 1000000);
                spot.Snr = int.Parse(StripNbsp(row.ChildNodes[3].InnerText));
                spot.Drift = int.Parse(StripNbsp(row.ChildNodes[4].InnerText));
                spot.Grid = StripNbsp(row.ChildNodes[5].InnerText);
                spot.Power = int.Parse(StripNbsp(row.ChildNodes[6].InnerText));
                spot.ReporterCallsign = StripNbsp(row.ChildNodes[8].InnerText);
                spot.ReporterLocator = StripNbsp(row.ChildNodes[9].InnerText);
                spot.Km = int.Parse(StripNbsp(row.ChildNodes[10].InnerText));
                spot.Mode = StripNbsp(row.ChildNodes[12].InnerText);

                spots.Add(spot);
            }

            return spots.ToArray();
        }

        private string StripNbsp(string innerText) => innerText.Replace("&nbsp;", "");
    }
}