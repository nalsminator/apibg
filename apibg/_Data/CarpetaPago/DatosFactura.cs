using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibg._Data
{
    public class DatosFactura
    {
        public int NroAutorizacion { get; set; }
        public int NroFactura { get; set; }
        public string CodigoControl { get; set; }
        public int  FacturaNITCI { get; set; }
        public string FacturaNombre { get; set; }
        public string CodigoMoneda { get; set; }
        public decimal MontoFacturado { get; set; }
        public string DatosAdicionales { get; set; }
    }
}
