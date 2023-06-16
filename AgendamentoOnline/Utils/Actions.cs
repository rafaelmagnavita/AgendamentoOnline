using AgendamentoOnline.Models;
using AgendamentoOnline.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendamentoOnline.Utils
{
    public class Actions
    {
        private ScheduleContext _context = new ScheduleContext();

        public object GetUserClass(User user)
        {
            try
            {
                //switch (user.Discriminator)
                //{
                //    case (int)UserType.PATIENT:
                //        return user as Patient;
                //    case (int)UserType.DOCTOR:
                //        return user as Doctor;
                //    case (int)UserType.MASTER:
                //        return user as AdminUser;
                //    case (int)UserType.ATTENDANT:
                //        return user as Attendant;
                //}
                return null;
            }
            catch (Exception ex)
            {
                LogManager.LogErros("GetUserClass" + ex.Message);
                return null;
            }

        }

    }
}