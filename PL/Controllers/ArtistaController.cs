using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ArtistaController : Controller
    {
        // GET: Artista
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Artista artista = new ML.Artista();
            ML.Result result = BL.Artista.GetAll();

            if (result.Correct)
            {
                artista.Artistas = result.Objects;
                return View(artista);
            }
            else
            {
                return View(artista);

            }

        }

        [HttpGet]
        public ActionResult Form(int? idArtista)
        {
            ML.Artista artista = new ML.Artista();

            if(idArtista == null)//add
            {
                return View(artista);
            }
            else
            {
                ML.Result result = BL.Artista.GetById(idArtista.Value);
                artista = (ML.Artista)result.Object;

                return View(artista);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Artista artista)
        {
            if(artista.IdArtista == 0)//add
            {
                ML.Result result = BL.Artista.Add(artista);
                if (result.Correct)
                {
                    ViewBag.Message = "El artista se ha agregado correctamente";
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                }
            } else
            {
                ML.Result result = BL.Artista.Update(artista);
                if (result.Correct)
                {
                    ViewBag.Message = "El artista se ha actualizado correctamente";
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                }
            }

            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete (int idArtista)
        {
            ML.Result result = BL.Artista.Delete(idArtista);
            if (result.Correct)
            {
                ViewBag.Message = "El artista se ha eliminado";
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }

            return PartialView("Modal");
        }
    }
}