namespace BackEnd_Ferry_Hundige
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Departure> Departures { get; set; }
        public virtual DbSet<Ferry> Ferries { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketType> TicketTypes { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.RefCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departure>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Departure)
                .HasForeignKey(e => e.RefDeparture)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departure>()
                .HasMany(e => e.Routes)
                .WithRequired(e => e.Departure)
                .HasForeignKey(e => e.RefDeparture)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ferry>()
                .HasMany(e => e.Departures)
                .WithRequired(e => e.Ferry)
                .HasForeignKey(e => e.SailingFerry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Price>()
                .HasMany(e => e.TicketTypes)
                .WithRequired(e => e.Price)
                .HasForeignKey(e => e.PriceOfTicket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.Prices)
                .WithRequired(e => e.Route)
                .HasForeignKey(e => e.ConnectedRoute)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vehicle>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Vehicle)
                .HasForeignKey(e => e.Transportation)
                .WillCascadeOnDelete(false);
        }
    }
}
