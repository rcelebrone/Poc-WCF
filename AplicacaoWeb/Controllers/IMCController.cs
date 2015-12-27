using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplicacaoWeb.Models;
using AplicacaoWeb.Data;

namespace AplicacaoWeb.Controllers
{
    public class IMCController : Controller
    {
        public ActionResult TesteWCF()
        {
            double peso = 71;
            double altura = 1.70;

            IMC imc = IMCRepository.ObterIMCViaWCF(peso, altura);

            return View(imc);
        }

        public ActionResult TesteWebApiClient()
        {
            double peso = 40;
            double altura = 1.60;

            IMC imc = IMCRepository.ObterIMCViaWebApiClient(peso, altura);

            return View(imc);
        }

        public ActionResult TesteRestSharp()
        {
            double peso = 72;
            double altura = 1.80;

            IMC imc = IMCRepository.ObterIMCViaRestSharp(peso, altura);

            return View(imc);
        }

        public ActionResult TesteJQuery()
        {
            return View();
        }
    }
}