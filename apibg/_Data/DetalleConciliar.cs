using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibg._Data
{
    public class DetalleConciliar
    {
        public DateTime Fechatransaccion { get; set; }
        public string NroTransaccionEmpresa { get; set; }
        public int NroTransaccionBanco { get; set; }
        public string CodigoTipoBusqueda { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string CodigoMoneda { get; set; }
        public decimal MontoPagado { get; set; }
        public string Usuario { get; set; }
    }
}
