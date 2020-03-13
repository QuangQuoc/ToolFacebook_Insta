using CreateAccountsProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlLdPlayer.Repositories.EntityTypeConfigurations
{
    public class HostEntityTypeConfiguration : EntityTypeConfiguration<Host>
    {
        public HostEntityTypeConfiguration()
        {
            this.ToTable("hosts");
            this.HasKey(h => h.Id);
            this.Property(h => h.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
            this.Property(h => h.Name)
                .HasColumnName("name")
                .HasMaxLength(255);
        }
    }
}
