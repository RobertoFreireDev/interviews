using System;

namespace ApiAppShop.Domain.Events
{
    public class AppPurchasedStatusConfirmationEvent
    {
        public string Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string AppId { get; set; }
        public string UserId { get; set; }
        public bool StatusConfirmation { get; set; }
    }
}
