﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using AgendamentoOnline.Utils.Enums;
using System.Data.Entity.Infrastructure;

namespace AgendamentoOnline.Models
{
    public class AdminUser : User
    {
        [NotMapped]
        public override int Type { get { return (int)UserType.MASTER; } }
    }
    public class Attendant : User
    {
        [NotMapped]
        public override int Type { get { return (int)UserType.ATTENDANT; } }
    }
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "An Name is required")]

        public string Name { get; set; }


        [Required(ErrorMessage = "An Identification is required")]

        public string Identification { get; set; }

        [Required(ErrorMessage = "An Login is required")]

        public string Login { get; set; }

        [Required(ErrorMessage = "An Password is required")]

        public string Password { get; set; }

        [NotMapped]
        public virtual int Type { get; set; }

    }
}