using ClientPatientManagement.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Vet.Domain;
using Vet.Services;

namespace Vet.Business
{
    public class DoctorBLL : IRepository<DoctorModel>
    {
        public void Delete(int id)
        {
            DoctorRepository.Instancia.Delete(id);
        }

        public DoctorModel GetById(int id)
        {
            return DoctorRepository.Instancia.GetById(id);
        }

        public void Insert(DoctorModel entity)
        {
            DoctorRepository.Instancia.Insert(entity);
        }

        public IEnumerable<DoctorModel> List()
        {
            return DoctorRepository.Instancia.List();
        }

        public void Update(DoctorModel entity)
        {
            DoctorRepository.Instancia.Update(entity);
        }
    }
}
