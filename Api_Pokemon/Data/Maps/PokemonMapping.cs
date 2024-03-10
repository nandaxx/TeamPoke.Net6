using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.Maps
{
    public class PokemonMapping : IEntityTypeConfiguration<Pokemon>
    {
        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            builder.ToTable("pokemon");
            builder.HasKey(x => x.IdIdentification);

            builder.Property(x => x.IdIdentification)
                .HasColumnName("idIdentificationPokemon")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("name");
            
            builder.Property(x => x.Id)
               .HasColumnName("IdPokedex");

            builder.Property(x => x.Weight)
                .HasColumnName("weight"); 
            
            builder.Property(x => x.Height)
                .HasColumnName("height");

            builder.Property(x => x.User.Id).HasColumnName("idUser");

        } 
    }
}
