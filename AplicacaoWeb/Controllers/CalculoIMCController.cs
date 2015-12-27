using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AplicacaoWeb.Models;

namespace AplicacaoWeb.Controllers
{
    public class CalculoIMCController : ApiController
    {
        public object GetIMC(double peso, double altura)
        {
            double valorIMC = peso / (altura * altura);
            string descSituacao;


            if (valorIMC > 25)
                descSituacao = "Acima do Peso";
            else if (valorIMC < 18.5)
                descSituacao = "Abaixo do Peso";
            else
                descSituacao = "Peso Normal";

            return new {
                Peso = peso,
                Altura = altura,
                ValorIMC = valorIMC,
                DescSituacao = descSituacao
            };
        }
    }
}
