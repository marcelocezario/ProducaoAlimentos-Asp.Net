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
        public bool Create([Bind(Include = "ID,LoteProdutoID,DataMovimentacao,Qtde,ValorMovimentacao")] MovimentacaoEstoqueProduto movimentacaoEstoqueProduto)
        {
            if (ModelState.IsValid)
            {
                db.MovimentacoesEstoqueProdutos.Add(movimentacaoEstoqueProduto);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool Edit([Bind(Include = "ID,LoteProdutoID,DataMovimentacao,Qtde,ValorMovimentacao")] MovimentacaoEstoqueProduto movimentacaoEstoqueProduto)
        {
            MovimentacaoEstoqueProduto movimentacaoEstoqueProdutoEditar = db.MovimentacoesEstoqueProdutos.Find(movimentacaoEstoqueProduto.ID);

            movimentacaoEstoqueProdutoEditar.DataMovimentacao = movimentacaoEstoqueProduto.DataMovimentacao;
            movimentacaoEstoqueProdutoEditar.Qtde = movimentacaoEstoqueProduto.Qtde;
            movimentacaoEstoqueProdutoEditar.ValorMovimentacao = movimentacaoEstoqueProduto.ValorMovimentacao;
            movimentacaoEstoqueProdutoEditar.LoteProdutoID = movimentacaoEstoqueProduto.LoteProdutoID;

            if (ModelState.IsValid)
            {
                db.Entry(movimentacaoEstoqueProdutoEditar).State = EntityState.Modified;
                db.SaveChanges();

                foreach (MovimentacaoEstoqueProduto mep in db.MovimentacoesEstoqueProdutos.Where(m => m.LoteProdutoID.Equals(movimentacaoEstoqueProduto.LoteProdutoID)).ToList())
                {
                    if (mep.Qtde < 0)
                    {
                        mep.ValorMovimentacao = -mep.Qtde * mep._LoteProduto.CustoMedio;
                    }
                    else
                    {
                        mep.ValorMovimentacao = mep.Qtde * mep._LoteProduto.CustoMedio;
                    }

                    db.Entry(mep).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            return false;
        }

        public bool Delete (int id)
        {
            MovimentacaoEstoqueProduto movimentacaoEstoqueProduto = db.MovimentacoesEstoqueProdutos.Find(id);
            if (movimentacaoEstoqueProduto != null)
            {
                db.MovimentacoesEstoqueProdutos.Remove(movimentacaoEstoqueProduto);
                db.SaveChanges();
                return true;
            }
            return false;
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
