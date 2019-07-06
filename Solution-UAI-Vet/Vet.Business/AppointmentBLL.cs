using System;
using System.Collections.Generic;
using System.Text;
using Vet.Domain;
using Vet.Services;
using WebApp.Data;

namespace Vet.Business
{
    public class AppointmentBLL : IRepository<AppointmentModel>
    {
        public void Delete(int id)
        {
            AppointmentRepository.Instancia.Delete(id);
        }

        public AppointmentModel GetById(int id)
        {
            return AppointmentRepository.Instancia.GetById(id);
        }

        public void Insert(AppointmentModel entity)
        {
            AppointmentRepository.Instancia.Insert(entity);
        }

        public IEnumerable<AppointmentModel> List()
        {
            return AppointmentRepository.Instancia.List();
        }

        public void Update(AppointmentModel entity)
        {
            AppointmentRepository.Instancia.Update(entity);
        }
    }
}
