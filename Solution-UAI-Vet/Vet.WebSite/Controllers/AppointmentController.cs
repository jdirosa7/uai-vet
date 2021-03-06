﻿using System;
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
using Vet.WebSite.Utils;

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
            try
            {
                var appointments = appointmentBusiness.List();
                return View(AppointmentModel.ToModelList(appointments));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                ModelState.AddModelError("Model", "Ha ocurrido un error. Por favor, contacte al administrador");
                return View();
            }
        }

        public ActionResult Calendar()
        {
            IEnumerable<Appointment> appointments = appointmentBusiness.List();

            List<CalendarModel> calendarItems = new List<CalendarModel>();

            appointments.ToList().ForEach(item =>
            {
                calendarItems.Add(AppointmentModel.ToCalendarModel(item));
            });
            
            ViewBag.Appointments = ToJSON(calendarItems);
            return View();
        }

        public static string ToJSON(List<CalendarModel> obj)
        {
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return oSerializer.Serialize(obj);
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Appointment appointment = appointmentBusiness.GetById(id);
                if (appointment == null)
                {
                    return HttpNotFound();
                }

                return View(AppointmentModel.ToModel(appointment));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View(); 
            }
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.DoctorId = new SelectList(doctorBusiness.List(), "Id", "Name");
                ViewBag.PatientId = new SelectList(patientBusiness.List(), "Id", "Name");
                ViewBag.RoomId = new SelectList(roomBusiness.List(), "Id", "Name");
                return View();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Hour,DoctorId,PatientId,RoomId")] AppointmentModel appointment)
        {
            try
            {
                if (appointment.Date == null)
                {
                    ModelState.AddModelError("Date", "Debe ingresar una fecha");
                }

                if (appointment.Hour == 0)
                {
                    ModelState.AddModelError("Hour", "Debe ingresar una hora");
                }


                IEnumerable<Appointment> appointments = appointmentBusiness.GetByFilters(AppointmentModel.FromModel(appointment));

                if (appointments.ToList().Count > 0)
                {
                    var ap = appointments.FirstOrDefault();

                    if(ap.DoctorId == appointment.DoctorId)
                    {
                        ModelState.AddModelError("Model", "El doctor ya tiene un turno asignado para el día y hora seleccionados");
                    }
                    else
                    {
                        ModelState.AddModelError("Model", "El paciente ya tiene un turno asignado en el día y horario seleccionados");
                    }                    
                }

                if (ModelState.IsValid)
                {
                    appointmentBusiness.Insert(AppointmentModel.FromModel(appointment));

                    return RedirectToAction("Index");
                }

                ViewBag.DoctorId = new SelectList(doctorBusiness.List(), "Id", "Name");
                ViewBag.PatientId = new SelectList(patientBusiness.List(), "Id", "Name");
                ViewBag.RoomId = new SelectList(roomBusiness.List(), "Id", "Name");
                return View(appointment);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Appointment appointment = appointmentBusiness.GetById(id);
                if (appointment == null)
                {
                    return HttpNotFound();
                }

                ViewBag.DoctorId = new SelectList(doctorBusiness.List(), "Id", "Name");
                ViewBag.PatientId = new SelectList(patientBusiness.List(), "Id", "Name");
                ViewBag.RoomId = new SelectList(roomBusiness.List(), "Id", "Name");
                return View(AppointmentModel.ToModel(appointment));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Hour,DoctorId,PatientId,RoomId")] AppointmentModel appointment)
        {
            try
            {
                if (appointment.Date == null)
                {
                    ModelState.AddModelError("Date", "Debe ingresar una fecha");
                }

                if (appointment.Hour == 0)
                {
                    ModelState.AddModelError("Hour", "Debe ingresar una hora");
                }


                IEnumerable<Appointment> appointments = appointmentBusiness.GetByFilters(AppointmentModel.FromModel(appointment));

                if (appointments.ToList().Count > 0)
                {
                    var ap = appointments.FirstOrDefault();

                    if (ap.DoctorId == appointment.DoctorId)
                    {
                        ModelState.AddModelError("Model", "El doctor ya tiene un turno asignado para el día y hora seleccionados");
                    }
                    else
                    {
                        ModelState.AddModelError("Model", "El paciente ya tiene un turno asignado en el día y horario seleccionados");
                    }
                }

                if (ModelState.IsValid)
                {
                    appointmentBusiness.Update(AppointmentModel.FromModel(appointment));

                    return RedirectToAction("Index");
                }

                ViewBag.DoctorId = new SelectList(doctorBusiness.List(), "Id", "Name");
                ViewBag.PatientId = new SelectList(patientBusiness.List(), "Id", "Name");
                ViewBag.RoomId = new SelectList(roomBusiness.List(), "Id", "Name");
                return View(appointment);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Appointment appointment = appointmentBusiness.GetById(id);
                if (appointment == null)
                {
                    return HttpNotFound();
                }
                return View(AppointmentModel.ToModel(appointment));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                appointmentBusiness.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }
    }
}
