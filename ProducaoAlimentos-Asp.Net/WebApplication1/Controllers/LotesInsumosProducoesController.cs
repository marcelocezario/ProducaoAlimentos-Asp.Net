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
    public class LotesInsumosProducoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: LotesInsumosProducoes
        public ActionResult Index()
        {
            var lotesInsumosProducao = db.LotesInsumosProducao.Include(l => l._LoteInsumo);
            return View(lotesInsumosProducao.ToList());
        }

        // GET: LotesInsumosProducoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoteInsumoProducao loteInsumoProducao = db.LotesInsumosProducao.Find(id);
            if (loteInsumoProducao == null)
            {
                return HttpNotFound();
            }
            return View(loteInsumoProducao);
        }

        // GET: LotesInsumosProducoes/Create
        public ActionResult Create()
        {
            ViewBag.LoteInsumoID = new SelectList(db.LotesInsumos, "ID", "ID");
            return View();
        }

        // POST: LotesInsumosProducoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoteInsumoProducaoID,QtdeInsumo,CustoInsumo,LoteInsumoID")] LoteInsumoProducao loteInsumoProducao)
        {
            if (ModelState.IsValid)
            {
                db.LotesInsumosProducao.Add(loteInsumoProducao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoteInsumoID = new SelectList(db.LotesInsumos, "ID", "ID", loteInsumoProducao.LoteInsumoID);
            return View(loteInsumoProducao);
        }

        // GET: LotesInsumosProducoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoteInsumoProducao loteInsumoProducao = db.LotesInsumosProducao.Find(id);
            if (loteInsumoProducao == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoteInsumoID = new SelectList(db.LotesInsumos, "ID", "ID", loteInsumoProducao.LoteInsumoID);
            return View(loteInsumoProducao);
        }

        // POST: LotesInsumosProducoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoteInsumoProducaoID,QtdeInsumo,CustoInsumo,LoteInsumoID")] LoteInsumoProducao loteInsumoProducao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loteInsumoProducao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoteInsumoID = new SelectList(db.LotesInsumos, "ID", "ID", loteInsumoProducao.LoteInsumoID);
            return View(loteInsumoProducao);
        }

        // GET: LotesInsumosProducoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoteInsumoProducao loteInsumoProducao = db.LotesInsumosProducao.Find(id);
            if (loteInsumoProducao == null)
            {
                return HttpNotFound();
            }
            return View(loteInsumoProducao);
        }

        // POST: LotesInsumosProducoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoteInsumoProducao loteInsumoProducao = db.LotesInsumosProducao.Find(id);
            db.LotesInsumosProducao.Remove(loteInsumoProducao);
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
