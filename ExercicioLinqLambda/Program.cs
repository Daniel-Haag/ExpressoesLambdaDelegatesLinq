using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;


namespace ExercicioLinqLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pressione Enter para o arquivo .txt ser lido.");
            Console.Read();

            string path = "../../../Produtos.txt";

            string[] linhas = File.ReadAllLines(path);

            List<ProdutoModel> produtos = new List<ProdutoModel>();

            for (int i = 0; i < linhas.Length; i++)
            {
                var produtoNomeValor = linhas[i].Trim().Split(',');

                ProdutoModel produto = new ProdutoModel();

                produto.Nome = produtoNomeValor[0];
                produto.Valor = double.Parse(produtoNomeValor[1], CultureInfo.InvariantCulture);

                produtos.Add(produto);
            }

            double valorMedio = double.Parse(produtos.Select(x => x.Valor).Average().ToString("F2"));

            Console.WriteLine($"Valor médio: {valorMedio}");
            Console.WriteLine($"Produtos ordenados:");

            produtos = produtos.Where(x => x.Valor < valorMedio).OrderByDescending(x => x.Nome).ToList();

            foreach (var item in produtos)
            {
                Console.WriteLine(item.Nome);
            }

            Console.Read();

        }
    }
}
