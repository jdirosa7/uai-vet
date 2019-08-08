using ClientPatientManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vet.Business;
using Vet.Domain;
using Vet.WebSite.Utils;

namespace WebApp.Controllers
{
    public class PatientController : Controller
    {
        PatientBLL patientBusiness = new PatientBLL();
        ClientBLL clientBusiness = new ClientBLL();
        // GET: Patient
        public ActionResult Index()
        {
            try
            {
                var patients = patientBusiness.List();
                return View(PatientModel.ToModelList(patients));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                ModelState.AddModelError("Model", "Ha ocurrido un error. Por favor, contacte al administrador");
                return View();
            }
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Patient patient = patientBusiness.GetById(id);
                if (patient == null)
                {
                    return HttpNotFound();
                }

                return View(PatientModel.ToModel(patient));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }            
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            try
            {
                var clients = clientBusiness.List();
                ViewBag.ClientId = new SelectList(clients, "Id", "Name");
                return View();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }            
        }

        // POST: Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientId,Name,Gender,Age, Image")] PatientModel patient, HttpPostedFileBase Image)
        {
            try
            {
                if (patient.Name == null || patient.Name == string.Empty)
                {
                    ModelState.AddModelError("Name", "Debe ingresar un nombre");
                }

                if (patient.ClientId == 0)
                {
                    ModelState.AddModelError("ClientId", "Debe seleccionar un cliente");
                }

                if (patient.Age == 0)
                {
                    ModelState.AddModelError("Age", "Debe ingresar una edad");
                }

                IEnumerable<Patient> patients = patientBusiness.GetByFilters(PatientModel.FromModel(patient));

                if (patients.ToList().Count > 0)
                {
                    ModelState.AddModelError("Model", "Ya existe un paciente con nombre: " +
                        patient.Name + " y dueño: " + patient.ClientId);
                }


                if (ModelState.IsValid)
                {
                    Patient p = patientBusiness.Insert(PatientModel.FromModel(patient));

                    //Guardar imagen en carpeta local
                    if (Image != null)
                    {
                        var fileName = Path.GetFileName(Image.FileName);
                        var extension = fileName.Substring(fileName.IndexOf('.'));
                        var newFileName = p.Id + extension;
                        var path = Path.Combine(Server.MapPath("~/Content/Images"), newFileName);
                        Image.SaveAs(path);
                    }


                    return RedirectToAction("Index");
                }

                var clients = patientBusiness.List();
                ViewBag.ClientId = new SelectList(clients, "Id", "Name", patient.ClientId);
                return View(patient);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            try
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
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientId,Name,Gender,Age")] PatientModel patient)
        {
            try
            {
                if (patient.Name == null || patient.Name == string.Empty)
                {
                    ModelState.AddModelError("Name", "Debe ingresar un nombre");
                }

                if (patient.ClientId == 0)
                {
                    ModelState.AddModelError("ClientId", "Debe seleccionar un cliente");
                }

                if (patient.Age == 0)
                {
                    ModelState.AddModelError("Age", "Debe ingresar una edad");
                }

                IEnumerable<Patient> patients = patientBusiness.GetByFilters(PatientModel.FromModel(patient));

                if (patients.ToList().Count > 0)
                {
                    ModelState.AddModelError("Model", "Ya existe un paciente con nombre: " +
                        patient.Name + " y dueño: " + patient.ClientId);
                }

                if (ModelState.IsValid)
                {
                    patientBusiness.Update(PatientModel.FromModel(patient));

                    return RedirectToAction("Index");
                }

                var allPatients = patientBusiness.List();
                ViewBag.ClientId = new SelectList(PatientModel.ToModelList(allPatients), "Id", "Name", patient.ClientId);
                return View(patient);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Patient patient = patientBusiness.GetById(id);
                if (patient == null)
                {
                    return HttpNotFound();
                }

                return View(PatientModel.ToModel(patient));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                patientBusiness.Delete(id);

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
