using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto
{
    public partial class Venta : Form
    {
        public Venta()
        {
            InitializeComponent();
            cbCantidad.SelectedIndex = cbCantidad.Items.IndexOf("1");
            dtpFecha.Value = DateTime.Now;
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "yyyy/MM/dd HH:mm:ss";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reporte_de_venta FormCuarto = new Reporte_de_venta();
            this.Hide();
            FormCuarto.ShowDialog();
            this.Close();
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            CargarDatos();
            RecalcularTotal();
            dgvCarrito.Columns.Add("ID_Articulo", "ID_Articulo");
            dgvCarrito.Columns.Add("ID_Proveedor", "ID_Proveedor");
            dgvCarrito.Columns.Add("NombreArticulo", "NombreArticulo");
            dgvCarrito.Columns.Add("Descripcion", "Descripción");
            dgvCarrito.Columns.Add("NombreEmpresa", "NombreEmpresa");
            dgvCarrito.Columns.Add("Precio", "Precio");
            dgvCarrito.Columns.Add("Cantidad", "Cantidad");
        }

        private void CargarDatos()
        {

            ConexionBD Read = new ConexionBD();
            ConexionBD Delete = new ConexionBD();

            DataTable datos = Read.Articulos();
            int eliminados = 0;

            for (int i = datos.Rows.Count - 1; i >= 0; i--)
            {
                int stock = Convert.ToInt32(datos.Rows[i]["CantidadStock"]);
                if (stock == 0)
                {
                    string idArticulo = datos.Rows[i]["ID_Articulo"].ToString();
                    if (Delete.DeleteArticulo(idArticulo))
                    {
                        datos.Rows.RemoveAt(i);
                        eliminados++;
                    }
                }
            }

            try
            {
                dgvArticulos2.DataSource = datos;

                if (eliminados > 0)
                {
                    MessageBox.Show($"{eliminados} artículos sin stock han sido eliminados, favor de activar el articulo si hay stock en existencia.");
                }
            }
            catch
            {
                MessageBox.Show("Algo salió mal");
            }

        }

        public void Limpiardatos()
        {
            cbCantidad.SelectedIndex = cbCantidad.Items.IndexOf("1");
            cbPago.Text = "";
            txtID2.Text = "";
            txtID3.Text = "";
            txtProve2.Text = "";
            txtNomArt.Text = "";
            txtPrecio.Text = "";
            txtDesc.Text = "";
        }

        private void dgvArticulos2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvArticulos2.Rows[e.RowIndex];

                txtNomArt.Text = row.Cells["NombreArticulo"].Value.ToString();
                txtDesc.Text = row.Cells["Descripcion"].Value.ToString();
                txtProve2.Text = row.Cells["NombreEmpresa"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                txtID2.Text = row.Cells["ID_Proveedor"].Value.ToString();
                txtID3.Text = row.Cells["ID_Articulo"].Value.ToString();
                CargarDatos();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 FormTercero = new Form1();
            this.Hide();
            FormTercero.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Proveedores FormSecundario = new Proveedores();
            this.Hide();
            FormSecundario.ShowDialog();
            this.Close();
        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNomArt.Text))
            {
                if (!String.IsNullOrEmpty(cbCantidad.Text))
                {
                    int idArticulo = Convert.ToInt32(txtID3.Text);
                    int idProveedor = Convert.ToInt32(txtID2.Text);
                    string nombreArticulo = txtNomArt.Text;
                    string descripcion = txtDesc.Text;
                    string nombreEmpresa = txtProve2.Text;
                    decimal precio = Convert.ToDecimal(txtPrecio.Text);
                    int cantidad = Convert.ToInt32(cbCantidad.Text);
                    int Stock = ObtenerStockDisponible(idArticulo);

                    if (Stock >= cantidad)
                    {
                        bool encontrado = false;

                        foreach (DataGridViewRow row in dgvCarrito.Rows)
                        {
                            int idArticuloCarrito = Convert.ToInt32(row.Cells["ID_Articulo"].Value);

                            if (idArticuloCarrito == idArticulo)
                            {
                                int cantidadActual = Convert.ToInt32(row.Cells["Cantidad"].Value);
                                row.Cells["Cantidad"].Value = (cantidadActual + cantidad).ToString();
                                encontrado = true;
                                break;
                            }
                        }

                        if (!encontrado)
                        {
                            dgvCarrito.Rows.Add(idArticulo, idProveedor, nombreArticulo, descripcion, nombreEmpresa, precio, cantidad);
                        }

                        Limpiardatos();
                        RecalcularTotal();
                    }
                    else
                    {
                        MessageBox.Show("Superas el Limite de Stock");
                    }
                }
                else
                {
                    MessageBox.Show("Se le olvidó escoger cantidad");
                }
            }
            else
            {
                MessageBox.Show("Escoja un Articulo");
            }

        }

        private void RecalcularTotal()
        {
            decimal totalAPagar = 0;

            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value);
                int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                totalAPagar += precio * cantidad;
            }

            lbTotal.Text = $"Total a pagar: {totalAPagar}";
        }

        private int ObtenerStockDisponible(int idArticulo)
        {
            ConexionBD Read = new ConexionBD();
            DataTable datos = Read.Articulos();

            foreach (DataRow row in datos.Rows)
            {
                int id = Convert.ToInt32(row["ID_Articulo"]);
                if (id == idArticulo)
                {
                    return Convert.ToInt32(row["CantidadStock"]);
                }
            }

            return 0;
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(cbPago.Text))
            {
                ConexionBD operacion = new ConexionBD();
                int comprasExitosas = 0;

                foreach (DataGridViewRow row in dgvCarrito.Rows)
                {
                    int idArticulo = Convert.ToInt32(row.Cells["ID_Articulo"].Value);
                    int idProveedor = Convert.ToInt32(row.Cells["ID_Proveedor"].Value);
                    decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    decimal Total = precio * cantidad;
                    String mPago = cbPago.Text;

                    if (operacion.RegistrarVenta(dtpFecha.Text, idProveedor.ToString(), idArticulo.ToString(), cantidad.ToString(), precio.ToString(), Total, mPago))
                    {
                        lbTotal.Text = "Total a Pagar: 0";
                        comprasExitosas++;
                    }
                }

                CargarDatos();
                dgvCarrito.Rows.Clear();
                Limpiardatos();

                if (comprasExitosas > 0)
                {
                    MessageBox.Show($"Se realizaron {comprasExitosas} compras exitosas.");
                }
                else
                {
                    MessageBox.Show("No se realizaron compras.");
                }
            }
            else
            {
                MessageBox.Show("Escoge Método de Pago");
            }

        }

        private void txtProve2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ConexionBD Read = new ConexionBD();
                DataTable Resultado = Read.BuscarArticulos2(txtProve2.Text);
                dgvArticulos2.DataSource = Resultado;
                e.Handled = true;
            }
        }

        private void txtNomArt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ConexionBD Read = new ConexionBD();
                DataTable Resultado = Read.BuscarArticulos3(txtNomArt.Text);
                dgvArticulos2.DataSource = Resultado;
                e.Handled = true;
            }
        }

        private void dgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCarrito.Rows.Count)
            {
                DataGridViewRow removedRow = dgvCarrito.Rows[e.RowIndex];

                if (removedRow.Cells["Precio"].Value != null && decimal.TryParse(removedRow.Cells["Precio"].Value.ToString(), out decimal precio))
                {
                    decimal currentTotal = 0;
                    if (decimal.TryParse(lbTotal.Text, out currentTotal))
                    {
                        currentTotal -= precio;
                        lbTotal.Text = $"Total a pagar: {currentTotal.ToString("C")}";
                    }
                }

                dgvCarrito.Rows.RemoveAt(0);

                RecalcularTotal();
            }
        }
    }
}
