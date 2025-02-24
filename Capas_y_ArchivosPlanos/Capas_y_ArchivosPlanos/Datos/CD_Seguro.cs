using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Importar el paquete para trabajar archivos
using System.IO;

namespace Datos
{
    public class CD_Seguro
    {
        private string ruta = @"..\..\recursos\seguros.txt";
        private string rutaVentas = @"..\..\recursos\ventas.txt";
        public string mensaje = "";

        public void InsertarSeguro(string codigo, string tipo, double valor, double porcentaje, double beneficio)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(ruta, true))
                {
                    escritor.WriteLine($"{codigo},{tipo},{valor},{porcentaje},{beneficio}");
                }
                mensaje = "Seguro registrado exitosamente.";
            }
            catch (IOException e)
            {
                mensaje = "ERROR: " + e.Message;
            }
        }

        public List<string> ListadoSeguros()
        {
            List<string> lista = new List<string>();
            try
            {
                using (StreamReader lector = new StreamReader(ruta))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        lista.Add(linea);
                    }
                }
            }
            catch (IOException e)
            {
                mensaje = "ERROR: " + e.Message;
            }
            return lista;
        }

        public string BuscarSeguro(string codigo)
        {
            try
            {
                using (StreamReader lector = new StreamReader(ruta))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(',');
                        if (datos[0] == codigo)
                        {
                            return linea;
                        }
                    }
                }
            }
            catch (IOException e)
            {
                mensaje = "ERROR: " + e.Message;
            }
            return null;
        }

        public void RegistrarVenta(string registro)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(rutaVentas, true))
                {
                    escritor.WriteLine(registro);
                }
            }
            catch (IOException e)
            {
                mensaje = "ERROR: " + e.Message;
            }
        }

        public List<string> ListadoVentas()
        {
            List<string> ventas = new List<string>();
            try
            {
                using (StreamReader lector = new StreamReader(rutaVentas))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        ventas.Add(linea);
                    }
                }
            }
            catch (IOException e)
            {
                mensaje = "ERROR: " + e.Message;
            }
            return ventas;
        }
    }
}
