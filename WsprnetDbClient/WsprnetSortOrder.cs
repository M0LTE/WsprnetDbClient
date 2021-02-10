namespace WsprnetDbClientLib
{
    public class WsprnetSortOrder
    {
        private readonly string formValue;
        public static WsprnetSortOrder Date => new WsprnetSortOrder("date");
        public static WsprnetSortOrder Call => new WsprnetSortOrder("callsign");
        public static WsprnetSortOrder Frequency => new WsprnetSortOrder("mhz");
        public static WsprnetSortOrder SNR => new WsprnetSortOrder("db");
        public static WsprnetSortOrder Grid => new WsprnetSortOrder("grid");
        public static WsprnetSortOrder Power => new WsprnetSortOrder("power");
        public static WsprnetSortOrder Reporter => new WsprnetSortOrder("reporter");
        public static WsprnetSortOrder Distance => new WsprnetSortOrder("distance");
        public static WsprnetSortOrder MilesPerWatt => new WsprnetSortOrder("distance/pow(10,(power-30.0)/10.0)");
        public static WsprnetSortOrder UploadOrder => new WsprnetSortOrder("spotnum");

        public override string ToString() => formValue;

        private WsprnetSortOrder(string formValue) => this.formValue = formValue;

        public override bool Equals(object obj)
        {
            if (!(obj is WsprnetSortOrder other))
            {
                return false;
            }

            return other.formValue == formValue;
        }

        public override int GetHashCode() => formValue == null ? 0 : formValue.GetHashCode();

        public static bool operator ==(WsprnetSortOrder lhs, WsprnetSortOrder rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }

                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(WsprnetSortOrder lhs, WsprnetSortOrder rhs) => !(lhs == rhs);
    }
}