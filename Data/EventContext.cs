namespace EventManagement.Data
{
    using eventGestion.Models.EventItems;
    using EventManagement.Models;
    using Microsoft.EntityFrameworkCore;

    public class EventContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public EventContext(DbContextOptions<EventContext> options)
        : base(options)
        { }

        public DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Participants)  
                .WithOne(p => p.Event)         
                .HasForeignKey(p => p.EventId); 
        }
    }
}

