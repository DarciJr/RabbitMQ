using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ
{
    public class Publisher : RabbitMQ
    {
        public Publisher(string host, string user, string password) :  base(host, user, password)
        {
        }

        public void PublishMessageAsUTF8(string queueName, string message)
        {
            DeclareQueue(queueName);

            var body = Encoding.UTF8.GetBytes(message);

            Model.BasicPublish(exchange: "",
                               routingKey: queueName,
                               basicProperties: null,
                               body: body);
        }
    }
}
