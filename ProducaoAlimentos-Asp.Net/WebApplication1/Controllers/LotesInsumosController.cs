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

        public ActionResult Index()
        {
            var lotesInsumos = db.LotesInsumos.Include(l => l._Fornecedor).Include(l => l._Insumo).Include(l => l._Marca);
            return View(lotesInsumos.ToList());
        }

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
            return PartialView(loteInsumo);
        }

        public ActionResult Create()
        {
            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome");
            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome");
            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DataCompra,InsumoID,MarcaID,FornecedorID,QtdeInicial,QtdeDisponivel,CustoMedio,CustoTotalInicial,Validade,_Insumo")] LoteInsumo loteInsumo)
        {

            if (ModelState.IsValid)
            {
                loteInsumo.QtdeDisponivel = loteInsumo.QtdeInicial;
                loteInsumo.CustoMedio = loteInsumo.CustoTotalInicial / loteInsumo.QtdeInicial;

                db.LotesInsumos.Add(loteInsumo);
                db.SaveChanges();

                loteInsumo = db.LotesInsumos.Include(li => li._Insumo).Where(li => li.ID == loteInsumo.ID).FirstOrDefault();

                // Incluir Movimentação Estoque Insumos
                MovimentacaoEstoqueInsumo movimentacaoEstoqueInsumo = new MovimentacaoEstoqueInsumo()
                {
                    DataMovimentacao = loteInsumo.DataCompra,
                    Qtde = loteInsumo.QtdeInicial,
                    ValorMovimentacao = loteInsumo.CustoTotalInicial,
                    LoteInsumoID = loteInsumo.ID
                };
                MovimentacoesEstoqueInsumosController meic = new MovimentacoesEstoqueInsumosController();
                if (meic.Create(movimentacaoEstoqueInsumo))
                {
                    // Incluir / Alterar Estoque Insumos
                    EstoqueInsumosController eic = new EstoqueInsumosController();
                    
                    var x = db.EstoqueInsumos.Where(ei => ei._Insumo.Nome.Equals(loteInsumo._Insumo.Nome)).FirstOrDefault();

                    if (x != null)
                    {
                        EstoqueInsumo estoqueInsumo = x;

                        estoqueInsumo.QtdeTotalEstoque += loteInsumo.QtdeInicial;
                        estoqueInsumo.CustoTotalEstoque += loteInsumo.CustoTotalInicial;

                        if (!eic.Edit(estoqueInsumo))
                            return View();
                    }
                    else
                    {
                        EstoqueInsumo estoqueInsumo = new EstoqueInsumo()
                        {
                            QtdeTotalEstoque = loteInsumo.QtdeInicial,
                            CustoTotalEstoque = loteInsumo.CustoTotalInicial,
                            InsumoID = loteInsumo.InsumoID
                        };

                        if (!eic.Create(estoqueInsumo))
                            return View();
                    }

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }

            ViewBag.FornecedorID = new SelectList(db.Fornecedores, "ID", "Nome", loteInsumo.FornecedorID);
            ViewBag.InsumoID = new SelectList(db.Insumos, "InsumoID", "Nome", loteInsumo.InsumoID);
            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "Nome", loteInsumo.MarcaID);
            return View(loteInsumo);
        }

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
            return PartialView(loteInsumo);
        }

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
            return PartialView(loteInsumo);
        }

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
    }
}
