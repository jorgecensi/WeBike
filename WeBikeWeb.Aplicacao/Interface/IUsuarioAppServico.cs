using System;
using System.Collections.Generic;
using WeBikeWeb.Aplicacao.ViewModels;


namespace WeBikeWeb.Aplicacao.Interface
{
    public interface IUsuarioAppServico : IDisposable
    {
        UsuarioViewModel Adicionar(UsuarioViewModel usuarioViewModel);
        UsuarioViewModel ObterPorId(Guid id);
        IEnumerable<UsuarioViewModel> ObterTodos();
        UsuarioViewModel Atualizar(UsuarioViewModel usuarioViewModel);
        void Remover(Guid id);
    }
}
