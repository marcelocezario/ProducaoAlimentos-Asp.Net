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
    public class EstoqueInsumosController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Index()
        {
            var estoqueInsumos = db.EstoqueInsumos.Include(e => e._Insumo);
            return View(estoqueInsumos.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstoqueInsumo estoqueInsumo = db.EstoqueInsumos.Find(id);
            if (estoqueInsumo == null)
            {
                return HttpNotFound();
            }
            return View(estoqueInsumo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool Create([Bind(Include = "ID,InsumoID,QtdeTotalEstoque,CustoTotalEstoque")] EstoqueInsumo estoqueInsumo)
        {
            if (ModelState.IsValid)
            {
                db.EstoqueInsumos.Add(estoqueInsumo);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstoqueInsumo estoqueInsumo = db.EstoqueInsumos.Find(id);
            if (estoqueInsumo == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome", estoqueInsumo.InsumoID);
            return View(estoqueInsumo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool Edit([Bind(Include = "ID,InsumoID,QtdeTotalEstoque,CustoTotalEstoque")] EstoqueInsumo estoqueInsumo)
        {
            EstoqueInsumo estoqueInsumoEditar = db.EstoqueInsumos.Find(estoqueInsumo.ID);

            estoqueInsumoEditar.QtdeTotalEstoque = estoqueInsumo.QtdeTotalEstoque;
            estoqueInsumoEditar.CustoTotalEstoque = estoqueInsumo.CustoTotalEstoque;

            if (ModelState.IsValid)
            {
                db.Entry(estoqueInsumoEditar).State = EntityState.Modified;
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
            EstoqueInsumo estoqueInsumo = db.EstoqueInsumos.Find(id);
            if (estoqueInsumo == null)
            {
                return HttpNotFound();
            }
            return View(estoqueInsumo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstoqueInsumo estoqueInsumo = db.EstoqueInsumos.Find(id);
            db.EstoqueInsumos.Remove(estoqueInsumo);
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
