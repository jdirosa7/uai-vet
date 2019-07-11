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
    public partial class PatientModel : IEntity
    {
        public int Id { get; set; }
        public ClientModel Owner { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public GenderModel Gender { get; set; }

        public static PatientModel ToModel(Vet.Domain.Patient entity)
        {
            return new PatientModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Owner = new ClientModel
                {
                    Id = entity.Owner.Id,
                    Name = entity.Owner.Name,
                    LastName = entity.Owner.LastName,
                    Email = entity.Owner.Email
                },
                ClientId = entity.Owner.Id,
                Gender = entity.Gender == Vet.Domain.Gender.Female ? GenderModel.Female : GenderModel.Male
            };
        }

        public static IEnumerable<PatientModel> ToModelList(IEnumerable<Vet.Domain.Patient> entities)
        {
            IList<PatientModel> patients = new List<PatientModel>();
            entities.ToList().ForEach(entity => patients.Add(ToModel(entity)));

            return patients;
        }

        public static Patient FromModel(PatientModel model)
        {
            return new Patient
            {
                Id = model.Id,
                Name = model.Name,
                //Owner = new Client
                //{
                //    Id = model.Owner.Id,
                //    Name = model.Owner.Name,
                //    LastName = model.Owner.LastName,
                //    Email = model.Owner.Email
                //},
                ClientId = model.ClientId,
                Gender = model.Gender == GenderModel.Female ? Vet.Domain.Gender.Female : Vet.Domain.Gender.Male
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