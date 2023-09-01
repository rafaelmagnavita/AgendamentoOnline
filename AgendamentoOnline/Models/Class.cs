using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendamentoOnline.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public string LinkLive { get; set; }
        public string LinkRecorded { get; set; }
        public DateTime Time { get; set; }
        public int CoachId { get; set; }
        public int PlanTypeId { get; set; }

    }
}