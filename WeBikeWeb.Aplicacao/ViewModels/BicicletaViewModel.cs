
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WeBikeWeb.Aplicacao.ViewModels
{
    public class BicicletaViewModel
    {
        //Todos os campos declarados na classe Bicicleta devem ser reescritos aqui
        //colocando os dataAnnotations para a parte de apresentação

        public BicicletaViewModel()
        {
            BicicletaId = Guid.NewGuid();
        }
        [Key]
        public Guid BicicletaId { get; set; }

        [DisplayName("Nome da Bicicleta")]
        [StringLength(50, ErrorMessage = "O campo Nome permite no máximo 50 caracteres!")]
        public string Nome { get; set; }

        [DisplayName("Tamanho do Aro\"")]
        public decimal Aro { get; set; }

        [DisplayName("Tamanho do Quadro\"")]
        public decimal Quadro { get; set; }

        [DisplayName("Valor Hora (R$)")]
        public decimal VlHora { get; set; }

        [DisplayName("Valor Dia (R$)")]
        public decimal VlDia { get; set; }

        [DisplayName("Valor Semana (R$)")]
        public decimal VlSemana { get; set; }

        [DisplayName("Foto")]
        public string Fotos { get; set; }

        [DisplayName("Deseja entregar?")]
        public bool Entrega { get; set; }
        
    }
}
