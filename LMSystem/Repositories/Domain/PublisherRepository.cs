using LMSystem.DAO;
using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.Repositories.Common;

namespace LMSystem.Repositories.Domain
{
    public class PublisherRepository: BaseRepository<PublisherEntity>, IPublisherRepository
    {
        private readonly LMSystemDbContext _dbContext;

        public PublisherRepository(LMSystemDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PublisherViewModel> GetPublishers()
        {
            return _dbContext.Publishers.Where(w => !w.IsInActive).Select(s => new PublisherViewModel
            {
                id = s.id,
                Name = s.Name,
            }).ToList();
        }
    }
}
