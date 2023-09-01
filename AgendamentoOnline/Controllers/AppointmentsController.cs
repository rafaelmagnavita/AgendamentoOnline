using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgendamentoOnline;
using AgendamentoOnline.Models;
using AgendamentoOnline.Utils;
using AgendamentoOnline.Utils.Enums;

namespace AgendamentoOnline.Controllers
{
    [Filters.SessionExpiredCheck]
    [Authorize]
    public class AppointmentsController : Controller
    {
        private ScheduleContext db = new ScheduleContext();

        // GET: Appointments

        public ActionResult Index()
        {
            try
            {
                User userLogged = Session["user"] as User;
                if (userLogged is Coach)
                {
                    return RedirectToAction("IndexDoc", "Appointments", new { Id = userLogged.Id });
                }
                else if (userLogged is Client)
                {
                    return RedirectToAction("IndexPat", "Appointments", new { Id = userLogged.Id });
                }
                else
                {
                    return RedirectToAction("IndexGeneral", "Appointments", null);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogErros("Index: " + ex.Message);
                return RedirectToAction("Login", "Home");
            }

        }
        public ActionResult IndexDoc(int? Id)
        {
            try
            {
                List<Appointment> appointments = db.Apppointments.ToList();
                return View(appointments.Where(a => a.CoachID.Equals(Id)).OrderBy(a => a.ScheduleTime).ToList());
            }
            catch (Exception ex)
            {
                LogManager.LogErros("IndexDoc: " + ex.Message);
                return RedirectToAction("Login", "Home");
            }

        }

        public ActionResult IndexGeneral()
        {
            try
            {
                List<Appointment> appointments = db.Apppointments.OrderBy(a => a.ScheduleTime).ToList();

                return View(appointments);
            }
            catch (Exception ex)
            {
                LogManager.LogErros("IndexGeneral: " + ex.Message);
                return RedirectToAction("Login", "Home");
            }

        }

        public ActionResult IndexPat(int? Id)
        {
            try
            {
                List<Appointment> appointments = db.Apppointments.ToList();

                return View(appointments.Where(a => a.ClientID.Equals(Id)).OrderBy(a => a.ScheduleTime).ToList());
            }
            catch (Exception ex)
            {
                LogManager.LogErros("IndexPat: " + ex.Message);
                return RedirectToAction("Login", "Home");
            }

        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Appointment appointment = db.Apppointments.Find(id);
                if (appointment == null)
                {
                    return HttpNotFound();
                }
                return View(appointment);
            }
            catch (Exception ex)
            {
                LogManager.LogErros("DetailsAppointment: " + ex.Message);
                return RedirectToAction("Login", "Home");
            }

        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            try
            {
                User loggedUser = Session["user"] as User;
                List<Coach> docList = new List<Coach>();
                List<Client> patList = new List<Client>();

                if (loggedUser is Coach)
                {
                    docList.Add(loggedUser as Coach);
                    patList = db.Clients.ToList();
                }
                if (loggedUser is Client)
                {
                    docList = db.Coachs.ToList();
                    patList.Add(loggedUser as Client);
                }
                else
                {
                    patList = db.Clients.ToList();
                    docList = db.Coachs.ToList();
                }
                ViewBag.Coachs = docList.OrderBy(a => a.Name);
                ViewBag.Clients = patList.OrderBy(a => a.Name);
                return View();
            }
            catch (Exception ex)
            {
                LogManager.LogErros("Get CreateAppointment: " + ex.Message);
                return RedirectToAction("Login", "Home");
            }

        }

        // POST: Appointments/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment appointment)
        {
            try
            {

                User user = Session["user"] as User;
                appointment.CreatedOn = DateTime.Now;
                appointment.ReviewUser = user.Id;
                appointment.UpdatedOn = DateTime.Now;
                appointment.Status = (int)AppointmentStatus.REQUESTED;
                if (ModelState.IsValid)
                {
                    db.Apppointments.Add(appointment);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(appointment);
            }
            catch (Exception ex)
            {
                LogManager.LogErros("Post CreateAppointment: " + ex.Message);
                return RedirectToAction("Login", "Home");
            }

        }


        // POST: Appointments/Delete/5
        public ActionResult Cancel(int id)
        {
            try
            {
                Appointment appointmentChanged = ChangeStatus(id, AppointmentStatus.CANCELLED);
                db.Apppointments.Attach(appointmentChanged);
                db.Entry(appointmentChanged).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                LogManager.LogErros("CancelAppointment: " + ex.Message);
                return RedirectToAction("Login", "Home");
            }

        }

        // POST: Appointments/Delete/5
        public ActionResult Confirm(int id)
        {
            try
            {
                Appointment appointmentChanged;
                Appointment appointment = db.Apppointments.Find(id);
                User userLogged = Session["User"] as User;
                if (userLogged is Client)
                {
                    appointment.PatConfirm = true;
                }
                else
                {
                    appointment.DocConfirm = true;
                }
                if (appointment.DocConfirm && appointment.PatConfirm)
                {
                    appointmentChanged = ChangeStatus(appointment, AppointmentStatus.CONFIRMED);
                }
                else
                {
                    appointmentChanged = ChangeStatus(appointment, appointment.Status);
                }
                db.Apppointments.Attach(appointmentChanged);
                db.Entry(appointmentChanged).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                LogManager.LogErros("CancelAppointment: " + ex.Message);
                return RedirectToAction("Login", "Home");
            }

        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (Exception ex)
            {
                LogManager.LogErros("DBDispose: " + ex.Message);
                throw;
            }

        }

        #region Methods

        public Appointment ChangeStatus(int id, AppointmentStatus status)
        {
            try
            {
                Appointment appointment = db.Apppointments.Find(id);
                User user = Session["user"] as User;
                appointment.Status = (int)status;
                appointment.ReviewUser = user.Id;
                appointment.UpdatedOn = DateTime.Now;
                return appointment;
            }
            catch (Exception ex)
            {
                LogManager.LogErros("CancelAppointment: " + ex.Message);
                return null;
            }

        }

        public Appointment ChangeStatus(Appointment appointment, AppointmentStatus status)
        {
            try
            {
                User user = Session["user"] as User;
                appointment.Status = (int)status;
                appointment.ReviewUser = user.Id;
                appointment.UpdatedOn = DateTime.Now;
                return appointment;
            }
            catch (Exception ex)
            {
                LogManager.LogErros("CancelAppointment: " + ex.Message);
                return null;
            }

        }

        public Appointment ChangeStatus(Appointment appointment, int status)
        {
            try
            {
                User user = Session["user"] as User;
                appointment.Status = status;
                appointment.ReviewUser = user.Id;
                appointment.UpdatedOn = DateTime.Now;
                return appointment;
            }
            catch (Exception ex)
            {
                LogManager.LogErros("CancelAppointment: " + ex.Message);
                return null;
            }

        }

        #endregion
    }
}
