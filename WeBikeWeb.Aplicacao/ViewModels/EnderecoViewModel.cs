
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WeBikeWeb.Aplicacao.ViewModels
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel()
        {
            EnderecoId = Guid.NewGuid();
        }

        [Key]
        public Guid EnderecoId { get; set; }

        [Required(ErrorMessage ="Preencha o campo País")]
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
    }
}
