using System.Collections.Generic;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Data;
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
            _unitOfWork.GetRepository<CategoryEntity>().Create(category);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<CategoryEntity>().Delete(id);
            _unitOfWork.Save();
        }

        public CategoryEntity Get(int id)
        {
            return _unitOfWork.GetRepository<CategoryEntity>().Get(id);
        }

        public IEnumerable<CategoryEntity> GetAll()
        {
            return _unitOfWork.GetRepository<CategoryEntity>().GetAll();
        }

        public void Update(CategoryEntity category)
        {
            _unitOfWork.GetRepository<CategoryEntity>().Update(category);
            _unitOfWork.Save();
        }
    }
}
