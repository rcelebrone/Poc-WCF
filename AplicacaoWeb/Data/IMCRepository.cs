using AplicacaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using RestSharp;

namespace AplicacaoWeb.Data
{
    public class IMCRepository
    {
        public static IMC ObterIMCViaWCF(double peso, double altura)
        {
            using (IMCService.IMCServiceClient client = new IMCService.IMCServiceClient()) {
                IMCService.ResultadoIMC retorno = client.CalculaIMC(peso, altura);

                IMC imc = new IMC();
                imc.Peso = retorno.Peso;
                imc.Altura = retorno.Altura;
                imc.ValorIMC = retorno.valorIMC;
                imc.DescSituacao = retorno.DescSituacao;

                return imc;
            }
        }

        public static IMC ObterIMCViaWebApiClient(double peso, double altura)
        {
            using (var client = new HttpClient()) {
                //limpa o header atual
                client.DefaultRequestHeaders.Accept.Clear();
                //configura o header para trabalhar com json
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue(
                        ConfigurationManager.AppSettings["JsonHeader"]));

                //criar uma mensagem de retorno
                HttpResponseMessage response = client.GetAsync(
                       ConfigurationManager.AppSettings["UrlBase"] + 
                       string.Format("calculoimc?peso={0}&altura={1}",
                       doubleToString(peso),
                       doubleToString(altura))).Result;

                response.EnsureSuccessStatusCode();
                
                return response.Content.ReadAsAsync<IMC>().Result;
            }
        }

        public static IMC ObterIMCViaRestSharp(double peso, double altura) {


            RestClient client = new RestClient(ConfigurationManager.AppSettings["UrlBase"]);

            RestRequest requisicao = new RestRequest(
                string.Format("calculoimc?peso={0}&altura={1}",
                       doubleToString(peso),
                       doubleToString(altura)), Method.GET);

            IRestResponse<IMC> resposta = client.Execute<IMC>(requisicao);

            return resposta.Data;
        }

        private static string doubleToString(double v) {
            return v.ToString().Replace(",", ".");
        }
    }
}