using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using BeanSceneSystem.Data;
using BeanSceneSystem.Models;
using BeanSceneSystem.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Transactions;

namespace BeanSceneSystem.Controllers
{
    public class EventController : Controller
    {
        BeanSceneSystemDbContext _context;
        IEventServices IEServices;

        public EventController(BeanSceneSystemDbContext Context, IEventServices ieServices)
        {
            _context = Context;
            IEServices = ieServices;
        }

        public IActionResult Index()
        {
            return View(IEServices.GetAllEvents());
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event E_obj)
        {
            IEServices.CreateEvent(E_obj);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete(int? id)
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Event E_obj)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Event.Update(E_obj);
                    transaction.Commit();
                }
                catch
                {
                    _context.Remove(E_obj);
                    transaction.Rollback();
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            Event e = _context.Event.FirstOrDefault(_e => _e.Id == id);
            if (e != null)
            {
                _context.Remove(e);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
