﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using AgendamentoOnline.Utils.Enums;

namespace AgendamentoOnline.Models
{
    public class Patient : User
    {
        [Required(ErrorMessage = "An Health Insurance is required")]

        public int HealthInsurance { get; set; }
        [Required(ErrorMessage = "An Mother Name is required")]

        public string MotherName { get; set; }
        [Required(ErrorMessage = "An Father Name is required")]

        public string FatherName { get; set; }
        [Required(ErrorMessage = "An Birth Date is required")]
        public DateTime Birth { get; set; }

        [NotMapped]
        public override int Type { get { return (int)UserType.PATIENT; } }
    }
}