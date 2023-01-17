using BeanSceneSystem.Models;
using BeanSceneSystem.Data;

namespace BeanSceneSystem.Services
{
    public class MemberGuestServices : IMemberGuestServices
    {
        BeanSceneSystemDbContext _context;
        public MemberGuestServices(BeanSceneSystemDbContext db)
        {
            _context = db;
        }
        public IEnumerable<MemberGuest> GetAllMemberGuests()
        {
            return _context.MemberGuest.Select(m => m).ToList();
        }
        public void CreateMemberGuest(MemberGuest MG)
        {
            _context.MemberGuest.Add(MG);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}
