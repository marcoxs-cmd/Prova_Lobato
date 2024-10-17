using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Exemplo6;

public class Genero
{
    public int GeneroID { get; set; }
    public string Nome { get; set; }
    public ICollection<LivroGenero> Livros { get; set; }

    public Genero()
    {
    }
}

public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder.Property(p => p.Nome).IsRequired().HasMaxLength(80);
    }
}