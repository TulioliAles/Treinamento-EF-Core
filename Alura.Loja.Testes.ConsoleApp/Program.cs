using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //GravarUsandoEntity();
            RecuperaProdutos();
            //ExcluirProdutos();
            AtualizarProduto();
            RecuperaProdutos();
        }

        private static void AtualizarProduto()
        {
            using (var repo = new LojaContext())
            {
                Produto primeiroProduto = repo.Produtos.First();

                primeiroProduto.Nome = "Cassino Royale 2";

                repo.Produtos.Update(primeiroProduto);

                repo.SaveChanges();
            }
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new LojaContext())
            {
                IList<Produto> produtos = repo.Produtos.ToList();

                foreach (var item in produtos)
                {
                    repo.Produtos.Remove(item);
                }

                repo.SaveChanges();
            }
        }

        private static void RecuperaProdutos()
        {
            using (var repo = new LojaContext())
            {
                IList<Produto> produtos = repo.Produtos.ToList();

                Console.WriteLine("Foram encontrados {0} produtos.", produtos.Count);

                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);       
                }
                Console.ReadKey();
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Cassino Royale";
            p.Categoria = "Livros";
            p.Preco = 39.90;

            using (var contexto = new LojaContext())
            {
                contexto.Produtos.Add(p);
                contexto.SaveChanges();
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
