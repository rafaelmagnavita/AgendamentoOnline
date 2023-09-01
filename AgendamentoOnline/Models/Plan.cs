using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendamentoOnline.Models
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }
        public int planType { get; set; }
        public DateTime Start { get; set; }
        public DateTime Expiration { get; set; }
        public bool isPaid { get; set; }
        public int UserId { get; set; }
    }
}