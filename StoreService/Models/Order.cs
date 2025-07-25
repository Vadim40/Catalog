namespace StoreService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public string TrackingNumber { get; set; }
        public int? LocationId { get; set; }

        public Location? Location { get; set; }

        public bool IsDelivery { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal PaymentAmount { get; set; }

        public decimal? PaymentAmountDelivery { get; set; }

        public List<Item> Items { get; set; }

    }
}
