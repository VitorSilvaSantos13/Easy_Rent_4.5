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
    public partial class VisualizarTodosCarros : Form
    {
        public VisualizarTodosCarros()
        {
            InitializeComponent();
        }

        private void VisualizarTodosCarros_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ps_carro";
            cmd.Connection = con;



            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            con.Open();

            adap.Fill(ds, "ps_carro");

            con.Close();

            dtgCarro.DataSource = ds;
            dtgCarro.DataMember = "ps_carro";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ps_carro";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;           
            
            if(cmbCategoria.Text != null)
            {
                cmd.Parameters.AddWithValue("Categoria", cmbCategoria.Text);
            }

            else
            {
                cmd.Parameters.AddWithValue("Categoria", null);
            }
            
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.SelectCommand = cmd;
            DataSet ds = new DataSet();

            con.Open();

            adap.Fill(ds);

            con.Close();

            dtgCarro.DataSource = ds;
            dtgCarro.DataMember = "Table";
        }
    }
}
