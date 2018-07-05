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

        public ActionResult Index()
        {
            var lotesProdutos = db.LotesProdutos.Include(l => l._Produto);
            return View(lotesProdutos.ToList());
        }

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

        public ActionResult Create()
        {
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DataProducao,ValorVendaUnitario,ProdutoID,QtdeInicial,QtdeDisponivel,CustoMedio,CustoTotalInicial,Validade,_Produto")] LoteProduto loteProduto)
        {
            if (ModelState.IsValid)
            {
                // Verificando se há insumos necessários suficientes em estoque

                bool insumosDisponiveis = true;

                Produto produto = db.Produtos.Find(loteProduto.ProdutoID);

                foreach (InsumoComposicaoProduto item in produto._ComposicaoProduto)
                {
                    double qtdeInsumo = item.QtdeInsumo * loteProduto.QtdeInicial;
                    double qtdeEstoqueInsumo = db.EstoqueInsumos.Where(m => m.InsumoID.Equals(item.InsumoID)).Sum(m => m.QtdeTotalEstoque);

                    if (qtdeInsumo > qtdeEstoqueInsumo)
                        insumosDisponiveis = false;
                }

                if (insumosDisponiveis)
                {
                    // Cria loteProduto no banco, depois vai ser alterado para incluir atributos faltantes sobre o custo

                    loteProduto.QtdeDisponivel = loteProduto.QtdeInicial;
                    db.LotesProdutos.Add(loteProduto);
                    db.SaveChanges();

                    double custoTotalLoteProduto = 0;

                    List<LoteInsumoProducao> lotesComposicaoProduto = new List<LoteInsumoProducao>();

                    // Percorre composição de Produto para encontrar os insumos necessário
                    foreach (InsumoComposicaoProduto item in loteProduto._Produto._ComposicaoProduto)
                    {
                        EstoqueInsumo estoqueInsumo = db.EstoqueInsumos.Where(e => e.InsumoID == item.InsumoID).FirstOrDefault();

                        double qtdeInsumo = item.QtdeInsumo * loteProduto.QtdeInicial;

                        while (qtdeInsumo > 0)
                        {
                            // Procura o Lote de Insumo que tenha estoque para e que esteja com a validade mais próxima 
                            LoteInsumo loteDisponivel = db.LotesInsumos.
                                Where(l => l.InsumoID == item.InsumoID && l.QtdeDisponivel > 0).
                                OrderBy(l => l.Validade).FirstOrDefault();

                            if ((loteDisponivel.QtdeDisponivel - qtdeInsumo) >= 0)
                            {
                                loteDisponivel.QtdeDisponivel -= qtdeInsumo;
                                LotesInsumosController lic = new LotesInsumosController();
                                lic.Edit(loteDisponivel);

                                LoteInsumoProducao loteInsumoProducao = new LoteInsumoProducao()
                                {
                                    QtdeInsumo = qtdeInsumo,
                                    CustoTotalInsumo = qtdeInsumo * loteDisponivel.CustoMedio,
                                    LoteInsumoID = loteDisponivel.ID,
                                    LoteProdutoID = loteProduto.ID
                                };

                                MovimentacaoEstoqueInsumo movimentacaoEstoqueInsumo = new MovimentacaoEstoqueInsumo()
                                {
                                    DataMovimentacao = loteProduto.DataProducao,
                                    Qtde = -qtdeInsumo,
                                    ValorMovimentacao = loteDisponivel.CustoMedio * qtdeInsumo,
                                    LoteInsumoID = loteDisponivel.ID
                                };

                                MovimentacoesEstoqueInsumosController meic = new MovimentacoesEstoqueInsumosController();
                                meic.Create(movimentacaoEstoqueInsumo);

                                estoqueInsumo.QtdeTotalEstoque -= loteInsumoProducao.QtdeInsumo;
                                estoqueInsumo.CustoTotalEstoque -= loteInsumoProducao.CustoTotalInsumo;

                                EstoqueInsumosController eic = new EstoqueInsumosController();
                                eic.Edit(estoqueInsumo);

                                lotesComposicaoProduto.Add(loteInsumoProducao);
                                qtdeInsumo = 0;
                                custoTotalLoteProduto += loteInsumoProducao.CustoTotalInsumo;
                            }
                            else
                            {
                                LoteInsumoProducao loteInsumoProducao = new LoteInsumoProducao()
                                {
                                    QtdeInsumo = loteDisponivel.QtdeDisponivel,
                                    CustoTotalInsumo = loteDisponivel.QtdeDisponivel * loteDisponivel.CustoMedio,
                                    LoteInsumoID = loteDisponivel.ID,
                                    LoteProdutoID = loteProduto.ID
                                };

                                MovimentacaoEstoqueInsumo movimentacaoEstoqueInsumo = new MovimentacaoEstoqueInsumo()
                                {
                                    DataMovimentacao = loteProduto.DataProducao,
                                    Qtde = -loteDisponivel.QtdeDisponivel,
                                    ValorMovimentacao = loteDisponivel.CustoMedio * loteDisponivel.QtdeDisponivel,
                                    LoteInsumoID = loteDisponivel.ID
                                };

                                MovimentacoesEstoqueInsumosController meic = new MovimentacoesEstoqueInsumosController();
                                meic.Create(movimentacaoEstoqueInsumo);

                                estoqueInsumo.QtdeTotalEstoque -= loteInsumoProducao.QtdeInsumo;
                                estoqueInsumo.CustoTotalEstoque -= loteInsumoProducao.CustoTotalInsumo;

                                EstoqueInsumosController eic = new EstoqueInsumosController();
                                eic.Edit(estoqueInsumo);

                                lotesComposicaoProduto.Add(loteInsumoProducao);
                                qtdeInsumo -= loteDisponivel.QtdeDisponivel;
                                custoTotalLoteProduto += loteInsumoProducao.CustoTotalInsumo;

                                loteDisponivel.QtdeDisponivel = 0;
                                LotesInsumosController lic = new LotesInsumosController();
                                lic.Edit(loteDisponivel);
                            }
                        }
                    }

                    loteProduto.CustoTotalInicial = custoTotalLoteProduto;
                    loteProduto.CustoMedio = custoTotalLoteProduto / loteProduto.QtdeInicial;
                    db.Entry(loteProduto).State = EntityState.Modified;

                    db.LotesInsumosProducao.AddRange(lotesComposicaoProduto);
                    db.SaveChanges();

                    MovimentacaoEstoqueProduto movimentacaoEstoqueProduto = new MovimentacaoEstoqueProduto()
                    {
                        DataMovimentacao = loteProduto.DataProducao,
                        Qtde = loteProduto.QtdeInicial,
                        ValorMovimentacao = loteProduto.CustoTotalInicial,
                        LoteProdutoID = loteProduto.ID
                    };

                    MovimentacoesEstoqueProdutosController mepc = new MovimentacoesEstoqueProdutosController();
                    if (mepc.Create(movimentacaoEstoqueProduto))
                    {
                        EstoqueProdutosController epc = new EstoqueProdutosController();

                        var x = db.EstoqueProdutos.Where(e => e.ProdutoID == loteProduto.ProdutoID).FirstOrDefault();

                        if (x != null)
                        {
                            EstoqueProduto estoqueProduto = x;

                            estoqueProduto.QtdeTotalEstoque += loteProduto.QtdeInicial;
                            estoqueProduto.CustoTotalEstoque += loteProduto.CustoTotalInicial;

                            epc.Edit(estoqueProduto);
                        }
                        else
                        {
                            EstoqueProduto estoqueProduto = new EstoqueProduto()
                            {
                                QtdeTotalEstoque = loteProduto.QtdeInicial,
                                CustoTotalEstoque = loteProduto.CustoTotalInicial,
                                ProdutoID = loteProduto.ProdutoID
                            };

                            if (!epc.Create(estoqueProduto))
                                return View();
                        }

                    return RedirectToAction("Index");
                    }
                }
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
    }
}
