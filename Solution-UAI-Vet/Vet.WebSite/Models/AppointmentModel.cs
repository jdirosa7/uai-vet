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
    public partial class AppointmentModel : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public DoctorModel Doctor { get; set; }
        public int DoctorId { get; set; }
        public PatientModel Patient { get; set; }
        public int PatientId { get; set; }
        public RoomModel Room { get; set; }
        public int RoomId { get; set; }

        public static AppointmentModel ToModel(Appointment entity)
        {
            return new AppointmentModel
            {
                Id = entity.Id,
                Date = Convert.ToDateTime(entity.Date.ToShortDateString()),
                Hour = entity.Hour,
                Doctor = new DoctorModel
                {
                    Id = entity.Doctor.Id,
                    Name = entity.Doctor.Name,
                    LastName = entity.Doctor.LastName,
                    Phone = entity.Doctor.Phone,
                    Email = entity.Doctor.Email
                },
                DoctorId = entity.Doctor.Id,
                Patient = new PatientModel
                {
                    Id = entity.Patient.Id,
                    Name = entity.Patient.Name,
                    Owner = new ClientModel
                    {
                        Id = entity.Patient.Owner.Id,
                        Name = entity.Patient.Owner.Name,
                        LastName = entity.Patient.Owner.LastName,
                        Email = entity.Patient.Owner.Email
                    },
                    ClientId = entity.Patient.Owner.Id,
                    Gender = entity.Patient.Gender == Gender.Female ? GenderModel.Female : GenderModel.Male
                },
                PatientId = entity.Patient.Id,
                Room = new RoomModel
                {
                    Id = entity.Room.Id,
                    Name = entity.Room.Name,
                    Location = entity.Room.Location
                },
                RoomId = entity.Room.Id
            };
        }

        public static IEnumerable<AppointmentModel> ToModelList(IEnumerable<Appointment> entities)
        {
            IList<AppointmentModel> appointments = new List<AppointmentModel>();
            entities.ToList().ForEach(entity => appointments.Add(ToModel(entity)));

            return appointments;
        }

        public static Appointment FromModel(AppointmentModel model)
        {
            return new Appointment
            {
                Id = model.Id,
                Date = model.Date,
                Hour = model.Hour,
                //Doctor = new Vet.Domain.Doctor
                //{
                //    Id = model.Doctor.Id,
                //    Name = model.Doctor.Name,
                //    LastName = model.Doctor.LastName,
                //    Phone = model.Doctor.Phone,
                //    Email = model.Doctor.Email
                //},
                DoctorId = model.DoctorId,
                //Patient = new Vet.Domain.Patient
                //{
                //    Id = model.Patient.Id,
                //    Name = model.Patient.Name,
                //    Owner = new Vet.Domain.Client
                //    {
                //        Id = model.Patient.Owner.Id,
                //        Name = model.Patient.Owner.Name,
                //        LastName = model.Patient.Owner.LastName,
                //        Email = model.Patient.Owner.Email
                //    },
                //    ClientId = model.Patient.Owner.Id,
                //    Gender = model.Patient.Gender == GenderModel.Female ? Gender.Female : Gender.Male
                //},
                PatientId = model.PatientId,
                //Room = new Vet.Domain.Room
                //{
                //    Id = model.Room.Id,
                //    Name = model.Room.Name,
                //    Location = model.Room.Location
                //},
                RoomId = model.RoomId
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