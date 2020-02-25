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
    public class AvatarEntityTypeConfiguration : EntityTypeConfiguration<Avatar>
    {
        public AvatarEntityTypeConfiguration()
        {
            this.ToTable("avatars");
            this.HasKey(a => a.Id);
            this.Property(a => a.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(a => a.Link)
                .HasColumnName("link");

            this.Property(a => a.UsingNumber)
                .HasColumnName("using_number");
        }
    }
}
