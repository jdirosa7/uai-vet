﻿using ClientPatientManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vet.Business;
using Vet.Domain;

namespace WebApp.Controllers
{
    public class PatientController : Controller
    {
        PatientBLL patientBusiness = new PatientBLL();
        // GET: Patient
        public ActionResult Index()
        {
            var patients = patientBusiness.List();
            return View(PatientModel.ToModelList(patients));
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            Vet.Domain.Patient patient = patientBusiness.GetById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }

            return View(ClientPatientManagement.Core.Model.PatientModel.ToModel(patient));
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            var clients = patientBusiness.List();
            ViewBag.ClientId = new SelectList(clients, "Id", "Name");
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientId,Name,Gender")] ClientPatientManagement.Core.Model.PatientModel patient)
        {
            if (ModelState.IsValid)
            {
                patientBusiness.Insert((Vet.Domain.Patient)ClientPatientManagement.Core.Model.PatientModel.FromModel(patient));

                return RedirectToAction("Index");
            }

            var clients = patientBusiness.List();
            ViewBag.ClientId = new SelectList(clients, "Id", "Name", patient.ClientId);
            return View(patient);
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            Vet.Domain.Patient patient = patientBusiness.GetById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }

            var clients = patientBusiness.List();
            ViewBag.ClientId = new SelectList(clients, "Id", "Name", patient.ClientId);
            return View(patient);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientId,Name,Gender")] ClientPatientManagement.Core.Model.PatientModel patient)
        {
            if (ModelState.IsValid)
            {
                patientBusiness.Update((Vet.Domain.Patient)ClientPatientManagement.Core.Model.PatientModel.FromModel(patient));

                return RedirectToAction("Index");
            }

            var clients = patientBusiness.List();
            ViewBag.ClientId = new SelectList(clients, "Id", "Name", patient.ClientId);
            return View(patient);
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            Vet.Domain.Patient patient = patientBusiness.GetById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }

            return View(ClientPatientManagement.Core.Model.PatientModel.ToModel(patient));
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            patientBusiness.Delete(id);

            return RedirectToAction("Index");
        }        
    }
}
