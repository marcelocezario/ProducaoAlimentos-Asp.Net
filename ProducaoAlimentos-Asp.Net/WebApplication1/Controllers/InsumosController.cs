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
    public class InsumosController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Index()
        {
            var insumos = db.Insumos.OrderBy(e => e.Nome).ToList();
            return View(insumos);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insumo insumo = db.Insumos.Find(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            return PartialView(insumo);
        }

        public ActionResult Create()
        {
            ViewBag.UnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida.OrderBy(um => um.Nome).ToList(), "UnidadeDeMedidaID", "Nome");
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsumoID,Nome,UnidadeDeMedidaID")] Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                db.Insumos.Add(insumo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida.OrderBy(um=> um.Nome).ToList(), "UnidadeDeMedidaID", "Nome", insumo.UnidadeDeMedidaID);
            return View(insumo);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insumo insumo = db.Insumos.Find(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida.OrderBy(um => um.Nome).ToList(), "UnidadeDeMedidaID", "Nome", insumo.UnidadeDeMedidaID);
            return PartialView(insumo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsumoID,Nome,UnidadeDeMedidaID")] Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insumo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida.OrderBy(um => um.Nome).ToList(), "UnidadeDeMedidaID", "Nome", insumo.UnidadeDeMedidaID);
            return View(insumo);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insumo insumo = db.Insumos.Find(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            return PartialView(insumo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insumo insumo = db.Insumos.Find(id);
            db.Insumos.Remove(insumo);
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
