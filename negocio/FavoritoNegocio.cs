using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class FavoritoNegocio
    {
        public void agregarFavorito(int usuario, int articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into FAVORITOS values (@idUsuario,@idArticulo)");
                datos.setearParametros("@idUsuario", usuario);
                datos.setearParametros("@idArticulo", articulo);
                datos.ejecutarEscritura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<int> listarFavoritos(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<int> listaFiltrada = new List<int>();

            try
            {
                datos.setearConsulta("select IdArticulo from FAVORITOS where IdUser=@idUser");
                datos.setearParametros("@idUser", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    listaFiltrada.Add((int)datos.Lector["IdArticulo"]);
                }

                return listaFiltrada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
