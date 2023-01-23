using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using apibg._Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace apibg.Controllers
{
    public class BusquedaController : Controller
    {
        [Route("api/VerificarConectividad")]
        [HttpGet]
        public object VerificarConectividad(int CodigoConvenio, string Usuario1, string UsuarioConexion, string ContraseniaConexion) => WebAPI.VerificarConectividad(CodigoConvenio, Usuario1, UsuarioConexion, ContraseniaConexion);

        [Route("api/ObtenerConceptosPago")]
        [HttpGet]
        public object ObtenerConceptosPago(int CodigoConvenio, string Usuario1, string UsuarioConexion, string ContraseniaConexion) => WebAPI.ObtenerConceptosPago(CodigoConvenio, Usuario1, UsuarioConexion, ContraseniaConexion);

        [Route("api/ObtenerListaNiveles")]
        [HttpGet]
        public object ObtenerListaNiveles(int CodigoConvenio, string Usuario1, string UsuarioConexion, string ContraseniaConexion) => WebAPI.ObtenerListaNiveles(CodigoConvenio, Usuario1, UsuarioConexion, ContraseniaConexion);

        [Route("api/ObtenerListaSubNiveles")]
        [HttpGet]
        public object ObtenerListaSubNiveles(int CodigoConvenio, string Usuario1, string UsuarioConexion, string ContraseniaConexion) => WebAPI.ObtenerListaSubNiveles(CodigoConvenio, Usuario1, UsuarioConexion, ContraseniaConexion);

        [Route("api/ObtenerListaClientes")]
        [HttpGet]
        public object ObtenerListaClientes(int CodigoConvenio, string Usuario1, string TipoConsulta, string UsuarioConexion, string ContraseniaConexion, string CodigoTipoBusqueda, string CodigoCliente) => WebAPI.ObtenerListaClientes(CodigoConvenio, Usuario1, TipoConsulta, UsuarioConexion, ContraseniaConexion, CodigoTipoBusqueda, CodigoCliente);

        [Route("api/ObtenerDeuda")]
        [HttpGet]
        public object ObtenerDeuda(int CodigoConvenio, string CodigoTipoBusqueda, string CodigoCliente, string Usuario1, string UsuarioConexion, string ContraseniaConexion) => WebAPI.ObtenerDeuda(CodigoConvenio, CodigoTipoBusqueda, CodigoCliente, Usuario1, UsuarioConexion, ContraseniaConexion);

        [Route("api/RegistrarPago")]
        [HttpGet]
        public object RegistrarPago(int CodigoConvenio, DateTime FechaTransaccion, string CodigoTipoBusqueda, string CodigoCliente, int facturaNITCI, string FacturaNombre, int NroTransaccion, string Usuario1, string UsuarioConexion, string ContraseniaConexion, List < DetallePago > DetallePago, List < DatosFactura > DatosFactura) => WebAPI.RegistrarPago(CodigoConvenio, FechaTransaccion, CodigoTipoBusqueda, CodigoCliente, facturaNITCI, FacturaNombre, NroTransaccion, Usuario1, UsuarioConexion, ContraseniaConexion, DetallePago, DatosFactura);

        [Route("api/ConsultarTransaccion")]
        [HttpGet]
        public object ConsultarTransaccion(int CodigoConvenio, DateTime FechaTransaccion, string NroTransaccion, string Usuario1, string UsuarioConexion, string ContraseniaConexion) => WebAPI.ConsultarTransaccion(CodigoConvenio, FechaTransaccion, NroTransaccion, Usuario1, UsuarioConexion, ContraseniaConexion);

        [Route("api/ObtenerDetallePagos")]
        [HttpGet]
        public object ObtenerDetallepagos(int CodigoConvenio, string CodigoTipoBusqueda, string CodigoCliente, DateTime FechaInicio, DateTime FechaFin, string Usuario1, string UsuarioConexion, string ContraseniaConexion) => WebAPI.ObtenerDetallePagos(CodigoConvenio, CodigoTipoBusqueda, CodigoCliente, FechaInicio, FechaFin, Usuario1, UsuarioConexion, ContraseniaConexion);

        [Route("api/ObtenerPlanPagos")]
        [HttpGet]
        public object ObtenerPlanPagos(int CodigoConvenio, string CodigoTipoBusqueda, string CodigoCliente, string Usuario1, string UsuarioConexion, string ContraseniaConexion) => WebAPI.ObtenerPlanPagos(CodigoConvenio, CodigoTipoBusqueda, CodigoCliente, Usuario1, UsuarioConexion, ContraseniaConexion);

        [Route("api/ConciliarPagos")]
        [HttpGet]
        public object ConciliarPagos(int CodigoConvenio, DateTime FechaInicio, DateTime FechaFin, string UsuarioPago, string UsuarioConsulta, string UsuarioConexion, string ContraseniaConexion) => WebAPI.ConciliarPagos(CodigoConvenio, FechaInicio, FechaFin, UsuarioPago, UsuarioConsulta, UsuarioConexion, ContraseniaConexion);
    }
}