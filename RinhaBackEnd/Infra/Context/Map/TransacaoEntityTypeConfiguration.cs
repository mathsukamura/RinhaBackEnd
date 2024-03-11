using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RinhaBackEnd.Models.Client;

namespace RinhaBackEnd.Infra.Context.Map;

public class TransacaoEntityTypeConfiguration : IEntityTypeConfiguration<Transacao>
{
    public void Configure(EntityTypeBuilder<Transacao> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Valor)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.Tipo)
            .HasColumnType("varchar(1)")
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnType("varchar(10)")
            .IsRequired();

        builder.HasOne(t => t.Cliente)
            .WithMany(c => c.Transacoes)
            .HasForeignKey(x => x.IdCliente);
    }
}