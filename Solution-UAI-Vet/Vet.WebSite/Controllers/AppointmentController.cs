using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClientPatientManagement.Core.Model;
using Vet.Business;
using Vet.Domain;

namespace WebApp.Controllers
{
    public class AppointmentController : Controller
    {
        AppointmentBLL appointmentBusiness = new AppointmentBLL();
        DoctorBLL doctorBusiness = new DoctorBLL();
        PatientBLL patientBusiness = new PatientBLL();
        RoomBLL roomBusiness = new RoomBLL();
        // GET: Appointment
        public ActionResult Index()
        {
            var appointments = appointmentBusiness.List();
            return View(appointments.ToList());
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            AppointmentModel appointment = appointmentBusiness.GetById(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            return View(Appointment.ToModel(appointment));
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(doctorBusiness.List(), "Id", "Name");
            ViewBag.PatientId = new SelectList(patientBusiness.List(), "Id", "Name");
            ViewBag.RoomId = new SelectList(roomBusiness.List(), "Id", "Name");
            return View();
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Hour,DoctorId,PatientId,RoomId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointmentBusiness.Insert(Appointment.FromModel(appointment));

                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(doctorBusiness.List(), "Id", "Name");
            ViewBag.PatientId = new SelectList(patientBusiness.List(), "Id", "Name");
            ViewBag.RoomId = new SelectList(roomBusiness.List(), "Id", "Name");
            return View(appointment);
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {            
            AppointmentModel appointment = appointmentBusiness.GetById(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            ViewBag.DoctorId = new SelectList(doctorBusiness.List(), "Id", "Name");
            ViewBag.PatientId = new SelectList(patientBusiness.List(), "Id", "Name");
            ViewBag.RoomId = new SelectList(roomBusiness.List(), "Id", "Name");
            return View(Appointment.ToModel(appointment));
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Hour,DoctorId,PatientId,RoomId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointmentBusiness.Update(Appointment.FromModel(appointment));

                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(doctorBusiness.List(), "Id", "Name");
            ViewBag.PatientId = new SelectList(patientBusiness.List(), "Id", "Name");
            ViewBag.RoomId = new SelectList(roomBusiness.List(), "Id", "Name");
            return View(appointment);
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            AppointmentModel appointment = appointmentBusiness.GetById(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            appointmentBusiness.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
