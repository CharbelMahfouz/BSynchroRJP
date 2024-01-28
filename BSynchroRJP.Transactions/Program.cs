using BSynchroRJP.Common;
using BSynchroRJP.Common.Messaging.Endpoints;
using BSynchroRJP.Transactions.Consumers;
using BSynchroRJP.Transactions.Domain.CQRS.Commands;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureMongoDbConnection(builder.Configuration);
builder.Services.ConfigureRepositories();
builder.Services.AddControllers();
builder.Services.ConfigureMediatr();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateTransactionCommand).Assembly));

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.AddConsumer<CreateTransactionConsumer>();
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(new Uri(builder.Configuration["RabbitMqConfig:Host"]!), h =>
        {
            h.Username(builder.Configuration["RabbitMqConfig:Username"]!);
            h.Password(builder.Configuration["RabbitMqConfig:Password"]!);
        });
        configurator.ReceiveEndpoint(Endpoints.CreateTransaction, e =>
        {
           
            e.ConfigureConsumer<CreateTransactionConsumer>(context);
        });
        configurator.ConfigureEndpoints(context);
    });

});
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
