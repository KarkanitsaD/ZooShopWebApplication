using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Data
{
    public class UnitOfWork
    {
        private readonly ZooShopContext _context = new();

        private IRepository<UserEntity> _userRepository;
        private IRepository<CategoryEntity> _categoryRepository;
        private IRepository<OrderEntity> _orderRepository;
        private IRepository<OrderStatusEntity> _orderStatusRepository;
        private IRepository<ProductEntity> _productRepository;
        private IRepository<CartEntity> _cartRepository;


        public IRepository<UserEntity> Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        public IRepository<CategoryEntity> Categories
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_context);
                return _categoryRepository;
            }
        }

        public IRepository<OrderEntity> Orders
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_context);
                return _orderRepository;
            }
        }
        
        public IRepository<OrderStatusEntity> OrderStatuses
        {
            get
            {
                if (_orderStatusRepository == null)
                    _orderStatusRepository = new OrderStatusRepository(_context);
                return _orderStatusRepository;
            }
        }


        public IRepository<ProductEntity> Products
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_context);
                return _productRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
