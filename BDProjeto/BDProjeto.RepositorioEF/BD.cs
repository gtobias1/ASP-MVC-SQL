using BDProjeto.DTO.ExemploBD;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BDProjeto.RepositorioEF
{
    public class BD : DbContext
    {
        public DbSet<Usuarios> usuario { get; set; }

        public BD() : base("ExemploBD")
        {
        
        }

        //Cria o modelo do banco de dados (campo)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Linha que remove a pluralização no nome das tabelas (tira o "s")
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Usuarios>().Property(t => t.USUARIO_ID).IsRequired().HasColumnType("int");
            modelBuilder.Entity<Usuarios>().Property(t => t.NOME).IsRequired().HasColumnType("varchar").HasMaxLength(125);
            modelBuilder.Entity<Usuarios>().Property(t => t.CARGO).IsRequired().HasColumnType("varchar").HasMaxLength(200);
            modelBuilder.Entity<Usuarios>().Property(t => t.DATAINSERCAO).IsRequired().HasColumnType("date");
        }
    }
}