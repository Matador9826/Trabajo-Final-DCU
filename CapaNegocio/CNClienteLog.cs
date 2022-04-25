using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CNClienteLog
    {
        CDClientes dClientes = new CDClientes();
        public bool ValidarDatosLog(CECliente cE)
        {
            bool vali = true;

            if ( cE.UserName == String.Empty ||cE.Name == String.Empty || cE.Lastname == String.Empty ||
                cE.Password == String.Empty || cE.Email == String.Empty)
            {
                vali = false;
                MessageBox.Show("Hay campos requeridos aun sin llenar.");
            }

            return vali;

        }

        public void PruebaMySql()
        {
            dClientes.PruebaConexion();
        }

        public void CrearUsuario(CECliente cE)
        {
            dClientes.Crear(cE);
        }
    }
}