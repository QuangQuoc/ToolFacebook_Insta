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
    public class BrowserEntityTypeConfiguration : EntityTypeConfiguration<Browser>
    {
        public BrowserEntityTypeConfiguration()
        {
            this.ToTable("browsers");
            this.HasKey(b => b.Id);
            this.Property(b => b.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
            this.Property(b => b.Name)
                .HasColumnName("name")
                .HasMaxLength(255);
            this.Property(b => b.FileName)
                .HasColumnName("file_name");
            this.Property(b => b.Status)
                .HasColumnName("status");
            this.Property(b => b.DeviceId)
                .HasColumnName("device_id");
            this.HasRequired<Device>(b => b.Device)
                .WithMany(d => d.Browsers)
                .HasForeignKey(b => b.DeviceId);
        }
    }
}
