
namespace ZooShop.Data.Entities
{
    public class CartItem
    {
        public long Id { get; set; }
        public long CartId { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }

        //public virtual Cart Cart { get; set; }
        public virtual User User{ get; set; }
        public virtual Product Product { get; set; }
    }
}
