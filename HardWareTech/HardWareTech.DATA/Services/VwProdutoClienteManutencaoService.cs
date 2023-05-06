using HardWareTech.DATA.Models;
using HardWareTech.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Services
{
    public class VwProdutoClienteManutencaoService
    {
        public RepositoryVwProdutoClienteManutencao oRepositoryVwProdutoClienteManutencao { get; set; }
        public RepositoryCliente oRepositoryCliente { get; set; }
        public RepositoryProduto oRepositoryProduto { get; set; }
        public RepositoryProdutoClienteManutencao oRepositoryProdutoClienteManutencao { get; set; }
        public RepositoryCategoria oRepositoryCategoria { get; set; }
        public RepositoryServico oRepositoryServico { get; set; }
        public VwProdutoClienteManutencaoService()
        {
            oRepositoryVwProdutoClienteManutencao = new();
            oRepositoryCliente = new();
            oRepositoryProduto = new();
            oRepositoryProdutoClienteManutencao = new();
            oRepositoryCategoria = new();
            oRepositoryServico = new();
        }
    }
}