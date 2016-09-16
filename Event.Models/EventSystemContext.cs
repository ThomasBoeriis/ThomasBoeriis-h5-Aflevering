namespace Event.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EventSystemContext : DbContext
    {
        public EventSystemContext()
            : base("name=EventModel")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<EventsInOrders> EventsInOrders { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<MediaTypes> MediaTypes { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Categories)
                .HasForeignKey(e => e.FK_Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customers)
                .HasForeignKey(e => e.FK_Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Events>()
                .HasMany(e => e.EventsInOrders)
                .WithRequired(e => e.Events)
                .HasForeignKey(e => e.FK_Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Events>()
                .HasMany(e => e.Media)
                .WithRequired(e => e.Events)
                .HasForeignKey(e => e.FK_Event)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Events>()
            //    .HasRequired(p => p.Location)
            //    .WithMany(s => s.Events)
            //    .HasForeignKey(p => p.FK_Location);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Location)
                .HasForeignKey(e => e.FK_Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MediaTypes>()
                .HasMany(e => e.Media)
                .WithRequired(e => e.MediaTypes)
                .HasForeignKey(e => e.FK_Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.EventsInOrders)
                .WithRequired(e => e.Orders)
                .HasForeignKey(e => e.FK_Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Status)
                .HasForeignKey(e => e.FK_Status)
                .WillCascadeOnDelete(false);
        }
    }
}
