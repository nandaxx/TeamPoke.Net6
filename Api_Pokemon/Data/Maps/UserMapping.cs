using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.Maps
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("idUser")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("name");

            builder.HasMany(x => x.Pokemons)
               .WithOne(s => s.User)
               .HasForeignKey(s => s.User.Id);
        }
    }
}
