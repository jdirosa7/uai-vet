using System;
using System.Collections.Generic;
using System.Text;
using Vet.Domain;
using Vet.Services;
using WebApp.Data;

namespace Vet.Business
{
    public class AppointmentBLL : IRepository<Appointment>
    {
        public void Delete(int id)
        {
            AppointmentRepository.Instancia.Delete(id);
        }

        public Appointment GetById(int id)
        {
            return AppointmentRepository.Instancia.GetById(id);
        }

        public void Insert(Appointment entity)
        {
            AppointmentRepository.Instancia.Insert(entity);
        }

        public IEnumerable<Appointment> List()
        {
            return AppointmentRepository.Instancia.List();
        }

        public void Update(Appointment entity)
        {
            AppointmentRepository.Instancia.Update(entity);
        }
    }
}
