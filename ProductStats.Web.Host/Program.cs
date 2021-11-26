using ProductStats.Application;
using ProductStats.Web.Host.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentityServer()
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddDeveloperSigningCredential();

builder.Services.AddAuthentication(defaultScheme: "Bearer")
    .AddIdentityServerAuthentication("Bearer", options =>
    {
        options.ApiName = Config.ApiName;
        options.Authority = "https://localhost:7100";
    });

builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseIdentityServer();

if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
