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

namespace WebApp.Controllers
{
    public class RoomController : Controller
    {
        private RoomBLL roomBusiness = new RoomBLL();

        // GET: Room
        public ActionResult Index()
        {
            var rooms = roomBusiness.List();
            return View(rooms);
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            Vet.Domain.Room room = roomBusiness.GetById(id);
            if (room == null)
            {
                return HttpNotFound();
            }

            //Mapear RoomModel a Room
            return View(ClientPatientManagement.Core.Model.RoomModel.ToModel(room));
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Location")] ClientPatientManagement.Core.Model.RoomModel room)
        {
            if (ModelState.IsValid)
            {
                roomBusiness.Insert(RoomModel.FromModel(room));                
                return RedirectToAction("Index");
            }

            return View(room);
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            Vet.Domain.Room room = roomBusiness.GetById(id);
            if (room == null)
            {
                return HttpNotFound();
            }

            return View(ClientPatientManagement.Core.Model.RoomModel.ToModel(room));
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Location")] ClientPatientManagement.Core.Model.RoomModel room)
        {
            if (ModelState.IsValid)
            {
                roomBusiness.Update((Vet.Domain.Room)ClientPatientManagement.Core.Model.RoomModel.FromModel(room));
                return RedirectToAction("Index");
            }
            return View(room);
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            Vet.Domain.Room room = roomBusiness.GetById(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            
            return View(ClientPatientManagement.Core.Model.RoomModel.ToModel(room));
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            roomBusiness.Delete(id);

            return RedirectToAction("Index");
        }       
    }
}
