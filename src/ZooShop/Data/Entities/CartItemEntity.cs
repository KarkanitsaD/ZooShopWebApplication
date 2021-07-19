
namespace ZooShop.Data.Entities
{
    public class CartItemEntity
    {
        public long Id { get; set; }
        public long CartId { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }

        //public virtual Cart Cart { get; set; }
        public virtual UserEntity User{ get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
