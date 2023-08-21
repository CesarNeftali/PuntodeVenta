using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class ConexionBD
    {
        public Boolean bAllOk = false;
        public String sLastError = "";

        public SqlConnection CrearConexionSQL()
        {
            String sCadConn = "Data Source=LAPTOP-TVFL5M2J;Initial Catalog=PuntoDeVenta;User ID=sa; Password=Fortec12;";
            SqlConnection conn = new SqlConnection(sCadConn);

            conn.Open();
            return conn;
        }

        //Pantalla de proveedores

        public bool RegistrarProveedor( String NombreEmpresa, String Contacto, String Direccion, String Telefono, String CorreoElectronico)
        {

            try
            {

                String sCMD = "INSERT INTO Proveedores(NombreEmpresa, Contacto, Direccion, Telefono, CorreoElectronico)" +
                    $"VALUES('{NombreEmpresa}', '{Contacto}', '{Direccion}', '{Telefono}', '{CorreoElectronico}')";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                cmd.ExecuteNonQuery();

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return bAllOk;
        }

        public bool UpdateProveedor(String ID_Proveedor, String NombreEmpresa, String Contacto, String Direccion, String Telefono, String CorreoElectronico)
        {

            try
            {

                String sCMD = $"UPDATE Proveedores SET NombreEmpresa = '{NombreEmpresa}', Contacto = '{Contacto}', Direccion = '{Direccion}', Telefono= '{Telefono}', CorreoElectronico= '{CorreoElectronico}' " + 
                    $"Where ID_Proveedor = '{ID_Proveedor}'";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                cmd.ExecuteNonQuery();

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return bAllOk;
        }

        public bool DeleteProveedor(String ID_Proveedor)
        {

            try
            {

                String sCMD = $"Delete From Proveedores WHere ID_Proveedor = '{ID_Proveedor}'";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                cmd.ExecuteNonQuery();

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return bAllOk;
        }

        public DataTable ConsultarProveedores()
        {
            DataTable datos = new DataTable();
            try
            {
                String sCMD = "Select * From Proveedores";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                datos.Load(cmd.ExecuteReader());

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return datos;
        }

        public DataTable BuscarProveedores(String Contacto)
        {
            DataTable datos = new DataTable();
            try
            {
                String sCMD = $"Select * From Proveedores where Contacto LIKE '%{Contacto}%'";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                datos.Load(cmd.ExecuteReader());

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return datos;
        }

        //Pantalla de Articulos

        public DataTable ConsultarArticulos()
        {
            DataTable datos = new DataTable();
            try
            {
                String sCMD = "Select ID_Articulo, ID_Proveedor, NombreArticulo, Descripcion, Precio, CantidadStock From Articulos where Activo = 1";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                datos.Load(cmd.ExecuteReader());

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return datos;
        }

        public DataTable ConsultarArt_Prov()
        {
            DataTable datos = new DataTable();
            try
            {
                String sCMD = "SELECT ID_Proveedor FROM Proveedores;";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                datos.Load(cmd.ExecuteReader());

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return datos;
        }

        public DataTable ConsultarNombreProveedor(String ID_Proveedor)
        {
            DataTable datos = new DataTable();
            try
            {
                String sCMD = $"Select NombreEmpresa From Proveedores where ID_Proveedor = '{ID_Proveedor}';";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                datos.Load(cmd.ExecuteReader());

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return datos;
        }

        public DataTable ConsultarArticulosInactivos()
        {
            DataTable datos = new DataTable();
            try
            {
                String sCMD = "Select ID_Articulo, ID_Proveedor, NombreArticulo, Descripcion, Precio, CantidadStock From Articulos where Activo = 0";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                datos.Load(cmd.ExecuteReader());

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return datos;
        }

        public DataTable BuscarArticulos(String NombreArticulo)
        {
            DataTable datos = new DataTable();
            try
            {
                String sCMD = $"Select ID_Articulo, ID_Proveedor, NombreArticulo, Descripcion, Precio, CantidadStock From Articulos where NombreArticulo LIKE '%{NombreArticulo}%' ";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                datos.Load(cmd.ExecuteReader());

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return datos;
        }

        public DataTable BuscarArticulosInactivos(String NombreArticulo)
        {
            DataTable datos = new DataTable();
            try
            {
                String sCMD = $"Select ID_Articulo, ID_Proveedor, NombreArticulo, Descripcion, Precio, CantidadStock From Articulos where Activo = 0 AND NombreArticulo LIKE '%{NombreArticulo}%'";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                datos.Load(cmd.ExecuteReader());

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return datos;
        }

        public bool RegistrarArticulo(String ID_Proveedor, String NombreArticulo, String Descripcion, String Precio, String CantidadStock)
        {

            try
            {

                String sCMD = "INSERT INTO Articulos(ID_Proveedor, NombreArticulo, Descripcion, Precio, CantidadStock)" +
                    $"VALUES('{ID_Proveedor}', '{NombreArticulo}', '{Descripcion}', '{Precio}', '{CantidadStock}')";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                cmd.ExecuteNonQuery();

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return bAllOk;
        }

        public bool UpdateArticulo(String ID_Articulo, String NombreArticulo, String Descripcion, String Precio, String CantidadStock)
        {

            try
            {

                String sCMD = $"UPDATE Articulos SET  NombreArticulo = '{NombreArticulo}', Descripcion = '{Descripcion}', Precio= '{Precio}', CantidadStock= '{CantidadStock}' " +
                    $"Where ID_Articulo = '{ID_Articulo}'";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                cmd.ExecuteNonQuery();

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return bAllOk;
        }

        public bool DeleteArticulo(String ID_Articulo)
        {
            try
            {

                String sCMD = $"UPDATE Articulos SET Activo = 0 WHERE ID_Articulo = '{ID_Articulo}';";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                cmd.ExecuteNonQuery();

                bAllOk = true;

            }
            catch (Exception ex)
            {
                sLastError = ex.Message;
                bAllOk = false;
            }

            return bAllOk;
        }

        public bool ActivarArticulo(String ID_Articulo, String CantidadStock)
        {

            try
            {

                String sCMD = $"UPDATE Articulos SET CantidadStock = '{CantidadStock}',Activo = 1 WHERE ID_Articulo = '{ID_Articulo}';";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                cmd.ExecuteNonQuery();

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return bAllOk;
        }

        //Pantalla Ventas

        public DataTable Articulos()
        {
            DataTable datos = new DataTable();
            try
            {
                String sCMD = "SELECT P.ID_Proveedor, P.NombreEmpresa, A.ID_Articulo, A.NombreArticulo, A.Descripcion, A.Precio, A.CantidadStock FROM Articulos A INNER JOIN Proveedores P ON A.ID_Proveedor = P.ID_Proveedor WHERE A.Activo = 1;";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                datos.Load(cmd.ExecuteReader());

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return datos;
        }

        public bool RegistrarVenta(String FechaVenta, String ID_Proveedor, String ID_Articulo, String CantidadVendida, String Precio, Decimal Total, String Pago)
        {
            Int32 FolioSiguiente = 0;
            try
            {

                String sCMD = $"INSERT INTO Ventas (FechaVenta, ID_Proveedor, ID_Articulo, CantidadVendida) VALUES ('{FechaVenta}', '{ID_Proveedor}', '{ID_Articulo}', '{CantidadVendida}');";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());
                cmd.ExecuteNonQuery();

                String sCMD2 = $"update articulos set CantidadStock = CantidadStock - '{CantidadVendida}' where ID_Articulo = '{ID_Articulo}';";
                SqlCommand cmd2 = new SqlCommand(sCMD2, CrearConexionSQL());
                cmd2.ExecuteNonQuery();

                String sCMD3 = $"SELECT TOP 1 ID_Venta as ID_Venta FROM Ventas ORDER BY ID_Venta DESC;";
                SqlCommand cmd3 = new SqlCommand(sCMD3, CrearConexionSQL());
                FolioSiguiente = Convert.ToInt32(cmd3.ExecuteScalar());

                String sCMD4 = "INSERT INTO DetallesVenta ( ID_Venta, ID_Articulo, CantidadVendida, PrecioUnitario, Total, Metodo)" +
                               $"VALUES ('{FolioSiguiente}', '{ID_Articulo}', '{CantidadVendida}', '{Precio}', '{Total}', '{Pago}' );";
                SqlCommand cmd4 = new SqlCommand(sCMD4, CrearConexionSQL());
                cmd4.ExecuteNonQuery();

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return bAllOk;
        }

        public DataTable BuscarArticulos2(String Empresa)
        {
            DataTable datos = new DataTable();
            try
            {
                String sCMD = $"SELECT P.ID_Proveedor, P.NombreEmpresa, A.ID_Articulo, A.NombreArticulo, A.Descripcion, A.Precio, A.CantidadStock FROM Articulos A INNER JOIN Proveedores P ON A.ID_Proveedor = P.ID_Proveedor WHERE A.Activo = 1 AND P.NombreEmpresa LIKE '%{Empresa}%';";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                datos.Load(cmd.ExecuteReader());

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return datos;
        }

        public DataTable BuscarArticulos3(String Articulo)
        {
            DataTable datos = new DataTable();
            try
            {
                String sCMD = $"SELECT P.ID_Proveedor, P.NombreEmpresa, A.ID_Articulo, A.NombreArticulo, A.Descripcion, A.Precio, A.CantidadStock FROM Articulos A INNER JOIN Proveedores P ON A.ID_Proveedor = P.ID_Proveedor WHERE A.Activo = 1 AND A.NombreArticulo LIKE '%{Articulo}%';";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                datos.Load(cmd.ExecuteReader());

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return datos;
        }

        //Pantalla Reporte de Venta

        public DataTable ReporteVenta(String Fecha)
        {
            DataTable datos = new DataTable();
            try
            {
                String sCMD = $"SELECT Ventas.FechaVenta, Proveedores.NombreEmpresa AS Proveedor, STRING_AGG(Articulos.NombreArticulo, ', ') AS ProductosVendidos, STRING_AGG(CONCAT('(', DetallesVenta.CantidadVendida, ')'), ', ') AS CantidadesVendidas, SUM(DetallesVenta.Total) AS TotalVentas FROM Ventas INNER JOIN Proveedores ON Ventas.ID_Proveedor = Proveedores.ID_Proveedor INNER JOIN DetallesVenta ON Ventas.ID_Venta = DetallesVenta.ID_Venta INNER JOIN Articulos ON DetallesVenta.ID_Articulo = Articulos.ID_Articulo WHERE Ventas.FechaVenta >= '{Fecha}' GROUP BY Ventas.FechaVenta, Proveedores.NombreEmpresa;";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                datos.Load(cmd.ExecuteReader());

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return datos;
        }

        public DataTable ReporteVentaPorFecha(String Fecha1, String Fecha2)
        {
            DataTable datos = new DataTable();
            try
            {
                String sCMD = $"SELECT Ventas.FechaVenta, Proveedores.NombreEmpresa AS Proveedor, STRING_AGG(Articulos.NombreArticulo, ', ') AS ProductosVendidos, STRING_AGG(CONCAT('(', DetallesVenta.CantidadVendida, ')'), ', ') AS CantidadesVendidas, SUM(DetallesVenta.Total) AS TotalVentas FROM Ventas INNER JOIN Proveedores ON Ventas.ID_Proveedor = Proveedores.ID_Proveedor INNER JOIN DetallesVenta ON Ventas.ID_Venta = DetallesVenta.ID_Venta INNER JOIN Articulos ON DetallesVenta.ID_Articulo = Articulos.ID_Articulo WHERE Ventas.FechaVenta BETWEEN '{Fecha1}' AND '{Fecha2}' GROUP BY Ventas.FechaVenta, Proveedores.NombreEmpresa;";
                SqlCommand cmd = new SqlCommand(sCMD, CrearConexionSQL());

                datos.Load(cmd.ExecuteReader());

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.Message;

                bAllOk = false;
            }

            return datos;
        }

    }
}
