using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Easy_Rent
{
    public partial class VisualizarFuncionario : Form
    {
        public VisualizarFuncionario()
        {
            InitializeComponent();
        }

        private void VisualizarFuncionario_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ps_visualizar_funcionario";
            cmd.Connection = con;



            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            con.Open();

            adap.Fill(ds, "ps_visualizar_funcionario");

            con.Close();

            dtgCliente.DataSource = ds;
            dtgCliente.DataMember = "ps_visualizar_funcionario";
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ps_visualizar_funcionario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            int numero = 0;
            bool canConvert = int.TryParse(textBox1.Text, out numero);
            if (canConvert == true)
            {
                cmd.Parameters.AddWithValue("cpf", textBox1.Text);
            }

            else
            {
                cmd.Parameters.AddWithValue("nome", textBox1.Text);
            }



            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.SelectCommand = cmd;
            DataSet ds = new DataSet();

            con.Open();

            adap.Fill(ds);

            con.Close();

            dtgCliente.DataSource = ds;
            dtgCliente.DataMember = "Table";
        }
    }
}
