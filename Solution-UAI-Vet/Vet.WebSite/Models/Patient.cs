using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Data;

namespace ClientPatientManagement.Core.Model
{
    public partial class Patient : IEntity
    {
        public int Id { get; set; }
        public Client Owner { get; private set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }        
    }

    [MetadataType(typeof(PatientMetadata))]
    public partial class Patient
    {
        public class PatientMetadata
        {
            [Key]
            [Required]
            public int Id { get; set; }

            [StringLength(50)]
            [Required]
            public string Name { get; set; }    
            
            [Required]
            public Gender Gender { get; set; }
        }
    }

    public class PatientModel
    {
        public IEnumerable<Patient> ObtenerPacientes()
        {
            return PatientRepository.Instancia.List();
        }

        public void AgregarPaciente(Patient paciente)
        {
            PatientRepository.Instancia.Insert(paciente);
        }

        public Patient ObtenerPacienteById(int id)
        {
            return PatientRepository.Instancia.GetById(id);
        }

        public void ActualizarPaciente(Patient paciente)
        {
            PatientRepository.Instancia.Update(paciente);
        }

        public void EliminarPaciente(int id)
        {
            PatientRepository.Instancia.Delete(id);
        }

    }
}