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
    public class LotesInsumosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: LotesInsumos
        public ActionResult Index()
        {
            var lotesInsumos = db.LotesInsumos.Include(l => l._Fornecedor).Include(l => l._Insumo).Include(l => l._Marca);
            return View(lotesInsumos.ToList());
        }

        // GET: LotesInsumos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoteInsumo loteInsumo = db.LotesInsumos.Find(id);
            if (loteInsumo == null)
            {
                return HttpNotFound();
            }
            return View(loteInsumo);
        }

        // GET: LotesInsumos/Create
        public ActionResult Create()
        {
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome");
            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome");
            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "Nome");
            return View();
        }

        // POST: LotesInsumos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DataCompra,InsumoID,MarcaID,FornecedorID,QtdeInicial,QtdeDisponivel,CustoMedio,CustoTotalInicial,Validade")] LoteInsumo loteInsumo)
        {
            if (ModelState.IsValid)
            {
                RegistrarLoteInsumo(loteInsumo);

                return RedirectToAction("Index");
            }

            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome", loteInsumo.FornecedorID);
            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome", loteInsumo.InsumoID);
            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "Nome", loteInsumo.MarcaID);
            return View(loteInsumo);
        }

        // GET: LotesInsumos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoteInsumo loteInsumo = db.LotesInsumos.Find(id);
            if (loteInsumo == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome", loteInsumo.FornecedorID);
            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome", loteInsumo.InsumoID);
            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "Nome", loteInsumo.MarcaID);
            return View(loteInsumo);
        }

        // POST: LotesInsumos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DataCompra,InsumoID,MarcaID,FornecedorID,QtdeInicial,QtdeDisponivel,CustoMedio,CustoTotalInicial,Validade")] LoteInsumo loteInsumo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loteInsumo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome", loteInsumo.FornecedorID);
            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome", loteInsumo.InsumoID);
            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "Nome", loteInsumo.MarcaID);
            return View(loteInsumo);
        }

        // GET: LotesInsumos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoteInsumo loteInsumo = db.LotesInsumos.Find(id);
            if (loteInsumo == null)
            {
                return HttpNotFound();
            }
            return View(loteInsumo);
        }

        // POST: LotesInsumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoteInsumo loteInsumo = db.LotesInsumos.Find(id);
            db.LotesInsumos.Remove(loteInsumo);
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

        public LoteInsumo BuscarLoteInsumoPorID(int idLoteInsumo)
        {
            return db.LotesInsumos.Find(idLoteInsumo);
        }

        public void RegistrarLoteInsumo(LoteInsumo loteInsumo)
        {
            db.LotesInsumos.Add(loteInsumo);
            db.SaveChanges();

            MovimentacoesEstoqueInsumosController meic = new MovimentacoesEstoqueInsumosController();
            meic.RegistrarMovimentacaoEstoque(loteInsumo.DataCompra, loteInsumo.QtdeInicial, loteInsumo.CustoTotalInicial, loteInsumo);
        }
    }
}
