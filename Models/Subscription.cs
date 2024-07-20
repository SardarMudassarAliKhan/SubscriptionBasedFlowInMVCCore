namespace SubscriptionBasedFlowInMVCCore.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string SubscriptionType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<SubscriptionFeature> Features { get; set; }
    }
}
