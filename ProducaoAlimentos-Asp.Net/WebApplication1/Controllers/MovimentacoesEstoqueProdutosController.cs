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

        public ActionResult Index()
        {
            var movimentacoesEstoqueProdutos = db.MovimentacoesEstoqueProdutos.Include(m => m._LoteProduto).OrderByDescending(m => m.DataMovimentacao).ThenByDescending(m => m.ID);
            return View(movimentacoesEstoqueProdutos.ToList());
        }

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
            return PartialView(movimentacaoEstoqueProduto);
        }

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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

//        public void RegistrarMovimentacaoEstoque(DateTime dataMovimentacao, double qtde, double valorMedio, LoteProduto loteProduto)
//        {
//            MovimentacaoEstoqueProduto mep = new MovimentacaoEstoqueProduto();
//
//            mep.DataMovimentacao = dataMovimentacao;
//            mep.Qtde = qtde;
//            mep.ValorMovimentacao = valorMedio * qtde;
//            mep.LoteProdutoID = loteProduto.ID;
//
//            if (qtde < 0)
//                mep.ValorMovimentacao *= -1;
//
//            EstoqueProdutosController epc = new EstoqueProdutosController();
//            epc.RegistrarEstoqueProduto(mep);
//
//            db.MovimentacoesEstoqueProdutos.Add(mep);
//            db.SaveChanges();
//        }
    }
}
