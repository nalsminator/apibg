using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibg._Data
{
    public class PlanPago
    {
        public int CodigoRespuesta { get; set; }
        public string MensajeRespuesta { get; set; }
        public string NombreCliente { get; set; }
        public string AbreviaturaNivel { get; set; }
        public string AbreviaturaSubNivel { get; set; }
        public string DatosAdicionales { get; set; }
        public object DetalleDeuda { get; set; }
    }
}
