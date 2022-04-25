using MySql.Data.MySqlClient;
using CapaEntidad;
using System.Data;

namespace CapaDatos
{
    
    public class CDClientes
    {
        public bool confirmarLogin = false;
        public string CadenaConexion = "Server=localhost;User=root;Password=root;Port=3306;database=proyectdcu";

        public void PruebaConexion()
        {
            MySqlConnection conexion = new MySqlConnection(CadenaConexion);

            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse" + ex.Message);
                return;
            }
            conexion.Close();
            MessageBox.Show("Conectado");
        }

        public void Crear(CECliente cE)
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(CadenaConexion);
                conexion.Open();
                string Query = "INSERT INTO usuario (UserName, Name, Lastname, Password, Email) VALUES ('" + cE.UserName + "','" + cE.Name + "','" + cE.Lastname + "','" + cE.Password + "', '"+ cE.Email+"');";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, conexion);
                mySqlCommand.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Registro creado!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        public void Buscar(CECliente cE)
        {

            try
            {
                MySqlConnection conexion = new MySqlConnection(CadenaConexion);
                conexion.Open();
                string Query = "SELECT * FROM usuario where UserName = '"+cE.UserName+"' and Password = '"+cE.Password+"';";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, conexion);
                mySqlCommand.ExecuteNonQuery();
               MySqlDataReader reader = mySqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    MessageBox.Show("Login exitoso!");
                    confirmarLogin = true;
                }
                else 
                {
                    
                    MessageBox.Show("Login fallido!");
                    confirmarLogin = false;
                }

                conexion.Close();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        
    }
}