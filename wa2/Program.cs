var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<wa2.WeatherClient>(client =>
{
    client.BaseAddress =new Uri( "http://wa1-service:8088");
});

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
