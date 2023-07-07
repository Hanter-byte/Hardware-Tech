using HardWareTech.DATA.Interfaces;
using HardWareTech.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Repositories
{
    public class RepositoryVwProdutoClienteVenda : RepositoryBase<VwProdutoClienteVenda>, IRepositoryVwProdutoClienteVenda
    {
        public RepositoryVwProdutoClienteVenda(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}