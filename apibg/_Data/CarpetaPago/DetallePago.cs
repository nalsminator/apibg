using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibg._Data
{
    public class DetallePago
    {
        public string AbreviaturaConceptoPago { get; set; }
        public int NroCuota { get; set; }
        public string CodigoMoneda { get; set; }
        public decimal MontoNeto { get; set; }
        public string DatosAdicionales { get; set; }

    }
}