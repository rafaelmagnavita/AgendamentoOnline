using AgendamentoOnline.Models;
using AgendamentoOnline.Utils.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AgendamentoOnline.Utils
{
    public static class Actions
    {
        private static ScheduleContext _context = new ScheduleContext();

        public static string GetDescription(Enum value)
        {
            try
            {
                return
                 value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description
                ?? value.ToString();
            }
            catch (Exception ex)
            {
                LogManager.LogErros("GetDescription" + ex);
                throw;
            }

        }

        public static int GetAge(DateTime birth)
        {
            try
            {
                bool notAged = false;
                if (birth.Month > DateTime.Now.Month)
                {
                    notAged = true;
                }
                else if (birth.Month == DateTime.Now.Month)
                {
                    if (birth.Day > DateTime.Now.Day)
                    {
                        notAged = true;
                    }
                }
                if (notAged)
                    return DateTime.Now.Year - birth.Year - 1;
                else
                    return DateTime.Now.Year - birth.Year;
            }
            catch (Exception ex)
            {
                LogManager.LogErros("GetAge" + ex);
                throw;
            }

        }

    }
}