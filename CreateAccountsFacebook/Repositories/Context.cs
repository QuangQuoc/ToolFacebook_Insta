namespace CreateAccountsProject.Repositories
{
    using ControlLdPlayer.Repositories.EntityTypeConfigurations;
    using CreateAccountsProject.Models;
    using MySql.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Linq;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Context : DbContext
    {
        // Your context has been configured to use a 'DbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CreateAccountsProject.Repositories.DbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DbContext' 
        // connection string in the application configuration file.
        public Context()
            : base("name=MyContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Models.Browser> Browsers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<LDProperty> LDProperties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new AvatarEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new BrowserEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new DeviceEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new HostEntityTypeConfiguration());
        }

        //public class MyEntity
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //}
    } 
}