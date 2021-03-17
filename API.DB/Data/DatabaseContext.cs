using Api.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.DB
{
    public class DatabaseContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!; //Set tables

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        
        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>();
            modelBuilder.Entity<User>().HasData(
               new User { ID = 1, Name = "Testing", Email = "P", Senha = "P"}
           );
        }
    }
}
