using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AgendamentoOnline.Utils.Enums
{
    public enum UserType
    {
        [Description("Doctor")]
        DOCTOR = 1,
        [Description("Patient")]
        PATIENT = 2,
        [Description("Attendant")]
        ATTENDANT = 3,
        [Description("Master")]
        MASTER = 4
    }
}