using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayoutQueueProvider.Models
{
    public class PayoutItem
    {
        public int PayoutItemId { get; set; }
        public string PayoutUBR { get; set; }
        public string PayoutQueueName { get; set; }
        public int PayoutRouteId { get; set; }
    }
}