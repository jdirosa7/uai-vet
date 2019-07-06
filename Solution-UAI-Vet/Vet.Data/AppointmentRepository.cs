using ClientPatientManagement.Core.Data;
using System;
using System.Collections.Generic;
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
            var appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
        }

        public AppointmentModel GetById(int id)
        {
            var db = new VetDbContext();
            var appointment = db.Appointments.Find(id);
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
            IList<AppointmentModel> appointments = db.Appointments.ToList();
            return appointments;
        }

        public void Update(AppointmentModel entity)
        {
            var db = new VetDbContext();
            var appointment = db.Appointments.Find(entity.Id);

            if (appointment != null)
            {
                appointment.Date = entity.Date;
                appointment.Hour = entity.Hour;
                appointment.Doctor = entity.Doctor;
                appointment.Patient = entity.Patient;
                appointment.Room = entity.Room;

                db.SaveChanges();
            }
        }
    }
}