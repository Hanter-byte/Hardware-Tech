using HardWareTech.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Services
{
    public class ServicoService
    {
        public RepositoryServico oRepositoryServico { get; set; }
        public ServicoService() {
            oRepositoryServico = new RepositoryServico();
        }
    }
}