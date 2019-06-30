using ClientPatientManagement.Core.Data;
using ClientPatientManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vet.Services;

namespace WebApp.Data
{
    public class AppointmentRepository : IRepository<Appointment>
    {
        public static AppointmentRepository Instancia = new AppointmentRepository();

        public void Delete(int id)
        {
            var db = new VetDbContext();
            var appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
        }

        public Appointment GetById(int id)
        {
            var db = new VetDbContext();
            var appointment = db.Appointments.Find(id);
            return appointment;
        }

        public void Insert(Appointment entity)
        {
            var db = new VetDbContext();
            db.Appointments.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<Appointment> List()
        {
            var db = new VetDbContext();
            IList<Appointment> appointments = db.Appointments.ToList();
            return appointments;
        }

        public void Update(Appointment entity)
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