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
            return
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description
                ?? value.ToString();
        }

    }
}