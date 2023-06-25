using HardWareTech.DATA.Interfaces;
using HardWareTech.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Services
{
    public class ProdutoClienteManutencaoService
    {
        public RepositoryProdutoClienteManutencao oRepositoryProdutoClienteManutencao { get; set; }
        public ProdutoClienteManutencaoService()
        {
            oRepositoryProdutoClienteManutencao = new RepositoryProdutoClienteManutencao();
        }
    }
}