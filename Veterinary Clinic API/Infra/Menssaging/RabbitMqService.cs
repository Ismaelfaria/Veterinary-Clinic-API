using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Veterinary_Clinic_API.Infra.Menssaging
{
    public class RabbitMqService : IMessageBusService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string _exchange = "trackings-service";
        private const string _queueName = "shipping-order-updated"; // Substitua pelo nome da sua fila
        private const string _routingKey = "order.created"; // Substitua pela chave de roteamento desejada

        public RabbitMqService()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            _connection = connectionFactory.CreateConnection("trackings-service-publisher");
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(_exchange, ExchangeType.Direct, durable: true);

            _channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            _channel.QueueBind(queue: _queueName, exchange: _exchange, routingKey: _routingKey);
        }

        public void Publish(object data, string routingKey)
        {
            var type = data.GetType();

            var payload = JsonConvert.SerializeObject(data);
            var arrayByte = Encoding.UTF8.GetBytes(payload);

            Console.WriteLine($"{type.Name} Published");

            _channel.BasicPublish(_exchange, routingKey, null, arrayByte);
        }

    }
}
