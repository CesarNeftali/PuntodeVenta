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
    public partial class Proveedores : Form
    {

        public Proveedores()
        {
            InitializeComponent();
            txtTelefono.KeyPress += new KeyPressEventHandler(txtTelefono_KeyPress);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if(String.IsNullOrEmpty(txtNombreEmpresa.Text))
            {
                MessageBox.Show("Añade Nombre de la Empresa");
            }
            else
            {
                if (String.IsNullOrEmpty(txtContacto.Text))
                {
                    MessageBox.Show("Añade Nombre del Contacto");
                }
                else
                {
                    if (String.IsNullOrEmpty(txtDireccion.Text))
                    {
                        MessageBox.Show("Añade la direccion de la empresa");
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(txtTelefono.Text))
                        {
                            MessageBox.Show("Añade el telefono del contacto");
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(txtCorreo.Text))
                            {
                                MessageBox.Show("Añade el correo del Contacto");
                            }
                            else
                            {
                                ConexionBD registrar = new ConexionBD();

                                if (registrar.RegistrarProveedor(txtNombreEmpresa.Text, txtContacto.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text))
                                {
                                    CargarDatos();
                                    LimpiarDatos();
                                    MessageBox.Show("El Proveedor se ha añadido");
                                }
                                else
                                {
                                    MessageBox.Show("Ups Algo Paso");
                                }
                            }
                        }
                    }
                }
            }

        }

        private void Proveedores_FormClosed(object sender, FormClosedEventArgs e)
        {
            Venta FormPrincipal = new Venta();
            this.Hide();
            FormPrincipal.ShowDialog();
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ConexionBD Update = new ConexionBD();

            if (Update.UpdateProveedor(txtID_Proveedor.Text, txtNombreEmpresa.Text, txtContacto.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text))
            {
                CargarDatos();
                LimpiarDatos();
                MessageBox.Show("La informacion del Proveedor se ha Actualizado");
            }
            else
            {
                MessageBox.Show("Ups Algo Paso");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ConexionBD Delete = new ConexionBD();

            if (Delete.DeleteProveedor(txtID_Proveedor.Text))
            {
                CargarDatos();
                LimpiarDatos();
                MessageBox.Show("La informacion del Proveedor se ha Eliminado Correctamente");
            }
            else
            {
                MessageBox.Show("Ups Algo Paso");
            }
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            ConexionBD Read = new ConexionBD();
            DataTable datos = Read.ConsultarProveedores();
            try
            {
                dgvProveedor.DataSource = datos;
            }
            catch
            {
                MessageBox.Show("Algo salio mal");
            }

        }

        private void LimpiarDatos()
        {
            txtID_Proveedor.Text = "";
            txtContacto.Text = "";
            txtNombreEmpresa.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }

        private void dgvProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProveedor.Rows[e.RowIndex];

                txtID_Proveedor.Text = row.Cells["ID_Proveedor"].Value.ToString();
                txtNombreEmpresa.Text = row.Cells["NombreEmpresa"].Value.ToString();
                txtContacto.Text = row.Cells["Contacto"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = row.Cells["CorreoElectronico"].Value.ToString();
                CargarDatos();
            }
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ConexionBD Read = new ConexionBD();
                DataTable Resultado = Read.BuscarProveedores(txtContacto.Text);
                dgvProveedor.DataSource = Resultado;
                e.Handled = true;
            }

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
