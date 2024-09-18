using LMSystem.DAO;
using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(AuthorViewModel authorViewModel)
        {
            AuthorEntity authorEntity = new AuthorEntity()
            {
                id = Guid.NewGuid().ToString(),
                Name = authorViewModel.Name,
                Biography = authorViewModel.Biography,
                Phone = authorViewModel.Phone,
                Email = authorViewModel.Email,
                Adress = authorViewModel.Adress,
                CreatedAt = DateTime.Now,
            };
            _unitOfWork.AuthorRepository.Create(authorEntity);
            _unitOfWork.Commit();
        }

        public bool Delete(string id)
        {
            try
            {
                AuthorEntity authorEntity = _unitOfWork.AuthorRepository.Getby(w => w.id == id).SingleOrDefault();

                if (authorEntity != null)
                {
                    authorEntity.IsInActive = true;
                    _unitOfWork.AuthorRepository.Update(authorEntity);
                    _unitOfWork.Commit();
                }

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<AuthorViewModel> GetAll()
        {
            IEnumerable<AuthorViewModel> Author = _unitOfWork.AuthorRepository.GetAll().Where(w => !w.IsInActive).Select(s => new AuthorViewModel
            {
                id = s.id,
                Name = s.Name,
                Biography = s.Biography,
                Phone = s.Phone,
                Email = s.Email,
                Adress = s.Adress,
            }).AsEnumerable();
            return Author;
        }

        public IEnumerable<AuthorViewModel> GetAuthors()
        {
            return _unitOfWork.AuthorRepository.GetAuthors();
        }

        public AuthorViewModel GetById(string id)
        {
            return _unitOfWork.AuthorRepository.Getby(w => w.id == id && !w.IsInActive).Select(s => new AuthorViewModel
            {
                id = s.id,
                Name = s.Name,
                Biography = s.Biography,
                Phone = s.Phone,
                Email = s.Email,
                Adress = s.Adress,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt

            }).FirstOrDefault();
        }

        public void Update(AuthorViewModel authorViewModel)
        {

            AuthorEntity authorEntity = new AuthorEntity()
            {
                id = authorViewModel.id,
                Name = authorViewModel.Name,
                Biography = authorViewModel.Biography,
                Phone = authorViewModel.Phone,
                Email = authorViewModel.Email,
                Adress = authorViewModel.Adress,
                CreatedAt = authorViewModel.CreatedAt,
                UpdatedAt = DateTime.Now,
            };
            _unitOfWork.AuthorRepository.Update(authorEntity);
            _unitOfWork.Commit();
        }
    }
}
