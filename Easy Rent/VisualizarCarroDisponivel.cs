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
    public partial class VisualizarCarroDisponivel : Form
    {
        public VisualizarCarroDisponivel()
        {
            InitializeComponent();
        }

        private void VisualizarCarro_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ps_visualizar_carro_disponivel";
            cmd.Connection = con;



            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            con.Open();

            adap.Fill(ds, "ps_visualizar_carro_disponivel");

            con.Close();

            dtgCarro.DataSource = ds;
            dtgCarro.DataMember = "ps_visualizar_carro_disponivel";
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ps_visualizar_carro_disponivel";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            
                cmd.Parameters.AddWithValue("Categoria", textBox1.Text);
            



            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.SelectCommand = cmd;
            DataSet ds = new DataSet();

            con.Open();

            adap.Fill(ds);

            con.Close();

            dtgCarro.DataSource = ds;
            dtgCarro.DataMember = "Table";
        }

        private void dtgCarro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
