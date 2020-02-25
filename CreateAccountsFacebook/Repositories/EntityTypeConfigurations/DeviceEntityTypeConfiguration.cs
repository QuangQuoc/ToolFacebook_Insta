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
    public class DeviceEntityTypeConfiguration : EntityTypeConfiguration<Device>
    {
        public DeviceEntityTypeConfiguration()
        {
            this.ToTable("devices");
            this.HasKey(d => d.Id);
            this.Property(d => d.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(d => d.Name)
                .HasColumnName("name")
                .HasMaxLength(255);

            this.Property(d => d.Status)
                .HasColumnName("status");

            this.Property(d => d.HostId)
                .HasColumnName("host_id");
            this.HasRequired<Host>(d => d.Host)
                .WithMany(h => h.Devices)
                .HasForeignKey(d => d.HostId);
        }
    }
}
