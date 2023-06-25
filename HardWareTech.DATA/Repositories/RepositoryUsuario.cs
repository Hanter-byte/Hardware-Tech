using HardWareTech.DATA.Interfaces;
using HardWareTech.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareTech.DATA.Repositories
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        public RepositoryUsuario(bool SaveChanges = true) : base(SaveChanges)
        {

        }

        public Usuario BuscarPorLogin(string login)
        {
            return _Contexto.Usuario.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }
    }
}