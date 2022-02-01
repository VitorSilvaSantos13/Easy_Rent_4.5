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
    public partial class AtualizarExcluirCarro : Form
    {
        public AtualizarExcluirCarro()
        {
            InitializeComponent();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "pu_carro";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("Km", txtKm.Text);
            cmd.Parameters.AddWithValue("Placa", mskBuscar.Text);

            if (rdbDisponivel.Checked == true)
            {
                cmd.Parameters.AddWithValue("StatusVeiculo", "Disponível");
            }

            if (rdbLocacao.Checked == true)
            {
                cmd.Parameters.AddWithValue("StatusVeiculo", "Locação");
            }

            if (rdbManutencao.Checked == true)
            {
                cmd.Parameters.AddWithValue("StatusVeiculo", "Manutenção");
            }

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Carro atualizado com sucesso!");

            mskBuscar.Text = ("");
            txtNome.Text = ("");
            mskPlaca.Text = ("");
            txtKm.Text = ("");
            rdbDisponivel.Checked = false;
            rdbLocacao.Checked = false;
            rdbManutencao.Checked = false;
        }

        public int IDCarro;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ps_carro";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("Placa", mskBuscar.Text);

            con.Open();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                IDCarro = dr.GetInt32(0);
                txtNome.Text = dr.GetString(2);
                mskPlaca.Text = dr.GetString(1);
                txtKm.Text = dr.GetString(18);

                if (dr.GetString(17) == "Locação")
                {
                    rdbLocacao.Checked = true;
                }

                if (dr.GetString(17) == "Disponível")
                {
                    rdbDisponivel.Checked = true;
                }

                if (dr.GetString(17) == "Manutenção" || dr.GetString(17) == "Lavando")
                {
                    rdbManutencao.Checked = true;
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            DialogResult dialogResult = MessageBox.Show("Deseja mesmo desativar esse Carro?", "", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                cmd.CommandText = "destaivar_carro";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("Placa", mskPlaca.Text);
                cmd.Parameters.AddWithValue("Situacao", "Desativado");

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Carro desativado com sucesso!");

                mskBuscar.Text = ("");
                txtNome.Text = ("");
                mskPlaca.Text = ("");
                txtKm.Text = ("");
                rdbDisponivel.Checked = false;
                rdbLocacao.Checked = false;
                rdbManutencao.Checked = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AtualizarExcluirCarro_Load(object sender, EventArgs e)
        {

        }
    }
}
