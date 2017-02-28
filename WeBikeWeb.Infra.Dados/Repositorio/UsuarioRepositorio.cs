using System;
using System.Collections.Generic;
using WeBikeWeb.Dominio.Entidades;
using WeBikeWeb.Dominio.Interfaces.Repositorio;

namespace WeBikeWeb.Infra.Dados.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
    }
}
