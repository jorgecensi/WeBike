
using System;
using System.Collections.Generic;
using WeBikeWeb.Aplicacao.Interface;
using WeBikeWeb.Aplicacao.ViewModels;
using WeBikeWeb.Dominio.Entidades;
using WeBikeWeb.Infra.Dados.Repositorio;
using AutoMapper;

namespace WeBikeWeb.Aplicacao
{
    public class BicicletaAppServico : IBicicletaAppServico
    {
        private readonly BicicletaRepositorio _bicicletaRepositorio = new BicicletaRepositorio();

        public AdicionarBicicletaViewModel Adicionar(AdicionarBicicletaViewModel adicionarBicicletaViewModel)
        {
            var bicicleta = Mapper.Map<AdicionarBicicletaViewModel, Bicicleta>(adicionarBicicletaViewModel);

            var endereco = Mapper.Map<AdicionarBicicletaViewModel, Endereco>(adicionarBicicletaViewModel);

            bicicleta.Endereco = endereco;
            _bicicletaRepositorio.Adicionar(bicicleta);

            return adicionarBicicletaViewModel;
        }

        public AdicionarBicicletaViewModel Atualizar(AdicionarBicicletaViewModel adicionarBicicletaViewModel)
        {
            var bicicleta = Mapper.Map<AdicionarBicicletaViewModel, Bicicleta>(adicionarBicicletaViewModel);
            var endereco = Mapper.Map<AdicionarBicicletaViewModel, Endereco>(adicionarBicicletaViewModel);
            bicicleta.Endereco = endereco;
            _bicicletaRepositorio.Atualizar(bicicleta);
            return adicionarBicicletaViewModel;
        }

       

        public BicicletaViewModel ObterPorAro(decimal aro)
        {
            return Mapper.Map<Bicicleta, BicicletaViewModel>(_bicicletaRepositorio.ObterPorAro(aro));
        }

        public BicicletaViewModel ObterPorEntrega(bool entrega)
        {
            return Mapper.Map<Bicicleta, BicicletaViewModel>(_bicicletaRepositorio.ObterPorEntrega(entrega));
        }

        public BicicletaViewModel ObterPorId(Guid id)
        {
            
            return Mapper.Map<Bicicleta, BicicletaViewModel>(_bicicletaRepositorio.ObterPorId(id));
        }

        public BicicletaViewModel ObterPorQuadro(decimal quadro)
        {
            return Mapper.Map<Bicicleta, BicicletaViewModel>(_bicicletaRepositorio.ObterPorQuadro(quadro));
        }

        public IEnumerable<BicicletaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Bicicleta>, IEnumerable<BicicletaViewModel>>(_bicicletaRepositorio.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _bicicletaRepositorio.Remover(id);
        }

        public void Dispose()
        {
            _bicicletaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<BicicletaViewModel> ObterPorUsuario(string id)
        {
            return Mapper.Map<IEnumerable<Bicicleta>, IEnumerable<BicicletaViewModel>>(_bicicletaRepositorio.ObterPorUsuario(id));
        }
    }
}
