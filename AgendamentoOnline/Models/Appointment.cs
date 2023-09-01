using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgendamentoOnline.Models
{
    public class Appointment
    {

        #region constants
        private ScheduleContext _context = new ScheduleContext();
        #endregion

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "An Coach Name is required")]
        [DisplayName("Coach")]

        public int CoachID { get; set; }

        public int ClientID { get; set; }

        public bool DocConfirm { get; set; }
        public bool PatConfirm { get; set; }


        [NotMapped]
        public Client Client { get { return _context.Clients.Find(ClientID); } }
        [NotMapped]
        public Coach Coach { get { return _context.Coachs.Find(CoachID); } }
        public int Status { get; set; }

        [NotMapped]
        public string StatusName { get { return Utils.Actions.GetDescription((Utils.Enums.AppointmentStatus)Status); } }
        public int ReviewUser { get; set; }
        [NotMapped]
        public string ReviewUserName { get { return _context.Users.Find(ReviewUser).Name; } }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }

        [Required(ErrorMessage = "Any Schedule Time is required")]
        public DateTime ScheduleTime { get; set; }

        [Required(ErrorMessage = "Any Motive is required")]

        public string Motive { get; set; }

    }
}