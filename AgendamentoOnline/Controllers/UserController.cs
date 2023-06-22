using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgendamentoOnline.Models;
using AgendamentoOnline.Utils;
using AgendamentoOnline.Utils.Enums;

namespace AgendamentoOnline.Controllers
{
    [Filters.SessionExpiredCheck]
    [Authorize]
    public class UserController : Controller
    {
        #region Variables
        private ScheduleContext _context = new ScheduleContext();

        #endregion

        #region Controllers
        public ActionResult Index()
        {
            try
            {
                User user = Session["user"] as User;

                if (!(user is AdminUser))
                {
                    return RedirectToAction("ManagePatients", "User");
                }
                else
                {
                    return RedirectToAction("ManageUsers", "User");

                }
            }
            catch (Exception ex)
            {
                LogManager.LogErros("Erro em Index-Users: " + ex.Message);
                throw;
            }
        }
        [Filters.NOTPATFILTER]
        public ActionResult ManagePatients(List<User> listUser = null)
        {
            try
            {
                listUser = _context.Users.OrderBy(a => a.Name).ToList();
                listUser = listUser.Where(a => a.Type == (int)UserType.PATIENT).ToList();
                return View(listUser);
            }
            catch (Exception ex)
            {
                LogManager.LogErros("Erro em ManagePatients-Users: " + ex.Message);
                throw;
            }
        }
        [Filters.ADMFILTER]
        public ActionResult ManageUsers(List<User> listUser = null)
        {
            try
            {
                listUser = _context.Users.OrderBy(a => a.Name).ToList();
                return View(listUser);

            }
            catch (Exception ex)
            {
                LogManager.LogErros("Erro em ManageUsers-Users: " + ex.Message);
                throw;
            }
        }

        [Filters.NOTPATFILTER]
        [HttpGet]
        public ActionResult Create(int type)
        {
            try
            {
                object user = new object();
                switch (type)
                {
                    case (int)UserType.ATTENDANT:
                        user = new Attendant();
                        break;
                    case (int)UserType.DOCTOR:
                        user = new Doctor();
                        break;
                    case (int)UserType.PATIENT:
                        user = new Patient();
                        break;
                    default:
                        return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (Exception ex)
            {
                LogManager.LogErros("Erro em Create-Users: " + ex.Message);
                throw;
            }
        }
        [Filters.NOTPATFILTER]
        [HttpPost]
        public ActionResult Create(object user)
        {
            try
            {
                int typeUser = ((User)user).Type;
                switch (typeUser)
                {
                    case (int)UserType.ATTENDANT:
                        Attendant att = user as Attendant;
                        if (ModelState.IsValid)
                        {
                            _context.Users.Add(att);
                            _context.SaveChanges();
                        }
                        break;
                    case (int)UserType.DOCTOR:
                        Doctor doc = user as Doctor;
                        if (ModelState.IsValid)
                        {
                            _context.Users.Add(doc);
                            _context.SaveChanges();
                        }
                        break;
                    case (int)UserType.PATIENT:
                        Patient pat = user as Patient;
                        if (ModelState.IsValid)
                        {
                            _context.Users.Add(pat);
                            _context.SaveChanges();
                        }
                        break;
                    default:
                        return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                LogManager.LogErros("Erro em Create-Post-Users: " + ex.Message);
                throw;
            }
        }

        #endregion

        #region Methods
        #endregion


    }
}