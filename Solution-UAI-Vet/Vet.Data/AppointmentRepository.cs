using ClientPatientManagement.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vet.Domain;
using Vet.Services;

namespace WebApp.Data
{
    public class AppointmentRepository : IRepository<AppointmentModel>
    {
        public static AppointmentRepository Instancia = new AppointmentRepository();

        public void Delete(int id)
        {
            var db = new VetDbContext();
            var appointment = db.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.Room).Where(x => x.Id == id).Single();
            db.Appointments.Remove(appointment);
            db.SaveChanges();
        }

        public AppointmentModel GetById(int id)
        {
            var db = new VetDbContext();
            var appointment = db.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.Room).Where(x => x.Id == id).Single();
            return appointment;
        }

        public void Insert(AppointmentModel entity)
        {
            var db = new VetDbContext();
            db.Appointments.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<AppointmentModel> List()
        {
            var db = new VetDbContext();
            IList<AppointmentModel> appointments = db.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.Room).ToList();
            return appointments;
        }

        public void Update(AppointmentModel entity)
        {
            var db = new VetDbContext();
            var appointment = db.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.Room).Where(x => x.Id == entity.Id).Single();

            if (appointment != null)
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}