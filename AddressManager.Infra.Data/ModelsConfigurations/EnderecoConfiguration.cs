using AddressManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AddressManager.Infra.Data.ModelsConfigurations
{
    internal class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.cep).HasMaxLength(8).IsRequired();
            builder.Property(x => x.Bairro).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Localidade).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Logradouro).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Complemento).HasMaxLength(100);
            builder.Property(x => x.Uf).HasMaxLength(2).IsRequired();
            builder.Property(x => x.Ibge).HasMaxLength(7);
            builder.Property(x => x.Gia).HasMaxLength(4);
            builder.Property(x => x.Ddd).HasMaxLength(2);
            builder.Property(x => x.Siafi).HasMaxLength(4);
        }
    }
}
