﻿using System;
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
                List<Doctor> docList = new List<Doctor>();
                List<Patient> patList = new List<Patient>();

                if (loggedUser is Doctor)
                {
                    docList.Add(loggedUser as Doctor);
                    patList = db.Patients.ToList();
                }
                if (loggedUser is Patient)
                {
                    docList = db.Doctors.ToList();
                    patList.Add(loggedUser as Patient);
                }
                else
                {
                    patList = db.Patients.ToList();
                    docList = db.Doctors.ToList();
                }
                ViewBag.Doctors = docList.OrderBy(a => a.Name);
                ViewBag.Patients = patList.OrderBy(a => a.Name);
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
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(int id)
        {
            try
            {
                Appointment appointment = db.Apppointments.Find(id);
                db.Apppointments.Remove(appointment);
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
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
