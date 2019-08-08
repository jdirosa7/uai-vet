using System;
using System.Collections.Generic;
using System.Text;
using Vet.Domain;
using Vet.Services;
using WebApp.Data;
using System.Linq;

namespace Vet.Business
{
    public class AppointmentBLL : IRepository<Appointment>
    {
        public void Delete(int id)
        {
            AppointmentRepository.Instancia.Delete(id);
        }

        public IEnumerable<Appointment> GetByFilters(Appointment entity)
        {
            return AppointmentRepository.Instancia.GetByFilters(entity);
        }

        public Appointment GetById(int id)
        {
            return AppointmentRepository.Instancia.GetById(id);
        }

        public Appointment Insert(Appointment entity)
        {
            var clients = this.GetByFilters(entity);
            if (clients.Count() == 0)
            {
                AppointmentRepository.Instancia.Insert(entity);
                return entity;
            }
            else
            {
                return null;
            }            
        }

        public IEnumerable<Appointment> List()
        {
            return AppointmentRepository.Instancia.List();
        }

        public void Update(Appointment entity)
        {
            AppointmentRepository.Instancia.Update(entity);
        }

        Appointment IRepository<Appointment>.Insert(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
