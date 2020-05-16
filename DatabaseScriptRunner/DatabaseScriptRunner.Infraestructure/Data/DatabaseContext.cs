using DatabaseScriptRunner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseScriptRunner.Infraestructure.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        //protected DatabaseContext() { }

        public DbSet<Database> Databases { get; set; } //TodosItens
        public DbSet<User> Users { get; set; } //TodosItens
        public DbSet<UserDatabase> UserDatabases { get; set; }
        public DbSet<ActionUser> ActionUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDatabase>().HasKey(sc =>
           new { sc.IdDatabase, sc.IdUser }); // chave composta

            modelBuilder.Entity<User>().HasKey(sc =>
           new { sc.IdUser }); // chave composta

        }













        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Database>().HasData(new Database
        //    {
        //        Id = 1,
        //        Name = "Banco AccessOne",
        //        ConnectionString = "Local(DbLocal)"
        //    }, new Database
        //    {
        //        Id = 2,
        //        Name = "Banco DatabaseScriptRunner",
        //        ConnectionString = "Local(DbScriptRunner)"
        //    });
        //}


    }
}
