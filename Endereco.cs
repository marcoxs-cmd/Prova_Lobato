using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Exemplo6;

public class Endereco
{
    public int EnderecoID { get; set; }
    public string Logradouro { get; set; }
    public string Cidade { get; set; }
    public string UF { get; set; }
    public string CEP { get; set; }
    public int AutorID { get; set; }
    public Autor Autor { get; set; }
}

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.Property(p => p.Logradouro).HasMaxLength(80).IsRequired();
        builder.Property(p => p.Cidade).HasMaxLength(40).IsRequired();
        builder.Property(p => p.UF).HasMaxLength(2).IsRequired();
        builder.Property(p => p.CEP).HasMaxLength(8).IsRequired();

    }
}