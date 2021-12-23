using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProvaCandidato.Data;
using ProvaCandidato.Data.Entidade;
using ProvaCandidato.ControladorBase;

namespace ProvaCandidato.Controllers
{
    public class ClientesController : BaseController<Cliente>
    {
        private ContextoPrincipal db = new ContextoPrincipal();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Cidade);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.CidadeId = new SelectList(db.Cidades, "Codigo", "Nome");
            return View();
        }

        // POST: Clientes/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nome,DataNascimento,CidadeId,Ativo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();

                TempData["UserMessage"] = "Cliente Incluido com sucesso.";

                return RedirectToAction("Index");
            }

            ViewBag.CidadeId = new SelectList(db.Cidades, "Codigo", "Nome", cliente.CidadeId);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeId = new SelectList(db.Cidades, "Codigo", "Nome", cliente.CidadeId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nome,DataNascimento,CidadeId,Ativo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();

                TempData["UserMessage"] = "Cliente alterado com sucesso.";

                return RedirectToAction("Index");
            }
            ViewBag.CidadeId = new SelectList(db.Cidades, "Codigo", "Nome", cliente.CidadeId);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();

            TempData["UserMessage"] = "Cliente deletado com sucesso.";

            return RedirectToAction("Index");
        }

        public ActionResult Pesquisar(string pesquisar)
        {
            var clientes = new List<Cliente>();
            if (string.IsNullOrEmpty(pesquisar))
            {
                clientes = db.Clientes.Include(c => c.Cidade).ToList();
            }
            else
            {
                clientes = db.Clientes.Include(c => c.Cidade).Where(c => c.Nome.Contains(pesquisar)).ToList();
            }
            
            return View("Index", clientes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
