using System;
using System.IO;
using System.Windows.Forms;

namespace Convierte_a_DXF
{
    public partial class Form1 : Form
    {
        Stream myStream = null;
        
        public Form1()
        {
            InitializeComponent();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "archivos de puntos (*.pnt)|*.pnt|(*.sdr)|*.sdr|(*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
        }

        private void b_convertir_Click(object sender, EventArgs e)
        {

            int order = getOrder();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        int resultCode = Convertidor.Convert(openFileDialog.FileName, order);
                        if (resultCode == 0)
                        {
                            MessageBox.Show("Generado correctamente, en directorio del archivo", "Aceptar", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error al convertir", "Aceptar", MessageBoxButtons.OK);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se pudo leer el archivo " + ex.Message);
                }
            }
        }

        private int getOrder()
        {
            return (r_xyz.Checked) ? 0 : 1;
        }
    }
}
