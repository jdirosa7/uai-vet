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
    public class RoomController : Controller
    {
        private RoomBLL roomBusiness = new RoomBLL();

        // GET: Room
        public ActionResult Index()
        {
            try
            {
                Log.Info("Ingreso a Room/Index");
                var rooms = roomBusiness.List();
                return View(RoomModel.ToModelList(rooms));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View();
            }            
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Room room = roomBusiness.GetById(id);
                if (room == null)
                {
                    return HttpNotFound();
                }

                return View(RoomModel.ToModel(room));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View("Details");
            }
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
        public ActionResult Create([Bind(Include = "Id,Name,Location")] RoomModel room)
        {
            try
            {
                if (room.Name == null || room.Name == string.Empty)
                {
                    ModelState.AddModelError("Name", "Debe ingresar un nombre");
                }

                if(room.Location == null || room.Location == string.Empty)
                {
                    ModelState.AddModelError("Location", "Debe ingresar una locación");
                }


                IEnumerable<Room> rooms = roomBusiness.GetByFilters(RoomModel.FromModel(room));

                if(rooms.ToList().Count > 0)
                {
                    ModelState.AddModelError("Model", "Ya existe un consultorio con nombre: " + 
                        room.Name + " y locación: " + room.Location);
                }

                if (ModelState.IsValid)
                {
                    roomBusiness.Insert(RoomModel.FromModel(room));
                    return RedirectToAction("Index");
                }

                return View(room);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View("Create", room);
            }
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Room room = roomBusiness.GetById(id);
                if (room == null)
                {
                    return HttpNotFound();
                }

                return View(RoomModel.ToModel(room));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View("Edit");
            }
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Location")] RoomModel room)
        {
            try
            {
                if (room.Name == null || room.Name == string.Empty)
                {
                    ModelState.AddModelError("Name", "Debe ingresar un nombre");
                }

                if (room.Location == null || room.Location == string.Empty)
                {
                    ModelState.AddModelError("Location", "Debe ingresar una locación");
                }


                IEnumerable<Room> rooms = roomBusiness.GetByFilters(RoomModel.FromModel(room));

                if (rooms.ToList().Count > 0)
                {
                    ModelState.AddModelError("Model", "Ya existe un consultorio con nombre: " +
                        room.Name + " y locación: " + room.Location);
                }


                if (ModelState.IsValid)
                {
                    roomBusiness.Update(RoomModel.FromModel(room));
                    return RedirectToAction("Index");
                }
                return View(room);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View("Edit", room);
            }
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Room room = roomBusiness.GetById(id);
                if (room == null)
                {
                    return HttpNotFound();
                }

                return View(RoomModel.ToModel(room));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View("Delete");
            }
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                roomBusiness.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return View("Delete");
            }
        }       
    }
}
