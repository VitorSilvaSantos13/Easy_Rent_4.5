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
    public partial class CadastroCarro : Form
    {
        public CadastroCarro()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            rdbACsim.Checked = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = "pi_carro";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("Placa", mskPlaca.Text);
                cmd.Parameters.AddWithValue("Nome", txtNome.Text);
                cmd.Parameters.AddWithValue("Ano", mskAno.Text);
                cmd.Parameters.AddWithValue("Marca", txtMarca.Text);
                cmd.Parameters.AddWithValue("Categoria", cmbCategoria.Text);
                cmd.Parameters.AddWithValue("CapacidadePortaMalas", txtCapacidadePortaMalas.Text);
                cmd.Parameters.AddWithValue("QuantidadeAirBag", txtAirbag.Text);
                cmd.Parameters.AddWithValue("Km", txtKm.Text);
                cmd.Parameters.AddWithValue("CapacidadePassageiros", txtCapaciadadePassageiros.Text);
                cmd.Parameters.AddWithValue("Portas", txtPorta.Text);
                cmd.Parameters.AddWithValue("StatusVeiculo", cmbStatus.Text);

                if (rbdAuto.Checked == true)
                {
                    cmd.Parameters.AddWithValue("Cambio", "Automático");
                }

                if (rbdManual.Checked == true)
                {
                    cmd.Parameters.AddWithValue("Cambio", "Manual");
                }

                if (rdbACnao.Checked == true)
                {
                    cmd.Parameters.AddWithValue("ArCondicionado", "Não");
                }

                if (rdbACsim.Checked == true)
                {
                    cmd.Parameters.AddWithValue("ArCondicionado", "Sim");
                }

                if (rdbAnao.Checked == true)
                {
                    cmd.Parameters.AddWithValue("AirBag", "Não");
                }

                if (rdbAsim.Checked == true)
                {
                    cmd.Parameters.AddWithValue("AirBag", "Sim");
                }

                if (rdbEletrica.Checked == true)
                {
                    cmd.Parameters.AddWithValue("Direcao", "Elétrica");
                }

                if (rdbHidraulica.Checked == true)
                {
                    cmd.Parameters.AddWithValue("Direcao", "Hidráulica");
                }

                if (rdbFreionao.Checked == true)
                {
                    cmd.Parameters.AddWithValue("FreioABS", "Não");
                }

                if (rdbFreiosim.Checked == true)
                {
                    cmd.Parameters.AddWithValue("FreioABS", "Sim");
                }

                if (rdbTnao.Checked == true)
                {
                    cmd.Parameters.AddWithValue("TravaEletrica", "Não");
                }

                if (rdbTsim.Checked == true)
                {
                    cmd.Parameters.AddWithValue("TravaEletrica", "Sim");
                }

                if (rdbVnao.Checked == true)
                {
                    cmd.Parameters.AddWithValue("VidroEletrico", "Não");
                }

                if (rdbVsim.Checked == true)
                {
                    cmd.Parameters.AddWithValue("VidroEletrico", "Sim");
                }

                cmd.Parameters.AddWithValue("Situacao", "Ativo");

                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Carro cadastrado com sucesso!");

                txtMarca.Text = "";
                txtNome.Text = "";
                txtAirbag.Text = "";
                txtCapaciadadePassageiros.Text = "";
                txtCapacidadePortaMalas.Text = "";
                txtKm.Text = "";
                mskAno.Text = "";
                mskPlaca.Text = "";
                txtPorta.Text = "";
                cmbCategoria.Text = "";
                cmbStatus.Text = "";
                rbdAuto.Checked = false;
                rbdManual.Checked = false;
                rdbACnao.Checked = false;
                rdbACsim.Checked = false;
                rdbAnao.Checked = false;
                rdbAsim.Checked = false;
                rdbEletrica.Checked = false;
                rdbFreionao.Checked = false;
                rdbFreiosim.Checked = false;
                rdbHidraulica.Checked = false;
                rdbTnao.Checked = false;
                rdbTsim.Checked = false;
                rdbVnao.Checked = false;
                rdbVsim.Checked = false;
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Há algum campo vazio!");
            }
        }

        private void rdbAsim_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbdAuto_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void rdbFnao_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbFsim_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void rdbVnao_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
