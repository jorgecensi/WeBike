using AutoMapper;
using WeBikeWeb.Aplicacao.ViewModels;
using WeBikeWeb.Dominio.Entidades;

namespace WeBikeWeb.Aplicacao.AutoMapper
{
    class ViewModelToDomainMappingProfile:Profile
    {
        protected override void Configure()
        {
            CreateMap<BicicletaViewModel, Bicicleta>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<AdicionarBicicletaViewModel, Bicicleta>();
            CreateMap<AdicionarBicicletaViewModel, Endereco>();
            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}
