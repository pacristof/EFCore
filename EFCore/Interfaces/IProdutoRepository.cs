using EFCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Interfaces
{
    interface IProdutoRepository
    {
        List<Produto> BuscarPorNome(string nome);
        Produto BuscarPorID(Guid id);
        void Adicionar(Produto produto);
        void Editar(Produto produto);
        void Remover(Guid id);
        List<Produto> Listar();
    }
}
