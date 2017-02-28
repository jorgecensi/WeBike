using System;
using System.Web.Mvc;
using WeBikeWeb.Aplicacao;

namespace Webikeweb.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly UsuarioAppServico _usuarioAppServico = new UsuarioAppServico();

      
        // GET: Usuarios
        public ActionResult Index()
        {
            return View(_usuarioAppServico.ObterTodos());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_usuarioAppServico.ObterPorId(id));
        }

       
    }
}