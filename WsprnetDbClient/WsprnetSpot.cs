using System;

namespace WsprnetDbClientLib
{
    public class WsprnetSpot
    {
        /// <summary>
        /// UTC
        /// </summary>
        public DateTime Timestamp { get; set; }
        public string Call { get; set; }
        /// <summary>
        /// In Hz
        /// </summary>
        public long Frequency { get; set; }
        /// <summary>
        /// dB
        /// </summary>
        public int Snr { get; set; }
        public int Drift { get; set; }
        public string Grid { get; set; }
        /// <summary>
        /// dBm
        /// </summary>
        public int Power { get; set; }
        public string ReporterCallsign { get; set; }
        public string ReporterLocator { get; set; }
        public int Km { get; set; }
        public string Mode { get; set; }

        public override int GetHashCode() => Timestamp.GetHashCode() ^ Call.GetHashCode() ^ ReporterCallsign.GetHashCode() ^ Frequency.GetHashCode();
    }
}