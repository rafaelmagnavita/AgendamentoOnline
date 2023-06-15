using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendamentoOnline.Models
{
    public class PatientUser : Patient
    {
        public override int Type { set => throw new NotImplementedException(); }
    }
    public abstract class Patient : User
    {

        [Required(ErrorMessage = "An Health Insurance is required")]

        public int HealthInsurance { get; set; }
        [Required(ErrorMessage = "An Mother Name is required")]

        public string MotherName { get; set; }
        [Required(ErrorMessage = "An Father Name is required")]

        public string FatherName { get; set; }
        [Required(ErrorMessage = "An Birth Date is required")]
        public DateTime Birth { get; set; }
        public override int Type { get => Type = 2; }

    }
}