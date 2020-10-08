using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Herencia
{
    public partial class Form1 : Form
    {
        Local local = new Local();
        Piso piso = new Piso();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtNroVentanas.Enabled = false;
            this.txtNroPiso.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.cbxTipo.SelectedIndex = -1;
            this.cbxEstado.SelectedIndex = -1;
            this.txtMts2.Text = string.Empty;
            this.txtNroVentanas.Text = string.Empty;
            this.txtNroPiso.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtPrecioBase.Text = string.Empty;
            this.lblPrecioFinal.Text = string.Empty;
            this.lblPrecioFinal.Text = "$0";
        }

        private void BloquearElementos()
        {
            this.txtNroVentanas.Text = string.Empty;
            this.txtNroPiso.Text = string.Empty;

            if(this.cbxTipo.SelectedIndex == 0)
            {
                this.txtNroVentanas.Enabled = true;
                this.txtNroPiso.Enabled = false;
            }
            else if(this.cbxTipo.SelectedIndex == 1)
            {
                this.txtNroPiso.Enabled = true;
                this.txtNroVentanas.Enabled = false;
            }
            else
            {
                this.txtNroPiso.Enabled = false;
                this.txtNroVentanas.Enabled = false;
            }
        }

        private void cbxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BloquearElementos();
        }

        private bool Validar()
        {
            if (this.cbxTipo.SelectedIndex != -1 && this.cbxEstado.SelectedIndex != -1 && !string.IsNullOrEmpty(this.txtMts2.Text) &&
                (!string.IsNullOrEmpty(this.txtNroVentanas.Text) || (!string.IsNullOrEmpty(this.txtNroPiso.Text))) &&
                !string.IsNullOrEmpty(this.txtDireccion.Text) && !string.IsNullOrEmpty(this.txtPrecioBase.Text))
                return true;
            else
                return false;
        }

        private void GuardarDatosLocal()
        {
            local.Direccion = this.txtDireccion.Text;
            local.Mts2 = Convert.ToSingle(this.txtMts2.Text);
            local.Estado = this.cbxEstado.SelectedItem.ToString();
            local.NroVentanas = Convert.ToInt32(this.txtNroVentanas.Text);
        }

        private void GuardarDatosPiso()
        {
            piso.Direccion = this.txtDireccion.Text;
            piso.Mts2 = Convert.ToSingle(this.txtMts2.Text);
            piso.Estado = this.cbxEstado.SelectedItem.ToString();
            piso.NroPiso = Convert.ToInt32(this.txtNroPiso.Text);
        }

        private float Calcular()
        {
            float resultado = 0.0f;

            if (this.cbxTipo.SelectedIndex == 0)
                resultado = local.Calcular(Convert.ToSingle(this.txtPrecioBase.Text));
            else if (this.cbxTipo.SelectedIndex == 1)
                resultado = piso.Calcular(Convert.ToSingle(this.txtPrecioBase.Text));

            return resultado;
        }

        private void btnCotizar_Click(object sender, EventArgs e)
        {
            bool valido = this.Validar();
            float precioFinal = 0.0f;

            if (valido)
            {
                if (cbxTipo.SelectedIndex == 0)
                    this.GuardarDatosLocal();
                else if (this.cbxTipo.SelectedIndex == 1)
                    this.GuardarDatosPiso();

                precioFinal = this.Calcular();
                this.lblPrecioFinal.Text = '$'+precioFinal.ToString();
            }
            else
                MessageBox.Show("Todos los campos son obligatorios", "Atención!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
