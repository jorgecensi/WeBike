using System.Collections.Generic;
using WeBikeWeb.Dominio.Entidades;

namespace WeBikeWeb.Dominio.Interfaces.Repositorio
{
    public interface IBicicletaRepositorio : IRepositorio<Bicicleta>
    {
        Bicicleta ObterPorAro(decimal aro);
        Bicicleta ObterPorQuadro(decimal quadro);
        Bicicleta ObterPorEntrega(bool entrega);
        IEnumerable<Bicicleta> ObterPorUsuario(string usuario);
    }
}
