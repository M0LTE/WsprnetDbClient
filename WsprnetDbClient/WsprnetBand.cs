namespace WsprnetDbClientLib
{
    public class WsprnetBand
    {
        private readonly string formValue;

        public static WsprnetBand All => new WsprnetBand("all");
        public static WsprnetBand _2190_to_600m => new WsprnetBand("2190");
        public static WsprnetBand _160m => new WsprnetBand("160");
        public static WsprnetBand _80m => new WsprnetBand("80");
        public static WsprnetBand _60m => new WsprnetBand("60");
        public static WsprnetBand _40m => new WsprnetBand("40");
        public static WsprnetBand _30m => new WsprnetBand("30");
        public static WsprnetBand _20m => new WsprnetBand("20");
        public static WsprnetBand _17m => new WsprnetBand("17");
        public static WsprnetBand _15m => new WsprnetBand("15");
        public static WsprnetBand _12m => new WsprnetBand("12");
        public static WsprnetBand _10m => new WsprnetBand("10");
        public static WsprnetBand _6m => new WsprnetBand("6");
        public static WsprnetBand _4m => new WsprnetBand("4");
        public static WsprnetBand _2m => new WsprnetBand("2");
        public static WsprnetBand _125cm => new WsprnetBand("220");
        public static WsprnetBand _70cm => new WsprnetBand("432");
        public static WsprnetBand _gHz => new WsprnetBand("u");

        public override string ToString() => formValue;

        private WsprnetBand(string formValue) => this.formValue = formValue;

        public override bool Equals(object obj)
        {
            if (!(obj is WsprnetBand other))
            {
                return false;
            }

            return other.formValue == formValue;
        }

        public override int GetHashCode() => formValue == null ? 0 : formValue.GetHashCode();

        public static bool operator ==(WsprnetBand lhs, WsprnetBand rhs)
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

        public static bool operator !=(WsprnetBand lhs, WsprnetBand rhs) => !(lhs == rhs);
    }
}
