using System;
using System.Collections.Generic;
using WeBikeWeb.Aplicacao.Interface;
using WeBikeWeb.Dominio.Entidades;
using WeBikeWeb.Infra.Dados.Repositorio;
using AutoMapper;
using WeBikeWeb.Aplicacao.ViewModels;

namespace WeBikeWeb.Aplicacao
{
    public class UsuarioAppServico : IUsuarioAppServico
    {
        private readonly UsuarioRepositorio _usuarioRepositorio = new UsuarioRepositorio();

        public UsuarioViewModel Adicionar(UsuarioViewModel usuarioViewModel)
        {            
            _usuarioRepositorio.Adicionar(Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel));
            return usuarioViewModel;
        }

        public UsuarioViewModel Atualizar(UsuarioViewModel usuarioViewModel)
        {
            _usuarioRepositorio.Atualizar(Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel));
            return usuarioViewModel;
        }

        public void Dispose()
        {
            _usuarioRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public UsuarioViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(_usuarioRepositorio.ObterPorId(id));
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioRepositorio.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _usuarioRepositorio.Remover(id);
        }
    }
}
