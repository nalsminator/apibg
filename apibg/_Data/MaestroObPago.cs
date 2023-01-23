using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibg._Data
{
    public class MaestroObPago
    {
        public DateTime FechaTransaccion { get; set; }
        public string NroTransaccion { get; set; }
        public string CodigoMoneda { get; set; }
        public decimal MontoTotalPagado { get; set; }
        public string Usuario { get; set; }
        public object DetallePago { get; set; }
        public object DatosFactura { get; set; }
    }
}
