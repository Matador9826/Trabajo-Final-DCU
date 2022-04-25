using MySql.Data.MySqlClient;
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
using CapaDatos;

namespace CapaPresentacion
{
    public partial class Listado : Form
    {

        public Listado()
        {
            InitializeComponent();
        }

        private void bttBuscar_Click(object sender, EventArgs e)
        {
            string CadenaConexion = "Server=localhost;User=root;Password=root;Port=3306;database=proyectdcu";
            try
            {
                MySqlConnection conexion = new MySqlConnection(CadenaConexion);
                conexion.Open();
                string Query = "SELECT * FROM usuario";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, conexion);
                mySqlCommand.ExecuteNonQuery();
                DataTable dataTable = new DataTable();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);

                mySqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                conexion.Close();
                MessageBox.Show("ESTOS SON LOS RESULTADOS!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
