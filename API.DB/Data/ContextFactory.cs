using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.DB.Data
{
    class ContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string [] args)
        {
            //Create migrations
            var connectionString = "Data Source=api.db";
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            optionsBuilder.UseSqlite(connectionString);
            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
