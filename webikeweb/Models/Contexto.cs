using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WeBikeWeb.Models
{
    public class Contexto : DbContext
    {
        public Contexto():base("DefaultConnection")
        {
            Database.SetInitializer<Contexto>(null);
        }
        static Contexto()
        {
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios");
      
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);
        }
       
        public DbSet<ApplicationUser> Usuarios { get; set; }

        public static Contexto Create()
        {
            return new Contexto();
        }
    }
}