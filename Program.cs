var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<MarketClient>("AlphaVantage", client =>
{
    client.BaseAddress = new Uri("https://www.alphavantage.co");
});
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
