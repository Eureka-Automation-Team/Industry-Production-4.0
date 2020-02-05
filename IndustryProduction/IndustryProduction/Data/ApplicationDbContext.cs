using System;
using System.Collections.Generic;
using System.Text;
using IndustryProduction.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IndustryProduction.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MachineModel> Machines { get; set; }
        public virtual DbSet<JobEntityTaskModel> JobTasks { get; set; }
        public virtual DbSet<JobEntityModel> JobEntities { get; set; }
        public virtual DbSet<TaskLogsModel> TaskTransactionLogs { get; set; }
        public virtual DbSet<LocationModel> ShelfLocations { get; set; }
    }
}
