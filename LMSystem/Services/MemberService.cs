using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(MemberViewModel memberViewModel)
        {
            MemberEntity memberEntity = new MemberEntity()
            {
                id = Guid.NewGuid().ToString(),
                Name = memberViewModel.Name,
                Email = memberViewModel.Email,
                Phone = memberViewModel.Phone,
                Adress = memberViewModel.Adress,
                MembershipDate = memberViewModel.MembershipDate,
                MembershipType = memberViewModel.MembershipType,
                CreatedAt = DateTime.Now,
            };
            _unitOfWork.MemberRepository.Create(memberEntity);
            _unitOfWork.Commit();
        }

        public bool Delete(string id)
        {
            try
            {
                MemberEntity memberEntity = _unitOfWork.MemberRepository.Getby(w => w.id == id).SingleOrDefault();
                {
                    if (memberEntity != null)
                    {
                        memberEntity.IsInActive = true;
                        _unitOfWork.MemberRepository.Update(memberEntity);
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

        public IEnumerable<MemberViewModel> GetAll()
        {
            IEnumerable<MemberViewModel> Member = _unitOfWork.MemberRepository.GetAll().Where(w => !w.IsInActive).Select(s => new MemberViewModel
            {
                id = s.id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone ?? "N/A",
                Adress = s.Adress,
                MembershipDate = s.MembershipDate,
                MembershipType = s.MembershipType,
            }).AsEnumerable();
            return Member;
        }

        public MemberViewModel GetByid(string id)
        {

            return _unitOfWork.MemberRepository.Getby(w => w.id == id && !w.IsInActive).Select(s => new MemberViewModel
            {
                id = s.id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                Adress = s.Adress,
                MembershipDate = s.MembershipDate,
                MembershipType = s.MembershipType,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt,

            }).FirstOrDefault();
        }

        public IEnumerable<MemberViewModel> GetMembers()
        {
            return _unitOfWork.MemberRepository.GetMembers();
        }

        public void Update(MemberViewModel memberViewModel)
        {

            MemberEntity memberEntity = new MemberEntity()
            {
                id = memberViewModel.id,
                Name = memberViewModel.Name,
                Email = memberViewModel.Email,
                Phone = memberViewModel.Phone,
                Adress = memberViewModel.Adress,
                MembershipDate = memberViewModel.MembershipDate,
                MembershipType = memberViewModel.MembershipType,
                CreatedAt = memberViewModel.CreatedAt,
                UpdatedAt = DateTime.Now,
            };
            _unitOfWork.MemberRepository.Update(memberEntity);
            _unitOfWork.Commit();

        }
    }
}
