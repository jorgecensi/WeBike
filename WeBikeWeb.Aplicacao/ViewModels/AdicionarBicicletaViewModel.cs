

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WeBikeWeb.Aplicacao.ViewModels
{
    public class AdicionarBicicletaViewModel
    {
        public AdicionarBicicletaViewModel()
        {
            BicicletaId = Guid.NewGuid();
            EnderecoId = Guid.NewGuid();

        }

        [Key]
        public Guid BicicletaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome da Bicicleta.")]
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

        //ENDERECO---------------------------------

        [Key]
        public Guid EnderecoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo País")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Preencha o campo Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo Estado")]
        public string Estado { get; set; }

        public string Cep { get; set; }

        [DisplayName("Rua Proxima")]
        [Required(ErrorMessage = "Preencha o campo Rua Proxima")]
        public string RuaProxima { get; set; }

        //USUARIO

        public string UsuarioId { get; set; }
       
    }
}
