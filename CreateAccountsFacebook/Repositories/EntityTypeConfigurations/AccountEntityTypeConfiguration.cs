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
    public class AccountEntityTypeConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountEntityTypeConfiguration()
        {
            this.ToTable("accounts");
            this.HasKey(a => a.Id);
            this.Property(a => a.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(a => a.UserName)
                .HasColumnName("user_name");
            this.Property(a => a.UserId)
                .HasColumnName("user_id");
            this.Property(a => a.Password)
                .HasColumnName("password");
            this.Property(a => a.FullName)
                .HasColumnName("full_name");
            this.Property(a => a.Email)
                .HasColumnName("email");
            this.Property(a => a.PhoneNumber)
                .HasColumnName("phone_number");
            this.Property(a => a.Fb2FACode)
                .HasColumnName("fb_2fa_code");
               
            this.HasRequired<Browser>(a => a.Browser)
                .WithRequiredPrincipal(b => b.Account);

            this.Property(a => a.BirthDay)
                .HasColumnName("birthday");
            this.Property(a => a.AvatarId)
                .HasColumnName("avatar_id");
            this.HasRequired<Avatar>(a => a.Avatar)
                .WithMany(av => av.Accounts)
                .HasForeignKey(a => a.AvatarId);
            this.Property(a => a.GioiTinh)
                .HasColumnName("gioi_tinh");
        }
    }
}
