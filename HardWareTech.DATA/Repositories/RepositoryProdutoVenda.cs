using HardWareTech.DATA.Interfaces;
using HardWareTech.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Repositories
{
    public class RepositoryProdutoVenda : RepositoryBase<ProdutoVenda>, IRepositoryProdutoVenda
    {
        public RepositoryProdutoVenda(bool SaveChanges = true) : base(SaveChanges) { }
        public void IncluirProdutosDaVenda(List<ProdutoVenda> produtosVendas)
        {
            produtosVendas.ForEach(produtoVenda =>
            {
                _Contexto.ProdutoVenda.Add(produtoVenda);
            });

            _Contexto.SaveChanges();
        }
    }
}
