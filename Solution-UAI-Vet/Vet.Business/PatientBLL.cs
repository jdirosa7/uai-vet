using System;
using System.Collections.Generic;
using System.Text;
using Vet.Domain;
using Vet.Services;
using WebApp.Data;

namespace Vet.Business
{
    public class PatientBLL : IRepository<Patient>
    {
        public void Delete(int id)
        {
            PatientRepository.Instancia.Delete(id);
        }

        public Patient GetById(int id)
        {
            return PatientRepository.Instancia.GetById(id);
        }

        public void Insert(Patient entity)
        {
            PatientRepository.Instancia.Insert(entity);
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
