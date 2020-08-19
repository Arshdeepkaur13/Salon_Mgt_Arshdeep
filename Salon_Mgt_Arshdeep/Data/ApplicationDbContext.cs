using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Salon_Mgt_Arshdeep.Models;

namespace Salon_Mgt_Arshdeep.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Staff_Mst> Staff_Msts { get; set; }
        public DbSet<Customer_Mst> Customer_Msts { get; set; }
        public DbSet<Appointment_Mst> Appointment_Msts { get; set; }
    }
}
