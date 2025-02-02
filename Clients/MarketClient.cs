
public class MarketClient
{
    private readonly HttpClient _client;
    private IConfiguration _configuration;
    public MarketClient(HttpClient client, IConfiguration configuration)
    {
        _client = client;
        _configuration = configuration;
    }

    public async Task<HttpResponseMessage> GetUsDaily(string symbol) => await _client.GetAsync($"query?function=TIME_SERIES_DAILY&symbol={symbol}&outputsize=compact&apikey={_configuration.GetValue<string>("APIKey")}");

    public async Task<HttpResponseMessage> GetUsWeekly(string symbol) => await _client.GetAsync($"query?function=TIME_SERIES_WEEKLY&symbol={symbol}&apikey={_configuration.GetValue<string>("APIKey")}");

    public async Task<HttpResponseMessage> GetUsMonthly(string symbol) => await _client.GetAsync($"query?function=TIME_SERIES_MONTHLY&symbol={symbol}&apikey={_configuration.GetValue<string>("APIKey")}");

    public async Task<HttpResponseMessage> TickerSearch(string keywords) => await _client.GetAsync($"query?function=SYMBOL_SEARCH&keywords={keywords}&apikey={_configuration.GetValue<string>("APIKey")}");
    public async Task<HttpResponseMessage> GlobalMarketStatus() => await _client.GetAsync($"query?function=MARKET_STATUS&apikey={_configuration.GetValue<string>("APIKey")}");
    public async Task<HttpResponseMessage> TopGainersLoosers() => await _client.GetAsync($"query?function=TOP_GAINERS_LOSERS&apikey={_configuration.GetValue<string>("APIKey")}");

}