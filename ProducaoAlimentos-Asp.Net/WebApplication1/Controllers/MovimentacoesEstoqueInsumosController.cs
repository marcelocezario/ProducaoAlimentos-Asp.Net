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
    public class MovimentacoesEstoqueInsumosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: MovimentacoesEstoqueInsumos
        public ActionResult Index()
        {
            var movimentacoesEstoqueInsumos = db.MovimentacoesEstoqueInsumos.Include(m => m._LoteInsumo);
            return View(movimentacoesEstoqueInsumos.ToList());
        }

        // GET: MovimentacoesEstoqueInsumos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoEstoqueInsumo movimentacaoEstoqueInsumo = db.MovimentacoesEstoqueInsumos.Find(id);
            if (movimentacaoEstoqueInsumo == null)
            {
                return HttpNotFound();
            }
            return View(movimentacaoEstoqueInsumo);
        }

        // GET: MovimentacoesEstoqueInsumos/Create
        public ActionResult Create()
        {
            ViewBag.LoteInsumoID = new SelectList(db.LotesInsumos, "ID", "ID");
            return View();
        }

        // POST: MovimentacoesEstoqueInsumos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LoteInsumoID,DataMovimentacao,Qtde,ValorMovimentacao")] MovimentacaoEstoqueInsumo movimentacaoEstoqueInsumo)
        {
            if (ModelState.IsValid)
            {
                db.MovimentacoesEstoqueInsumos.Add(movimentacaoEstoqueInsumo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoteInsumoID = new SelectList(db.LotesInsumos, "ID", "ID", movimentacaoEstoqueInsumo.LoteInsumoID);
            return View(movimentacaoEstoqueInsumo);
        }

        // GET: MovimentacoesEstoqueInsumos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoEstoqueInsumo movimentacaoEstoqueInsumo = db.MovimentacoesEstoqueInsumos.Find(id);
            if (movimentacaoEstoqueInsumo == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoteInsumoID = new SelectList(db.LotesInsumos, "ID", "ID", movimentacaoEstoqueInsumo.LoteInsumoID);
            return View(movimentacaoEstoqueInsumo);
        }

        // POST: MovimentacoesEstoqueInsumos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LoteInsumoID,DataMovimentacao,Qtde,ValorMovimentacao")] MovimentacaoEstoqueInsumo movimentacaoEstoqueInsumo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimentacaoEstoqueInsumo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoteInsumoID = new SelectList(db.LotesInsumos, "ID", "ID", movimentacaoEstoqueInsumo.LoteInsumoID);
            return View(movimentacaoEstoqueInsumo);
        }

        // GET: MovimentacoesEstoqueInsumos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoEstoqueInsumo movimentacaoEstoqueInsumo = db.MovimentacoesEstoqueInsumos.Find(id);
            if (movimentacaoEstoqueInsumo == null)
            {
                return HttpNotFound();
            }
            return View(movimentacaoEstoqueInsumo);
        }

        // POST: MovimentacoesEstoqueInsumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovimentacaoEstoqueInsumo movimentacaoEstoqueInsumo = db.MovimentacoesEstoqueInsumos.Find(id);
            db.MovimentacoesEstoqueInsumos.Remove(movimentacaoEstoqueInsumo);
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

        public void RegistrarMovimentacaoEstoque (DateTime dataMovimentacao, double qtde, double valorMovimentacao, LoteInsumo loteInsumo)
        {
            MovimentacaoEstoqueInsumo mei = new MovimentacaoEstoqueInsumo();

            mei.DataMovimentacao = dataMovimentacao;
            mei.Qtde = qtde;
            mei.ValorMovimentacao = valorMovimentacao;
            mei.LoteInsumoID = loteInsumo.ID;

            EstoqueInsumosController eic = new EstoqueInsumosController();
            eic.RegistrarEstoqueInsumo(mei);

            db.MovimentacoesEstoqueInsumos.Add(mei);
            db.SaveChanges();
        }
    }
}
