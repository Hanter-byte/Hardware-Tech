using HardWareTech.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Services
{
    public class VendaService
    {
        public VendaService()
        {
            oRepositoryVenda = new RepositoryVenda(); ;
            oRepositoryCliente = new RepositoryCliente();
            oRepositoryProduto = new RepositoryProduto();
            oRepositoryProdutoVenda = new RepositoryProdutoVenda();
        }

        public RepositoryVenda oRepositoryVenda { get; set; }
        public RepositoryCliente oRepositoryCliente { get; set; }
        public RepositoryProduto oRepositoryProduto { get; set; }
        public RepositoryProdutoVenda oRepositoryProdutoVenda { get; set; }

    }
}