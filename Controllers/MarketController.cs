using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace TickerHub.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MarketController : ControllerBase
{
    private MarketClient _marketClient;

    public MarketController(MarketClient marketClient)
    {
        _marketClient = marketClient;
    }
    private async Task<ActionResult> GetMarketData(Func<Task<HttpResponseMessage>> apiCall)
    {
        var response = await apiCall();
        var json = await response.Content.ReadAsStringAsync();

        var parsedJson = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(json);
        return Ok(parsedJson);
    }

    [HttpGet("GetUSDaily")]
    public async Task<ActionResult> GetUSDaily(string symbol) => await GetMarketData(() => _marketClient.GetUsDaily(symbol));

    [HttpGet("GetUsWeekly")]
    public async Task<ActionResult> GetUsWeekly(string symbol) => await GetMarketData(() => _marketClient.GetUsWeekly(symbol));

    [HttpGet("GetUSMonthly")]
    public async Task<ActionResult> GetUSMonthly(string symbol) => await GetMarketData(() => _marketClient.GetUsMonthly(symbol));

    [HttpGet("TickerSearch")]
    public async Task<ActionResult> TickerSearch(string keywords) => await GetMarketData(() => _marketClient.TickerSearch(keywords));

    [HttpGet("GlobalMarketStatus")]
    public async Task<ActionResult> GlobalMarketStatus() => await GetMarketData(() => _marketClient.GlobalMarketStatus());

    [HttpGet("TopGainersLoosers")]
    public async Task<ActionResult> TopGainersLoosers() => await GetMarketData(() => _marketClient.TopGainersLoosers());
}