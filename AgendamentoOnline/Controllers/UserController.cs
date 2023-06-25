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
                        return View("NewAtt", user);
                    case (int)UserType.DOCTOR:
                        user = new Doctor();
                        return View("NewDoc", user);
                    case (int)UserType.PATIENT:
                        user = new Patient();
                        return View("NewPat", user);
                    default:
                        return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                LogManager.LogErros("Erro em Create-Users: " + ex.Message);
                throw;
            }
        }
        [Filters.NOTPATFILTER]
        [HttpPost]
        public ActionResult NewDoc(Doctor doc)
        {
            try
            {
                doc.Login = doc.Identification;
                doc.Password = Security.PasswordEncryption.EncryptPassword(doc.Identification.Substring(doc.Identification.Length - 3));
                if (ModelState.IsValid)
                {
                    _context.Users.Add(doc);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {
                LogManager.LogErros("Erro em NewDoc-Post-Users: " + ex.Message);
                throw;
            }
        }

        [Filters.NOTPATFILTER]
        [HttpPost]
        public ActionResult NewPat(Patient pat)
        {
            try
            {
                pat.Login = pat.Identification;
                pat.Password = Security.PasswordEncryption.EncryptPassword(pat.Identification.Substring(pat.Identification.Length - 3));
                if (ModelState.IsValid)
                {
                    _context.Users.Add(pat);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {
                LogManager.LogErros("Erro em NewPat-Post-Users: " + ex.Message);
                throw;
            }
        }

        [Filters.NOTPATFILTER]
        [HttpPost]
        public ActionResult NewAtt(Attendant att)
        {
            try
            {
                att.Login = att.Identification;
                att.Password = Security.PasswordEncryption.EncryptPassword(att.Identification.Substring(att.Identification.Length - 3));
                if (ModelState.IsValid)
                {
                    _context.Users.Add(att);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {
                LogManager.LogErros("Erro em NewAtt-Post-Users: " + ex.Message);
                throw;
            }
        }

        #endregion

        #region Methods
        #endregion


    }
}