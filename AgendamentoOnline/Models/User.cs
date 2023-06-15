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

        [Required(ErrorMessage = "An Album Title is required")]

        public string Login { get; set; }

        [Required(ErrorMessage = "An Album Title is required")]

        public string Password { get; set; }

        [Required(ErrorMessage = "An Album Title is required")]

        public abstract int Type { get; set; }

    }
}