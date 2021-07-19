using System.Collections.Generic;
using ZooShop.Data.Entities;


namespace ZooShop.Business.Contracts
{
    public interface ICartService
    {
        void Create(CartEntity cart);
        void Update(CartEntity cart);
        void Delete(int id);
        CartEntity Get(int id);        
        IEnumerable<CartEntity> GetAll();
    }
}
