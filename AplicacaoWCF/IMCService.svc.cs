using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AplicacaoWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IMCService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select IMCService.svc or IMCService.svc.cs at the Solution Explorer and start debugging.
    public class IMCService : IIMCService
    {
        public ResultadoIMC CalculaIMC(double peso, double altura)
        {
            ResultadoIMC imc = new ResultadoIMC();

            imc.Peso = peso;
            imc.Altura = altura;
            imc.valorIMC = peso / (altura * altura);

            if (imc.valorIMC > 25)
                imc.DescSituacao = "Acima do Peso";
            else if (imc.valorIMC < 18.5)
                imc.DescSituacao = "Abaixo do Peso";
            else
                imc.DescSituacao = "Peso Normal";

            return imc;
        }

        public void DoWork()
        {
        }
    }
}
