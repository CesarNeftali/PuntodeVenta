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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtPrecio.KeyPress += new KeyPressEventHandler(txtPrecio_KeyPress);
            txtCantidad.KeyPress += new KeyPressEventHandler(txtCantidad_KeyPress);
        }

        private void Limpiardatos()
        {
            txtNombre_Articulo.Text = "";
            cbID_Proveedor.Text = "";
            txtID_Articulo.Text = "";
            txtPrecio.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {

            if(String.IsNullOrEmpty(cbID_Proveedor.Text))
            {
                MessageBox.Show("Elige El ID del proveedor");
            }
            else
            {
                if(String.IsNullOrEmpty(txtNombre_Articulo.Text))
                {
                    MessageBox.Show("Añade Nombre del Articulo");
                }
                else
                {
                    if(String.IsNullOrEmpty(txtDescripcion.Text))
                    {
                        MessageBox.Show("Añade una descripcion al Articulo");
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(txtPrecio.Text))
                        {
                            MessageBox.Show("Añade un Precio al Articulo");
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(txtCantidad.Text))
                            {
                                MessageBox.Show("Añade una cantdad de stock al Articulo");
                            }
                            else
                            {
                                ConexionBD registrar = new ConexionBD();

                                if (registrar.RegistrarArticulo(cbID_Proveedor.Text, txtNombre_Articulo.Text, txtDescripcion.Text, txtPrecio.Text, txtCantidad.Text))
                                {
                                    Limpiardatos();
                                    CargarDatos();
                                    MessageBox.Show("El Articulo se ha añadido");
                                }
                                else
                                {
                                    Limpiardatos();
                                    MessageBox.Show("Ups Algo Paso");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Venta FormPrincipal = new Venta();
            this.Hide();
            FormPrincipal.ShowDialog();
            this.Close();
        }

        public void CargarDatos()
        {
            ConexionBD Read = new ConexionBD();
            DataTable datos = Read.ConsultarArticulos();
            try
            {
                dgvArticulos.DataSource = datos;
            }
            catch
            {
                MessageBox.Show("Algo salio mal");
            }

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            CambiarNombreLabel();
            LlenarCb();
            CargarDatos();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            ConexionBD Delete = new ConexionBD();

            if (Delete.DeleteArticulo(txtID_Articulo.Text))
            {
                Limpiardatos();
                CargarDatos();
                MessageBox.Show("El Articulo se ha Eliminado");
            }
            else
            {
                MessageBox.Show("Ups Algo Paso");
            }
        }

        private void btnActualizar2_Click(object sender, EventArgs e)
        {
            ConexionBD Update = new ConexionBD();

            if (Update.UpdateArticulo(txtID_Articulo.Text, txtNombre_Articulo.Text, txtDescripcion.Text, txtPrecio.Text, txtCantidad.Text))
            {
                Limpiardatos();
                CargarDatos();
                MessageBox.Show("El Articulo se ha Actualizado");
            }
            else
            {
                MessageBox.Show("Ups Algo Paso");
            }
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvArticulos.Rows[e.RowIndex];

                txtID_Articulo.Text = row.Cells["ID_Articulo"].Value.ToString();
                cbID_Proveedor.Text = row.Cells["ID_Proveedor"].Value.ToString();
                txtNombre_Articulo.Text = row.Cells["NombreArticulo"].Value.ToString();
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                txtCantidad.Text = row.Cells["CantidadStock"].Value.ToString();
                CargarDatos();
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            Inactivos Inac = new Inactivos(this);
            Inac.ShowDialog();
        }

        public void LlenarCb()
        {
            ConexionBD Read = new ConexionBD();
            try
            {
                DataTable proveedoresTable = Read.ConsultarArt_Prov();
                foreach (DataRow row in proveedoresTable.Rows)
                {
                    cbID_Proveedor.Items.Add(row["ID_Proveedor"].ToString());
                }
            }
            catch
            {
                MessageBox.Show("Algo salió mal");
            }
        }

        public void CambiarNombreLabel()
        {
            ConexionBD Read = new ConexionBD();
            try
            {
                DataTable proveedoresTable = Read.ConsultarNombreProveedor(cbID_Proveedor.Text);

                
                if (proveedoresTable.Rows.Count > 0)
                {
                    DataRow firstRow = proveedoresTable.Rows[0];
                    string proveedor = firstRow["NombreEmpresa"].ToString();

                    lbProveedor.Text = "Proveedor: " + proveedor;
                }
                else
                {
                    lbProveedor.Text = "Proveedor:";
                }
            }
            catch
            {
                MessageBox.Show("Algo salió mal");
            }
        }

        private void cbID_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbID_Proveedor.SelectedItem != null)
            {
                CambiarNombreLabel();
            }
            else
            {
                lbProveedor.Text = "Proveedor:";
            }
        }

        private void cbID_Proveedor_TextUpdate(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbID_Proveedor.Text))
            {
                lbProveedor.Text = "Proveedor";
            }
        }

        private void txtNombre_Articulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                ConexionBD Read = new ConexionBD();
                DataTable Resultado = Read.BuscarArticulos(txtNombre_Articulo.Text);
                dgvArticulos.DataSource = Resultado;
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
