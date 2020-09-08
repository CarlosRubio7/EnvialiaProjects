using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uptook
{
    public partial class ImportarBDD : Form
    {
        ConectarBD con = new ConectarBD();
        ImportExcel import;

        public ImportarBDD()
        {
            InitializeComponent();
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                       BOTÓN - BUSCAR                       ********/
        /********                                                            ********/
        /****************************************************************************/
        private void bt_buscar_Click(object sender, EventArgs e)
        {
            bt_cancelar.Enabled = true;
            OpenFileDialog fbd = new OpenFileDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
            {
                tb_ruta.Text = fbd.FileName.ToString();
            }
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                       BOTÓN - IMPORTAR                     ********/
        /********                                                            ********/
        /****************************************************************************/
        private void bt_importar_Click(object sender, EventArgs e)
        {
            if (tb_ruta.Text != "")
            {
                try
                {
                    con.ConexionBd();
                    import = new ImportExcel();
                    import.RecogerDatosExcel(tb_ruta.Text);
                    con.DesconectarBd();
                }
                catch (Exception f)
                {
                    String msg = "Error al insertar" + f.ToString();
                    con.DesconectarBd();
                    MessageBox.Show(msg);
                }
            }
        }
    }
}
