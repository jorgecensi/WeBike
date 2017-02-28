

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WeBikeWeb.Dominio.Interfaces.Repositorio
{
    public interface IRepositorio<T> : IDisposable where T:class
    {
        T Adicionar(T obj);
        T ObterPorId(Guid id);
        IEnumerable<T> ObterTodos();
        T Atualizar(T obj);
        void Remover(Guid id);
        IEnumerable<T> Buscar(Expression<Func<T, bool>> predicate);
        int SaveChanges();
    }
}
