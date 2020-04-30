namespace RejestrZaginionych.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RejestrZaginionych.Models.MissingPersonListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RejestrZaginionych.Models.MissingPersonListContext context)
        {
            context.Database.ExecuteSqlCommand("DELETE FROM Users WHERE login = 'test'");
            context.Database.ExecuteSqlCommand("DELETE FROM Users WHERE login = 'admin'");


            context.Database.ExecuteSqlCommand("INSERT INTO Users (FirstName,LastName,UserType,Active,login,password,Email) VALUES(\'Użytkownik\',\'Testowy\',1,1,\'test\',\'tUppqpbvlASW4rFBrAJ9VsWkWGVE37t2b+VUWRYLCXqKqqOyv6i3NLZvKQyNkVJvBG4HeAq6yAWwGXzbFiQGdw==',\'test@rejestr.pl\')");
            context.Database.ExecuteSqlCommand("INSERT INTO Users (FirstName,LastName,UserType,Active,login,password,Email) VALUES (\'Administrator\',\'Administrujący\',2,1,\'admin\',\'tUppqpbvlASW4rFBrAJ9VsWkWGVE37t2b+VUWRYLCXqKqqOyv6i3NLZvKQyNkVJvBG4HeAq6yAWwGXzbFiQGdw==',\'admin@rejestr.pl\')");
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
