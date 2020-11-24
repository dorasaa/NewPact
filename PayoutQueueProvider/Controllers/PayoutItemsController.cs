using PayoutQueueProvider.Models;
using System.Web.Http;
using System.Web.Http.Results;
namespace PayoutQueueProvider.Controllers
{
    public class PayoutItemsController : ApiController
    {
        // GET: PayoutItems
       
        public JsonResult<PayoutItem> Get()
        {
            var item = new PayoutItem()
            {
                PayoutItemId = 84984,
                PayoutUBR = "JHKNKJ-JHHDJKH-NJKJHH-KJKJKJK",
                PayoutQueueName = "TUNES",
                PayoutRouteId = 2
            };


            return Json<PayoutItem>(item, new Newtonsoft.Json.JsonSerializerSettings() { });
        }
    }
}