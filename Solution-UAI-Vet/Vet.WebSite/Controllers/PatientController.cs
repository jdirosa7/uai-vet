using ClientPatientManagement.Core.Model;
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
        ClientBLL clientBusiness = new ClientBLL();
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

            return View(PatientModel.ToModel(patient));
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            var clients = clientBusiness.List();
            ViewBag.ClientId = new SelectList(clients, "Id", "Name");
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientId,Name,Gender")] PatientModel patient)
        {
            if (ModelState.IsValid)
            {
                patientBusiness.Insert(PatientModel.FromModel(patient));

                return RedirectToAction("Index");
            }

            var clients = patientBusiness.List();
            ViewBag.ClientId = new SelectList(clients, "Id", "Name", patient.ClientId);
            return View(patient);
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            Patient patient = patientBusiness.GetById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }

            //var patients = patientBusiness.List();
            //ViewBag.ClientId = new SelectList(PatientModel.ToModelList(patients), "Id", "Name", PatientModel.ToModel(patient).ClientId);
            var clients = clientBusiness.List();
            ViewBag.ClientId = new SelectList(clients, "Id", "Name", PatientModel.ToModel(patient).ClientId);
            return View(PatientModel.ToModel(patient));
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientId,Name,Gender")] PatientModel patient)
        {
            if (ModelState.IsValid)
            {
                patientBusiness.Update(PatientModel.FromModel(patient));

                return RedirectToAction("Index");
            }

            var patients = patientBusiness.List();
            ViewBag.ClientId = new SelectList(PatientModel.ToModelList(patients), "Id", "Name", patient.ClientId);
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

            return View(PatientModel.ToModel(patient));
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
