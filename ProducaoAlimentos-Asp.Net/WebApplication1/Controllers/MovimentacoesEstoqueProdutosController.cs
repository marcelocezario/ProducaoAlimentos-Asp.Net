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
    public class MovimentacoesEstoqueProdutosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: MovimentacoesEstoqueProdutos
        public ActionResult Index()
        {
            var movimentacoesEstoqueProdutos = db.MovimentacoesEstoqueProdutos.Include(m => m._LoteProduto);
            return View(movimentacoesEstoqueProdutos.ToList());
        }

        // GET: MovimentacoesEstoqueProdutos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoEstoqueProduto movimentacaoEstoqueProduto = db.MovimentacoesEstoqueProdutos.Find(id);
            if (movimentacaoEstoqueProduto == null)
            {
                return HttpNotFound();
            }
            return View(movimentacaoEstoqueProduto);
        }

        // GET: MovimentacoesEstoqueProdutos/Create
        public ActionResult Create()
        {
            ViewBag.LoteProdutoID = new SelectList(db.LotesProdutos, "ID", "ID");
            return View();
        }

        // POST: MovimentacoesEstoqueProdutos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LoteProdutoID,DataMovimentacao,Qtde,ValorMovimentacao")] MovimentacaoEstoqueProduto movimentacaoEstoqueProduto)
        {
            if (ModelState.IsValid)
            {
                db.MovimentacoesEstoqueProdutos.Add(movimentacaoEstoqueProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoteProdutoID = new SelectList(db.LotesProdutos, "ID", "ID", movimentacaoEstoqueProduto.LoteProdutoID);
            return View(movimentacaoEstoqueProduto);
        }

        // GET: MovimentacoesEstoqueProdutos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoEstoqueProduto movimentacaoEstoqueProduto = db.MovimentacoesEstoqueProdutos.Find(id);
            if (movimentacaoEstoqueProduto == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoteProdutoID = new SelectList(db.LotesProdutos, "ID", "ID", movimentacaoEstoqueProduto.LoteProdutoID);
            return View(movimentacaoEstoqueProduto);
        }

        // POST: MovimentacoesEstoqueProdutos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LoteProdutoID,DataMovimentacao,Qtde,ValorMovimentacao")] MovimentacaoEstoqueProduto movimentacaoEstoqueProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimentacaoEstoqueProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoteProdutoID = new SelectList(db.LotesProdutos, "ID", "ID", movimentacaoEstoqueProduto.LoteProdutoID);
            return View(movimentacaoEstoqueProduto);
        }

        // GET: MovimentacoesEstoqueProdutos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoEstoqueProduto movimentacaoEstoqueProduto = db.MovimentacoesEstoqueProdutos.Find(id);
            if (movimentacaoEstoqueProduto == null)
            {
                return HttpNotFound();
            }
            return View(movimentacaoEstoqueProduto);
        }

        // POST: MovimentacoesEstoqueProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovimentacaoEstoqueProduto movimentacaoEstoqueProduto = db.MovimentacoesEstoqueProdutos.Find(id);
            db.MovimentacoesEstoqueProdutos.Remove(movimentacaoEstoqueProduto);
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
