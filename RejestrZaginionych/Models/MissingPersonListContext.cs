namespace RejestrZaginionych.Models {
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MissingPersonListContext : DbContext {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'RejestrZaginionych.Views.Home.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public MissingPersonListContext()
            : base("name=RejestrZaginionych") {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<MissingPerson> MissingPersons { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<User>()
           .HasIndex(p => new { p.Login, p.Email})
           .IsUnique(true);
        }

    }

    
}