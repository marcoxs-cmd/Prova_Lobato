using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Exemplo6;

public class Livro
{
    public string ISBN { get; set; }
    public string Titulo { get; set; }
    public int? Paginas { get; set; }
    public Autor Autor { get; set; }
    public ICollection<LivroGenero> Generos { get; set; }
    public int Estoque { get; set; } 
}

public class LivroConfiguration : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        builder.HasKey(p => p.ISBN);
        builder.HasIndex(p => p.Titulo);
        builder.Property(p => p.ISBN).HasMaxLength(13).IsRequired();
        builder.Property(p => p.Titulo).HasMaxLength(120).IsRequired();
    }
}