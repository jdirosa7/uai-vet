using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vet.Domain;
using Vet.Services;

namespace ClientPatientManagement.Core.Model
{
    public partial class Patient : IEntity
    {
        public int Id { get; set; }
        public Client Owner { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }

        public static Patient ToModel(PatientModel entity)
        {
            return new Patient
            {
                Id = entity.Id,
                Name = entity.Name,
                Owner = new Client
                {
                    Id = entity.Owner.Id,
                    Name = entity.Owner.Name,
                    LastName = entity.Owner.LastName,
                    Email = entity.Owner.Email
                },
                ClientId = entity.Owner.Id,
                Gender = entity.Gender == GenderModel.Female ? Gender.Female : Gender.Male
            };
        }

        public static PatientModel FromModel(Patient model)
        {
            return new PatientModel
            {
                Id = model.Id,
                Name = model.Name,
                Owner = new ClientModel
                {
                    Id = model.Owner.Id,
                    Name = model.Owner.Name,
                    LastName = model.Owner.LastName,
                    Email = model.Owner.Email
                },
                ClientId = model.Owner.Id,
                Gender = model.Gender == Gender.Female ? GenderModel.Female : GenderModel.Male
            };
        }
    }

    

    //public class PatientModel
    //{
    //    public IEnumerable<Patient> ObtenerPacientes()
    //    {
    //        return PatientRepository.Instancia.List();
    //    }

    //    public void AgregarPaciente(Patient paciente)
    //    {
    //        PatientRepository.Instancia.Insert(paciente);
    //    }

    //    public Patient ObtenerPacienteById(int id)
    //    {
    //        return PatientRepository.Instancia.GetById(id);
    //    }

    //    public void ActualizarPaciente(Patient paciente)
    //    {
    //        PatientRepository.Instancia.Update(paciente);
    //    }

    //    public void EliminarPaciente(int id)
    //    {
    //        PatientRepository.Instancia.Delete(id);
    //    }

    //}
}