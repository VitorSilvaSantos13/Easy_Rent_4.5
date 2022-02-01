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
    public partial class VisualizarLocacaoEmAndamento : Form
    {
        public VisualizarLocacaoEmAndamento()
        {
            InitializeComponent();
        }

        private void dtgLocacao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VisualizarLocacaoEmAndamento_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ps_locacao_andamento";
            cmd.Connection = con;



            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            con.Open();

            adap.Fill(ds, "ps_locacao_andamento");

            con.Close();

            dtgLocacao.DataSource = ds;
            dtgLocacao.DataMember = "ps_locacao_andamento";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ps_locacao_andamento";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("NomeCliente", textBox1.Text);

            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.SelectCommand = cmd;
            DataSet ds = new DataSet();

            con.Open();

            adap.Fill(ds);

            con.Close();

            dtgLocacao.DataSource = ds;
            dtgLocacao.DataMember = "Table";
        }
    }
}
