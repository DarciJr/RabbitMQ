using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQ
{
    public class Consumer : RabbitMQ
    {
        public RabbitMQMessage LastMessage { get; set; }

        public Consumer(string host, string user, string password) : base(host, user, password)
        {
            LastMessage = new RabbitMQMessage();
        }

        public void CosumeMessage(string queueName)
        {
            var consumer = new EventingBasicConsumer(Model);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body;
                var message = Encoding.UTF8.GetString(body);
                LastMessage.QueueOrigin = queueName;
                LastMessage.Content = message;
            };
            Model.BasicConsume(queue: queueName,
                               autoAck: true,
                               consumer: consumer);
        }
    }
}
