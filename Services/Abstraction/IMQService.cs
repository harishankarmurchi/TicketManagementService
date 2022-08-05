using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction
{
    public interface IMQService
    {
        void PublishMessage(object message, string queueName);
    }
}
