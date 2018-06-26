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

        // GET: EstoqueInsumos
        public ActionResult Index()
        {
            var estoqueInsumos = db.EstoqueInsumos.Include(e => e._Insumo);
            return View(estoqueInsumos.ToList());
        }

        // GET: EstoqueInsumos/Details/5
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

        // GET: EstoqueInsumos/Create
        public ActionResult Create()
        {
            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome");
            return View();
        }

        // POST: EstoqueInsumos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,InsumoID,QtdeTotalEstoque,CustoTotalEstoque")] EstoqueInsumo estoqueInsumo)
        {
            if (ModelState.IsValid)
            {
                db.EstoqueInsumos.Add(estoqueInsumo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome", estoqueInsumo.InsumoID);
            return View(estoqueInsumo);
        }

        // GET: EstoqueInsumos/Edit/5
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

        // POST: EstoqueInsumos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,InsumoID,QtdeTotalEstoque,CustoTotalEstoque")] EstoqueInsumo estoqueInsumo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estoqueInsumo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome", estoqueInsumo.InsumoID);
            return View(estoqueInsumo);
        }

        // GET: EstoqueInsumos/Delete/5
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

        // POST: EstoqueInsumos/Delete/5
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
