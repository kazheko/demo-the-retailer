namespace Demo.TheRetailer.WebApp.Models
{
    public class Basket
    {
        public Basket()
        {
            BasketItems = new List<BasketItem>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
