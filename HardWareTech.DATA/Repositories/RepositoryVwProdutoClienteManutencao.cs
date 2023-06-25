using HardWareTech.DATA.Interfaces;
using HardWareTech.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Repositories
{
    public class RepositoryVwProdutoClienteManutencao : RepositoryBase<VwProdutoClienteManutencao>, IRepositoryVwProdutoClienteManutencao
    {
        public RepositoryVwProdutoClienteManutencao(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}