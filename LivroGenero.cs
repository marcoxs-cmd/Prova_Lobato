using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Exemplo6;

public class LivroGenero
{
    public string ISBN { get; set; }
    public int GeneroID { get; set; }
    public Livro Livro { get; set; }
    public Genero Genero { get; set; }
}

public class LivroGeneroConfiguration : IEntityTypeConfiguration<LivroGenero>
{
    public void Configure(EntityTypeBuilder<LivroGenero> builder)
    {
        builder.HasKey(p => new { p.ISBN, p.GeneroID });
        
        builder.Property(p => p.ISBN).HasMaxLength(13).IsRequired();
        builder.Property(p => p.GeneroID).IsRequired();
        
        builder.HasOne<Livro>(p => p.Livro)
            .WithMany(p => p.Generos)
            .HasForeignKey(p => p.ISBN);
        builder.HasOne<Genero>(p => p.Genero)
            .WithMany(p => p.Livros)
            .HasForeignKey(p => p.GeneroID);
    }
}