using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
  
    public  class MQService: IMQService
    {
        private readonly IConnection _connection;
        public  MQService(IConfiguration congiguration)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            
            using var connection = factory.CreateConnection();
            _connection= connection; ;
            

        }

        public void PublishMessage(object message, string queueName)
        {
            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            


            //var message = new { FlightId = 1, SeatNos = new List<string> { "1A" }, Status = true };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish("", queueName, null, body);
            


        }
    }
}
