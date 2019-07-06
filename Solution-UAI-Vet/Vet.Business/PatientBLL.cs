using System;
using System.Collections.Generic;
using System.Text;
using Vet.Domain;
using Vet.Services;
using WebApp.Data;

namespace Vet.Business
{
    public class PatientBLL : IRepository<PatientModel>
    {
        public void Delete(int id)
        {
            PatientRepository.Instancia.Delete(id);
        }

        public PatientModel GetById(int id)
        {
            return PatientRepository.Instancia.GetById(id);
        }

        public void Insert(PatientModel entity)
        {
            PatientRepository.Instancia.Insert(entity);
        }

        public IEnumerable<PatientModel> List()
        {
            return PatientRepository.Instancia.List();
        }

        public void Update(PatientModel entity)
        {
            PatientRepository.Instancia.Update(entity);
        }
    }
}
