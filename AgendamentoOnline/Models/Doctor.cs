using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendamentoOnline.Models
{
    public class DoctorUser : Doctor
    {
        public override int Type { set => throw new NotImplementedException(); }
    }
    public abstract class Doctor : User
    {


        [Required(ErrorMessage = "An Album Title is required")]
        public string Identification { get; set; }

        [Required(ErrorMessage = "An Album Title is required")]
        public int Specialization { get; set; }

        public override int Type { get => Type = 1; }

    }
}