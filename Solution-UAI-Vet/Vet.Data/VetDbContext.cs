using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Vet.Domain;

namespace ClientPatientManagement.Core.Data
{
    public class VetDbContext : DbContext
    {
        public VetDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<AppointmentModel> Appointments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Puedo eliminar o agregar convenciones
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}