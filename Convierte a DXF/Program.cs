using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Convierte_a_DXF
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// Diseñado para ejecutar archivo sobre exe y ejecutar en consola, o en solitario
        /// Si se usa el metodo de arrastrado la UI no se muestra
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            CorrectNumberFormat();
            //Detects if is running with parameters
            if (args.Any())
            {
                var path = args[0];
                if (File.Exists(path))
                {
                    try
                    {
                        //Show warning message, to ensure PXYZ order
                        DialogResult boton = MessageBox.Show("De clic en ok si el archivo tiene orden PXYZ\nde lo contrario ejecute el programa por separado", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (boton == DialogResult.OK) { 
                            int resultCode = Convertidor.Convert(Path.GetFullPath(path));
                            if (resultCode == 0)
                            {
                                MessageBox.Show("Generado correctamente, en directorio del archivo", "Aceptar", MessageBoxButtons.OK);
                            }
                            else
                            {
                                MessageBox.Show("Se produjo un error al convertir", "Aceptar", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            return;
                        }           
            
                    }
                    catch
                    {
                        MessageBox.Show("Error al convertir\nSolo archivos NXYZ separado por comas", "Aceptar", MessageBoxButtons.OK);
                    }
                }
            }
            //Show UI if not running with parameters
            else {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }

        //Forces the app to use period on decimal separators
        public static void CorrectNumberFormat()
        {
            var culture = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            if (culture.NumberFormat.NumberDecimalSeparator != ".")
            {
                culture.NumberFormat.NumberDecimalSeparator = ".";
                culture.NumberFormat.CurrencyDecimalSeparator = ".";
                culture.NumberFormat.PercentDecimalSeparator = ".";
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;

                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
        }
    }
}
