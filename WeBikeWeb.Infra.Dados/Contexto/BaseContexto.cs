

using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using WeBikeWeb.Dominio.Entidades;
using WeBikeWeb.Infra.Dados.ConfigEntidades;

namespace WeBikeWeb.Infra.Dados.Contexto
{
    public class BaseContexto : DbContext
    {
        public BaseContexto():base("DefaultConnection")
        {
            Database.SetInitializer<BaseContexto>(null);
        }
        static BaseContexto()
        {
           DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remover as convenção que não se aplicam ao projeto
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Toda propriedade que tiver o mesmo nome da classe + Id será considerado chave da tabela
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //toda propriedade string será criada como campo varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //toda propriedade string que não tiver o tamanho definido, será criado com o tamanho de 100
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            // adiciona as configurações de banco das tabelas
            modelBuilder.Configurations.Add(new BicicletaConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());



            // modelBuilder.Entity<ApplicationUser>().ToTable("Usuario");

            // modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            // modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //  modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Bicicleta> Bicicletas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        

        public static BaseContexto Create()
        {
            return new BaseContexto();
        }
        public override int SaveChanges()
        {
            //sempre que tiver um campo chamado DataCadastro, 
            //na primeira vez ele irá atribuir a hora local do servidor
            //nas próximas vezes ele não altera o campo
            foreach(var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if(entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }

            }
            return base.SaveChanges();
        }
    }
}