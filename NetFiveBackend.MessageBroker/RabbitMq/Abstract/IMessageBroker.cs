using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.MessageBroker.RabbitMq.Abstract
{
    public interface IMessageBroker
    {
        Task Publish(string exchangeName, object message);
    }

}
