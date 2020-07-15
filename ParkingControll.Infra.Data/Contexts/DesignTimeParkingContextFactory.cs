using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ParkingControll.Infra.CrossCutting.Constants;
using System;

namespace ParkingControll.Infra.Data.Contexts
{
    public class DesignTimeParkingContextFactory : IDesignTimeDbContextFactory<ParkingContext>
    {
        public ParkingContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ParkingContext> optionsBuilder = new DbContextOptionsBuilder<ParkingContext>();
            optionsBuilder.UseSqlServer(Consts.ConnectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));

            return new ParkingContext(optionsBuilder.Options);
        }
    }
}
