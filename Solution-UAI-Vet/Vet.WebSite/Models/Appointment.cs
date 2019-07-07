using ClientPatientManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vet.Domain;
using Vet.Services;

namespace ClientPatientManagement.Core.Model
{
    public partial class Appointment : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }

        public static Appointment ToModel(AppointmentModel entity)
        {
            return new Appointment
            {
                Id = entity.Id,
                Date = entity.Date,
                Hour = entity.Hour,
                Doctor = new Doctor
                {
                    Id = entity.Doctor.Id,
                    Name = entity.Doctor.Name,
                    LastName = entity.Doctor.LastName,
                    Phone = entity.Doctor.Phone,
                    Email = entity.Doctor.Email
                },
                DoctorId = entity.Doctor.Id,
                Patient = new Patient
                {
                    Id = entity.Patient.Id,
                    Name = entity.Patient.Name,
                    Owner = new Client
                    {
                        Id = entity.Patient.Owner.Id,
                        Name = entity.Patient.Owner.Name,
                        LastName = entity.Patient.Owner.LastName,
                        Email = entity.Patient.Owner.Email                        
                    },
                    ClientId = entity.Patient.Owner.Id,
                    Gender = entity.Patient.Gender == GenderModel.Female ? Gender.Female : Gender.Male
                },
                PatientId = entity.Patient.Id,
                Room = new Room
                {
                    Id = entity.Room.Id,
                    Name = entity.Room.Name,
                    Location = entity.Room.Location
                },
                RoomId = entity.Room.Id
            };
        }

        public static AppointmentModel FromModel(Appointment model)
        {
            return new AppointmentModel
            {
                Id = model.Id,
                Date = model.Date,
                Hour = model.Hour,
                Doctor = new DoctorModel
                {
                    Id = model.Doctor.Id,
                    Name = model.Doctor.Name,
                    LastName = model.Doctor.LastName,
                    Phone = model.Doctor.Phone,
                    Email = model.Doctor.Email
                },
                DoctorId = model.Doctor.Id,
                Patient = new PatientModel
                {
                    Id = model.Patient.Id,
                    Name = model.Patient.Name,
                    Owner = new ClientModel
                    {
                        Id = model.Patient.Owner.Id,
                        Name = model.Patient.Owner.Name,
                        LastName = model.Patient.Owner.LastName,
                        Email = model.Patient.Owner.Email
                    },
                    ClientId = model.Patient.Owner.Id,
                    Gender = model.Patient.Gender == Gender.Female ? GenderModel.Female : GenderModel.Male
                },
                PatientId = model.Patient.Id,
                Room = new RoomModel
                {
                    Id = model.Room.Id,
                    Name = model.Room.Name,
                    Location = model.Room.Location
                },
                RoomId = model.Room.Id
            };
        }
    }

    

    //public class AppointmentModel
    //{
    //    public IEnumerable<Appointment> ObtenerCitas()
    //    {
    //        return AppointmentRepository.Instancia.List();
    //    }

    //    public void AgregarCita(Appointment cita)
    //    {
    //        AppointmentRepository.Instancia.Insert(cita);
    //    }

    //    public Appointment ObtenerCitaById(int id)
    //    {
    //        return AppointmentRepository.Instancia.GetById(id);
    //    }

    //    public void ActualizarCita(Appointment cita)
    //    {
    //        AppointmentRepository.Instancia.Update(cita);
    //    }

    //    public void EliminarCita(int id)
    //    {
    //        AppointmentRepository.Instancia.Delete(id);
    //    }

    //}
}