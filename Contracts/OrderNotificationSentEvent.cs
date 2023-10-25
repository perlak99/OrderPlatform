using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class OrderNotificationSentEvent
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
