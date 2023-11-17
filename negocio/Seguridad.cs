using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    //Genero una clase estatica para no tener que generar una instancia
    //para usarla
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            User usuario = user != null ? (User)user : null;
            if (usuario != null && usuario.Id != 0)
                return true;
            else
                return false;
        }

        public static bool esAdmin(object user)
        {
            User usuario = user != null ? (User)user : null;
            return usuario != null ? usuario.Admin : false;
        }
    }
}
