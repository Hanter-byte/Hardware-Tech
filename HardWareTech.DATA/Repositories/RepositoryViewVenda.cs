using CursoAspNetCoreMVC.DATA.Interfaces;
using HardWareTech.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Repositories
{
    public class RepositoryViewVenda : RepositoryBase<ViewVendas>, IRepositoryViewVenda
    {
        public RepositoryViewVenda(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}
