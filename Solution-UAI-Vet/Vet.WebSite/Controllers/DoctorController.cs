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
using Vet.WebSite.Utils;

namespace WebApp.Controllers
{
    public class DoctorController : Controller
    {
        DoctorBLL doctorBusiness = new DoctorBLL();
        // GET: Doctor
        public ActionResult Index()
        {
            try
            {
                var doctors = doctorBusiness.List();
                return View(DoctorModel.ToModelList(doctors));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }            
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Doctor doctor = doctorBusiness.GetById(id);
                if (doctor == null)
                {
                    return HttpNotFound();
                }

                return View(DoctorModel.ToModel(doctor));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
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
        public ActionResult Create([Bind(Include = "Id,Name,LastName,DNI,Enrollment,Phone,Email")] DoctorModel doctor)
        {
            try
            {
                if (doctor.Name == null || doctor.Name == string.Empty)
                {
                    ModelState.AddModelError("Name", "Debe ingresar un nombre");
                }

                if (doctor.LastName == null || doctor.LastName == string.Empty)
                {
                    ModelState.AddModelError("LastName", "Debe ingresar un apellido");
                }

                if (doctor.DNI == 0)
                {
                    ModelState.AddModelError("DNI", "Debe ingresar un DNI");
                }

                if (doctor.Enrollment == null || doctor.Enrollment == string.Empty)
                {
                    ModelState.AddModelError("Enrollment", "Debe ingresar el enrollment");
                }

                if (doctor.Phone == null || doctor.Phone == string.Empty)
                {
                    ModelState.AddModelError("Phone", "Debe ingresar un teléfono");
                }

                if (doctor.Email == null || doctor.Email == string.Empty)
                {
                    ModelState.AddModelError("Email", "Debe ingresar un email");
                }


                IEnumerable<Doctor> doctors = doctorBusiness.GetByFilters(DoctorModel.FromModel(doctor));

                if (doctors.ToList().Count > 0)
                {
                    ModelState.AddModelError("Model", "Ya existe un doctor con DNI: " +
                        doctor.DNI + " y Enrollment: " + doctor.Enrollment);
                }


                if (ModelState.IsValid)
                {
                    doctorBusiness.Insert(DoctorModel.FromModel(doctor));

                    return RedirectToAction("Index");
                }

                return View(doctor);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Doctor doctor = doctorBusiness.GetById(id);
                if (doctor == null)
                {
                    return HttpNotFound();
                }

                return View(DoctorModel.ToModel(doctor));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,DNI,Enrollment,Phone,Email")] DoctorModel doctor)
        {
            try
            {
                if (doctor.Name == null || doctor.Name == string.Empty)
                {
                    ModelState.AddModelError("Name", "Debe ingresar un nombre");
                }

                if (doctor.LastName == null || doctor.LastName == string.Empty)
                {
                    ModelState.AddModelError("LastName", "Debe ingresar un apellido");
                }

                if (doctor.DNI == 0)
                {
                    ModelState.AddModelError("DNI", "Debe ingresar un DNI");
                }

                if (doctor.Enrollment == null || doctor.Enrollment == string.Empty)
                {
                    ModelState.AddModelError("Enrollment", "Debe ingresar el enrollment");
                }

                if (doctor.Phone == null || doctor.Phone == string.Empty)
                {
                    ModelState.AddModelError("Phone", "Debe ingresar un teléfono");
                }

                if (doctor.Email == null || doctor.Email == string.Empty)
                {
                    ModelState.AddModelError("Email", "Debe ingresar un email");
                }


                IEnumerable<Doctor> doctors = doctorBusiness.GetByFilters(DoctorModel.FromModel(doctor));

                if (doctors.ToList().Count > 0)
                {
                    ModelState.AddModelError("Model", "Ya existe un doctor con DNI: " +
                        doctor.DNI + " y Enrollment: " + doctor.Enrollment);
                }


                if (ModelState.IsValid)
                {
                    doctorBusiness.Update(DoctorModel.FromModel(doctor));

                    return RedirectToAction("Index");
                }
                return View(doctor);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Doctor doctor = doctorBusiness.GetById(id);
                if (doctor == null)
                {
                    return HttpNotFound();
                }

                return View(DoctorModel.ToModel(doctor));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                doctorBusiness.Delete(id);

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
