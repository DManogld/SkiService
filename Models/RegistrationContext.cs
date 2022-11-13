using Microsoft.EntityFrameworkCore;

namespace SkiService.Models
{
    /// <summary>
    /// Klasse für erstellen von Datenbanken
    /// </summary>
    public class RegistrationContext : DbContext
    {
        /// <summary>
        /// Leerer Konstruktor
        /// </summary>
        RegistrationContext()
        {
        }

        /// <summary>
        /// Konstruktor für Instaziierung
        /// </summary>
        /// <param name="options"></param>
        public RegistrationContext(DbContextOptions<RegistrationContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Status> Status { get; set; }= null!;
        public DbSet<Mitarbeiter> Mitarbeiters { get; set; }

    }

}
