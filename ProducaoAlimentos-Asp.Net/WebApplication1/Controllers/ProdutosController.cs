using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class ProdutosController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Index()
        {
            var produtos = db.Produtos.OrderBy(p => p.Nome).ToList();
            return View(produtos);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return PartialView(produto);
        }

        public ActionResult Create()
        {
            ViewBag.UnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida, "UnidadeDeMedidaID", "Nome");
            ViewBag.InsumoID = new SelectList(db.Insumos.OrderBy(i => i.Nome), "InsumoID", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoID,Nome,UnidadeDeMedidaID,InsumoID")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Edit", "Produtos", new { @id = produto.ProdutoID });
            }
            ViewBag.UnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida, "UnidadeDeMedidaID", "Nome", produto.UnidadeDeMedidaID);
            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome");

            return View(produto);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida, "UnidadeDeMedidaID", "Nome", produto.UnidadeDeMedidaID);
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoID,Nome,UnidadeDeMedidaID")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Produtos", new { @id = produto.ProdutoID });
            }
            ViewBag.UnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida, "UnidadeDeMedidaID", "Nome", produto.UnidadeDeMedidaID);
            return View(produto);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return PartialView(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
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
