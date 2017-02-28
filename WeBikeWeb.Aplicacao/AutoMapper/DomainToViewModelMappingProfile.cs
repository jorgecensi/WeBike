using AutoMapper;
using WeBikeWeb.Aplicacao.ViewModels;
using WeBikeWeb.Dominio.Entidades;

namespace WeBikeWeb.Aplicacao.AutoMapper
{
    public class DomainToViewModelMappingProfile:Profile
    {
        protected override void Configure()
        {
            CreateMap<Bicicleta, BicicletaViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Bicicleta, AdicionarBicicletaViewModel>();
            CreateMap<Endereco, AdicionarBicicletaViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
