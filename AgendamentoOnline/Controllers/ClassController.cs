using AgendamentoOnline.Models;
using AgendamentoOnline.Utils;
using AgendamentoOnline.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgendamentoOnline.Controllers
{
    [Filters.SessionExpiredCheck]
    [Authorize]
    public class ClassController : Controller
    {
        #region constants
        private ScheduleContext _context = new ScheduleContext();
        #endregion

        #region controllers
        // GET: Class
        public ActionResult Index(DateTime? day)
        {
            try
            {
                var classes = FindClassbyDay();
                return View(classes);
            }
            catch (Exception ex)
            {
                LogManager.LogErros("FindIndex: " + ex.Message);
                return RedirectToAction("Login", "Home");
            }

        }
        #endregion

        #region Voids

        private List<Class> FindClassbyDay(DateTime? day = null)
        {
            try
            {
                var classes = new List<Class>();
                if (day == null) { day = DateTime.Now; }
                User loggedUser = Session["user"] as User;
                List<int> permissions = new List<int>();
                switch (loggedUser.Type)
                {
                    case (int)UserType.ATTENDANT:
                    case (int)UserType.Coach:
                    case (int)UserType.MASTER:
                        permissions.Add((int)PlanType.All);
                        break;
                    case (int)UserType.Client:
                        List<Plan> Clientpermissions = _context.Plans.Where(a => a.isPaid && a.Start.Date >= DateTime.Now.Date
                        && a.Expiration <= DateTime.Now.Date && a.UserId == loggedUser.Id).ToList();
                        foreach (Plan permission in Clientpermissions)
                        {
                            permissions.Add(permission.planType);
                        }
                        break;
                    default:
                        return new List<Class>();
                }
                if (permissions.Contains((int)PlanType.All))
                {
                    classes = _context.Classes.Where(a => a.Time.Day == day.Value.Day).ToList();
                }
                else
                {
                    classes = _context.Classes.Where(a => a.Time.Day == day.Value.Day && permissions.Contains(a.PlanTypeId)).ToList();
                }
                return classes;
            }
            catch (Exception ex)
            {
                LogManager.LogErros("FindIndex: " + ex.Message);
                return new List<Class>();
            }
        }
        #endregion
    }
}