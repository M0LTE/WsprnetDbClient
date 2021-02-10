using System;
using System.Threading.Tasks;
using WsprnetDbClientLib;

namespace download_spots
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new WsprnetDbClient();

            var spots = await client.GetSpots(WsprnetBand.All);

            foreach (var spot in spots)
            {
                Console.WriteLine($"{spot.Timestamp:yyyy-MM-dd HH:mm} {spot.Call} {spot.Frequency} {spot.Snr} {spot.Drift} {spot.Grid} {spot.Power} {spot.ReporterCallsign} {spot.ReporterLocator} {spot.Km} {spot.Mode}");
            }
        }
    }
}
