
using System;
using System.Collections.Generic;
using System.Linq;
using WeBikeWeb.Dominio.Entidades;
using WeBikeWeb.Dominio.Interfaces.Repositorio;

namespace WeBikeWeb.Infra.Dados.Repositorio
{
    public class BicicletaRepositorio : Repositorio<Bicicleta>, IBicicletaRepositorio
    {
        public Bicicleta ObterPorAro(decimal aro)
        {
            return Buscar(b => b.Aro == aro).FirstOrDefault();
        }

        public Bicicleta ObterPorEntrega(bool entrega)
        {
            throw new NotImplementedException();
        }

        public Bicicleta ObterPorQuadro(decimal quadro)
        {
            throw new NotImplementedException();
        }

       
        public IEnumerable<Bicicleta> ObterPorUsuario(string usuario)
        {
            return Buscar(b => b.UsuarioId == usuario).ToList();
        }
    }
}
