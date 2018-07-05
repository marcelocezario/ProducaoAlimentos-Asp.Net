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
            var movimentacoesEstoqueInsumos = db.MovimentacoesEstoqueInsumos.Include(m => m._LoteInsumo).OrderByDescending(m => m.DataMovimentacao).ThenByDescending(m => m.ID);
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
            return PartialView(movimentacaoEstoqueInsumo);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool Edit([Bind(Include = "ID,LoteInsumoID,DataMovimentacao,Qtde,ValorMovimentacao")] MovimentacaoEstoqueInsumo movimentacaoEstoqueInsumo)
        {
//          MovimentacaoEstoqueInsumo movimentacaoEstoqueInsumoEditar = db.MovimentacoesEstoqueInsumos.Where(m => m.LoteInsumoID.Equals(movimentacaoEstoqueInsumo.LoteInsumoID)).FirstOrDefault();
            MovimentacaoEstoqueInsumo movimentacaoEstoqueInsumoEditar = db.MovimentacoesEstoqueInsumos.Find(movimentacaoEstoqueInsumo.ID);

            movimentacaoEstoqueInsumoEditar.DataMovimentacao = movimentacaoEstoqueInsumo.DataMovimentacao;
            movimentacaoEstoqueInsumoEditar.Qtde = movimentacaoEstoqueInsumo.Qtde;
            movimentacaoEstoqueInsumoEditar.ValorMovimentacao = movimentacaoEstoqueInsumo.ValorMovimentacao;
            movimentacaoEstoqueInsumoEditar.LoteInsumoID = movimentacaoEstoqueInsumo.LoteInsumoID;

            if (ModelState.IsValid)
            {
                db.Entry(movimentacaoEstoqueInsumoEditar).State = EntityState.Modified;
                db.SaveChanges();

                foreach (MovimentacaoEstoqueInsumo mei in db.MovimentacoesEstoqueInsumos.Where(m => m.LoteInsumoID.Equals(movimentacaoEstoqueInsumo.LoteInsumoID)).ToList())
                {
                    if(mei.Qtde < 0)
                    {
                        mei.ValorMovimentacao = -mei.Qtde * mei._LoteInsumo.CustoMedio;
                    }
                    else
                    {
                        mei.ValorMovimentacao = mei.Qtde * mei._LoteInsumo.CustoMedio;
                    }
                     
                    db.Entry(mei).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            MovimentacaoEstoqueInsumo movimentacaoEstoqueInsumo = db.MovimentacoesEstoqueInsumos.Find(id);
            if (movimentacaoEstoqueInsumo != null)
            {
                db.MovimentacoesEstoqueInsumos.Remove(movimentacaoEstoqueInsumo);
                db.SaveChanges();
                return true;
            }
            return false;
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
