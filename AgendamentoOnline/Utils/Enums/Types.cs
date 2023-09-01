using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AgendamentoOnline.Utils.Enums
{
    public enum UserType
    {
        [Description("Coach")]
        Coach = 1,
        [Description("Client")]
        Client = 2,
        [Description("Attendant")]
        ATTENDANT = 3,
        [Description("Master")]
        MASTER = 4
    }

    public enum PlanType
    {
        [Description("Health")]
        Health = 1,
        [Description("Strong")]
        Strong = 2,
        [Description("Cardio")]
        Cardio = 3,
        [Description("All")]
        All = 4
    }
}