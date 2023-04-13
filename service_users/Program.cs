using userBusiness.Models;
using userData;
using userContract.Interfaces;
using RabbitMQ.Client;
using service_users;
using MassTransit;
using service_users.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<TransactionConsumer>();

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("amqp://guest:guest@localhost:5672");

        cfg.ReceiveEndpoint("subTransactions", c =>
        {
            c.ConfigureConsumer<TransactionConsumer>(ctx);
        });
    });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IUser, userBusiness.Models.User>();
builder.Services.AddTransient<IUser_DAL, userService>();



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

app.UseAuthorization();

app.MapControllers();

app.Run();

