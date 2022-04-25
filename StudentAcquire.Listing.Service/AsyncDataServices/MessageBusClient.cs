using System;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace StudentAcquire.Listing.Service.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbitMQPort"]),
            };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "listing-exchange", type: ExchangeType.Fanout);

                _connection.ConnectionShutdown += RabbitMq_ConnectionShutdown;

                Console.WriteLine("--> RabbitMQ Connection Established");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Error Connecting to RabbitMQ: {ex.Message}");
            }
        }

        private void RabbitMq_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine($"--> RabbitMQ Connection Shutdown: {e.ReplyText}");
        }

        public void PublishNewListing(ListingPublishDto listing)
        {
            var message = JsonSerializer.Serialize(listing);

            if(_connection.IsOpen)
            {
                Console.WriteLine($"--> Publishing Listing: {message}");

                SendMessage(message);
            } 
            else 
            {
                Console.WriteLine($"--> RabbitMQ Connection Closed");
            }
        }

        public void Dispose()
        {
            Console.WriteLine("--> Disposing RabbitMQ Connection");
            if(_channel.IsOpen){
                _channel.Close();
                _connection.Close();
            }
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "listing-exchange",
                                 routingKey: "",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine("--> Message Sent");
        }
    }
}