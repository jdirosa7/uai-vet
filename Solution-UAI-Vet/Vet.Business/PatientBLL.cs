using System;
using System.Collections.Generic;
using System.Text;
using Vet.Domain;
using Vet.Services;
using WebApp.Data;
using System.Linq;

namespace Vet.Business
{
    public class PatientBLL : IRepository<Patient>
    {
        public void Delete(int id)
        {
            PatientRepository.Instancia.Delete(id);
        }

        public IEnumerable<Patient> GetByFilters(Patient entity)
        {
            return PatientRepository.Instancia.GetByFilters(entity);
        }

        public Patient GetById(int id)
        {
            return PatientRepository.Instancia.GetById(id);
        }

        public Patient Insert(Patient entity)
        {
            var patients = this.GetByFilters(entity);
            if (patients.Count() == 0)
            {
                entity = PatientRepository.Instancia.Insert(entity);
                return entity;
            }
            else
            {
                return null;
            }            
        }

        public IEnumerable<Patient> List()
        {
            return PatientRepository.Instancia.List();
        }

        public void Update(Patient entity)
        {
            PatientRepository.Instancia.Update(entity);
        }
    }
}
