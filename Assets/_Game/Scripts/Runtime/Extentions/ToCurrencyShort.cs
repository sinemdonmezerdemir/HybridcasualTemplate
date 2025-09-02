namespace Runtime.Extensions
{
    public static class ToCurrencyShort
    {
        public static string ToCurrencySortString(this float money, string format = "0.##")
        {
            if (money < 999) return money.ToString(format);
            string result = (money / 1000).ToString(format) + "K";
            return result;
        }

        public static string ToCurrencySortString(this int money)
        {
            if (money < 999) return money.ToString();
            string result = money / 1000 + "K";
            return result;
        }
    }
}