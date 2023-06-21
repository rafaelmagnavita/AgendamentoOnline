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
        public ActionResult Index(List<User> listUser = null)
        {
            try
            {
                if (listUser == null)
                {
                    listUser = new List<User>();
                    User user = Session["user"] as User;
                    listUser = _context.Users.OrderBy(a => a.Name).ToList();

                    if (!(user is AdminUser))
                    {
                        listUser = listUser.Where(a => a.Type == (int)UserType.PATIENT).ToList();

                    }
                }
                foreach (User user in listUser)
                {
                }
                return View(listUser);
            }
            catch (Exception ex)
            {
                LogManager.LogErros("Erro em Login-Get: " + ex.Message);
                throw;
            }
        }

        public ActionResult IndexPat()
        {
            try
            {

            }
            catch (Exception ex)
            {
                LogManager.LogErros("Erro em Login-Get: " + ex.Message);
                throw;
            }
            return View();
        }

        public ActionResult IndexAdm()
        {
            try
            {

            }
            catch (Exception ex)
            {
                LogManager.LogErros("Erro em Login-Get: " + ex.Message);
                throw;
            }
            return View();
        }

        #endregion

        #region Methods
        #endregion


    }
}