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
    public class InsumosComposicaoProdutosController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome");
                ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }

            List<Produto> produtos = new List<Produto>();
            produtos.Add(produto);

            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome");
            ViewBag.ProdutoID = new SelectList(produtos, "ProdutoID", "Nome");
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsumoComposicaoProdutoID,QtdeInsumo,InsumoID,ProdutoID")] InsumoComposicaoProduto insumoComposicaoProduto)
        {
            if (ModelState.IsValid)
            {
                db.InsumosComposicaoProdutos.Add(insumoComposicaoProduto);
                db.SaveChanges();
                return RedirectToAction("Edit", "Produtos", new { @id = insumoComposicaoProduto.ProdutoID });
            }
            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome", insumoComposicaoProduto.InsumoID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome", insumoComposicaoProduto.ProdutoID);
            return RedirectToAction("Create", "InsumosComposicaoProdutos", new { @id = insumoComposicaoProduto.ProdutoID });
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsumoComposicaoProduto insumoComposicaoProduto = db.InsumosComposicaoProdutos.Find(id);
            if (insumoComposicaoProduto == null)
            {
                return HttpNotFound();
            }
            List<Produto> produtos = new List<Produto>();
            produtos.Add(insumoComposicaoProduto._Produto);

            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome", insumoComposicaoProduto.InsumoID);
            ViewBag.ProdutoID = new SelectList(produtos, "ProdutoID", "Nome", insumoComposicaoProduto.ProdutoID);
            return PartialView(insumoComposicaoProduto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsumoComposicaoProdutoID,QtdeInsumo,InsumoID,ProdutoID")] InsumoComposicaoProduto insumoComposicaoProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insumoComposicaoProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "Produtos", new { @id = insumoComposicaoProduto.ProdutoID });
            }
            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome", insumoComposicaoProduto.InsumoID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome", insumoComposicaoProduto.ProdutoID);
            return PartialView(insumoComposicaoProduto);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsumoComposicaoProduto insumoComposicaoProduto = db.InsumosComposicaoProdutos.Find(id);
            if (insumoComposicaoProduto == null)
            {
                return HttpNotFound();
            }
            return PartialView(insumoComposicaoProduto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InsumoComposicaoProduto insumoComposicaoProduto = db.InsumosComposicaoProdutos.Find(id);

            int produtoID = insumoComposicaoProduto.ProdutoID;

            db.InsumosComposicaoProdutos.Remove(insumoComposicaoProduto);
            db.SaveChanges();
            return RedirectToAction("Edit", "Produtos", new { @id = insumoComposicaoProduto.ProdutoID });
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
