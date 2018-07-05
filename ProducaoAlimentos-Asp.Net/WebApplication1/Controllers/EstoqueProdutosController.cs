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
    public class EstoqueProdutosController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Index()
        {
            var estoqueProdutos = db.EstoqueProdutos.Include(e => e._Produto);
            return View(estoqueProdutos.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstoqueProduto estoqueProduto = db.EstoqueProdutos.Find(id);
            if (estoqueProduto == null)
            {
                return HttpNotFound();
            }
            return View(estoqueProduto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool Create([Bind(Include = "ID,ProdutoID,QtdeTotalEstoque,CustoTotalEstoque")] EstoqueProduto estoqueProduto)
        {
            if (ModelState.IsValid)
            {
                db.EstoqueProdutos.Add(estoqueProduto);
                db.SaveChanges();
                return true;
            }

            return false;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool Edit([Bind(Include = "ID,ProdutoID,QtdeTotalEstoque,CustoTotalEstoque")] EstoqueProduto estoqueProduto)
        {
            EstoqueProduto estoqueProdutoEditar = db.EstoqueProdutos.Find(estoqueProduto.ID);

            estoqueProdutoEditar.QtdeTotalEstoque = estoqueProduto.QtdeTotalEstoque;
            estoqueProdutoEditar.CustoTotalEstoque = estoqueProduto.CustoTotalEstoque;

            if (ModelState.IsValid)
            {
                db.Entry(estoqueProdutoEditar).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstoqueProduto estoqueProduto = db.EstoqueProdutos.Find(id);
            if (estoqueProduto == null)
            {
                return HttpNotFound();
            }
            return View(estoqueProduto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstoqueProduto estoqueProduto = db.EstoqueProdutos.Find(id);
            db.EstoqueProdutos.Remove(estoqueProduto);
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
