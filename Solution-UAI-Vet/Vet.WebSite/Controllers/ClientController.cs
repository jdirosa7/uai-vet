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

namespace WebApp.Models
{
    public class ClientController : Controller
    {
        ClientBLL clientBusiness = new ClientBLL();
        // GET: Client
        public ActionResult Index()
        {
            try
            {
                var clients = clientBusiness.List();
                return View(ClientModel.ToModelList(clients));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                ModelState.AddModelError("Model", "Ha ocurrido un error. Por favor, contacte al administrador");
                return View();
            }
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Client client = clientBusiness.GetById(id);
                if (client == null)
                {
                    return HttpNotFound();
                }

                return View(ClientModel.ToModel(client));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LastName,DNI,Address,Phone,Email")] ClientModel client)
        {
            try
            {
                if (client.Name == null || client.Name == string.Empty)
                {
                    ModelState.AddModelError("Name", "Debe ingresar un nombre");
                }

                if (client.LastName == null || client.LastName == string.Empty)
                {
                    ModelState.AddModelError("LastName", "Debe ingresar un apellido");
                }

                if (client.DNI == 0)
                {
                    ModelState.AddModelError("DNI", "Debe ingresar un DNI");
                }

                if (client.Address == null || client.Address == string.Empty)
                {
                    ModelState.AddModelError("Address", "Debe ingresar una dirección");
                }

                if (client.Phone == null || client.Phone == string.Empty)
                {
                    ModelState.AddModelError("Phone", "Debe ingresar un teléfono");
                }

                if (client.Email == null || client.Email == string.Empty)
                {
                    ModelState.AddModelError("Email", "Debe ingresar un email");
                }


                IEnumerable<Client> rooms = clientBusiness.GetByFilters(ClientModel.FromModel(client));

                if (rooms.ToList().Count > 0)
                {
                    ModelState.AddModelError("Model", "Ya existe un cliente con DNI: " +
                        client.DNI);
                }


                if (ModelState.IsValid)
                {
                    clientBusiness.Insert(ClientModel.FromModel(client));

                    return RedirectToAction("Index");
                }

                return View(client);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Client client = clientBusiness.GetById(id);
                if (client == null)
                {
                    return HttpNotFound();
                }
                return View(ClientModel.ToModel(client));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,DNI,Address,Phone,Email")] ClientModel client)
        {
            try
            {
                if (client.Name == null || client.Name == string.Empty)
                {
                    ModelState.AddModelError("Name", "Debe ingresar un nombre");
                }

                if (client.LastName == null || client.LastName == string.Empty)
                {
                    ModelState.AddModelError("LastName", "Debe ingresar un apellido");
                }

                if (client.DNI == 0)
                {
                    ModelState.AddModelError("DNI", "Debe ingresar un DNI");
                }

                if (client.Address == null || client.Address == string.Empty)
                {
                    ModelState.AddModelError("Address", "Debe ingresar una dirección");
                }

                if (client.Phone == null || client.Phone == string.Empty)
                {
                    ModelState.AddModelError("Phone", "Debe ingresar un teléfono");
                }

                if (client.Email == null || client.Email == string.Empty)
                {
                    ModelState.AddModelError("Email", "Debe ingresar un email");
                }


                IEnumerable<Client> rooms = clientBusiness.GetByFilters(ClientModel.FromModel(client));

                if (rooms.ToList().Count > 0)
                {
                    ModelState.AddModelError("Model", "Ya existe un cliente con DNI: " +
                        client.DNI);
                }

                if (ModelState.IsValid)
                {
                    clientBusiness.Update(ClientModel.FromModel(client));

                    return RedirectToAction("Index");
                }
                return View(client);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Client client = clientBusiness.GetById(id);
                if (client == null)
                {
                    return HttpNotFound();
                }
                return View(ClientModel.ToModel(client));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                clientBusiness.Delete(id);

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
