using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Datos;

namespace Negocio
{
    public class CN_Seguro
    {
        private Datos.CD_Seguro datosSeguro = new Datos.CD_Seguro();

        public string RegistrarSeguro(string codigo, string tipo, double valor, double porcentaje)
        {
            double beneficio = valor * (porcentaje / 100);
            datosSeguro.InsertarSeguro(codigo, tipo, valor, porcentaje, beneficio);
            return datosSeguro.mensaje;
        }

        public List<string> ObtenerSeguros()
        {
            return datosSeguro.ListadoSeguros();
        }

        public string BuscarSeguroPorCodigo(string codigo)
        {
            return datosSeguro.BuscarSeguro(codigo);
        }

        public string RegistrarVentaSeguro(string codigo, string identificacion, string cliente, string contacto, int beneficiarios)
        {
            string seguro = BuscarSeguroPorCodigo(codigo);
            if (seguro != null)
            {
                string[] datos = seguro.Split(',');
                double valorBase = Convert.ToDouble(datos[2]);
                double incrementoTipo = (valorBase * Convert.ToDouble(datos[3])) / 100;
                double incrementoBeneficiario = valorBase * 0.1 * beneficiarios;
                double beneficioTotal = Convert.ToDouble(datos[4]);
                double beneficioPorBeneficiario = beneficiarios > 0 ? beneficioTotal / beneficiarios : beneficioTotal;
                double totalPagar = valorBase + incrementoTipo + incrementoBeneficiario;

                string registro = $"{codigo},{identificacion},{cliente},{contacto},{valorBase},{incrementoTipo},{incrementoBeneficiario},{beneficioTotal},{beneficioPorBeneficiario},{totalPagar}";
                datosSeguro.RegistrarVenta(registro);
                return "Venta registrada exitosamente.";
            }
            return "Seguro no encontrado.";
        }

        public List<string> ObtenerVentas()
        {
            return datosSeguro.ListadoVentas();
        }
    }
}
