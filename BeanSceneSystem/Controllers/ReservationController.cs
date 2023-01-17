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
    public class ReservationController : Controller
    {
        BeanSceneSystemDbContext _context;
        IReservationServices IRServices;

        public ReservationController(BeanSceneSystemDbContext db, IReservationServices irServices)
        {
            _context = db;
            IRServices = irServices;
        }
        public IActionResult Index()
        {
            return View(IRServices.GetAllReservations());
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reservation R_obj)
        {
            IRServices.CreateReservation(R_obj);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Reservation R_obj)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Reservation.Update(R_obj);
                    transaction.Commit();
                }
                catch
                {
                    _context.Remove(R_obj);
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
            Reservation r = _context.Reservation.FirstOrDefault(_r => _r.Id == id);
            if (r != null)
            {
                _context.Remove(r);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
