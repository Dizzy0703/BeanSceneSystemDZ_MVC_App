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
    public class MemberGuestController : Controller
    {
        BeanSceneSystemDbContext _context;
        IMemberGuestServices IMGServices;

        public MemberGuestController(BeanSceneSystemDbContext Context, IMemberGuestServices imgServices)
        {
            _context = Context;
            IMGServices = imgServices;
        }

        public IActionResult Index()
        {
            return View(IMGServices.GetAllMemberGuests());
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MemberGuest MG_obj)
        {
            IMGServices.CreateMemberGuest(MG_obj);
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
        public IActionResult Edit(MemberGuest MG_obj)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.MemberGuest.Update(MG_obj);
                    transaction.Commit();
                }
                catch
                {
                    _context.Remove(MG_obj);
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
            MemberGuest mg = _context.MemberGuest.FirstOrDefault(_mg => _mg.Id == id);
            if (mg != null)
            {
                _context.Remove(mg);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
