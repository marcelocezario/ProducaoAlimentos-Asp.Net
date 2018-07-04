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

        public ActionResult Index()
        {
            var movimentacoesEstoqueInsumos = db.MovimentacoesEstoqueInsumos.Include(m => m._LoteInsumo);
            return View(movimentacoesEstoqueInsumos.ToList());
        }

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

        public ActionResult Create()
        {
            ViewBag.LoteInsumoID = new SelectList(db.LotesInsumos, "ID", "ID");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool Create([Bind(Include = "ID,LoteInsumoID,DataMovimentacao,Qtde,ValorMovimentacao")] MovimentacaoEstoqueInsumo movimentacaoEstoqueInsumo)
        {
            if (ModelState.IsValid)
            {
                db.MovimentacoesEstoqueInsumos.Add(movimentacaoEstoqueInsumo);
                db.SaveChanges();
                return true;
            }
            return false;
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
    }
}
