
using System;
using System.Collections.Generic;
using WeBikeWeb.Aplicacao.ViewModels;

namespace WeBikeWeb.Aplicacao.Interface
{
    public interface IBicicletaAppServico: IDisposable
    {

        AdicionarBicicletaViewModel Adicionar(AdicionarBicicletaViewModel adicionarBicicletaViewModel);
        BicicletaViewModel ObterPorAro(decimal aro);
        BicicletaViewModel ObterPorQuadro(decimal quadro);
        BicicletaViewModel ObterPorEntrega(bool entrega);
        BicicletaViewModel ObterPorId(Guid id);
        IEnumerable<BicicletaViewModel> ObterPorUsuario(string id);
        IEnumerable<BicicletaViewModel> ObterTodos();
        AdicionarBicicletaViewModel Atualizar(AdicionarBicicletaViewModel adicionarBicicletaViewModel);
        void Remover(Guid id);
    }
}
