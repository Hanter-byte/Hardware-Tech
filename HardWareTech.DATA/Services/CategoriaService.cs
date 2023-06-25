using HardWareTech.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Services
{
    public class CategoriaService
    {
        public RepositoryCategoria oRepositoryCategoria { get; set; }
        public CategoriaService()
        {
            oRepositoryCategoria = new RepositoryCategoria();
        }
    }
}