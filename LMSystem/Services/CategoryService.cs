using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.UnitOfWorks;

namespace LMSystem.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(CategoryViewModel categoryViewModel)
        {
            CategoryEntity categoryEntity = new CategoryEntity()
            {
                id = Guid.NewGuid().ToString(),
                Name = categoryViewModel.Name,
                Description = categoryViewModel.Description,
                CreatedAt = DateTime.Now,
            };
            _unitOfWork.CategoryRepository.Create(categoryEntity);
            _unitOfWork.Commit();
        }

        public bool Delete(string id)
        {
            try
            {
                CategoryEntity categoryEntity = _unitOfWork.CategoryRepository.Getby(w => w.id == id).SingleOrDefault();
                {
                    if (categoryEntity != null)
                    {
                        categoryEntity.IsInActive = true;
                        _unitOfWork.CategoryRepository.Update(categoryEntity);
                        _unitOfWork.Commit();
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            IEnumerable<CategoryViewModel> Category = _unitOfWork.CategoryRepository.GetAll().Where(w => !w.IsInActive).Select(s => new CategoryViewModel
            {
                id = s.id,
                Name = s.Name,
                Description = s.Description,
            }).AsEnumerable();
            return Category;
        }

        public CategoryViewModel GetById(string id)
        {
            return _unitOfWork.CategoryRepository.Getby(w => w.id == id && !w.IsInActive).Select(s => new CategoryViewModel
            {
                id = s.id,
                Name = s.Name,
                Description = s.Description,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt

            }).FirstOrDefault();
        }

        public IEnumerable<CategoryViewModel> GetCategories()
        {
            return _unitOfWork.CategoryRepository.GetCategories();
        }

        public void Update(CategoryViewModel categoryViewModel)
        {
            CategoryEntity categoryEntity = new CategoryEntity()
            {
                id = categoryViewModel.id,
                Name = categoryViewModel.Name,
                Description = categoryViewModel.Description,
                CreatedAt = categoryViewModel.CreatedAt,
                UpdatedAt = DateTime.Now,
            };
            _unitOfWork.CategoryRepository.Update(categoryEntity);
            _unitOfWork.Commit();
        }
    }
}
