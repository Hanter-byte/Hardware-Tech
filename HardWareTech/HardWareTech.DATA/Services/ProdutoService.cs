using HardWareTech.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Services
{
    public class ProdutoService
    {
        public RepositoryProduto oRepositoryProduto { get; set; }
        public ProdutoService()
        {
            oRepositoryProduto = new RepositoryProduto();
        }
    }
}