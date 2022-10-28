using FacturasSYC.Models;
using System.Data.SqlClient;
using System.Data;

namespace FacturasSYC.Datos
{
    public class FacturaDatos
    {
        public List<FacturaModel> Listar()
        {
            var oLista = new List<FacturaModel>();

            var cn = new conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType =  CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new FacturaModel() { 
                            ID_FACTURA = Convert.ToInt32(dr["ID_FACTURA"]),
                            NUME_DOC = Convert.ToInt32(dr["NUME_DOC"]),
                            CODI_ESTADO = Convert.ToInt32(dr["CODI_ESTADO"]),
                            VALOR_FAC = Convert.ToInt32(dr["VALOR_FAC"]),
                            FECHA_FAC = Convert.ToDateTime(dr["FECHA_FAC"])
                        });
                    }
                }
            }
            return oLista;
        }

        public List<ReporteModel> Reportar()
        {
            var oLista = new List<ReporteModel>();

            var cn = new conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Reporte", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ReporteModel(){
                            FECHA_FAC = Convert.ToDateTime(dr["FECHA_FAC"]),
                            NOMBRE = Convert.ToString(dr["NOMBRE"]),
                            VALOR_FAC = Convert.ToInt32(dr["VALOR_FAC"]),
                            DESCRIPCION = Convert.ToString(dr["DESCRIPCION"]),
                        });
                    }
                }
            }
            return oLista;
        }
        public bool Guardar(FacturaModel oFactura)
        {
            bool rpta;

            try
            {
                var cn = new conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("ID_FACTURA", oFactura.ID_FACTURA);  //ojo acá hay algo raro
                    cmd.Parameters.AddWithValue("NUME_DOC", oFactura.NUME_DOC);
                    cmd.Parameters.AddWithValue("CODI_ESTADO", oFactura.CODI_ESTADO);
                    cmd.Parameters.AddWithValue("VALOR_FAC", oFactura.VALOR_FAC);
                    cmd.Parameters.AddWithValue("FECHA_FAC", oFactura.FECHA_FAC);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch(Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
