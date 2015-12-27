using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace AplicacaoWCF
{
    [DataContract]
    public class ResultadoIMC
    {
        [DataMember]
        public double Peso { get; set; }

        [DataMember]
        public double Altura { get; set; }

        [DataMember]
        public double valorIMC { get; set; }

        [DataMember]
        public string DescSituacao { get; set; }

    }
}