using CAFEMENU.MessageBroker.RabbitMq.Abstract;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.MessageBroker.RabbitMq.Concrete
{
    public class RabbitMqMessageBroker : IMessageBroker
    {
        string HOSTNAME = string.Empty;
        string USERNAME = string.Empty;
        string PASSWORD = string.Empty;

        public RabbitMqMessageBroker(IConfiguration configuration)
        {
            HOSTNAME = configuration.GetSection("RabbitMQ:Host").Value;
            USERNAME = configuration.GetSection("RabbitMQ:User").Value;
            PASSWORD = configuration.GetSection("RabbitMQ:Password").Value;            
        }
        public async Task Publish(string exchangeName, object message)
        {
            await Task.Yield();
            var factory = new ConnectionFactory() { HostName = HOSTNAME, UserName = USERNAME, Password = PASSWORD };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchangeName, "fanout", durable: true, false);
                var serializedMessage = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(serializedMessage);
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                channel.BasicPublish(exchange: exchangeName, "", body: body);
            }
        }
    }

}
