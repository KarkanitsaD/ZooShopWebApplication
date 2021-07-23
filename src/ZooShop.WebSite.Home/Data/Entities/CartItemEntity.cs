
namespace ZooShop.Website.Home.Data.Entities
{
    public class CartItemEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        //public virtual Cart Cart { get; set; }
        public virtual UserEntity User{ get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
