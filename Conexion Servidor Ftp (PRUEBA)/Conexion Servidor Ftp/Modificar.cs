using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion_Servidor_Ftp
{
    public partial class Modificar : Form
    {
        ConectarBD con = new ConectarBD();
        string dato_mod;

        public string Dato_mod
        {
            get
            {
                return dato_mod;
            }
            set
            {
                dato_mod = value;
            }
        }
        public Modificar()
        {
            InitializeComponent();
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                      BOTÓN - GUARDAR                       ********/
        /********                                                            ********/
        /****************************************************************************/
        private void button1_Click(object sender, EventArgs e)
        {
            ConectarBD con = new ConectarBD();
            con.ConexionBd();
            string retorno = "";
            string stock = "";

            try
            {
                if (cb_retorno.Checked == true)
                    retorno = "SI";
                else
                    retorno = "NO";

                if (cb_stock.Checked == true)
                    stock = "SI";
                else
                    stock = "NO";

                con.UpdateBd(tb_id.Text, tb_pedido.Text, tb_key.Text, tb_referencia.Text, tb_destinatario.Text, tb_direccion.Text, tb_poblacion.Text, tb_codigo_postal.Text, tb_telefono.Text,
                             tb_proveedor.Text, tb_descripcion.Text, tb_bultos.Text, tb_peso.Text, tb_codigo_tarifa.Text, tb_reembolso.Text, retorno, tb_observaciones.Text, tb_etiqueta.Text, stock,
                             tb_tiposervicio.Text, tb_email.Text);
                MessageBox.Show("El registro se ha modificado correctamente");
            }
            catch (Exception ex)
            {
                String msg = "Error al modificar los datos" + "Details:" + '\n' + ex.ToString();
                MessageBox.Show(msg);
            }

            con.DesconectarBd();
            this.Close(); 
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                     BOTÓN - CANCELAR                       ********/
        /********                                                            ********/
        /****************************************************************************/
        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                      EVENTO - LOAD                         ********/
        /********                                                            ********/
        /****************************************************************************/
        private void Modificar_Load(object sender, EventArgs e)
        {
            con.ConexionBd();
            List<ConectarBD> lista = con.ConsultarIdBd(dato_mod);

            foreach (ConectarBD dat in lista)
            {
                if (dat.Retorno == "SI")
                    cb_retorno.Checked = true;
                else
                    cb_retorno.Checked = false;

                if (dat.Stock == "SI")
                    cb_stock.Checked = true;
                else
                    cb_stock.Checked = false;
                tb_id.Text = dat.Id;
                tb_pedido.Text = dat.Num_pedido;
                tb_key.Text = dat.Num_key;
                tb_referencia.Text = dat.Ref_producto;
                tb_fecha_pedido.Text = dat.Fecha_pedido;
                tb_destinatario.Text = dat.Destinatario;
                tb_direccion.Text = dat.Direccion;
                tb_poblacion.Text = dat.Poblacion;
                tb_codigo_postal.Text = dat.Cod_postal;
                tb_telefono.Text = dat.Telefono;
                tb_proveedor.Text = dat.Proveedor;
                tb_descripcion.Text = dat.Descripcion_producto;
                tb_bultos.Text = dat.Bultos;
                tb_peso.Text = dat.Peso;
                tb_codigo_tarifa.Text = dat.Cod_tarifa;
                tb_reembolso.Text = dat.Reembolso;
                tb_observaciones.Text = dat.Observaciones;
                tb_etiqueta.Text = dat.Etiqueta;
                tb_tiposervicio.Text = dat.Servicio;
                tb_email.Text = dat.Email;

            }

            con.DesconectarBd();
        }
    }
}
