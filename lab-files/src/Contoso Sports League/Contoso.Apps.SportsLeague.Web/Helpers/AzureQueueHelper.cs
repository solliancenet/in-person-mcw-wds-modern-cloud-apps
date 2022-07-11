using Contoso.Apps.SportsLeague.Data.Models;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Apps.SportsLeague.Web.Helpers
{
    public class AzureQueueHelper
    {
        IQueueClient queueClient;

        public AzureQueueHelper(IConfiguration config)
        {
            // Retrieve the Service Bus Queue from a connection string in the web.config file.
            queueClient = new QueueClient(new ServiceBusConnectionStringBuilder(config["ConnectionStrings:ReceiptQueue"]));
        }

        /// <summary>
        /// Create a message in our Azure Service Bus Queue, which will be sent to our Worker Role in order
        /// to generate a Pdf file that gets saved to blob storage, and can be emailed to the client.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task QueueReceiptRequest(Order order)
        {
            String jsonOrder = JsonConvert.SerializeObject(order);

            // Create a brokered message and add it to the queue.
            var message = new Message(Encoding.UTF8.GetBytes(jsonOrder));
            
            // Async enqueue the message.
            await queueClient.SendAsync(message);
        }
    }
}