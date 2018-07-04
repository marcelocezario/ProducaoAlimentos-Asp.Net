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
    public class LotesProdutosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: LotesProdutos
        public ActionResult Index()
        {
            var lotesProdutos = db.LotesProdutos.Include(l => l._Produto);
            return View(lotesProdutos.ToList());
        }

        // GET: LotesProdutos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoteProduto loteProduto = db.LotesProdutos.Find(id);
            if (loteProduto == null)
            {
                return HttpNotFound();
            }
            return View(loteProduto);
        }

        // GET: LotesProdutos/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome");
            return View();
        }

        // POST: LotesProdutos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DataProducao,ValorVendaUnitario,ProdutoID,QtdeInicial,QtdeDisponivel,CustoMedio,CustoTotalInicial,Validade")] LoteProduto loteProduto)
        {
            if (ModelState.IsValid)
            {
//                NovoLoteProduto(loteProduto);

                return RedirectToAction("Index");
            }

            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome", loteProduto.ProdutoID);
            return View(loteProduto);
        }

        // GET: LotesProdutos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoteProduto loteProduto = db.LotesProdutos.Find(id);
            if (loteProduto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome", loteProduto.ProdutoID);
            return View(loteProduto);
        }

        // POST: LotesProdutos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DataProducao,ValorVendaUnitario,ProdutoID,QtdeInicial,QtdeDisponivel,CustoMedio,CustoTotalInicial,Validade")] LoteProduto loteProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loteProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome", loteProduto.ProdutoID);
            return View(loteProduto);
        }

        // GET: LotesProdutos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoteProduto loteProduto = db.LotesProdutos.Find(id);
            if (loteProduto == null)
            {
                return HttpNotFound();
            }
            return View(loteProduto);
        }

        // POST: LotesProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoteProduto loteProduto = db.LotesProdutos.Find(id);
            db.LotesProdutos.Remove(loteProduto);
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
/*
        public LoteProduto BuscarLoteProdutoPorID(int idLoteProduto)
        {
            return db.LotesProdutos.Find(idLoteProduto);
        }

        public void NovoLoteProduto(LoteProduto loteProduto)
        {
            loteProduto.QtdeDisponivel = loteProduto.QtdeInicial;

            double custoTotal = 0;

            foreach (LoteInsumoProducao item in loteProduto._ItensInsumoProducao)
            {
                custoTotal += item.CustoTotalInsumo;
            }

            loteProduto.CustoMedio = custoTotal / loteProduto.QtdeInicial;

            db.LotesProdutos.Add(loteProduto);
            db.SaveChanges();

            LotesProdutosController lpc = new LotesProdutosController();
            loteProduto = lpc.BuscarLoteProdutoPorID(loteProduto.ID);

            LotesInsumosController lic = new LotesInsumosController();
            foreach (var lip in loteProduto._ItensInsumoProducao)
            {
                lic.BaixarLoteInsumo(lip._LoteInsumo, lip.QtdeInsumo, loteProduto.DataProducao);
            }

            MovimentacoesEstoqueProdutosController meip = new MovimentacoesEstoqueProdutosController();
            meip.RegistrarMovimentacaoEstoque(loteProduto.DataProducao, loteProduto.QtdeInicial, loteProduto.CustoMedio, loteProduto);
        }

        public void BaixarLoteProduto(LoteProduto loteProduto, double qtde, DateTime dataMovimentacao)
        {
            qtde *= -1;

            loteProduto.QtdeDisponivel += qtde;

            db.Entry(loteProduto).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            MovimentacoesEstoqueProdutosController mepc = new MovimentacoesEstoqueProdutosController();
            mepc.RegistrarMovimentacaoEstoque(dataMovimentacao, qtde, loteProduto.CustoMedio, loteProduto);
        }
        */
    }
}
