using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class Distribuidora
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    var query = context.DistribuidoraGetAll().ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Distribuidora distribuidora = new ML.Distribuidora();
                            distribuidora.IdDistribuidora = obj.IdDistribuidora;
                            distribuidora.Nombre = obj.Nombre;
                            distribuidora.Direccion = obj.Direccion;
                            distribuidora.Email = obj.Email;
                            distribuidora.Telefono = obj.Telefono;
                            result.Objects.Add(distribuidora);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay distribuidoras";
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

        public static ML.Result GetById(int idDistribuidora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    var query = context.DistribuidoraGetById(idDistribuidora).SingleOrDefault();

                    if (query != null)
                    {

                        ML.Distribuidora distribuidora = new ML.Distribuidora();
                        distribuidora.IdDistribuidora = query.IdDistribuidora;
                        distribuidora.Nombre = query.Nombre;
                        distribuidora.Direccion = query.Direccion;
                        distribuidora.Email = query.Email;
                        distribuidora.Telefono = query.Telefono;
                        result.Object = distribuidora;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay distribuidora con ese ID: "+idDistribuidora;
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

        public static ML.Result Add(ML.Distribuidora distribuidora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    int query = context.DistribuidoraAdd(distribuidora.Nombre, distribuidora.Direccion, distribuidora.Email, distribuidora.Telefono);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo agregar la Distribuidora";
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

        public static ML.Result Update(ML.Distribuidora distribuidora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    int query = context.DistribuidoraUpdate(distribuidora.IdDistribuidora, distribuidora.Nombre, distribuidora.Direccion, distribuidora.Email, distribuidora.Telefono);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar la Distribuidora";
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

        public static ML.Result Delete(int idDistribuidora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    int query = context.DistribuidoraDelete(idDistribuidora);
                    if (query > 0)
                    {
                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar la distribuidora";
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

    }
}
