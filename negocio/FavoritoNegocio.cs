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


        public List<Articulo> listarFavoritos(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> listaFiltrada = new List<Articulo>();

            try
            {
                datos.setearConsulta("select A.Id, Nombre, Descripcion, ImagenUrl from ARTICULOS A INNER JOIN FAVORITOS F ON F.IdUser = @idUser AND F.IdArticulo = A.Id");
                datos.setearParametros("@idUser", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    listaFiltrada.Add(aux);
                }

                return listaFiltrada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void quitarFavorito(int idArticulo, int idUser)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("delete from favoritos where idUser = @idUsuario AND IdArticulo = @idArt");
                datos.setearParametros("@idUsuario", idUser);
                datos.setearParametros("@idArt", idArticulo);
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
    }
}
