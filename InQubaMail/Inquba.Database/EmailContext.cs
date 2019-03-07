using Inquba.Databases.Interfaces;
using Inquba.Databases.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Inquba.Databases.Models;

namespace Inquba.Databases
{
    public class EmailContext : DbContext
    {
        public DbSet<Email> Emails { get; set; }
        public DbSet<Location> Locations { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var statemanager = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager;
            var deletedentries = statemanager
                .GetObjectStateEntries(EntityState.Deleted)
                .Select(e => e.Entity)
                .OfType<IStatus>()
                .ToArray();

            foreach(var deletedentry in deletedentries)
            {
                if (deletedentry == null) continue;

                statemanager.ChangeObjectState(deletedentry, EntityState.Modified);
                deletedentry.Status = false;
                
            }

          
            var createdentries = statemanager
                .GetObjectStateEntries(EntityState.Added)
                .Select(e => e.Entity)
                .OfType<BaseModel>()
                .ToArray();

            foreach(var createdentry in createdentries)
            {
                createdentry.CreatedDate = DateTime.Now;
                createdentry.CreatedBy = Environment.UserName;
                createdentry.UpDatedDate = DateTime.Now;
                createdentry.UpdatedBy = Environment.UserName;

            }
            var updatedentries = statemanager
               .GetObjectStateEntries(EntityState.Modified)
               .Select(e => e.Entity)
               .OfType<BaseModel>()
               .ToArray();

            foreach (var updatedentry in updatedentries)
            {
               
                updatedentry.UpDatedDate = DateTime.Now;
                updatedentry.UpdatedBy = Environment.UserName;

            }

            return base.SaveChanges();

        }

    }
}