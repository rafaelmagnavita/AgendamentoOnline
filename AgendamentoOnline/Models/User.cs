using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendamentoOnline.Models
{
    public abstract class User
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

        [Required(ErrorMessage = "An Type is required")]

        public abstract int Type { get; set; }

    }
}