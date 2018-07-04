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

        // GET: EstoqueProdutos
        public ActionResult Index()
        {
            var estoqueProdutos = db.EstoqueProdutos.Include(e => e._Produto);
            return View(estoqueProdutos.ToList());
        }

        // GET: EstoqueProdutos/Details/5
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

        // GET: EstoqueProdutos/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome");
            return View();
        }

        // POST: EstoqueProdutos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProdutoID,QtdeTotalEstoque,CustoTotalEstoque")] EstoqueProduto estoqueProduto)
        {
            if (ModelState.IsValid)
            {
                db.EstoqueProdutos.Add(estoqueProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome", estoqueProduto.ProdutoID);
            return View(estoqueProduto);
        }

        // GET: EstoqueProdutos/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome", estoqueProduto.ProdutoID);
            return View(estoqueProduto);
        }

        // POST: EstoqueProdutos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProdutoID,QtdeTotalEstoque,CustoTotalEstoque")] EstoqueProduto estoqueProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estoqueProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome", estoqueProduto.ProdutoID);
            return View(estoqueProduto);
        }

        // GET: EstoqueProdutos/Delete/5
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

        // POST: EstoqueProdutos/Delete/5
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
/*
        public EstoqueProduto BuscarEstoqueProdutoPorNome(string nomeProduto)
        {
            var ep = from x in db.EstoqueProdutos.ToList()
                     where x._Produto.Nome.Equals(nomeProduto)
                     select x;
            if (ep != null)
                return ep.FirstOrDefault();
            else
                return null;
        }

        public void RegistrarEstoqueProduto(MovimentacaoEstoqueProduto mep)
        {
            LotesProdutosController lpc = new LotesProdutosController();
            LoteProduto loteProduto = lpc.BuscarLoteProdutoPorID(mep.LoteProdutoID);

            EstoqueProduto estoqueProduto = BuscarEstoqueProdutoPorNome(loteProduto._Produto.Nome);

            if (estoqueProduto != null)
            {
                estoqueProduto.QtdeTotalEstoque += mep.Qtde;
                estoqueProduto.CustoTotalEstoque += mep.ValorMovimentacao;

                db.Entry(estoqueProduto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                estoqueProduto = new EstoqueProduto();

                estoqueProduto.QtdeTotalEstoque = mep.Qtde;
                estoqueProduto.CustoTotalEstoque = mep.ValorMovimentacao;
                estoqueProduto.ProdutoID = loteProduto.ProdutoID;

                db.EstoqueProdutos.Add(estoqueProduto);
                db.SaveChanges();
            }
        }
        */

    }
}
