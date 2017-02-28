
using System.Data.Entity.ModelConfiguration;
using WeBikeWeb.Dominio.Entidades;

namespace WeBikeWeb.Infra.Dados.ConfigEntidades
{
    public class EnderecoConfig: EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.EnderecoId);

            Property(e => e.Pais)
                .IsRequired();

            Property(e => e.Estado)
                .IsRequired();

            Property(e => e.Cidade)
                .IsRequired();

            Property(e => e.Bairro)
                .IsRequired();

            Property(e => e.Logradouro)
                .IsRequired();

            Property(e => e.RuaProxima)
                .IsRequired();

            ToTable("Enderecos");

        }
    }
}
