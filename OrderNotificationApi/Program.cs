using MassTransit;
using OrderNotificationApi.Consumers;
using OrderNotificationApi.Services;
using OrderNotificationApi.Services.Interfaces;

namespace OrderNotificationApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<INotificationService, NotificationService>();

            builder.Services.AddMassTransit(busConfiguration =>
            {
                busConfiguration.SetKebabCaseEndpointNameFormatter();

                busConfiguration.AddConsumer<OrderAddedConsumer>();

                busConfiguration.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(builder.Configuration["RabbitMQSettings:Hostname"]!), h =>
                    {
                        h.Username(builder.Configuration["RabbitMQSettings:Username"]);
                        h.Password(builder.Configuration["RabbitMQSettings:Password"]);
                    });

                    configurator.ConfigureEndpoints(context);
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}