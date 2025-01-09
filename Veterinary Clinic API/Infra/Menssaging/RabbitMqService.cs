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
        private const string _queue = "shipping-order-updated";
        private const string _routingKey = "order.created";

        public RabbitMqService()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            _connection = connectionFactory.CreateConnection("NameOfConnection");
            _channel = _connection.CreateModel();
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
