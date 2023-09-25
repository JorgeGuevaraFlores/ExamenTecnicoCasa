using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class DiscoController : Controller
    {
        // GET: Disco
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Disco disco = new ML.Disco();
            disco.Artista = new ML.Artista();
            disco.GeneroMusical = new ML.GeneroMusical();
            disco.Distribuidora = new ML.Distribuidora();

            ML.Result result = BL.Disco.GetAll();

            disco.Discos = result.Objects;

            if (result.Correct)
            {
                return View(disco);
            } else
            {
                return View(disco);
            }
        }

        [HttpGet]
        public ActionResult Form(int? idDisco) {
            ML.Disco disco = new ML.Disco();
            disco.Artista = new ML.Artista();
            disco.GeneroMusical = new ML.GeneroMusical();
            disco.Distribuidora = new ML.Distribuidora();

            disco.Artista.Artistas = BL.Artista.GetAll().Objects;
            disco.GeneroMusical.Generos = BL.GeneroMusical.GetAll().Objects;
            disco.Distribuidora.Distribuidoras = BL.Distribuidora.GetAll().Objects;

            if (idDisco == null) //add
            {
                return View(disco);
            } else
            {
                ML.Result result = BL.Disco.GetById(idDisco.Value);
                if (result.Correct)
                {
                    disco = (ML.Disco)result.Object;
                    disco.Artista.Artistas = BL.Artista.GetAll().Objects;
                    disco.GeneroMusical.Generos = BL.GeneroMusical.GetAll().Objects;
                    disco.Distribuidora.Distribuidoras = BL.Distribuidora.GetAll().Objects;
                    return View(disco);
                }
                
            }

            return View();
        }

        [HttpPost]
        public ActionResult Form(ML.Disco disco)
        {
            if(disco.IdDisco == 0) //add
            {
                ML.Result result = BL.Disco.Add(disco);
                if (result.Correct)
                {
                    ViewBag.Message = "El disco se ha agregado correctamente";
                } else
                {
                    ViewBag.Message = result.ErrorMessage;
                }
            }
            else//update
            {
                 ML.Result result = BL.Disco.Update(disco);
                if (result.Correct)
                {
                    ViewBag.Message = "El disco se ha actualizado correctamente";
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                }
            }

            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete (int idDisco)
        {
            ML.Result result = BL.Disco.Delete(idDisco);
            if (result.Correct)
            {
                ViewBag.Message = "Se ha borrado el disco";
            } else
            {
                ViewBag.Message = result.ErrorMessage;
            }

            return PartialView("Modal");
        }
    }
}