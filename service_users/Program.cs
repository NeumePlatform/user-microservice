using System.Security.Claims;
using System.Text;
using userBusiness.Models;
using userData;
using userContract.Interfaces;
using RabbitMQ.Client;
using service_users;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using service_users.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<TransactionConsumer>();

    //config.UsingRabbitMq((ctx, cfg) =>
    //{
    //    cfg.Host("amqp://guest:guest@localhost:5672");

    //    cfg.ReceiveEndpoint("subTransactions", c =>
    //    {
    //        c.ConfigureConsumer<TransactionConsumer>(ctx);
    //    });
    //});

    config.UsingAzureServiceBus((ctx, cfg) =>
    {
        cfg.Host("Endpoint=sb://neumeplatform.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=pf2GckyPcbONdiBWK80Vw1OqCDMsvgk/5+ASbKLV//w=");

        cfg.ReceiveEndpoint("transactions", c =>
        {
            c.ConfigureConsumer<TransactionConsumer>(ctx);
        });
    });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IUser, userBusiness.Models.User>();
builder.Services.AddTransient<IUser_DAL, userService>();

var domain = $"https://{builder.Configuration["Auth0:Domain"]}/";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = domain;
        options.Audience = builder.Configuration["Auth0:Audience"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = ClaimTypes.NameIdentifier
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("read:user", policy => policy.Requirements.Add(new HasScopeRequirement("read:user", domain)));
});

builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

