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

namespace AgendamentoOnline.Controllers
{
    public class AppointmentsController : Controller
    {
        private ScheduleContext db = new ScheduleContext();

        // GET: Appointments
        public ActionResult IndexDoc(int? Id)
        {
            try
            {
                List<Appointment> appointments = db.Apppointments.ToList();
                return View(appointments.Where(a => a.DoctorID.Equals(Id)).OrderBy(a => a.ScheduleTime).ToList());
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

                return View(appointments.Where(a => a.PatientID.Equals(Id)).OrderBy(a => a.ScheduleTime).ToList());
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

        // GET: Appointments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointments/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DoctorID,PatientID,Status,ReviewUser,UpdatedOn,CreatedOn,ScheduleTime,Motive")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Apppointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appointment);
        }


        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(int id)
        {
            Appointment appointment = db.Apppointments.Find(id);
            db.Apppointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
