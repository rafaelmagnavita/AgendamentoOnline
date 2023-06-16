﻿using AgendamentoOnline.Models;
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
        private ScheduleContext _context = new ScheduleContext();
        private Actions actions = new Actions();


        public ActionResult Login()
        {
            return View();
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
                        Session["usuario"] = loggedUser;
                        var ticket = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(
                        1, userExists.Name, DateTime.Now, DateTime.Now.AddHours(12), true, userExists.Login.ToString()));
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticket);
                        Response.Cookies.Add(cookie);
                        return RedirectToAction("Index", "Home");
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
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}