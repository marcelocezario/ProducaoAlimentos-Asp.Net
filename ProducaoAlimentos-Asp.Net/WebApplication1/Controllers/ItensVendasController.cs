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
    public class ItensVendasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: ItensVendas
        public ActionResult Index()
        {
            var itensVenda = db.ItensVenda.Include(i => i._LoteProduto);
            return View(itensVenda.ToList());
        }

        // GET: ItensVendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVenda itemVenda = db.ItensVenda.Find(id);
            if (itemVenda == null)
            {
                return HttpNotFound();
            }
            return View(itemVenda);
        }

        // GET: ItensVendas/Create
        public ActionResult Create()
        {
            ViewBag.LoteProdutoID = new SelectList(db.LotesProdutos, "ID", "ID");
            return View();
        }

        // POST: ItensVendas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemVendaID,ValorUnitarioItem,ValorTotalItem,QtdeProduto,LoteProdutoID")] ItemVenda itemVenda)
        {
            if (ModelState.IsValid)
            {
                db.ItensVenda.Add(itemVenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoteProdutoID = new SelectList(db.LotesProdutos, "ID", "ID", itemVenda.LoteProdutoID);
            return View(itemVenda);
        }

        // GET: ItensVendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVenda itemVenda = db.ItensVenda.Find(id);
            if (itemVenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoteProdutoID = new SelectList(db.LotesProdutos, "ID", "ID", itemVenda.LoteProdutoID);
            return View(itemVenda);
        }

        // POST: ItensVendas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemVendaID,ValorUnitarioItem,ValorTotalItem,QtdeProduto,LoteProdutoID")] ItemVenda itemVenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemVenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoteProdutoID = new SelectList(db.LotesProdutos, "ID", "ID", itemVenda.LoteProdutoID);
            return View(itemVenda);
        }

        // GET: ItensVendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVenda itemVenda = db.ItensVenda.Find(id);
            if (itemVenda == null)
            {
                return HttpNotFound();
            }
            return View(itemVenda);
        }

        // POST: ItensVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemVenda itemVenda = db.ItensVenda.Find(id);
            db.ItensVenda.Remove(itemVenda);
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
