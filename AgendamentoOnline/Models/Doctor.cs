using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using AgendamentoOnline.Utils.Enums;

namespace AgendamentoOnline.Models
{
    public class Doctor : User
    {
        [Required(ErrorMessage = "An Album Title is required")]
        public int Specialization { get; set; }
    }
}