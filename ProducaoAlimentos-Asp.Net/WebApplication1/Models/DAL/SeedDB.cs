using System.Collections.Generic;
using System.Data.Entity;

namespace WebApplication1.Models.DAL
{
    //public class SeedDB : DropCreateDatabaseIfModelChanges<Contexto>
    public class SeedDB : DropCreateDatabaseAlways<Contexto>
    {
        protected override void Seed(Contexto context)
        {
            // Inicializando dados na tabela Estados
            List<Estado> estados = new List<Estado>()
            {
                new Estado(){ Nome = "Acre", Sigla = "AC" },
                new Estado(){ Nome = "Alagoas", Sigla = "AL" },
                new Estado(){ Nome = "Amapá", Sigla = "AP" },
                new Estado(){ Nome = "Amazonas", Sigla = "AM" },
                new Estado(){ Nome = "Bahia", Sigla = "BA" },
                new Estado(){ Nome = "Ceará", Sigla = "CE" },
                new Estado(){ Nome = "Distrito Federal", Sigla = "DF" },
                new Estado(){ Nome = "Espirito Santo", Sigla = "ES" },
                new Estado(){ Nome = "Goiás", Sigla = "GO" },
                new Estado(){ Nome = "Maranhão", Sigla = "MA" },
                new Estado(){ Nome = "Mato Grosso", Sigla = "MT" },
                new Estado(){ Nome = "Mato Grosso do Sul", Sigla = "MS" },
                new Estado(){ Nome = "Minas Gerais", Sigla = "MG" },
                new Estado(){ Nome = "Pará", Sigla = "PA" },
                new Estado(){ Nome = "Paraíba", Sigla = "PB" },
                new Estado(){ Nome = "Paraná", Sigla = "PR" },
                new Estado(){ Nome = "Pernambuco", Sigla = "PE" },
                new Estado(){ Nome = "Piauí", Sigla = "PI" },
                new Estado(){ Nome = "Rio de Janeiro", Sigla = "RJ" },
                new Estado(){ Nome = "Rio Grande do Norte", Sigla = "RN" },
                new Estado(){ Nome = "Rio Grande do Sul", Sigla = "RS" },
                new Estado(){ Nome = "Rondônia", Sigla = "RO" },
                new Estado(){ Nome = "Roraima", Sigla = "RR" },
                new Estado(){ Nome = "Santa Catarina", Sigla = "SC" },
                new Estado(){ Nome = "São Paulo", Sigla = "SP" },
                new Estado(){ Nome = "Sergipe", Sigla = "SE" },
                new Estado(){ Nome = "Tocantins", Sigla = "TO" },
            };
            context.Estados.AddRange(estados);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela Cidades
            List<Cidade> cidades = new List<Cidade>()
            {
                new Cidade(){ Nome = "Curitiba", EstadoID = 16 },
                new Cidade(){ Nome = "Florianópolis", EstadoID = 24 },
                new Cidade(){ Nome = "São José dos Pinhais", EstadoID = 16 },
            };
            context.Cidades.AddRange(cidades);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela Enderecos
            List<Endereco> enderecos = new List<Endereco>()
            {
                new Endereco(){ Logradouro = "Rua Senador Accioly Filho", Numero = 511, Complemento = "Universidade Positivo",
                    Bairro = "Cidade Industrial", Cep = "81310-000", CidadeID = 1},
                new Endereco(){ Logradouro = "Rua Aleatória", Numero = 10, Complemento = "",
                    Bairro = "Centro", Cep = "83000-000", CidadeID = 2},
            };
            context.Enderecos.AddRange(enderecos);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela UnidadesDeMedida
            List<UnidadeDeMedida> unidadesDeMedida = new List<UnidadeDeMedida>()
            {
                new UnidadeDeMedida(){ Nome = "Centimetro", Sigla = "cm", Fracionavel = true},
                new UnidadeDeMedida(){ Nome = "Litro", Sigla = "l", Fracionavel = true},
                new UnidadeDeMedida(){ Nome = "Quilo", Sigla = "kg", Fracionavel = true},
                new UnidadeDeMedida(){ Nome = "Unidade", Sigla = "un", Fracionavel = false}
            };
            context.UnidadesDeMedida.AddRange(unidadesDeMedida);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela Clientes
            List<Cliente> clientes = new List<Cliente>()
            {
                new Cliente(){ Nome = "Antonio da Silva", Cpf_Cnpj = "164.842.566-67",
                    Telefone = "99999-9999",Email = "antonio@gmail.com", EnderecoID = 1},
                new Cliente(){ Nome = "Siclano José dos Santos", Cpf_Cnpj = "394.824.178-36",
                    Telefone = "3000-0000", Email = "siclano@hotmail.com", EnderecoID = 2},
            };
            context.Clientes.AddRange(clientes);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela Fornecedores
            List<Fornecedor> fornecedores = new List<Fornecedor>()
            {
                new Fornecedor(){ Nome = "Alimentos Distribuição Ltda", Cpf_Cnpj = "66.752.485/0001-88",
                    Telefone = "0800-777-7777", Email = "pedidos@alimentos.com.br", EnderecoID = 2},
                new Fornecedor(){ Nome = "Delivery Center S.A", Cpf_Cnpj = "30.636.422/0001-19",
                    Telefone = "3131-3131", Email = "contato_delivery@hotmail.com", EnderecoID = 1},
            };
            context.Fornecedores.AddRange(fornecedores);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela Insumos
            List<Insumo> insumos = new List<Insumo>()
            {
                new Insumo(){ Nome = "Batata", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Farinha de Trigo", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Óleo", UnidadeDeMedidaID = 2},
                new Insumo(){ Nome = "Ovo", UnidadeDeMedidaID = 4},
            };
            context.Insumos.AddRange(insumos);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela Marcas
            List<Marca> marcas = new List<Marca>()
            {
                new Marca(){ Nome = "Nestle"},
                new Marca(){ Nome = "Tirol"},
                new Marca(){ Nome = "Venturelli"}
            };
            context.Marcas.AddRange(marcas);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela Produtos
            List<Produto> produtos = new List<Produto>()
                        {
                            new Produto(){ Nome = "Nhoque", UnidadeDeMedidaID = 3, _ComposicaoProduto = new List<InsumoComposicaoProduto>()
                            {
                                new InsumoComposicaoProduto(){ InsumoID = 1, QtdeInsumo = 0.6},
                                new InsumoComposicaoProduto(){ InsumoID = 2, QtdeInsumo = 0.3},
                                new InsumoComposicaoProduto(){ InsumoID = 3, QtdeInsumo = 0.01},
                                new InsumoComposicaoProduto(){ InsumoID = 4, QtdeInsumo = 1}
                            }
                            },
                            new Produto(){ Nome = "Batata", UnidadeDeMedidaID = 3, _ComposicaoProduto = new List<InsumoComposicaoProduto>()
                            {
                                new InsumoComposicaoProduto(){ InsumoID = 1, QtdeInsumo = 1}
                            }
                            }
                            };
            context.Produtos.AddRange(produtos);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela EstoqueInsumos
            List<EstoqueInsumo> estoqueInsumos = new List<EstoqueInsumo>()
                 {
                     new EstoqueInsumo(){ InsumoID = 1, QtdeTotalEstoque = 10, CustoTotalEstoque = 30 }
                 };
            context.EstoqueInsumos.AddRange(estoqueInsumos);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela EstoqueProdutos
            List<EstoqueProduto> estoqueProdutos = new List<EstoqueProduto>()
            {
                new EstoqueProduto(){ ProdutoID = 2, QtdeTotalEstoque = 3, CustoTotalEstoque = 9 }
            };
            context.EstoqueProdutos.AddRange(estoqueProdutos);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela LotesInsumos
            List<LoteInsumo> lotesInsumos = new List<LoteInsumo>()
            {
                new LoteInsumo(){ DataCompra = new System.DateTime(2018,06,15), QtdeInicial = 15, QtdeDisponivel = 10, CustoMedio = 3,
                    CustoTotalInicial = 45, Validade = new System.DateTime(2018,06,30) , InsumoID = 1, MarcaID = 1, FornecedorID = 1 }
            };
            context.LotesInsumos.AddRange(lotesInsumos);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela MovimentacoesEstoqueInsumos
            List<MovimentacaoEstoqueInsumo> movimentacoesEstoqueInsumos = new List<MovimentacaoEstoqueInsumo>()
            {
                new MovimentacaoEstoqueInsumo(){ DataMovimentacao = new System.DateTime(2018,06,15), Qtde = 15, ValorMovimentacao = 45,  LoteInsumoID = 1 },
                new MovimentacaoEstoqueInsumo(){ DataMovimentacao = new System.DateTime(2018,06,25), Qtde = -5, ValorMovimentacao = 15,  LoteInsumoID = 1 }
            };
            context.MovimentacoesEstoqueInsumos.AddRange(movimentacoesEstoqueInsumos);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela LotesProdutos
            List<LoteProduto> lotesProdutos = new List<LoteProduto>()
            {
                new LoteProduto()
                {
                    DataProducao = new System.DateTime(2018,06,25), ValorVendaUnitario = 4, ProdutoID = 2 , QtdeInicial = 5, QtdeDisponivel = 3,
                    CustoMedio = 3, CustoTotalInicial = 15, Validade = new System.DateTime(2018,07,05), _ItensInsumoProducao = new List<LoteInsumoProducao>
                    {
                        new LoteInsumoProducao() { QtdeInsumo = 5, CustoInsumo = 15, LoteInsumoID = 1}
                    }
                }
            };
            context.LotesProdutos.AddRange(lotesProdutos);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela MovimentacoesEstoqueProdutos
            List<MovimentacaoEstoqueProduto> movimentacoesEstoqueProdutos = new List<MovimentacaoEstoqueProduto>()
            {
                new MovimentacaoEstoqueProduto(){ DataMovimentacao = new System.DateTime(2018,06,25), Qtde = 5, ValorMovimentacao = 15, LoteProdutoID = 1},
                new MovimentacaoEstoqueProduto(){ DataMovimentacao = new System.DateTime(2018,06,30), Qtde = -2, ValorMovimentacao = 6, LoteProdutoID = 1}
            };
            context.MovimentacoesEstoqueProdutos.AddRange(movimentacoesEstoqueProdutos);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela Vendas
            List<Venda> vendas = new List<Venda>()
            {
                new Venda()
                {
                     DataVenda = new System.DateTime(2018,06,30), ValorTotalVenda = 8, _ItensVenda = new List<ItemVenda>
                     {
                         new ItemVenda { ValorUnitarioItem = 4, ValorTotalItem = 8, QtdeProduto = 2, LoteProdutoID = 1}
                     }
                }
            };
            context.Vendas.AddRange(vendas);
            base.Seed(context);
            context.SaveChanges();
        }
    }
}