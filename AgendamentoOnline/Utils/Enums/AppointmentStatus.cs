using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AgendamentoOnline.Utils.Enums
{
    public enum AppointmentStatus
    {
        [Description("Requested")]
        REQUESTED = 1,
        [Description("Confirmed")]
        CONFIRMED = 2,
        [Description("Finished")]
        FINISHED = 3,
        [Description("Cancelled")]
        CANCELLED = 4,
        [Description("Client Missed")]
        PATMISSED = 5,
        [Description("Rescheduled")]
        RESCHEDULED = 6,
        [Description("Started")]
        STARTED = 7,
        [Description("Coach Missed")]
        DOCMISSED = 8
    }
}