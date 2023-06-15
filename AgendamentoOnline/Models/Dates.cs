using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendamentoOnline.Models
{
    public class Dates
    {
        [Key]
        public int Id { get; set; }
        public bool isAvaible { get; set; }
        public DateTime Date { get; set; }

    }
}