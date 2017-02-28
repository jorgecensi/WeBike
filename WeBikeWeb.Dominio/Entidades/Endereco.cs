
using System;

namespace WeBikeWeb.Dominio.Entidades
{
    
    public class Endereco
    {
        public Endereco()
        {
            EnderecoId = Guid.NewGuid();
          
        }
        public Guid EnderecoId { get; set; }
        public string Pais { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string RuaProxima { get; set; }
       


    }
}