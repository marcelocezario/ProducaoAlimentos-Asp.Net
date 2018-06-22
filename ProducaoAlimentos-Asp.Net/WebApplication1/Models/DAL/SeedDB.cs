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
                new Cidade(){ Nome = "São José dos Pinhais", EstadoID = 16 },
                new Cidade(){ Nome = "Florianópolis", EstadoID = 24 },
            };
            context.Cidades.AddRange(cidades);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela Enderecos
            List<Endereco> enderecos = new List<Endereco>()
            {
                new Endereco(){ Logradouro = "Rua Senador Accioly Filho", Numero = 511, Complemento = "Universidade Positivo", Bairro = "Cidade Industrial", Cep = "81310-000", CidadeID = 1},
                new Endereco(){ Logradouro = "Rua Aleatória", Numero = 10, Complemento = "", Bairro = "Centro", Cep = "83000-000", CidadeID = 2},
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
                new Cliente(){ Nome = "Antonio da Silva", Cpf_Cnpj = "164.842.566-67", Telefone = "99999-9999", Email = "antonio@gmail.com", EnderecoID = 1},
                new Cliente(){ Nome = "Siclano José dos Santos", Cpf_Cnpj = "394.824.178-36", Telefone = "3000-0000", Email = "siclano@hotmail.com", EnderecoID = 2},
            };
            context.Clientes.AddRange(clientes);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela Fornecedores
            List<Fornecedor> fornecedores = new List<Fornecedor>()
            {
                new Fornecedor(){ Nome = "Alimentos Distribuição Ltda", Cpf_Cnpj = "66.752.485/0001-88", Telefone = "0800-777-7777", Email = "pedidos@alimentos.com.br", EnderecoID = 2},
                new Fornecedor(){ Nome = "Delivery Center S.A", Cpf_Cnpj = "30.636.422/0001-19", Telefone = "3131-3131", Email = "contato_delivery@hotmail.com", EnderecoID = 1},
            };
            context.Fornecedores.AddRange(fornecedores);
            base.Seed(context);
            context.SaveChanges();

            // Inicializando dados na tabela Insumos
            List<Insumo> insumos = new List<Insumo>()
            {
                new Insumo(){ Nome = "Açúcar", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Arroz", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Batata", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Creme de Leite", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Farinha de Trigo", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Feijão", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Leite", UnidadeDeMedidaID = 2},
                new Insumo(){ Nome = "Leite Condensado", UnidadeDeMedidaID = 3},
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
                                new InsumoComposicaoProduto(){ InsumoID = 3, QtdeInsumo = 0.6},
                                new InsumoComposicaoProduto(){ InsumoID = 5, QtdeInsumo = 0.3},
                                new InsumoComposicaoProduto(){ InsumoID = 10, QtdeInsumo = 1},
                                new InsumoComposicaoProduto(){ InsumoID = 9, QtdeInsumo = 0.01}
                            } },
                            new Produto() {Nome = "Bolo", UnidadeDeMedidaID = 3, _ComposicaoProduto = new List<InsumoComposicaoProduto>()
                            {
                                new InsumoComposicaoProduto(){ InsumoID = 10, QtdeInsumo = 10 },
                                new InsumoComposicaoProduto(){ InsumoID = 5, QtdeInsumo = 0.15},
                                new InsumoComposicaoProduto(){ InsumoID = 1, QtdeInsumo = 0.15},
                                new InsumoComposicaoProduto(){InsumoID = 8, QtdeInsumo = 0.395}
                            } },
                            };
            context.Produtos.AddRange(produtos);
            base.Seed(context);
            context.SaveChanges();
            //
            //
            //            List<EstoqueInsumo> estoqueInsumo = new List<EstoqueInsumo>()
            //            {
            //                new EstoqueInsumo(){ InsumoID = 3, QtdeTotalEstoque = 0, CustoTotalEstoque = 0 }
            //            };
            //            context.EstoqueInsumos.AddRange(estoqueInsumo);
            //            base.Seed(context);
            //            context.SaveChanges();
            //

        }
    }
}