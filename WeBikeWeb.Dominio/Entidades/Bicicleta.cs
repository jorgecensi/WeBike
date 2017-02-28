
using System;
namespace WeBikeWeb.Dominio.Entidades
{
    public class Bicicleta
    {
        public Bicicleta()
        {
            BicicletaId = Guid.NewGuid();
            Endereco = new Endereco();
            
        }
        public Guid BicicletaId { get; set; }
        public string Nome { get; set; }      
        public decimal Aro { get; set; }       
        public decimal Quadro { get; set; }       
        public decimal VlHora { get; set; }     
        public decimal VlDia { get; set; }        
        public decimal VlSemana { get; set; }        
        public string Fotos { get; set; }        
        public bool Entrega { get; set; }
        public DateTime DataCadastro { get; set; }

        public Guid EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        
    }
}
