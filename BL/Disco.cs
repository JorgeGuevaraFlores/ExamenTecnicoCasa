using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Disco
    {
        public static ML.Result Add(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    int query = context.DiscoAdd(disco.Titulo, disco.Duracion, disco.Anio, disco.Ventas, disco.Artista.IdArtista, disco.GeneroMusical.IdGenero, disco.Distribuidora.IdDistribuidora);

                    if(query > 0 )
                    {
                        result.Correct = true;
                    } else
                    {
                        result.Correct= false;
                        result.ErrorMessage = "No se pudo dar de alta";
                    }

                }

            } catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.InnerException.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Update(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    int query = context.DiscoUpdate(disco.IdDisco,disco.Titulo, disco.Duracion, disco.Anio, disco.Ventas, disco.Disponibilidad, disco.Artista.IdArtista, disco.GeneroMusical.IdGenero, disco.Distribuidora.IdDistribuidora);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.InnerException.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    var query = context.DiscoGetAll().ToList();
                    if(query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach(var getDisco in query)
                        {
                            ML.Disco disco = new ML.Disco();
                            disco.IdDisco = getDisco.IdDisco;
                            disco.Titulo = getDisco.Titulo;
                            disco.Duracion = getDisco.Duracion;
                            disco.Anio = getDisco.Anio;
                            disco.Ventas = (decimal)getDisco.Ventas;
                            disco.Disponibilidad = (bool)getDisco.Disponibilidad;

                            disco.Artista = new ML.Artista();
                            disco.GeneroMusical = new ML.GeneroMusical();
                            disco.Distribuidora = new ML.Distribuidora();

                            disco.Artista.IdArtista = getDisco.IdArtista;
                            disco.Artista.Nombre = getDisco.ArtistaNombre;
                            disco.Artista.ApellidoPaterno = getDisco.ArtistaApellidoPaterno;
                            disco.Artista.ApellidoMaterno = getDisco.ArtistaApellidoMaterno;

                            disco.GeneroMusical.IdGenero = getDisco.IdGenero;
                            disco.GeneroMusical.Nombre = getDisco.GeneroMusicalNombre;

                            disco.Distribuidora.IdDistribuidora = getDisco.IdDistribuidora;
                            disco.Distribuidora.Nombre = getDisco.DistribuidoraNombre;
                            disco.Distribuidora.Direccion = getDisco.Direccion;
                            disco.Distribuidora.Email = getDisco.Email;
                            disco.Distribuidora.Telefono = getDisco.Telefono;

                            result.Objects.Add(disco);
                        }

                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros en la tabla";
                    }
                }

            } catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.InnerException.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetById(int idDisco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    var query = context.DiscoGetById(idDisco).SingleOrDefault();

                    if (query != null)
                    {
                            ML.Disco disco = new ML.Disco();
                            disco.IdDisco = query.IdDisco;
                            disco.Titulo = query.Titulo;
                            disco.Duracion = query.Duracion;
                            disco.Anio = query.Anio;
                            disco.Ventas = (decimal)query.Ventas;
                            disco.Disponibilidad = (bool)query.Disponibilidad;

                            disco.Artista = new ML.Artista();
                            disco.GeneroMusical = new ML.GeneroMusical();
                            disco.Distribuidora = new ML.Distribuidora();

                            disco.Artista.IdArtista = query.IdArtista;
                            disco.Artista.Nombre = query.ArtistaNombre;
                            disco.Artista.ApellidoPaterno = query.ArtistaApellidoPaterno;
                            disco.Artista.ApellidoMaterno = query.ArtistaApellidoMaterno;

                            disco.GeneroMusical.IdGenero = query.IdGenero;
                            disco.GeneroMusical.Nombre = query.GeneroMusicalNombre;

                            disco.Distribuidora.IdDistribuidora = query.IdDistribuidora;
                            disco.Distribuidora.Nombre = query.DistribuidoraNombre;
                            disco.Distribuidora.Direccion = query.Direccion;
                            disco.Distribuidora.Email = query.Email;
                            disco.Distribuidora.Telefono = query.Telefono;

                            result.Object = disco;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el registro";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.InnerException.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Delete (int idDisco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    var query = context.DiscoDelete(idDisco);
                    if (query > 0)
                    {
                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar";
                    }
                }

            } catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.InnerException.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
