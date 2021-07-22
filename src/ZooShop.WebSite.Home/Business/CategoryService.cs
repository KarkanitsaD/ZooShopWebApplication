using System.Collections.Generic;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Business
{
    public class CategoryService : ICategoryService
    {
        private readonly UnitOfWork _unitOfWork;


        public CategoryService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(CategoryEntity category)
        {
            _unitOfWork.Categories.Create(category);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Categories.Delete(id);
            _unitOfWork.Save();
        }

        public CategoryEntity Get(int id)
        {
            return _unitOfWork.Categories.Get(id);
        }

        public IEnumerable<CategoryEntity> GetAll()
        {
            return _unitOfWork.Categories.GetAll();
        }

        public void Update(CategoryEntity category)
        {
            _unitOfWork.Categories.Update(category);
            _unitOfWork.Save();
        }
    }
}
