using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class Registro : Form
    {
        CNClienteLog cN = new CNClienteLog();
        public Registro()
        {
            InitializeComponent();
        }

        private void bttCrRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                bool vali;
                CECliente cECliente = new CECliente();
                cECliente.Name = txtNombre.Text;
                cECliente.UserName = txtRegUsuario.Text;
                cECliente.Lastname = txtApellido.Text;
                cECliente.Password = txtPass2.Text;
                cECliente.Email = txtCorreo.Text;

                vali = cN.ValidarDatosLog(cECliente);
                if (vali == false)
                {
                    return;
                }

                CDClientes dClientes = new CDClientes();
                dClientes.Crear(cECliente);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            this.DialogResult = DialogResult.OK;

        }
    }
}
