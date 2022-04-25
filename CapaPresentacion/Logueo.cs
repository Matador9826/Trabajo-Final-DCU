using CapaEntidad;
using CapaNegocio;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class Logueo : Form
    {
       

        CNClienteLog clienteLog = new CNClienteLog();
        public Logueo()
        {
            InitializeComponent();

        }

        private void bttEntrar_Click(object sender, EventArgs e)
        {
            bool vali;
            CECliente cECliente = new CECliente();
            cECliente.UserName = txtUsuario.Text;
            cECliente.Password = txtPass.Text;

           vali = clienteLog.ValidarDatosLog(cECliente);
            if (vali == false)
            {
                return;
            }

            CDClientes cDClientes = new CDClientes();
            cDClientes.Buscar(cECliente);

            if (cDClientes.confirmarLogin == true)
            {
                Listado listado = new Listado();
                listado.Show();   
            }
            this.Hide();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttRegistrar_Click(object sender, EventArgs e)
        {

          this.Hide();
          DialogResult result = new DialogResult();
          Registro registro = new Registro();
          result = registro.ShowDialog();
          registro.Close();

           if (result == DialogResult.OK)
           {
                this.Show();
           }

           

        }

      
    }
}