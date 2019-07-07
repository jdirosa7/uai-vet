using ClientPatientManagement.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Vet.Domain;
using Vet.Services;

namespace Vet.Business
{
    public class DoctorBLL : IRepository<Doctor>
    {
        public void Delete(int id)
        {
            DoctorRepository.Instancia.Delete(id);
        }

        public Doctor GetById(int id)
        {
            return DoctorRepository.Instancia.GetById(id);
        }

        public void Insert(Doctor entity)
        {
            DoctorRepository.Instancia.Insert(entity);
        }

        public IEnumerable<Doctor> List()
        {
            return DoctorRepository.Instancia.List();
        }

        public void Update(Doctor entity)
        {
            DoctorRepository.Instancia.Update(entity);
        }
    }
}
