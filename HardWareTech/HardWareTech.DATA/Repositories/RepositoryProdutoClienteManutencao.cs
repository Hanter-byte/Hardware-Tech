using HardWareTech.DATA.Interfaces;
using HardWareTech.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Repositories
{
    public class RepositoryProdutoClienteManutencao : RepositoryBase<ProdutoClienteManutencao>, IProdutoClienteManutencao
    {
        public RepositoryProdutoClienteManutencao(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}