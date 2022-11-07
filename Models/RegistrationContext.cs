﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace SkiService.Models
{
    public class RegistrationContext : DbContext
    {
        RegistrationContext()
        {
        }

        public RegistrationContext(DbContextOptions<RegistrationContext> options)
            : base(options)
        {
        }


        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Status> Status { get; set; }= null!;
    }

}