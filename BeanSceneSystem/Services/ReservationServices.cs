using BeanSceneSystem.Models;
using BeanSceneSystem.Data;

namespace BeanSceneSystem.Services
{
    public class ReservationServices : IReservationServices
    {
        BeanSceneSystemDbContext _context;
        public ReservationServices(BeanSceneSystemDbContext db)
        {
            _context = db;
        }
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _context.Reservation.Select(r => r).ToList();
        }
        public void CreateReservation(Reservation R)
        {
            _context.Reservation.Add(R);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}
