using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class RequisicionD
    {
        public bool GuardarRequisicionCompleta(string codigo, int idTipoImpuesto, decimal subtotal, decimal impuesto, decimal total, System.Collections.Generic.List<(string producto, int cantidad, decimal precio)> detalles, out string mensajeError)
        {
            mensajeError = string.Empty;
            using (SqlConnection conexion = Conexion.Instancia.CrearConexion())
            {
                conexion.Open();
                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    
                    int idRequisicionGenerada = 0;
                    using (SqlCommand cmd = new SqlCommand("sp_CrearRequisicion", conexion, transaccion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoRequisicion", codigo);
                        cmd.Parameters.AddWithValue("@ID_TipoImpuesto", idTipoImpuesto);

                        SqlParameter paramOutput = new SqlParameter("@ID_RequisicionGenerada", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(paramOutput);

                        cmd.ExecuteNonQuery();
                        idRequisicionGenerada = Convert.ToInt32(paramOutput.Value);
                    }

                    
                    foreach (var item in detalles)
                    {
                        using (SqlCommand cmdItem = new SqlCommand("sp_AgregarItemRequisicion", conexion, transaccion))
                        {
                            cmdItem.CommandType = CommandType.StoredProcedure;
                            cmdItem.Parameters.AddWithValue("@ID_Requisicion", idRequisicionGenerada);
                            cmdItem.Parameters.AddWithValue("@NombreProducto", item.producto);
                            cmdItem.Parameters.AddWithValue("@Cantidad", item.cantidad);
                            cmdItem.Parameters.AddWithValue("@PrecioUnitario", item.precio);

                            cmdItem.ExecuteNonQuery();
                        }
                    }

                    
                    using (SqlCommand cmdTotales = new SqlCommand("sp_ActualizarTotalesRequisicion", conexion, transaccion))
                    {
                        cmdTotales.CommandType = CommandType.StoredProcedure;
                        cmdTotales.Parameters.AddWithValue("@ID_Requisicion", idRequisicionGenerada);
                        cmdTotales.Parameters.AddWithValue("@Subtotal", subtotal);
                        cmdTotales.Parameters.AddWithValue("@Impuesto", impuesto);
                        cmdTotales.Parameters.AddWithValue("@Total", total);

                        cmdTotales.ExecuteNonQuery();
                    }

                    transaccion.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    mensajeError = ex.Message;
                    return false;
                }
            }
        }

        //Vista para listar requisiciones
        public DataTable ObtenerRequisiciones()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexion = Conexion.Instancia.CrearConexion())
            {
               
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vw_ObtenerLasRequisiciones ORDER BY idRequisicion DESC", conexion))
                {
                    cmd.CommandType = CommandType.Text; 
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tabla);
                }
            }
            return tabla;
        }


        public DataTable ObtenerReporteRequisicionesAprobadas()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexion = Conexion.Instancia.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vw_ReporteRequisicionAprobada ORDER BY idRequisicion DESC", conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tabla);
                }
            }
            return tabla;
        }

        // Método para actualizar estado vía SP
        public bool CambiarEstado(int idRequisicion, int nuevoIdEstado, out string mensajeError)
        {
            mensajeError = string.Empty;
            try
            {
                using (SqlConnection conexion = Conexion.Instancia.CrearConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CambiarEstadoRequisicion", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idRequisicion", idRequisicion);
                        cmd.Parameters.AddWithValue("@nuevoIdEstado", nuevoIdEstado);

                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
                return false;
            }
        }
    }
}
