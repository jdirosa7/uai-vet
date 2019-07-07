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

namespace WebApp.Models
{
    public class ClientController : Controller
    {
        ClientBLL clientBusiness = new ClientBLL();
        // GET: Client
        public ActionResult Index()
        {
            var clients = clientBusiness.List();
            return View(clients);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            ClientModel client = clientBusiness.GetById(id);
            if (client == null)
            {
                return HttpNotFound();
            }

            return View(Client.ToModel(client));
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
        public ActionResult Create([Bind(Include = "Id,Name,LastName,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                clientBusiness.Insert(Client.FromModel(client));

                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            ClientModel client = clientBusiness.GetById(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(Client.ToModel(client));
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                clientBusiness.Update(Client.FromModel(client));

                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            ClientModel client = clientBusiness.GetById(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(Client.ToModel(client));
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clientBusiness.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
