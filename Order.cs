using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TestOrderHistory
{
    public static class Order
    {
        [FunctionName("GetOrderDetails")]
        public static async Task<IActionResult> Run(
       [HttpTrigger(AuthorizationLevel.Function, "get", Route = "orders/{orderNumber}")] HttpRequest req,
       string orderNumber,
       ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request for order number: {orderNumber}");

            // You can perform some processing here to fetch order details based on the order number.
            // For this example, we'll just create a sample JSON response.

            var orderDetails = new
            {
                OrderNumber = orderNumber,
                Product = "Sample Product",
                Quantity = 5,
                TotalAmount = 100.00
            };

            string responseJson = JsonConvert.SerializeObject(orderDetails);

            return new OkObjectResult(responseJson);
        }
    }
}
