using RabbitMQ.Client;
using System;

namespace RabbitMQ
{
    public class RabbitMQ : IDisposable
    {
        protected ConnectionFactory ConnectionFactory;
        protected IConnection Connection;
        protected IModel Model;

        public RabbitMQ(string host, string user, string password)
        {
            ConnectionFactory = new ConnectionFactory()
            {
                HostName = host,
                UserName = user,
                Password = password
            };

            Connection = ConnectionFactory.CreateConnection();
            Model = Connection.CreateModel();
        }

        public void Dispose()
        {
            Model.Dispose();
            Connection.Dispose();
        }

        public QueueDeclareOk DeclareQueue(string queueName)
        {
            return Model.QueueDeclare(queue: queueName,
                               durable: false,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);
        }
    }
}
