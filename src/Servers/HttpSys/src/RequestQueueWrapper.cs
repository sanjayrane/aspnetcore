using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.AspNetCore.HttpSys.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Microsoft.AspNetCore.Server.HttpSys
{
    public class RequestQueueWrapper
    {
        private readonly ILogger _logger;
        public string QueueName { get; }
        public string Uri { get; }
        internal RequestQueue Queue { get; }

        internal RequestQueueWrapper(string queueName, string uri, ILogger logger)
        {
            _logger = logger;
            QueueName = queueName;
            Uri = uri;
            Queue = new RequestQueue(null, queueName, RequestQueueMode.Receiver, _logger);
            Queue.UrlGroup = new UrlGroup(Queue, UrlPrefix.Create(uri));
        }
    }
}
