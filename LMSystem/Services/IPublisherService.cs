using LMSystem.Models.ViewModels;

namespace LMSystem.Services
{
    public interface IPublisherService
    {
        void Create(PublisherViewModel publisherViewModel);
        IEnumerable<PublisherViewModel> GetAll();
        PublisherViewModel GetById(string id);
        void Update(PublisherViewModel publisherViewModel);
        bool Delete(string id);
        IEnumerable<PublisherViewModel> GetPublishers();
    }
}
