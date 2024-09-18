using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.UnitOfWorks;

namespace LMSystem.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublisherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(PublisherViewModel publisherViewModel)
        {
            PublisherEntity publisherEntity = new PublisherEntity()
            {
                id = Guid.NewGuid().ToString(),
                Name = publisherViewModel.Name,
                Adress = publisherViewModel.Adress,
                ContactInfo = publisherViewModel.ContactInfo,
                CreatedAt = DateTime.Now,
            };
            _unitOfWork.PublisherRepository.Create(publisherEntity);
            _unitOfWork.Commit();
        }

        public bool Delete(string id)
        {
            try
            {
                PublisherEntity publisherEntity = _unitOfWork.PublisherRepository.Getby(w => w.id == id).SingleOrDefault();
                {
                    if (publisherEntity != null)
                    {
                        publisherEntity.IsInActive = true;
                        _unitOfWork.PublisherRepository.Update(publisherEntity);
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
        public IEnumerable<PublisherViewModel> GetAll()
        {
            IEnumerable<PublisherViewModel> publisher = _unitOfWork.PublisherRepository.GetAll().Where(w => !w.IsInActive).Select(s => new PublisherViewModel
            {
                id = s.id,
                Name = s.Name,
                Adress = s.Adress,
                ContactInfo = s.ContactInfo,
            }).AsEnumerable();
            return publisher;
        }

        public PublisherViewModel GetById(string id)
        {
            return _unitOfWork.PublisherRepository.Getby(w => w.id == id && !w.IsInActive).Select(s => new PublisherViewModel
            {
                id = s.id,
                Name = s.Name,
                Adress = s.Adress,
                ContactInfo = s.ContactInfo,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt

            }).FirstOrDefault();
        }

        public IEnumerable<PublisherViewModel> GetPublishers()
        {
            return _unitOfWork.PublisherRepository.GetPublishers();
        }

        public void Update(PublisherViewModel publisherViewModel)
        {
            PublisherEntity publisherEntity = new PublisherEntity()
            {
                id = publisherViewModel.id,
                Name = publisherViewModel.Name,
                Adress = publisherViewModel.Adress,
                ContactInfo = publisherViewModel.ContactInfo,
                CreatedAt = publisherViewModel.CreatedAt,
                UpdatedAt = DateTime.Now,
            };
            _unitOfWork.PublisherRepository.Update(publisherEntity);
            _unitOfWork.Commit();

        }
    }
}
