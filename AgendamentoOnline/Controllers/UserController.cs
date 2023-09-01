using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgendamentoOnline.Models;
using AgendamentoOnline.Utils;
using AgendamentoOnline.Utils.Enums;
//using AutoMapper;

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
                    return RedirectToAction("ManageClients", "User");
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
        public ActionResult ManageClients()
        {
            try
            {
                var listUser = _context.Users.OrderBy(a => a.Name).ToList();
                listUser = listUser.Where(a => a.Type == (int)UserType.Client).ToList();
                return View();
            }
            catch (Exception ex)
            {
                LogManager.LogErros("Erro em ManageClients-Users: " + ex.Message);
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
                    case (int)UserType.Coach:
                        user = new Coach();
                        return View("NewCoach", user);
                    case (int)UserType.Client:
                        user = new Client();
                        return View("NewClient", user);
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
        public ActionResult NewCoach(Coach doc)
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
                LogManager.LogErros("Erro em NewCoach-Post-Users: " + ex.Message);
                throw;
            }
        }

        [Filters.NOTPATFILTER]
        [HttpPost]
        public ActionResult NewClient(Client pat)
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
                LogManager.LogErros("Erro em NewClient-Post-Users: " + ex.Message);
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