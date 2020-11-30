using EFCore.Context;
using EFCore.Domains;
using EFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _ctx;

        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }
        /// <summary>
        /// Adiciona um produto
        /// </summary>
        /// <param name="produto">Produto a ser adicionado</param>
        public void Adicionar(Produto produto)
        {
            try
            {
                // Dados salvo no contexto em memória
                _ctx.Produtos.Add(produto);

                 // _ctx.Set<Produto>().Add(produto);
                 // _ctx.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                // Salva as alterações no banco de dados
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Busca itens por ID
        /// </summary>
        /// <param name="id">ID do produto</param>
        /// <returns>Resultado da busca</returns>
        public Produto BuscarPorID(Guid id)
        {
            try
            {
                // Retorna uma lista com o campo de pesquisa desejado
                // List<Produto> produto = _ctx.Produtos.Where(c => c.Nome == "nome do produto").ToList();

                // Retorna o produto procurado por id
                // Produto produto = _ctx.Produtos.Where(c => c.Id == id).FirstOrDefault();

                // Retorna o produto procurado por id
                // Produto produto = _ctx.Produtos.FirstOrDefault(c => c.Id == id);

                // Retorna o produto procurado por id
                Produto produto = _ctx.Produtos.Find(id);

                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Busca produto pelo nome
        /// </summary>
        /// <param name="nome">Nome a ser procurado</param>
        /// <returns>Produto com nome pesquisado</returns>
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                // Procura produto por nome
                List<Produto> produto = _ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();

                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        /// <summary>
        /// Edita um produto
        /// </summary>
        /// <param name="produto">Produto a ser editado</param>
        public void Editar(Produto produto)
        {
            try
            {
                // Busca um produto por id para fazer alteração
                Produto produtoTemp = BuscarPorID(produto.Id);

                // Caso não encontre um produto, ele cria uma exception
                if (produto == null)
                    throw new Exception("Produto não encontrado.");

                // Informações a serem alteradas
                produtoTemp.Nome  = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                // Altera o produto
                _ctx.Produtos.Update(produtoTemp);

                // Salva as mudanças
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Lista os produtos
        /// </summary>
        /// <returns>Lista de produtos</returns>
        public List<Produto> Listar()
        {
            try
            {
                // Lista os produtos
                List<Produto> produtos = _ctx.Produtos.ToList();
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">Id utilizado para remover</param>
        public void Remover(Guid id)
        {
            try
            {
                // Faz uma busca por ID para fazer a remoção do produto
                Produto produto = BuscarPorID(id);

                // Caso não encontre um produto, ele cria uma exception
                if (produto == null)
                    throw new Exception("Produto não encontrado");
                // Remove um produto
                _ctx.Produtos.Remove(produto);

                // Salva as mudanças
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
