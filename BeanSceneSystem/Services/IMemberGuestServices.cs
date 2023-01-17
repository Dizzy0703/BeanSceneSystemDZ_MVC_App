using BeanSceneSystem.Models;

namespace BeanSceneSystem.Services
{
    public interface IMemberGuestServices
    {
        public IEnumerable<MemberGuest> GetAllMemberGuests();
        public void CreateMemberGuest(MemberGuest MG);
    }
}
