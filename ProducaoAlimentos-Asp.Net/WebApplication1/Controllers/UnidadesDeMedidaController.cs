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

        // GET: UnidadesDeMedida
        public ActionResult Index()
        {
            return View(db.UnidadesDeMedida.ToList());
        }

        // GET: UnidadesDeMedida/Details/5
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
            return View(unidadeDeMedida);
        }

        // GET: UnidadesDeMedida/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnidadesDeMedida/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: UnidadesDeMedida/Edit/5
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
            return View(unidadeDeMedida);
        }

        // POST: UnidadesDeMedida/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: UnidadesDeMedida/Delete/5
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
            return View(unidadeDeMedida);
        }

        // POST: UnidadesDeMedida/Delete/5
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
