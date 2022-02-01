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
    public partial class FinalizarLocacao : Form
    {
        public FinalizarLocacao()
        {
            InitializeComponent();
        }

        int IDReserva;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            if (txtBusca.TextLength == 0)
            {
                MessageBox.Show("Digite um ID");
            }

            else
            {
                cmd.CommandText = "ps_locacao";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("IDLocacao", txtBusca.Text);

                con.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    IDReserva = dr.GetInt32(2);
                    mskDataLcacao.Text = dr.GetDateTime(3).ToString();
                    mskDataDevolução.Text = dr.GetDateTime(4).ToString();
                    txtNomeCliente.Text = dr.GetString(5).ToString();
                    mskCelular.Text = dr.GetString(10).ToString();
                    cmbCategoria.Text = dr.GetString(11).ToString();
                    txtKmInicial.Text = dr.GetString(16);

                    if (dr.GetString(6).ToString() != null)
                    {
                        mskCPF.Text = dr.GetString(6).ToString();
                    }

                    if (dr.GetString(7).ToString() != null)
                    {
                        mskCNH.Text = dr.GetString(7).ToString();
                    }

                    if (dr.GetString(8).ToString() != null)
                    {
                        mskCNPJ.Text = dr.GetString(8).ToString();
                    }

                    if (dr.GetString(9).ToString() != null)
                    {
                        txtRazao.Text = dr.GetString(9).ToString();
                    }

                    if (dr.GetString(17).ToString() != null)
                    {
                        cmbKM.Text = dr.GetString(17).ToString();
                    }

                    if (dr.GetString(18).ToString() != null)
                    {
                        lblKM.Text = dr.GetString(18).ToString();
                    }

                    if (dr.GetString(19).ToString() == "Sim")
                    {
                        cbxBebeConforto.Checked = true;
                        nupBebe.Value = decimal.Parse(dr.GetString(20));
                    }

                    if (dr.GetString(21).ToString() == "Sim")
                    {
                        cbxCadeiraBebe.Checked = true;
                        nupCadeira.Value = decimal.Parse(dr.GetString(22));
                    }

                    if (dr.GetString(23).ToString() == "Sim")
                    {
                        cbxAssento.Checked = true;
                        nupAssento.Value = decimal.Parse(dr.GetString(24));
                    }

                    lblValortotal.Text = dr.GetDecimal(25).ToString();
                    txtVeiculo.Text = dr.GetString(14);
                    mskPlaca.Text = dr.GetString(15);
                    mskValor.Text = dr.GetDecimal(12).ToString();

                    DateTime data = dr.GetDateTime(4);

                    con.Close();

                    decimal valor = decimal.Parse(lblValortotal.Text);

                    DateTime hoje = DateTime.Now;

                    double dia = (hoje - data).TotalDays;

                    if(dia > 0)
                    {
                        MessageBox.Show("O cliente exedeu " + dia + " dia(s) e terá que pagar o total de " + dia + "diarias a mais!");

                        if (cmbCategoria.Text == "Hatch - R$40,00/dia")
                        {
                            decimal multa = decimal.Parse(dia.ToString()) * 40;
                            lblValortotal.Text = (valor + multa).ToString();
                        }

                        if (cmbCategoria.Text == "Premium - R$150,00/dia")
                        {
                            decimal multa = decimal.Parse(dia.ToString()) * 150;
                            lblValortotal.Text = (valor + multa).ToString();
                        }

                        if (cmbCategoria.Text == "Sedan - R$60,00/dia")
                        {
                            decimal multa = decimal.Parse(dia.ToString()) * 60;
                            lblValortotal.Text = (valor + multa).ToString();
                        }

                        if (cmbCategoria.Text == "SUV - R$100,00/dia")
                        {
                            decimal multa = decimal.Parse(dia.ToString()) * 100;
                            lblValortotal.Text = (valor + multa).ToString();
                        }

                        if (cmbCategoria.Text == "Van - R$140,00/dia")
                        {
                            decimal multa = decimal.Parse(dia.ToString()) * 140;
                            lblValortotal.Text = (valor + multa).ToString();
                        }
                    }

                    txtKmFinal.Enabled = true;
                    txtKmInicial.Enabled = true;

                    lblDiferenca.Text = (decimal.Parse(lblValortotal.Text) - decimal.Parse(mskValor.Text)).ToString();
                }
            }
        }

        private void txtKmFinal_TextChanged(object sender, EventArgs e)
        {
                        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKmFinal_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbKM.Text != "")
                {
                    int KmInicial = Int32.Parse(txtKmInicial.Text);
                    int KmFinal = Int32.Parse(txtKmFinal.Text);
                    decimal PrecoKm = decimal.Parse(lblKM.Text);

                    if (cmbKM.Text == "3000")
                    {
                        int diferenca = KmFinal - KmInicial;

                        if (diferenca > 3000)
                        {
                            MessageBox.Show("O cliente excedeu o limite de Km, portanto terá que pagar a diferença");

                            int KmAMais = diferenca - 3000;
                            lblValortotal.Text = ((decimal.Parse(KmAMais.ToString()) * PrecoKm) + decimal.Parse(lblValortotal.Text)).ToString();
                        }
                    }

                    if (cmbKM.Text == "4000")
                    {
                        int diferenca = KmFinal - KmInicial;

                        if (diferenca > 4000)
                        {
                            MessageBox.Show("O cliente excedeu o limite de Km, portanto terá que pagar a diferença");

                            int KmAMais = diferenca - 4000;
                            lblValortotal.Text = ((decimal.Parse(KmAMais.ToString()) * PrecoKm) + Int32.Parse(lblValortotal.Text)).ToString();
                        }
                    }

                    if (cmbKM.Text == "5000")
                    {
                        int diferenca = KmFinal - KmInicial;

                        if (diferenca > 5000)
                        {
                            MessageBox.Show("O cliente excedeu o limite de Km, portanto terá que pagar a diferença");

                            int KmAMais = diferenca - 5000;
                            lblValortotal.Text = ((decimal.Parse(KmAMais.ToString()) * PrecoKm) + Int32.Parse(lblValortotal.Text)).ToString();
                        }
                    }
                }

                lblDiferenca.Text = (decimal.Parse(lblValortotal.Text) - decimal.Parse(mskValor.Text)).ToString();
            }

            catch
            {
                MessageBox.Show("Escreva o Km final do veículo");
            }
        }

            

        private void button1_Click(object sender, EventArgs e)
        {
            string novoKm = (Int32.Parse(txtKmFinal.Text) + Int32.Parse(txtKmInicial.Text)).ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "finalizar_locacao";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("IDLocacao", txtBusca.Text);
            cmd.Parameters.AddWithValue("Situacao", "Finalizada");
            cmd.Parameters.AddWithValue("Placa", mskPlaca.Text);
            cmd.Parameters.AddWithValue("DtHoraDevol", mskDataDevolução.Text);
            cmd.Parameters.AddWithValue("Km", novoKm);
            cmd.Parameters.AddWithValue("ValorTotal", decimal.Parse(lblValortotal.Text));
            cmd.Parameters.AddWithValue("IDReserva", IDReserva);
            cmd.Parameters.AddWithValue("DataFinalizacao", DateTime.Now);
            cmd.Parameters.AddWithValue("PagamentoFinal", cmbPagamento.Text);
            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Locação finalizada com sucesso!");

            txtBusca.Text = "";
            txtIDFuncionario.Text = "";
            txtKmFinal.Text = "";
            txtKmInicial.Text = "";
            txtNomeCliente.Text = "";
            txtRazao.Text = "";
            txtVeiculo.Text = "";
            mskCelular.Text = "";
            mskCNH.Text = "";
            mskCNPJ.Text = "";
            mskCPF.Text = "";
            mskDataDevolução.Text = "";
            mskDataLcacao.Text = "";
            mskPlaca.Text = "";
            mskValor.Text = "";
            cmbCategoria.Text = "";
            cmbKM.Text = "";
            cbxAssento.Checked = false;
            cbxBebeConforto.Checked = false;
            cbxCadeiraBebe.Checked = false;
            nupAssento.Value = 0;
            nupBebe.Value = 0;
            nupCadeira.Value = 0;
            lblValortotal.Text = "0";
            lblDiferenca.Text = "0";
            cmbPagamento.Text = "";
        }
    }
}