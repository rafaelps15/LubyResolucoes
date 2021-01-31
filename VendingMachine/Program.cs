using System;
using System.Collections.Generic;
using VendingMachine.classes;

namespace VendingMachine
{
    class Program
    {
        private static List<Produto> produtosMaquina = ProdutoDado.ObterProdutos();

        static void Main(string[] args)
        {
            try
            {
                int opcaoEscolhida = EscolherOpcaoVisualizacao();

                switch (opcaoEscolhida)
                {
                    case 1:
                        VisualizarProdutos();
                        int opcaoCompraEscolhida = EscolherOpcapCompra();
                        int quantidadeCompra = EscolherQuantidadeCompra();
                        var valor = ObterValorPagar();
                        EfetuarCompra(opcaoCompraEscolhida, quantidadeCompra, valor);
                        CompraConcluida();
                        VisualizarEstoque();
                        break;

                    case 2:
                        VisualizarEstoque();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }
        }

        private static void CompraConcluida()
        {
            Console.WriteLine("Compra finalizada.");
            PularLinha();
        }

        private static void VisualizarEstoque()
        {
            PularLinha();
            Console.WriteLine("-------------------------------------------------------------");
            PularLinha();

            foreach (var produto in produtosMaquina)
            {
                Console.WriteLine($"{produto.Nome}: {produto.Quantidade}");
            }

            PularLinha();
            Console.WriteLine("-------------------------------------------------------------");
            PularLinha();
        }

        private static void EfetuarCompra(int opcaoCompraEscolhida, int quantidadeCompra, double valor)
        {
            PularLinha();

            var produtoComprar = produtosMaquina[opcaoCompraEscolhida - 1];

            var possuiEstoque = produtoComprar.Quantidade >= quantidadeCompra;

            if (!possuiEstoque)
                throw new Exception($"Produto não possui estoque para a quantidade desejada.\nQuantidade disponível: {produtoComprar.Quantidade}\n");

            var valorPagar = produtoComprar.Valor * quantidadeCompra;

            if (valor != valorPagar)
            {
                if (valor > valorPagar)
                {
                    Console.WriteLine($"Troco de {valor - valorPagar:C2}");
                }
                else
                {
                    Console.WriteLine($"Valor faltante de {valorPagar - valor:C2}");

                    PularLinha();

                    var valorRestante = Math.Round(valorPagar - valor, 2);
                    var entradaValorRestante = 0.0;

                    while (valorRestante != entradaValorRestante)
                    {
                        Console.Write("Pague o valor restante: ");
                        entradaValorRestante = double.Parse(Console.ReadLine());
                        PularLinha();
                    }
                }
            }

            produtoComprar.Quantidade -= quantidadeCompra;

            PularLinha();
        }

        static int EscolherOpcaoVisualizacao()
        {
            Console.WriteLine("1 - Visualizar Produtos.");
            Console.WriteLine("2 - Visualizar Estoque.");

            PularLinha();

            var opcao = int.Parse(Console.ReadLine());

            return opcao;
        }

        private static void VisualizarProdutos()
        {
            PularLinha();

            Console.WriteLine("Digite a opção de compra: ");

            PularLinha();

            for (int i = 0; i < produtosMaquina.Count; i++)
            {
                Produto produto = produtosMaquina[i];

                Console.WriteLine($"{i + 1} - {produto.Nome} - {produto.Valor:C2} - {produto.Quantidade} Disponíveis");
            }
        }

        private static int EscolherOpcapCompra()
        {
            PularLinha();

            var opcaoEscolhida = int.Parse(Console.ReadLine());

            PularLinha();

            return opcaoEscolhida;
        }

        private static int EscolherQuantidadeCompra()
        {
            Console.Write("Digite a quantidade: ");

            var quantidade = int.Parse(Console.ReadLine());

            return quantidade;
        }

        private static double ObterValorPagar()
        {
            PularLinha();

            Console.Write("Digite o valor a ser pago: ");
            var valor = double.Parse(Console.ReadLine());

            return valor;
        }

        private static void PularLinha()
        {
            Console.WriteLine();
        }
    }
}
