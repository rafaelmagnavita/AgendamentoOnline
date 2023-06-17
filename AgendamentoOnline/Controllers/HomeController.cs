using AgendamentoOnline.Models;
using AgendamentoOnline.Utils;
using AgendamentoOnline.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AgendamentoOnline.Controllers
{
    public class HomeController : Controller
    {
        #region constants
        private ScheduleContext _context = new ScheduleContext();
        #endregion

        #region controllers
        public ActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                LogManager.LogErros("Erro em Login-Get: " + ex.Message);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            try
            {
                var userExists = _context.Users.Where(a => a.Login == user.Login).FirstOrDefault();
                if (userExists != null && user.Password.Equals(userExists?.Password))
                {
                    if (userExists != null)
                    {
                        object loggedUser = Convert.ChangeType(userExists, userExists.GetType());
                        Session["user"] = loggedUser;
                        var ticket = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(
                        1, userExists.Name, DateTime.Now, DateTime.Now.AddHours(12), true, userExists.Login.ToString()));
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticket);
                        Response.Cookies.Add(cookie);

                        return FindIndex();
                    }
                }
                ModelState.AddModelError("", "Login ou Senha Incorretos");
                return View();
            }
            catch (Exception ex)
            {
                LogManager.LogErros("Erro em Login-Post: " + ex.Message);
                throw;
            }
        }
        [Authorize]
        public ActionResult LogOut()
        {
            try
            {
                Session.Clear();
                Session.Abandon();
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "Home");
            }
            catch (Exception ex)
            {
                LogManager.LogErros("LogOut: " + ex.Message);
                throw;
            }

        }
        #endregion
        #region methods
        private ActionResult FindIndex()
        {
            try
            {
                User loggedUser = Session["user"] as User;
                switch (loggedUser.Type)
                {
                    case (int)UserType.ATTENDANT:
                        return RedirectToAction("IndexGeneral", "Appointments");
                    case (int)UserType.DOCTOR:
                        return RedirectToAction("IndexDoc", "Appointments", new { Id = loggedUser.Id });
                    case (int)UserType.MASTER:
                        return RedirectToAction("IndexGeneral", "Appointments");
                    case (int)UserType.PATIENT:
                        return RedirectToAction("IndexPat", "Appointments", new { Id = loggedUser.Id });
                    default:
                        return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                LogManager.LogErros("FindIndex: " + ex.Message);
                return RedirectToAction("Login", "Home");
            }


        }
        #endregion
    }
}