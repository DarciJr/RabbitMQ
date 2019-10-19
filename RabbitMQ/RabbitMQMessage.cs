using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ
{
    public class RabbitMQMessage
    {
        public string QueueOrigin { get; set; }
        public string Content { get; set; }
    }
}
