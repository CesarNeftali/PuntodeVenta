using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Inactivos : Form
    {
        private Form1 FormVenta;
        public Inactivos(Form1 form1)
        {
            InitializeComponent();
            this.FormVenta = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConexionBD Activar = new ConexionBD();
            if (Activar.ActivarArticulo(txtID2.Text, txtCantidad2.Text))
            {
                limpiardatos2();
                CargarDatos2();
                MessageBox.Show("Producto ha sido activado");
            }
            else
            {
                MessageBox.Show("Ups Algo Paso");
            }
        }

        private void CargarDatos2()
        {
            ConexionBD Read = new ConexionBD();
            DataTable datos = Read.ConsultarArticulosInactivos();
            try
            {
                dgvInactivos.DataSource = datos;
            }
            catch
            {
                MessageBox.Show("Algo salio mal");
            }
        }

        private void limpiardatos2()
        {
            txtID2.Text = "";
            txtIDProveedor2.Text = "";
            txtNombreArticulo2.Text = "";
            txtDescripcion2.Text = "";
            txtCantidad2.Text = "";
        }

        private void Inactivos_Load(object sender, EventArgs e)
        {
            CargarDatos2();
        }

        private void dgvInactivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvInactivos.Rows[e.RowIndex];

                txtID2.Text = row.Cells["ID_Articulo"].Value.ToString();
                txtIDProveedor2.Text = row.Cells["ID_Proveedor"].Value.ToString();
                txtNombreArticulo2.Text = row.Cells["NombreArticulo"].Value.ToString();
                txtDescripcion2.Text = row.Cells["Descripcion"].Value.ToString();
                CargarDatos2();
            }
        }

        private void Inactivos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            FormVenta.CargarDatos();
        }

        private void txtNombreArticulo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ConexionBD Read = new ConexionBD();
                DataTable Resultado = Read.BuscarArticulosInactivos(txtNombreArticulo2.Text);
                dgvInactivos.DataSource = Resultado;
                e.Handled = true;
            }
        }
    }
}
