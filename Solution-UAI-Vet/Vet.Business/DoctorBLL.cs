using ClientPatientManagement.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Vet.Domain;
using Vet.Services;
using System.Linq;

namespace Vet.Business
{
    public class DoctorBLL : IRepository<Doctor>
    {
        public void Delete(int id)
        {
            DoctorRepository.Instancia.Delete(id);
        }

        public IEnumerable<Doctor> GetByFilters(Doctor entity)
        {
            return DoctorRepository.Instancia.GetByFilters(entity);
        }

        public Doctor GetById(int id)
        {
            return DoctorRepository.Instancia.GetById(id);
        }

        public Doctor Insert(Doctor entity)
        {
            var doctors = this.GetByFilters(entity);
            if (doctors.Count() == 0)
            {
                DoctorRepository.Instancia.Insert(entity);
                return entity;
            }
            else
            {
                return null;
            }
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
