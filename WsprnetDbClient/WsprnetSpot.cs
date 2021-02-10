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

        public override int GetHashCode() =>
            Timestamp.GetHashCode()
            ^ (Call == null ? 0 : Call.GetHashCode())
            ^ Frequency.GetHashCode()
            ^ Snr.GetHashCode()
            ^ Drift.GetHashCode()
            ^ Grid.GetHashCode()
            ^ Power.GetHashCode()
            ^ (ReporterCallsign == null ? 0 : ReporterCallsign.GetHashCode())
            ^ (ReporterLocator == null ? 0 : ReporterLocator.GetHashCode())
            ^ Km.GetHashCode()
            ^ (Mode == null ? 0 : Mode.GetHashCode());

        public override bool Equals(object obj)
        {
            if (!(obj is WsprnetSpot other))
            {
                return false;
            }

            return other.Timestamp == Timestamp
                && other.Call == Call
                && other.Frequency == Frequency
                && other.Snr == Snr
                && other.Drift == Drift
                && other.Grid == Grid
                && other.Power == Power
                && other.ReporterCallsign == ReporterCallsign
                && other.ReporterLocator == ReporterLocator
                && other.Km == Km
                && other.Mode == Mode;
        }

        public override string ToString()
        {
            return $"{Timestamp:yyyy-MM-dd HH:mm} {Call}->{ReporterCallsign} @ {Frequency / 1000}kHz";
        }
    }
}