using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int idTipoUsuario { get; set; }
        public TipoUsuarioDomain tipoUsuario { get; set; }
    }
}
