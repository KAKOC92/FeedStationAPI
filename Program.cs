using FDAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//28 мая
// билдер можно удалить
builder.Services.Configure<ForwardedHeadersOptions>(options => {
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddDbContext<FSAPIContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("connect")));
var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Check}/{action=Index}/{id?}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
