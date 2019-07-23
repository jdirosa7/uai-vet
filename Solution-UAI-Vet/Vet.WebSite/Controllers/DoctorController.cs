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
    public class DoctorController : Controller
    {
        DoctorBLL doctorBusiness = new DoctorBLL();
        // GET: Doctor
        public ActionResult Index()
        {
            var doctors = doctorBusiness.List();
            return View(DoctorModel.ToModelList(doctors));
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            Vet.Domain.Doctor doctor = doctorBusiness.GetById(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            return View(DoctorModel.ToModel(doctor));
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LastName,Enrollment,Phone,Email")] DoctorModel doctor)
        {
            if (ModelState.IsValid)
            {
                doctorBusiness.Insert(DoctorModel.FromModel(doctor));

                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            Vet.Domain.Doctor doctor = doctorBusiness.GetById(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            return View(DoctorModel.ToModel(doctor));
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,Enrollment,Phone,Email")] DoctorModel doctor)
        {
            if (ModelState.IsValid)
            {
                doctorBusiness.Update(DoctorModel.FromModel(doctor));

                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            Vet.Domain.Doctor doctor = doctorBusiness.GetById(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            return View(DoctorModel.ToModel(doctor));
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            doctorBusiness.Delete(id);

            return RedirectToAction("Index");
        }        
    }
}
