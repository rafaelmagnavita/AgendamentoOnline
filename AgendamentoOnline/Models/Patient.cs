using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendamentoOnline.Models
{
    public abstract class Patient : User
    {
        [Required(ErrorMessage = "An Album Title is required")]

        public string Name { get; set; }

        [Required(ErrorMessage = "An Album Title is required")]
        public string Identification { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        public int HealthInsurance { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        public string MotherName { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        public DateTime Birth { get; set; }
        public override int Type { get => Type = 2; }

    }
}