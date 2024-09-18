using LMSystem.DAO;
using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.Repositories.Common;

namespace LMSystem.Repositories.Domain
{
    public class MemberRepository: BaseRepository<MemberEntity>, IMemberRepository
    {
        private readonly LMSystemDbContext _dbContext;

        public MemberRepository(LMSystemDbContext dbContext):base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<MemberViewModel> GetMembers()
        {
            return _dbContext.Members.Where(w => !w.IsInActive).Select(s => new MemberViewModel
            {
                id=s.id,
                Name=s.Name,
            }).ToList();
        }
    }
}
