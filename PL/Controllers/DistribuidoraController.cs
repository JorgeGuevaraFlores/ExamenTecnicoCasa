using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class DistribuidoraController : Controller
    {
        // GET: Distribuidora
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Distribuidora distribuidora = new ML.Distribuidora();
            ML.Result result = BL.Distribuidora.GetAll();
            if (result.Correct)
            {
                distribuidora.Distribuidoras = result.Objects;
                return View(distribuidora);
            }
            else
            {
                return View(distribuidora);
            }
        }

        [HttpGet]
        public ActionResult Form(int? idDistribuidora)
        {

            if (idDistribuidora == null)
            {
                return View();
            }
            else
            {
                ML.Distribuidora distribuidora = new ML.Distribuidora();
                ML.Result result = BL.Distribuidora.GetById(idDistribuidora.Value);
                distribuidora = (ML.Distribuidora)result.Object;
                return View(distribuidora);
            }

        }

        [HttpPost]
        public ActionResult Form(ML.Distribuidora distribuidora)
        {
            if (distribuidora.IdDistribuidora == 0)
            {
                ML.Result result = BL.Distribuidora.Add(distribuidora);
                if (result.Correct)
                {
                    ViewBag.Message = "La distribuidora se ha dado de alta correctamente";
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                }
            }
            else
            {
                ML.Result result = BL.Distribuidora.Update(distribuidora);
                if (result.Correct)
                {
                    ViewBag.Message = "La distribuidora se ha actualizado correctamente";
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                }
            }

            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int idDistribuidora)
        {
            ML.Result result = BL.Distribuidora.Delete(idDistribuidora);
            if (result.Correct)
            {
                ViewBag.Message = "Se borro correctamente";
            } else
            {
                ViewBag.Message = result.ErrorMessage;
            }

            return PartialView("Modal");
        }

    }
}