using HardWareTech.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Services
{
    public class UsuarioService
    {
        public RepositoryUsuario oRepositoryUsuario { get; set; }
        public UsuarioService()
        {
            oRepositoryUsuario = new RepositoryUsuario();
        }
    }
}