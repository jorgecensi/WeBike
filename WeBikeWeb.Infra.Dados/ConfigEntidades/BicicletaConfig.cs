
using System.Data.Entity.ModelConfiguration;
using WeBikeWeb.Dominio.Entidades;

namespace WeBikeWeb.Infra.Dados.ConfigEntidades
{
    public class BicicletaConfig:EntityTypeConfiguration<Bicicleta>
    {
        public BicicletaConfig()
        {
            //define chave primaria
            HasKey(b => b.BicicletaId);

            //define alguns atributos da propriedade
            Property(b => b.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(b => b.VlDia)
                .IsRequired();

            Property(b => b.VlHora)
                .IsRequired();

            Property(b => b.VlSemana)
                .IsRequired();
           
            //relacionamento com o Endereco
            HasRequired(b => b.Endereco);

            HasRequired(u => u.Usuario)
                .WithMany(u => u.Bicicletas)
                .HasForeignKey(u => u.UsuarioId);


            ToTable("Bicicletas");

        }
    }
}
