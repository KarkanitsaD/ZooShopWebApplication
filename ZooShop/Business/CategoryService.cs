using System.Collections.Generic;
using ZooShop.Business.Interfaces;
using ZooShop.Data.Entities;
using ZooShop.Data.UnitOfWork;

namespace ZooShop.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private UnitOfWork _unitOfWork;


        public CategoryService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Category category)
        {
            _unitOfWork.Categories.Create(category);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Categories.Delete(id);
            _unitOfWork.Save();
        }

        public Category Get(int id)
        {
            return _unitOfWork.Categories.Get(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork.Categories.GetAll();
        }

        public void Update(Category category)
        {
            _unitOfWork.Categories.Update(category);
            _unitOfWork.Save();
        }
    }
}
