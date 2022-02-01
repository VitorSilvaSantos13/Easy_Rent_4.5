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
    public partial class VisualizarCliente : Form
    {
        public VisualizarCliente()
        {
            InitializeComponent();
        }

        private void Vizu___Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ps_clientes_visualizar_pf_pj";
            cmd.Connection = con;



            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            con.Open();

            adap.Fill(ds, "ps_clientes_visualizar_pf_pj");

            con.Close();

            dtgCliente.DataSource = ds;
            dtgCliente.DataMember = "ps_clientes_visualizar_pf_pj";
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ps_clientes_visualizar_pf_pj";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            int numero = 0;
            bool canConvert = int.TryParse(textBox1.Text, out numero);
            if (canConvert == true)
            {
                cmd.Parameters.AddWithValue("cpfcnpj", textBox1.Text);
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

        private void dtgCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
