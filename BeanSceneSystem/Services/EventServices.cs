using BeanSceneSystem.Models;
using BeanSceneSystem.Data;

namespace BeanSceneSystem.Services
{
    public class EventServices : IEventServices
    {
        BeanSceneSystemDbContext _context;
        public EventServices(BeanSceneSystemDbContext db)
        {
            _context = db;
        }
        public IEnumerable<Event> GetAllEvents()
        {
            return _context.Event.Select(e => e).ToList();
        }
        public void CreateEvent(Event E)
        {
            _context.Event.Add(E);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}
