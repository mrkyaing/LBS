using LMSystem.Models.ViewModels;

namespace LMSystem.Services
{
    public interface IMemberService
    {
        void Create(MemberViewModel memberViewModel);
        IEnumerable<MemberViewModel> GetAll();
        MemberViewModel GetByid(string id);
        void Update(MemberViewModel memberViewModel);
        bool Delete(string id);
        IEnumerable<MemberViewModel> GetMembers();

    }
}
