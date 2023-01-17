using BeanSceneSystem.Models;

namespace BeanSceneSystem.Services
{
    public interface IReservationServices
    {
        public IEnumerable<Reservation> GetAllReservations();
        public void CreateReservation(Reservation R);
    }
}
