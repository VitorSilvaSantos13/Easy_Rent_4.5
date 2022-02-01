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
    public partial class VicualizarReserva : Form
    {
        public VicualizarReserva()
        {
            InitializeComponent();
        }

        private void VicualizarReserva_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ps_reserva";
            cmd.Connection = con;



            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            con.Open();

            adap.Fill(ds, "ps_reserva");

            con.Close();

            dtgReserva.DataSource = ds;
            dtgReserva.DataMember = "ps_reserva";
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ps_reserva";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            //int numero = 0;
            //bool canConvert = int.TryParse(txtNom.Text, out numero);
            //if (canConvert == true)
            //{
            //    cmd.Parameters.AddWithValue("cpfcnpj", textBox1.Text);
            //}

            //if
            //{
                cmd.Parameters.AddWithValue("NomeCliente", txtNome.Text);
            //}



            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.SelectCommand = cmd;
            DataSet ds = new DataSet();

            con.Open();

            adap.Fill(ds);

            con.Close();

            dtgReserva.DataSource = ds;
            dtgReserva.DataMember = "Table";
        }

        private void dtgReserva_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
