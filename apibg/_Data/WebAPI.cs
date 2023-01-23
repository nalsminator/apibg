using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using apibg._Data;
using Newtonsoft.Json;

namespace apibg
{
    public class WebAPI
    {
        //public static Estudiante BuscarEstudiante(string idestu)
        //{
        //    Estudiante est = new Estudiante();
        //    SqlCommand cmd = new SqlCommand("sp_buscarestudiante")
        //    {
        //        CommandType = CommandType.StoredProcedure
        //    };
        //    cmd.Parameters.AddWithValue("@idestu", idestu);
        //    SqlDataReader sqldr = DBConn.Sp_fila(cmd);
        //    if (sqldr.Read() == true)
        //    {
        //        est.Idestu = sqldr.GetString(0);
        //        est.Desper = sqldr.GetString(1);
        //        est.Idcarr = sqldr.GetByte(6);
        //    }
        //    else
        //    {
        //        est.Idestu = "";
        //        est.Desper = "";
        //        est.Idcarr = 0;
        //    }
        //    return est;
        //}
        /*funcion de prueba*/
        //public static Usuario BuscarPorId(int idusuario)
        //{
        //    Usuario IU = new Usuario();
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_bg")
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };
        //        cmd.Parameters.AddWithValue("@tipo", 1);
        //        dt = DBConn.Sp_dt(cmd);
        //        if (dt.Rows.Count>0)
        //        {
        //            IU.Codreg = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
        //            IU.Desper = Convert.ToString(dt.Rows[0].ItemArray[1]);
        //            IU.Numide = Convert.ToInt32(dt.Rows[0].ItemArray[2]);
        //            IU.Fecnac = Convert.ToDateTime(dt.Rows[0].ItemArray[3]);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IU.Codreg = 0;
        //        IU.Desper = "";
        //        IU.Numide = 0;
        //        IU.Fecnac = new DateTime();
        //    }
        //    return IU;
        //}

        //verificar la conectividad a la base de datos
        public static Conectividad VerificarConectividad(int CodigoConvenio, string Usuario1, string UsuarioConexion, string ContraseniaConexion)
         {
            
            Conectividad con = new Conectividad();
            if (VerifricarDatos(CodigoConvenio, Usuario1, UsuarioConexion, ContraseniaConexion) == true)
            {
                {
                    try                                                
                    {
                        DBConn.ConexionSQL().Open();
                        DBConn.ConexionSQL().Close();
                        con.CodigoRespuesta = 0;
                    }
                    catch
                    {
                        DBConn.ConexionSQL().Close();
                        con.CodigoRespuesta = 1;
                    }
                }
                return con;
            }
            else
            {
                con.CodigoRespuesta = 1;
                return con;
            }
        }
        public static ConceptosPago ObtenerConceptosPago(int CodigoConvenio, string Usuario1, string UsuarioConexion, string ContraseniaConexion)
        {
            ConceptosPago cp = new ConceptosPago();
            if (VerifricarDatos(CodigoConvenio, Usuario1, UsuarioConexion, ContraseniaConexion) == true)
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("sp_bg_conceptospago")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dt = DBConn.Sp_dt(cmd);

                //armo una lista con el datatable
                List<DetalleConceptoPago> dcp = new List<DetalleConceptoPago>();
                foreach (DataRow dr in dt.Rows)
                {
                    dcp.Add(new DetalleConceptoPago
                    {
                        Abreviatura = dr[0].ToString(),
                        Descripcion = dr[1].ToString(),
                        Estado = dr[2].ToString(),
                    });
                }

                cp.CodigoRespuesta = 0;
                cp.MensajeRespuesta = "OK";
                cp.DetalleConceptos = dcp;
                return cp;
            }
            else
            {
                cp.CodigoRespuesta = 1;
                cp.MensajeRespuesta = "Información incorrecta.";
                cp.DetalleConceptos = null;
                return cp;
            }
        }
        public static ListaNiveles ObtenerListaNiveles(int CodigoConvenio, string Usuario1, string UsuarioConexion, string ContraseniaConexion)
        {
            ListaNiveles ln = new ListaNiveles();
            if (VerifricarDatos(CodigoConvenio, Usuario1, UsuarioConexion, ContraseniaConexion) == true)
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("sp_bg_listanivel")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dt = DBConn.Sp_dt(cmd);

                List<DetalleListaNiveles> dln = new List<DetalleListaNiveles>();
                foreach (DataRow dr in dt.Rows)
                {
                    dln.Add(new DetalleListaNiveles
                    {
                        AbreviaturaNivel = dr[0].ToString(),
                        DescripcionNivel = dr[1].ToString(),
                        Estado = "H",
                    });
                }
                ln.CodigoRespuesta = 0;
                ln.MensajeRespuesta = "OK";
                ln.DetalleNiveles = dln;
                return ln;
            }
            else
            {
                ln.CodigoRespuesta = 1;
                ln.MensajeRespuesta = "Información incorrecta.";
                ln.DetalleNiveles = null;
                return ln;
            }
        }
        public static ListaSubNiveles ObtenerListaSubNiveles(int CodigoConvenio, string Usuario1, string UsuarioConexion, string ContraseniaConexion)
        {
            ListaSubNiveles lsn = new ListaSubNiveles();
            if (VerifricarDatos(CodigoConvenio, Usuario1, UsuarioConexion, ContraseniaConexion) == true)
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("sp_bg_listasubnivel")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dt = DBConn.Sp_dt(cmd);

                List<DetalleListaSubNiveles> dlsn = new List<DetalleListaSubNiveles>();
                foreach (DataRow dr in dt.Rows)
                {
                    dlsn.Add(new DetalleListaSubNiveles
                    {
                        AbreviaturaSubnivel = dr[0].ToString(),
                        DescripcionSubnivel = dr[1].ToString(),
                        Estado = "H",
                    });
                }
                lsn.CodigoRespuesta = 0;
                lsn.MensajeRespuesta = "OK";
                lsn.DetalleSubNiveles = dlsn;
                return lsn;
            }
            else
            {
                lsn.CodigoRespuesta = 1;
                lsn.MensajeRespuesta = "Información incorrecta";
                lsn.DetalleSubNiveles = null;
                return lsn;
            }
        }
        public static ListaClientes ObtenerListaClientes(int CodigoConvenio, string Usuario1, string TipoConsulta, string UsuarioConexion, string ContraseniaConexion, string CodigoTipoBusqueda, string CodigoCliente)
        {
            ListaClientes lc = new ListaClientes();
            if (VerifricarDatos(CodigoConvenio, Usuario1, UsuarioConexion, ContraseniaConexion) == true)
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("sp_bg_listaclientes")
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TipoConsulta", TipoConsulta);
                cmd.Parameters.AddWithValue("@CodigoTipoBusqueda", CodigoTipoBusqueda);
                cmd.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
                dt = DBConn.Sp_dt(cmd);
                if (dt.Rows.Count>0)
                {
                    List<DetalleListaClientes> dlc = new List<DetalleListaClientes>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        dlc.Add(new DetalleListaClientes
                        {
                            CodigoTipoBusqueda = dr[0].ToString(),
                            CodigoCliente = dr[1].ToString(),
                            NombreCliente = dr[2].ToString(),
                            AbreviaturaNivel = dr[3].ToString(),
                            AbreviaturaSubNivel = dr[4].ToString(),
                        });
                    }
                    lc.CodigoRespuesta = 0;
                    lc.MensajeRespuesta = "OK";
                    lc.DetalleClientes = dlc;
                    return lc;
                }
                else
                {
                    lc.CodigoRespuesta = 1;
                    lc.MensajeRespuesta = "No se encontró al estudiante.";
                    lc.DetalleClientes = null;
                    return lc;
                }
            }
            else
            {
                lc.CodigoRespuesta = 1;
                lc.MensajeRespuesta = "Información incorrecta.";
                lc.DetalleClientes = null;
                return lc;
            }
        }
        public static Deuda ObtenerDeuda(int CodigoConvenio, string CodigoTipoBusqueda, string CodigoCliente, string Usuario1, string UsuarioConexion, string ContraseniaConexion)
        {
            Deuda deu = new Deuda();
            if (VerifricarDatos(CodigoConvenio, Usuario1, UsuarioConexion, ContraseniaConexion) == true)
            {
                string csql = "";
                string idestu;
                if (CodigoTipoBusqueda == "COD") { csql = "select codreg from Ba02Perso where codreg like '" + CodigoCliente + "%'"; }
                if (CodigoTipoBusqueda == "DID") { csql = "select codreg from Ba02Perso where numide='" + CodigoCliente + "'"; }
                SqlCommand cmdx = new SqlCommand(csql) { CommandType = CommandType.Text };
                idestu = DBConn.ConsultarValor(cmdx).ToString();

                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("sp_bg_obtenerdeuda"){
                CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@tipo", 1);
                cmd.Parameters.AddWithValue("@CodigoCliente", idestu);
                cmd.Parameters.AddWithValue("@nromov1", "");
                dt = DBConn.Sp_dt(cmd);

                if (dt.Rows.Count > 0)
                {
                    List<DetalleDeuda> dlc = new List<DetalleDeuda>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        DataTable dt1 = new DataTable();
                        SqlCommand cmd1 = new SqlCommand("sp_bg_obtenerdeuda")
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd1.Parameters.AddWithValue("@tipo", 2);
                        cmd1.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
                        cmd1.Parameters.AddWithValue("@nromov1", dr[1].ToString());
                        dt1 = DBConn.Sp_dt(cmd1);

                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow dr1 in dt1.Rows)
                            {
                                List<NumeroDeMovimiento> mov = new List<NumeroDeMovimiento>();
                                mov.Add(new NumeroDeMovimiento { nromov = dr1[0].ToString() });
                                dlc.Add(new DetalleDeuda
                                {
                                    Gestion = Convert.ToInt32(dr1[1]),
                                    AbreviaturaConceptoPago = dr1[2].ToString(),
                                    Prioridad = Convert.ToInt32(dr1[3]),
                                    NroCuota = Convert.ToInt32(dr1[4]),
                                    MesPeriodo = Convert.ToInt32(dr1[5]),
                                    AnioPeriodo = Convert.ToInt32(dr1[6]),
                                    FechaVencimiento = Convert.ToDateTime(dr1[7]),
                                    CodigoMoneda = dr1[8].ToString(),
                                    MontoConcepto = Convert.ToDecimal(dr1[9]),
                                    MontoMulta = Convert.ToDecimal(dr1[10]),
                                    MontoDescuento = Convert.ToDecimal(dr1[11]),
                                    MontoNeto = Convert.ToDecimal(dr1[12]),
                                    DatosAdicionales = mov
                                });
                            }
                        }
                    }
         
                    DataTable dtc = new DataTable();
                    SqlCommand cmdc = new SqlCommand("sp_bg_listaclientes")
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmdc.Parameters.AddWithValue("@TipoConsulta", "D");
                    cmdc.Parameters.AddWithValue("@CodigoTipoBusqueda", "COD");
                    cmdc.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
                    dtc = DBConn.Sp_dt(cmdc);

                    /*datos cliente*/
                    deu.CodigoRespuesta = 0;
                    deu.MensajeRespuesta = "OK";
                    foreach (DataRow dr in dtc.Rows)
                    {
                        deu.NombreCliente = dr[2].ToString();
                        deu.AbreviaturaNivel = dr[3].ToString();
                        deu.AbreviaturaSubNivel = dr[4].ToString();
                    }

                    /*datos factura*/
                    //SqlCommand cmdN = new SqlCommand("sp_bg_nitnombre")
                    //{
                    //    CommandType = CommandType.StoredProcedure
                    //};
                    //cmdN.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
                    //SqlDataReader sqldr = DBConn.Sp_fila(cmdN);
                    //if (sqldr.Read() == true)
                    //{
                    //    deu.FacturaNITCI = Convert.ToInt32(sqldr[0]);
                    //    deu.FacturaNombre = sqldr.GetString(1);
                    //    sqldr.Close();
                    //}
                    //else
                    //{
                    deu.FacturaNITCI = 0;
                    deu.FacturaNombre = null;
                    //    sqldr.Close();
                    //}
                    deu.FacturaPuedeModDatos = "S";
                    deu.DatosAdicionales = null;
                    //var jsondt = JsonConvert.SerializeObject(dlc);
                    deu.DetalleDeuda = dlc;
                    //deu.DetalleDeuda = dlc;
                    //var json = JsonConvert.SerializeObject(deu);
                    return deu;
                }
                else
                {
                    /*no tiene deudas*/
                    deu.CodigoRespuesta = 1;
                    deu.MensajeRespuesta = "No tiene deudas.";
                    deu.NombreCliente = "";
                    deu.AbreviaturaNivel = "";
                    deu.AbreviaturaSubNivel = "";
                    deu.FacturaNITCI = 0;
                    deu.FacturaNombre = null;
                    deu.FacturaPuedeModDatos = "N";
                    deu.DatosAdicionales = null;
                    deu.DetalleDeuda = null;
                    return deu;
                }
            }
            else
            {
                /*datos conexion banco*/
                deu.CodigoRespuesta = 1;
                deu.MensajeRespuesta = "Información incorrecta.";
                deu.NombreCliente = "";
                deu.AbreviaturaNivel = "";
                deu.AbreviaturaSubNivel = "";
                deu.FacturaNITCI = 0;
                deu.FacturaNombre = null;
                deu.FacturaPuedeModDatos = "N";
                deu.DatosAdicionales = null;
                deu.DetalleDeuda = null;
                return deu;
            }
        }
        public static Pago RegistrarPago(int CodigoConvenio, DateTime FechaTransaccion, string CodigoTipoBusqueda, string CodigoCliente, int facturaNITCI, string FacturaNombre, int NroTransaccion, string Usuario1, string UsuarioConexion, string ContraseniaConexion, List<DetallePago> DetallePago, List<DatosFactura> DatosFactura)
        {
            Pago p = new Pago();
            if (VerifricarDatos(CodigoConvenio, Usuario1, UsuarioConexion, ContraseniaConexion) == true)
            {
                List<DetallePago> dp = new List<DetallePago>();
                NumeroDeMovimiento nm = new NumeroDeMovimiento();
                dp = DetallePago;

                /*por cada deuda*/
                for (int i = 0; i < dp.Count; i++)
                {
                    nm = JsonConvert.DeserializeObject<NumeroDeMovimiento>(dp[4].ToString());
                    dp.Add(new DetallePago
                    {
                        AbreviaturaConceptoPago = dp[0].ToString(), //abreviatura
                        NroCuota = Convert.ToInt32(dp[1]), //nrocuo
                        CodigoMoneda = dp[2].ToString(), //BOB
                        MontoNeto = Convert.ToDecimal(dp[3]), //monto
                        DatosAdicionales = nm.nromov, //datosadicionales nromov
                    });
                    SqlCommand cmd = new SqlCommand("sp_bg_registropagos")
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@codigoconvenio", CodigoConvenio);
                    cmd.Parameters.AddWithValue("@fechatransaccion", FechaTransaccion);
                    cmd.Parameters.AddWithValue("@codigotipobusqueda", CodigoTipoBusqueda);
                    cmd.Parameters.AddWithValue("@codigocliente", CodigoCliente);
                    cmd.Parameters.AddWithValue("@facturanitci", facturaNITCI);
                    cmd.Parameters.AddWithValue("@facturanombre", FacturaNombre);
                    cmd.Parameters.AddWithValue("@nrotransaccion", NroTransaccion);
                    cmd.Parameters.AddWithValue("@usuario", Usuario1);
                    cmd.Parameters.AddWithValue("@abreviatura", dp[0].ToString());
                    cmd.Parameters.AddWithValue("@nrocuota", Convert.ToInt32(dp[1]));
                    cmd.Parameters.AddWithValue("@codigomoneda", dp[2].ToString());
                    cmd.Parameters.AddWithValue("@montoneto", Convert.ToDecimal(dp[3]));
                    cmd.Parameters.AddWithValue("@datosadicionales", nm.nromov);
                    //bool valor = DBConn.Sp_abm(cmd);
                    //if (valor == true)
                    //{
                    //llamar a procedimientos sp_bg_grabarpago
                    SqlCommand cmd1 = new SqlCommand("sp_bg_grabarpago")
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd1.Parameters.AddWithValue("@idcarr", CodigoConvenio);
                    cmd1.Parameters.AddWithValue("@nromov", nm.nromov);
                    cmd1.Parameters.AddWithValue("@idestu", CodigoCliente);
                    cmd1.Parameters.AddWithValue("@monto", Convert.ToDecimal(dp[3]));
                    bool valor2 = DBConn.Sp_abm(cmd1);
                    if (valor2 == true)
                    {
                        SqlCommand cmdnro = new SqlCommand("sp_bg_lastnromovbd11")
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmdnro.Parameters.AddWithValue("@nromov", nm.nromov);
                        string val = DBConn.Sp_valor(cmdnro).ToString();
                        cmd.Parameters.AddWithValue("@rnomovbd11", val);
                        DBConn.Sp_abm(cmd);
                        p.CodigoRespuesta = 0;
                        p.MensajeRespuesta = "OK";
                        p.NroTransaccion = val;
                        p.DatosFacturaEmpresa = null;
                        return p;
                    }
                    else
                    {
                        p.CodigoRespuesta = 1;
                        p.MensajeRespuesta = "ERROR";
                        p.NroTransaccion = "0";
                        p.DatosFacturaEmpresa = null;
                        return p;
                    }
                    //}
                    //else
                    //{
                    //    p.CodigoRespuesta = 1;
                    //    p.MensajeRespuesta = "ERROR";
                    //    p.NroTransaccion = "0";
                    //    p.DatosFacturaEmpresa = null;
                    //    return p;
                    //}
                }
                return p;
            }
            else
            {
                p.CodigoRespuesta = 1;
                p.MensajeRespuesta = "ERROR";
                p.NroTransaccion = "0";
                p.DatosFacturaEmpresa = null;
                return p;
            }
        }
        public static bool VerifricarDatos(int CodigoConvenio, string Usuario1, string UsuarioConexion, string ContraseniaConexion)
        {
            SqlCommand cmd = new SqlCommand("sp_parambg")
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@usuario1", Usuario1);
            SqlDataReader sqldr = DBConn.Sp_fila(cmd);
            if (sqldr.Read() == true)
            {
                if (CodigoConvenio == sqldr.GetInt32(1) && (UsuarioConexion == sqldr.GetString(2)) && (ContraseniaConexion == sqldr.GetString(3)))
                {
                    sqldr.Close();
                    return true;
                }
                else
                {
                    sqldr.Close();
                    return false;
                }
            }
            else
            {
                sqldr.Close();
                return false;
            }
        }
        public static ConsultarTransaccionX ConsultarTransaccion(int CodigoConvenio, DateTime FechaTransaccion, string NroTransaccion, string Usuario1, string UsuarioConexion, string ContraseniaConexion)
        {
            ConsultarTransaccionX ct = new ConsultarTransaccionX();
            if (VerifricarDatos(CodigoConvenio, Usuario1, UsuarioConexion, ContraseniaConexion) == true)
            {
                SqlCommand cmd = new SqlCommand("sp_bg_consultartransaccion")
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@nromov", NroTransaccion);
                int estado;
                try
                {
                    estado = Convert.ToInt32(DBConn.Sp_valor(cmd));
                }
                catch
                {
                    estado = 9;
                }

                switch (estado)
                {
                    case 0:
                        ct.CodigoRespuesta = 0;
                        ct.MensajeRespuesta = "OK";
                        ct.EstadoTransaccion = "R";
                        return ct;
                    case 1:
                        ct.CodigoRespuesta = 0;
                        ct.MensajeRespuesta = "OK";
                        ct.EstadoTransaccion = "A";
                        return ct;
                    case 9:
                        ct.CodigoRespuesta = 0;
                        ct.MensajeRespuesta = "OK";
                        ct.EstadoTransaccion = "N";
                        return ct;
                    default:
                        ct.CodigoRespuesta = 1;
                        ct.MensajeRespuesta = "ERROR";
                        ct.EstadoTransaccion = "";
                        return ct;
                }
            }
            else
            {
                ct.CodigoRespuesta = 1;
                ct.MensajeRespuesta = "ERROR";
                ct.EstadoTransaccion = "";
                return ct;
            }
        }
        public static ObPago ObtenerDetallePagos (int CodigoConvenio, string CodigoTipoBusqueda, string CodigoCliente, DateTime FechaInicio, DateTime FechaFin, string Usuario1, string UsuarioConexion, string ContraseniaConexion)                             
        {
            string nombre="";
            if (VerifricarDatos(CodigoConvenio, Usuario1, UsuarioConexion, ContraseniaConexion) == true)
            {
                //SqlCommand cmd = new SqlCommand("sp_bg_obtenerdetallepagos")
                //{
                //    CommandType = CommandType.StoredProcedure
                //};
                //DateTime a = FechaInicio.ToUniversalTime();
                //DateTime b = FechaFin.ToUniversalTime();
                //cmd.Parameters.AddWithValue("@idestu", CodigoCliente);
                //cmd.Parameters.AddWithValue("@fecini", a);
                //cmd.Parameters.AddWithValue("@fecfin", b);
                //cmd.Parameters.AddWithValue("@codigobusqueda", CodigoTipoBusqueda);

                string csql = "";
                string idestu;
                if (CodigoTipoBusqueda=="COD")
                {
                    csql = "select codreg from Ba02Perso where codreg like '" + CodigoCliente +"%'";
                }
                if (CodigoTipoBusqueda=="DID")
                {
                    csql = "select codreg from Ba02Perso where numide='" + CodigoCliente + "'";
                }
                SqlCommand cmdx = new SqlCommand(csql)
                {
                    CommandType = CommandType.Text
                };
                idestu = DBConn.ConsultarValor(cmdx).ToString();

                string sql = "select codges, abreviatura, totmus, Bd11enccj.fecreg, codusr, desper, nromov from Bd11enccj join ConceptosPago on Bd11enccj.codcpt = ConceptosPago.cod join ba02perso on Bd11enccj.codreg = Ba02Perso.codreg where Bd11enccj.codreg='" + idestu + "' and Bd11enccj.fecreg between convert(date, '" + FechaInicio + "') and convert(date, '" + FechaFin + "') order by Bd11enccj.fecreg asc";
                SqlCommand cmd = new SqlCommand(sql){CommandType = CommandType.Text};
              
                DataTable dt = new DataTable();

                //dt = DBConn.Sp_dt(cmd);
                dt = DBConn.ConsultarDT(cmd);
                if (dt.Rows.Count > 0)
                {
                    List<MaestroObPago> mop = new List<MaestroObPago>();
                    foreach (DataRow dr1 in dt.Rows)
                    {
                        nombre = Convert.ToString(dr1[5]);
                        List<DetalleObPago> dop = new List<DetalleObPago>();
                        dop.Add(new DetalleObPago
                        { 
                            Gestion = Convert.ToInt32(dr1[0]),
                            AbreviaturaConceptoPago = Convert.ToString(dr1[1]),
                            NroCuota = 0,
                            MesPeriodo = 0,
                            AnioPeriodo = 0,
                            FechaVencimiento = Convert.ToDateTime(dr1[3]),
                            CodigoMoneda = "BOB",
                            MontoConcepto = Convert.ToDecimal(dr1[2]),
                            MontoMulta = 0,
                            MontoDescuento = 0,
                            MontoNeto = Convert.ToDecimal(dr1[2]),
                            DatosAdicionales = ""
                        });
                        mop.Add(new MaestroObPago
                        {
                            FechaTransaccion = Convert.ToDateTime(dr1[3]),
                            NroTransaccion = Convert.ToString(dr1[6]),
                            CodigoMoneda = "BOB",
                            MontoTotalPagado = Convert.ToDecimal(dr1[2]),
                            Usuario = Convert.ToString(dr1[4]),
                            DetallePago = dop,
                            DatosFactura = null
                        });
                    }
                    ObPago op = new ObPago();
                    op.CodigoRespuesta = 0;
                    op.MensajeRespuesta = "OK";
                    op.NombreCliente = nombre;
                    op.MaestroPagos = mop;
                    return op;
                }
                else
                {
                    ObPago op = new ObPago();
                    op.CodigoRespuesta = 1;
                    op.MensajeRespuesta = "ERROR";
                    op.NombreCliente = "";
                    op.MaestroPagos = null;
                    return op;
                }
            }
            else
            {
                ObPago op = new ObPago();
                op.CodigoRespuesta = 1;
                op.MensajeRespuesta = "ERROR";
                op.NombreCliente = "";
                op.MaestroPagos = null;
                return op;
            }
        }
        public static PlanPago ObtenerPlanPagos (int CodigoConvenio, string CodigoTipoBusqueda, string CodigoCliente, string Usuario1, string UsuarioConexion, string ContraseniaConexion)
        {
            PlanPago pp = new PlanPago();
            if (VerifricarDatos(CodigoConvenio, Usuario1, UsuarioConexion, ContraseniaConexion) == true)
            {
                string csql = "";
                string idestu, nombre;
                string carrera = "";
                if (CodigoTipoBusqueda == "COD") { csql = "select codreg from Ba02Perso where codreg like '" + CodigoCliente + "%'"; }
                if (CodigoTipoBusqueda == "DID") { csql = "select codreg from Ba02Perso where numide='" + CodigoCliente + "'"; }
                SqlCommand cmdx = new SqlCommand(csql) { CommandType = CommandType.Text  };
                idestu = DBConn.ConsultarValor(cmdx).ToString();

                SqlCommand cmdname = new SqlCommand("select desper from ba02perso where codreg='" + idestu +"'") { CommandType = CommandType.Text };
                nombre = DBConn.ConsultarValor(cmdname).ToString();

                string sql = "select codges, abreviatura, fecmov, totcxc, totrec, totdes, ((totcxc + totrec) - totdes), (select case when be08.estado=0 then 'P' else 'A' end), ca02.sigla from Be08enccc be08 join ConceptosPago cp on be08.grpcta = cp.cod join Cf03estca cf03 on be08.coddeu = cf03.idestu join Ca02carre ca02 on cf03.idcarr = ca02.idcarr where be08.coddeu='" + idestu +"' and be08.estado in (0, 3, 7) and cf03.estado = 0 order by be08.fecmov asc";
                SqlCommand cmd = new SqlCommand(sql) { CommandType = CommandType.Text };

                DataTable dt = new DataTable();

                List<DetallePlanPago> dpp = new List<DetallePlanPago>();
                dt = DBConn.ConsultarDT(cmd);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        carrera = Convert.ToString(dr[8]);

                        dpp.Add(new DetallePlanPago
                        {
                            Gestion = Convert.ToInt32(dr[0]),
                            AbreviaturaConceptoPago = Convert.ToString(dr[1]),
                            Prioridad = 0,
                            NroCuota = 0,
                            MesPeriodo = 0,
                            AnioPeriodo = 0,
                            FechaVencimiento = Convert.ToDateTime(dr[2]),
                            CodigoMoneda = "BOB",
                            MontoConcepto = Convert.ToDecimal(dr[3]),
                            MontoMulta = Convert.ToDecimal(dr[4]),
                            MontoDescuento = Convert.ToDecimal(dr[5]),
                            MontoNeto = Convert.ToDecimal(dr[6]),
                            Estado = Convert.ToString(dr[7])
                        });
                    }
                    pp.CodigoRespuesta = 0;
                    pp.MensajeRespuesta = "OK";
                    pp.NombreCliente = nombre;
                    pp.AbreviaturaNivel = carrera;
                    pp.AbreviaturaSubNivel = "";
                    pp.DatosAdicionales = "";
                    pp.DetalleDeuda = dpp;
                    return pp;
                }
                else
                {
                    pp.CodigoRespuesta = 1;
                    pp.MensajeRespuesta = "ERROR";
                    pp.NombreCliente = "";
                    pp.AbreviaturaNivel = "";
                    pp.AbreviaturaSubNivel = "";
                    pp.DatosAdicionales = "";
                    pp.DetalleDeuda = null;
                    return pp;
                }
            }
            else
            {
                pp.CodigoRespuesta = 1;
                pp.MensajeRespuesta = "ERROR";
                pp.NombreCliente = "";
                pp.AbreviaturaNivel = "";
                pp.AbreviaturaSubNivel = "";
                pp.DatosAdicionales = "";
                pp.DetalleDeuda = null;
                return pp;
            }
        }
        public static Conciliar ConciliarPagos(int CodigoConvenio, DateTime FechaInicio, DateTime FechaFin, string UsuarioPago, string UsuarioConsulta, string UsuarioConexion, string ContraseniaConexion)
        {
            Conciliar c = new Conciliar();
            if (VerifricarDatos(CodigoConvenio, UsuarioConsulta, UsuarioConexion, ContraseniaConexion) == true)
            {
                string csql="";
                if (UsuarioPago == null)
                {
                    csql = "select fechatransaccion, nromovbd11, nrotransaccion, codigotipobusqueda, codigocliente, desper, codigomoneda, montoneto, usuario from BGPagos bg join Ba02Perso ba02 on bg.codigocliente = ba02.codreg where fechatransaccion between '" + FechaInicio + "' and '" + FechaFin + "' order by fechatransaccion asc";
                }
                else
                {
                    csql = "select fechatransaccion, nromovbd11, nrotransaccion, codigotipobusqueda, codigocliente, desper, codigomoneda, montoneto, usuario from BGPagos bg join Ba02Perso ba02 on bg.codigocliente = ba02.codreg where fechatransaccion between '" + FechaInicio + "' and '" + FechaFin + "' and usuario='" + UsuarioPago + "' order by fechatransaccion asc";
                }
                SqlCommand cmdx = new SqlCommand(csql) { CommandType = CommandType.Text };
                DataTable dt = new DataTable();
                dt = DBConn.ConsultarDT(cmdx);
                List<DetalleConciliar> dc = new List<DetalleConciliar>();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dc.Add(new DetalleConciliar
                        {
                            Fechatransaccion = Convert.ToDateTime(dr[0]),
                            NroTransaccionEmpresa = Convert.ToString(dr[1]),
                            NroTransaccionBanco = Convert.ToInt32(dr[2]),
                            CodigoTipoBusqueda = Convert.ToString(dr[3]),
                            CodigoCliente = Convert.ToString(dr[4]),
                            NombreCliente = Convert.ToString(dr[5]),
                            CodigoMoneda = Convert.ToString(dr[6]),
                            MontoPagado = Convert.ToDecimal(dr[7]),
                            Usuario = Convert.ToString(dr[8])
                        });
                    }
                    c.CodigoRespuesta = 0;
                    c.MensajeRespuesta = "OK";
                    c.DetallePago = dc;
                    return c;
                }
                else
                {
                    c.CodigoRespuesta = 1;
                    c.MensajeRespuesta = "ERROR";
                    c.DetallePago = null;
                    return c;
                }
            } 
            else
            {
                c.CodigoRespuesta = 1;
                c.MensajeRespuesta = "ERROR";
                c.DetallePago = null;
                return c;
            }
        }
    }
}