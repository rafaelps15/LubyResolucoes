using System.Collections.Generic;

namespace VendingMachine.classes
{
    public class ProdutoDado
    {
        public static List<Produto> ObterProdutos()
        {
            var produtos = new List<Produto>();

            Produto produtoRefrigerante = new Produto();
            produtoRefrigerante.Nome = "Refrigerante";
            produtoRefrigerante.Quantidade = 8;
            produtoRefrigerante.Valor = 4.5;

            Produto produtoSuco = new Produto();
            produtoSuco.Nome = "Suco";
            produtoSuco.Quantidade = 10;
            produtoSuco.Valor = 3.5;

            Produto produtoCha = new Produto();
            produtoCha.Nome = "Chá verde";
            produtoCha.Quantidade = 3;
            produtoCha.Valor = 0.20;

            produtos.Add(produtoRefrigerante);
            produtos.Add(produtoSuco);
            produtos.Add(produtoCha);

            return produtos;
        }
    }
}
