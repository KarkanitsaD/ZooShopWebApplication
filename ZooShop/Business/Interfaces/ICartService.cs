using System.Collections.Generic;
using ZooShop.Data.Entities;


namespace ZooShop.Business.Interfaces
{
    public interface ICartService
    {
        void Create(Cart cart);
        void Update(Cart cart);
        void Delete(int id);
        Cart Get(int id);        
        IEnumerable<Cart> GetAll();
    }
}
