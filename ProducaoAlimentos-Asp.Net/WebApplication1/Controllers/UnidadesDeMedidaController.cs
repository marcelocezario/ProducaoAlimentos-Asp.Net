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
    public class UnidadesDeMedidaController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Index()
        {
            var unidadesDeMedidas = db.UnidadesDeMedida.OrderBy(um => um.Nome).ToList();
            return View(unidadesDeMedidas);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeDeMedida unidadeDeMedida = db.UnidadesDeMedida.Find(id);
            if (unidadeDeMedida == null)
            {
                return HttpNotFound();
            }
            return PartialView(unidadeDeMedida);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnidadeDeMedidaID,Nome,Sigla,Fracionavel")] UnidadeDeMedida unidadeDeMedida)
        {
            if (ModelState.IsValid)
            {
                db.UnidadesDeMedida.Add(unidadeDeMedida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unidadeDeMedida);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeDeMedida unidadeDeMedida = db.UnidadesDeMedida.Find(id);
            if (unidadeDeMedida == null)
            {
                return HttpNotFound();
            }
            return PartialView(unidadeDeMedida);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UnidadeDeMedidaID,Nome,Sigla,Fracionavel")] UnidadeDeMedida unidadeDeMedida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidadeDeMedida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidadeDeMedida);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeDeMedida unidadeDeMedida = db.UnidadesDeMedida.Find(id);
            if (unidadeDeMedida == null)
            {
                return HttpNotFound();
            }
            return PartialView(unidadeDeMedida);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnidadeDeMedida unidadeDeMedida = db.UnidadesDeMedida.Find(id);
            db.UnidadesDeMedida.Remove(unidadeDeMedida);
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
