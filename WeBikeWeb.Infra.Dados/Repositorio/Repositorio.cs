

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WeBikeWeb.Dominio.Interfaces.Repositorio;
using WeBikeWeb.Infra.Dados.Contexto;

namespace WeBikeWeb.Infra.Dados.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected BaseContexto Db;
        protected DbSet<T> DbSet;

        public Repositorio()
        {
            Db = new BaseContexto();
            DbSet = Db.Set<T>();
        }

        public virtual T Adicionar(T obj)
        {
            var objReturn = DbSet.Add(obj);
            SaveChanges();
            return objReturn;
        }

        public virtual T Atualizar(T obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();

            return obj;
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual T ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<T> ObterTodos()
        {
            //serve para paginar  busca de todos os registros
            //Take é a quantidade de registros que vai buscar
            //Skip é a partir de qual registro ele vai buscar
            //return DbSet.Take(qtd).Skip(pula).ToList();

            //retorna tudo
            return DbSet.ToList();
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(ObterPorId(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}
