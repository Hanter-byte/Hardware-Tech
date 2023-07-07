using HardWareTech.DATA.Models;
using HardWareTech.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Services
{
    public class VwProdutoClienteVendaService
    {
        public RepositoryVwProdutoClienteVenda oRepositoryVwProdutoClienteVenda { get; set; }
        public RepositoryCliente oRepositoryCliente { get; set; }
        public RepositoryProduto oRepositoryProduto { get; set; }
        public RepositoryProdutoVenda oRepositoryProdutoVenda { get; set; }
        public RepositoryVenda oRepositoryVenda { get; set; }
        public VwProdutoClienteVendaService()
        {
            oRepositoryVwProdutoClienteVenda = new();
            oRepositoryCliente = new();
            oRepositoryProduto = new();
            oRepositoryProdutoVenda = new();
            oRepositoryVenda = new();
        }
    }
}