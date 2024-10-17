using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Exemplo6;

public class Autor
{
    public int AutorID { get; set; }
    public string Nome { get; set; }
    public DateOnly? DataNascimento { get; set; }
    public Endereco Endereco { get; set; }
    public ICollection<Livro> Livros { get; set; }
}

public class AutorConfiguration : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> builder)
    {
        builder.HasIndex(p => p.Nome);
        builder.Property(p => p.Nome).HasMaxLength(80).IsRequired();
        builder.HasOne<Endereco>(p => p.Endereco).WithOne(p => p.Autor).
            HasForeignKey<Endereco>(p => p.AutorID);
        builder.HasMany(p => p.Livros).WithOne(p => p.Autor).OnDelete(DeleteBehavior.Cascade);
    }
}