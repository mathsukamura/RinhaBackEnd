using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RinhaBackEnd.Models.Client;

namespace RinhaBackEnd.Infra.Context.Map;

public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cliente");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Limite)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.Saldo)
            .HasColumnType("int")
            .IsRequired();
        
        builder.Property<uint>("Xmin").IsRowVersion();
    }
}