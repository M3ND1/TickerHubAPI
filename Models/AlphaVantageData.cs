using Newtonsoft.Json;

class AlphaVantageData
{
    public class Root
    {
        [JsonProperty("Meta Data")]
        public MetaData MetaData { get; set; }

        [JsonProperty("Time Series (Daily)")]
        public TimeSeriesDaily TimeSeriesDaily { get; set; }
    }
    public class MetaData
    {
        [JsonProperty("1. Information")]
        public string Information { get; set; } = string.Empty;

        [JsonProperty("2. Symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonProperty("3. Last Refreshed")]
        public string LastRefreshed { get; set; } = string.Empty;

        [JsonProperty("4. Output Size")]
        public string OutputSize { get; set; } = string.Empty;

        [JsonProperty("5. Time Zone")]
        public string TimeZone { get; set; } = string.Empty;
    }
    public class TimeSeriesDaily
    {
        [JsonProperty("1. open")]
        public string Open { get; set; } = string.Empty;
        [JsonProperty("2. high")]
        public string High { get; set; } = string.Empty;
        [JsonProperty("3. low")]
        public string Low { get; set; } = string.Empty;
        [JsonProperty("4. close")]
        public string Close { get; set; } = string.Empty;
        [JsonProperty("5. adjusted close")]
        public string AdjustedClose { get; set; } = string.Empty;
        [JsonProperty("6. volume")]
        public string Volume { get; set; } = string.Empty;
        [JsonProperty("7. dividend amount")]
        public string DividendAmount { get; set; } = string.Empty;
        [JsonProperty("8. split coefficient")]
        public string SplitCoefficient { get; set; } = string.Empty;
    }
}