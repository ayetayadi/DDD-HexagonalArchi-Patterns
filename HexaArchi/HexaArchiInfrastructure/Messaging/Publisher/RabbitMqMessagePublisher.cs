using HexaArchi.Application.Ports.Driven;
using HexaArchi.Domain.Models;
using HexaArchi.SharedKarnel.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace HexaArchi.Infrastructure.Messaging.Publisher
{
    public class RabbitMqMessagePublisher : IMessagePublisher
    {
        private readonly RabbitMQSettings _rabbitMQSettings;

        public RabbitMqMessagePublisher(IOptions<RabbitMQSettings> rabbitMQSettings)
        {
            _rabbitMQSettings = rabbitMQSettings.Value;
        }

        public async Task PublishMessageAsync(Message message)
        {
            var factory = new ConnectionFactory() { HostName = _rabbitMQSettings.HostName };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _rabbitMQSettings.QueueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            var basicProperties = channel.CreateBasicProperties();
            basicProperties.Persistent = true;

            channel.BasicPublish(exchange: "",
                                 routingKey: _rabbitMQSettings.QueueName,
                                 basicProperties: basicProperties,
                                 body: messageBody);

            await Task.CompletedTask;
        }
    }
}
