using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.Repositories.Common;

namespace LMSystem.Repositories.Domain
{
    public interface IMemberRepository: IBaseRepository<MemberEntity>
    {
        IEnumerable<MemberViewModel> GetMembers();
    }
}
