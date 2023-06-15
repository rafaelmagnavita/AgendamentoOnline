using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendamentoOnline.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "An Album Title is required")]
        [DisplayName("Doctor")]

        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public int Status { get; set; }
        public int ReviewUser { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }

        [Required(ErrorMessage = "An Album Title is required")]
        public DateTime ScheduleTime { get; set; }

        [Required(ErrorMessage = "An Album Title is required")]

        public string Motive { get; set; }

    }
}