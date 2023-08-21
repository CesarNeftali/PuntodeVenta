using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proyecto
{
    public partial class Reporte_de_venta : Form
    {
        public Reporte_de_venta()
        {
            InitializeComponent();
            dtpFecha1.Format = DateTimePickerFormat.Custom;
            dtpFecha1.CustomFormat = "yyyy/MM/dd 00:00:00";
            dtpFecha2.Value = DateTime.Now;
            dtpFecha2.Format = DateTimePickerFormat.Custom;
            dtpFecha2.CustomFormat = "yyyy/MM/dd 00:00:00";
        }

        private void Reporte_de_venta_FormClosed(object sender, FormClosedEventArgs e)
        {
            Venta FormPrincipal = new Venta();
            this.Hide();
            FormPrincipal.ShowDialog();
            this.Close();
        }

        public void CargarDatos()
        {
            ConexionBD Read = new ConexionBD();
            DataTable datos = Read.ReporteVenta(dtpFecha2.Text);
            try
            {
                dgvReporte.DataSource = datos;
            }
            catch
            {
                MessageBox.Show("Algo salio mal");
            }

        }

        private void Reporte_de_venta_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
                    saveFileDialog.Title = "Guardar como archivo CSV";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            DataGridView dgv = dgvReporte;

                            
                            foreach (DataGridViewColumn Columnas in dgvReporte.Columns)
                            {
                                writer.Write('"' + Columnas.HeaderText + '"' + ",");
                            }
                            writer.WriteLine();

                            
                            foreach (DataGridViewRow Filas in dgvReporte.Rows)
                            {
                                foreach (DataGridViewCell cell in Filas.Cells)
                                {
                                    writer.Write('"' + cell.Value?.ToString() + '"' + ",");
                                }
                                writer.WriteLine();
                            }
                        }
                        CargarDatos();
                        MessageBox.Show("Los datos se han exportado exitosamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar los datos");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ConexionBD Read = new ConexionBD();
            DataTable Resultado = Read.ReporteVentaPorFecha(dtpFecha1.Text, dtpFecha2.Text);
            dgvReporte.DataSource = Resultado;
        }
    }
}
