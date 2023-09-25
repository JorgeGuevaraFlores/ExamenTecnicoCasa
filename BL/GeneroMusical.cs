using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GeneroMusical
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result(); 
            try
            {
                using(DL.JGuevaraExamenTecnicoEntities context = new DL.JGuevaraExamenTecnicoEntities())
                {
                    var query = context.GeneroMusicalGetAll().ToList();

                    if(query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach(var obj in query)
                        {
                            ML.GeneroMusical genero = new ML.GeneroMusical();
                            genero.IdGenero = obj.IdGenero;
                            genero.Nombre = obj.Nombre;
                            result.Objects.Add(genero);
                        }

                        result.Correct = true;
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
