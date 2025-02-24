using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Usar la capa de negocio
using Negocio;

namespace Presentacion
{
    public partial class FrmSeguros : Form
    {
        private Negocio.CN_Seguro negocioSeguro = new Negocio.CN_Seguro();

        public FrmSeguros()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            string tipo = txtTipo.Text;
            double valor = Convert.ToDouble(txtValor.Text);
            double porcentaje = Convert.ToDouble(txtPorcentaje.Text);

            string mensaje = negocioSeguro.RegistrarSeguro(codigo, tipo, valor, porcentaje);
            MessageBox.Show(mensaje);
            CargarSeguros();
        }

        private void CargarSeguros()
        {
            listSeguros.Items.Clear();
            foreach (var seguro in negocioSeguro.ObtenerSeguros())
            {
                listSeguros.Items.Add(seguro);
            }
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoVenta.Text;
            string identificacion = txtIdentificacion.Text;
            string cliente = txtCliente.Text;
            string contacto = txtContacto.Text;
            int beneficiarios = (int)numBeneficiarios.Value;

            string mensaje = negocioSeguro.RegistrarVentaSeguro(codigo, identificacion, cliente, contacto, beneficiarios);
            MessageBox.Show(mensaje);
            CargarVentas();
        }

        private void CargarVentas()
        {
            listVentas.Items.Clear();
            foreach (var venta in negocioSeguro.ObtenerVentas())
            {
                listVentas.Items.Add(venta);
            }
        }
    }
}
