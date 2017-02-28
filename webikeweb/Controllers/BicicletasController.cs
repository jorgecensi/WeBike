using Microsoft.AspNet.Identity;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeBikeWeb.Aplicacao;
using WeBikeWeb.Aplicacao.ViewModels;


namespace WeBikeWeb.Controllers
{
   
    public class BicicletasController : Controller
    {
        private readonly BicicletaAppServico _bicicletaAppServico = new BicicletaAppServico();

        public ActionResult Busca()
        {
            return View(_bicicletaAppServico.ObterTodos());
        }

        [Authorize]
        // GET: Bicicletas
        public ActionResult Index()
        {
            return View(_bicicletaAppServico.ObterPorUsuario(User.Identity.GetUserId().ToString()));
        }

       
        [Authorize]
        // GET: Bicicletas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bicicletaViewModel = _bicicletaAppServico.ObterPorId(id.Value);
            if (bicicletaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bicicletaViewModel);
        }
        [Authorize]
        // GET: Bicicletas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bicicletas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // para não receber injeção de html usar  public ActionResult Create([Bind(Include = "BicicletaId,Nome,Aro,Quadro,VlHora,VlDia,VlSemana,Fotos,Entrega")] BicicletaViewModel bicicletaViewModel)
        [HttpPost]
        [Authorize]
        // [ValidateAntiForgeryToken]
        public ActionResult Create( AdicionarBicicletaViewModel adicionarBicicletaViewModel)
        {
            if (ModelState.IsValid)
            {

                HttpPostedFileBase arquivo;
                if (Request.Files.Count > 0)
                {
                    //recupera o primerio arquivo carregado em tela
                    arquivo = Request.Files[0];
                    if (arquivo != null)
                    {
                        //salva o arquivo no servidor
                        arquivo.SaveAs(HttpContext.Server.MapPath("~/Img/Bikes/")
                                                             + arquivo.FileName);
                        //atribui o caminho do arquivo no atributo da classe bicicleta
                        adicionarBicicletaViewModel.Fotos = "Img/Bikes/" + arquivo.FileName;
                    }
                }

                //associa o usuario
              
                adicionarBicicletaViewModel.UsuarioId =  User.Identity.GetUserId().ToString();
                _bicicletaAppServico.Adicionar(adicionarBicicletaViewModel);
                return RedirectToAction("Index");
            }

            return View(adicionarBicicletaViewModel);
        }
        [Authorize]
        // GET: Bicicletas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Não esta funcionando!!!!!!!!!
            // tenho que dar um jeito de mapear duas classes de dominio em uma classe ViewModel
            var bicicletaViewModel = _bicicletaAppServico.ObterPorId(id.Value);
            if (bicicletaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bicicletaViewModel);
        }

        // POST: Bicicletas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdicionarBicicletaViewModel adicionarBicicletaViewModel)
        {
            if (ModelState.IsValid)
            {
                _bicicletaAppServico.Atualizar(adicionarBicicletaViewModel);
                return RedirectToAction("Index");
            }
            return View(adicionarBicicletaViewModel);
        }
        [Authorize]
        // GET: Bicicletas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bicicletaViewModel = _bicicletaAppServico.ObterPorId(id.Value);
            if (bicicletaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bicicletaViewModel);
        }

        // POST: Bicicletas/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _bicicletaAppServico.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bicicletaAppServico.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
