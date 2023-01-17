using BeanSceneSystem.Models;

namespace BeanSceneSystem.Services
{
    public interface IEventServices
    {
        public IEnumerable<Event> GetAllEvents();
        public void CreateEvent(Event E);
    }
}
