using ABEGestionProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Infrastructure
{
   public class GestionProyectosDBContext: DbContext
    {
        public GestionProyectosDBContext(
            DbContextOptions<GestionProyectosDBContext> options) : base(options) { }
        

        public DbSet<Project> Projects { get; set; }
        public DbSet<Epic> Epics { get; set; }
        public DbSet<UserHistory> UserHistories { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Chore> Chores { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectID = 1,
                    Name = "CRAPS",
                    Description = "juego para moviles",
                    Responsible = "ABE",
                    StartDate = new DateTime(2021, 10, 30),
                    Type = "App para Android"
                },

                new Project
                {
                    ProjectID = 2,
                    Name = "4 PALABRAS",
                    Description = "juego para moviles",
                    Responsible = "ABE",
                    StartDate = new DateTime(2021, 11, 30),
                    Type = "App para Android"
                }
                );

            modelBuilder.Entity<Epic>().HasData(
                 new Epic
                 {
                     EpicID = 1,
                     Name = "Gestión de la BD",
                     ProjectID = 1
                 },


                 new Epic
                 {
                     EpicID = 2,
                     Name = "Gestión de UI",
                     ProjectID = 2
                 });

            modelBuilder.Entity<Sprint>().HasData(
                 new Sprint
                 {
                     SprintID = 1,
                     Name = "G3 - Modelado",
                     Points = 3,
                     Estate = "Por empezar"
                 },


                 new Sprint
                 {
                     SprintID = 2,
                     Name = "G3 - Productos",
                     Points = 5,
                     Estate = "En proceso"
                 });

            modelBuilder.Entity<UserHistory>().HasData(
                 new UserHistory
                 {
                     UserHistoryID = 1,
                     Title = "Listado de Productos",
                     IAsA = "Admin",
                     INeed = "Ver un listado de productos completo",
                     SoThat = "Atender las consultas de los clientes",
                     Estimate = "8",
                     Priority = "Alta",
                     EpicID = 1,
                     SprintID = 1
                 },


                 new UserHistory
                 {
                     UserHistoryID = 2,
                     Title = "Listado de modelados",
                     IAsA = "Admin",
                     INeed = "Ver un listado de modelados completo",
                     SoThat = "Atender las consultas de los usuarios",
                     Estimate = "5",
                     Priority = " Muy Alta",
                     EpicID = 2,
                     SprintID = 2
                 });


            modelBuilder.Entity<Role>().HasData(
                 new Role
                 {
                     RoleID = 1,
                     Name = "Informador"
                 },


                 new Role
                 {
                     RoleID = 2,
                     Name = "Desarrollador"
                 });


            modelBuilder.Entity<Person>().HasData(
                 new Person
                 {
                     PersonID = 1,
                     Name = "Ronal Estrada",
                     RoleID = 1
                 },


                 new Person
                 {
                     PersonID = 2,
                     Name = "Andre Maylle",
                     RoleID = 2
                 });


            modelBuilder.Entity<Chore>().HasData(
                 new Chore
                 {
                     ChoreID = 1,
                     Name = "Llenado BD",
                     Points = 3,
                     State = "En proceso",
                     PersonID = 1,
                     UserHistoryID = 1
                 },


                 new Chore
                 {
                     ChoreID = 2,
                     Name = "Llenado tablas",
                     Points = 5,
                     State = "Por empezar",
                     PersonID = 2,
                     UserHistoryID = 2
                 });
        }
    }
}
