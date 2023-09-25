using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Artista
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    var query = context.ArtistaGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query.Count > 0)
                    {
                        
                        foreach (var obj in query)
                        {
                            ML.Artista artista = new ML.Artista();
                            artista.IdArtista = obj.IdArtista;
                            artista.Nombre = obj.Nombre;
                            artista.ApellidoPaterno = obj.ApellidoPaterno;
                            artista.ApellidoMaterno = obj.ApellidoMaterno;
                            result.Objects.Add(artista);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay artistas";
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

        public static ML.Result GetById(int idArtista)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    var query = context.ArtistaGetById(idArtista).SingleOrDefault();

                    if (query != null)
                    {

                        ML.Artista artista = new ML.Artista();
                        artista.IdArtista = query.IdArtista;
                        artista.Nombre = query.Nombre;
                        artista.ApellidoPaterno = query.ApellidoPaterno;
                        artista.ApellidoMaterno = query.ApellidoMaterno;
                        
                        result.Object = artista;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay artistas con ese ID";
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

        public static ML.Result Add(ML.Artista artista)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    int query = context.ArtistaAdd(artista.Nombre, artista.ApellidoPaterno, artista.ApellidoMaterno);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo dar de alta";
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

        public static ML.Result Update(ML.Artista artista)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    int query = context.ArtistaUpdate(artista.IdArtista, artista.Nombre, artista.ApellidoPaterno, artista.ApellidoMaterno);
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

        public static ML.Result Delete(int idArtista)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    int query = context.ArtistaDelete(idArtista);
                    if(query > 0)
                    {
                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo borrar el Artista";
                    }
                }

            } catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage= ex.InnerException.Message;
                result.Ex = ex;
            }

            return result;
        }

    }
}
