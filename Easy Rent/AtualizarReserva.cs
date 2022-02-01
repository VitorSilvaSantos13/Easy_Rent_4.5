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
    public partial class AtualizarReserva : Form
    {
        public AtualizarReserva()
        {
            InitializeComponent();
        }

        string categoria;

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
                cmd.CommandText = "ps_reserva_locacao";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("IDReserva", txtBusca.Text);

                con.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (dr.GetString(21) == "Locação")
                    {
                        MessageBox.Show("Já foi efetuada uma locação nessa reserva!");
                        con.Close();
                    }

                    else
                    {
                        IDPessoa = dr.GetInt32(1);
                        mskDtHRetirada.Text = dr.GetDateTime(9).ToString();
                        mskDtHDevol.Text = dr.GetDateTime(10).ToString();
                        txtNomeCliente.Text = dr.GetString(2).ToString();
                        mskCelular.Text = dr.GetString(7).ToString();
                        cmbCategoria.Text = dr.GetString(8).ToString();

                        if (dr.GetString(4).ToString() != null)
                        {
                            mskCPF.Text = dr.GetString(4).ToString();
                        }

                        if (dr.GetString(6).ToString() != null)
                        {
                            mskCNH.Text = dr.GetString(6).ToString();
                        }

                        if (dr.GetString(5).ToString() != null)
                        {
                            mskCNPJ.Text = dr.GetString(5).ToString();
                        }

                        if (dr.GetString(3).ToString() != null)
                        {
                            txtRazaoSocial.Text = dr.GetString(3).ToString();
                        }

                        if (dr.GetString(11).ToString() != null)
                        {
                            cmbKM.Text = dr.GetString(11).ToString();
                        }

                        if (dr.GetString(12).ToString() != null)
                        {
                            lblKM.Text = dr.GetString(12).ToString();
                        }

                        if (dr.GetString(13).ToString() == "Sim")
                        {
                            cbxBebeConforto.Checked = true;
                            nupBebe.Value = decimal.Parse(dr.GetString(14).ToString());
                        }

                        if (dr.GetString(15).ToString() == "Sim")
                        {
                            cbxCadeiraBebe.Checked = true;
                            nupCadeira.Value = decimal.Parse(dr.GetString(16).ToString());
                        }

                        if (dr.GetString(17).ToString() == "Sim")
                        {
                            cbxAssento.Checked = true;
                            nupAssento.Value = decimal.Parse(dr.GetString(18).ToString());
                        }

                        if (dr.GetString(8).ToString() == "Hatch - R$40,00/dia" || dr.GetString(8).ToString() == "Hatch")
                        {
                            categoria = "Hatch";
                        }

                        if (dr.GetString(8).ToString() == "Premium - R$150,00/dia" || dr.GetString(8).ToString() == "Premium")
                        {
                            categoria = "Premium";
                        }

                        if (dr.GetString(8).ToString() == "Sedan - R$60,00/dia" || dr.GetString(8).ToString() == "Sedan")
                        {
                            categoria = "Sedan";
                        }

                        if (dr.GetString(8).ToString() == "SUV - R$100,00/dia" || dr.GetString(8).ToString() == "SUV")
                        {
                            categoria = "SUV";
                        }

                        if (dr.GetString(8).ToString() == "Van - R$140,00/dia" || dr.GetString(8).ToString() == "Van")
                        {
                            categoria = "Van";
                        }

                        lblValorTotal.Text = dr.GetString(19);

                        con.Close();
                    }
                }
            }

            txtNomeCliente.Enabled = true;
            cmbCategoria.Enabled = true;
            mskCelular.Enabled = true;
            mskDtHDevol.Enabled = true;
            mskDtHRetirada.Enabled = true;
            cbxAssento.Enabled = true;
            cbxBebeConforto.Enabled = true;
            cbxCadeiraBebe.Enabled = true;

            if (txtRazaoSocial.Text != "")
            {
                txtRazaoSocial.Enabled = true;
            }
        }

        private void cbxBebeConforto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxBebeConforto.Checked == true)
            {
                nupBebe.Enabled = true;
                decimal Valor = decimal.Parse(lblValorTotal.Text);
                decimal Preco = Valor + ((20.00m * Int32.Parse(nupBebe.Text)) * totalDias);
                lblValorTotal.Text = Preco.ToString();
                precosemkm = (Preco);
            }

            else if (cbxBebeConforto.Checked == false)
            {
                nupBebe.Enabled = false;
                decimal Valor = decimal.Parse(lblValorTotal.Text);
                decimal Preco = Valor - ((20.00m * Int32.Parse(nupBebe.Text)) * totalDias);
                lblValorTotal.Text = Preco.ToString();
                precosemkm = (Preco);
            }
        }

        private void cbxCadeiraBebe_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCadeiraBebe.Checked == true)
            {
                nupCadeira.Enabled = true;
                decimal Valor = decimal.Parse(lblValorTotal.Text);
                decimal Preco = Valor + ((20.00m * Int32.Parse(nupCadeira.Text)) * totalDias);
                lblValorTotal.Text = Preco.ToString();
                precosemkm = (Preco);
            }

            else if (cbxCadeiraBebe.Checked == false)
            {
                nupCadeira.Enabled = false;
                decimal Valor = decimal.Parse(lblValorTotal.Text);
                decimal Preco = Valor - ((20.00m * Int32.Parse(nupCadeira.Text)) * totalDias);
                lblValorTotal.Text = Preco.ToString();
                precosemkm = (Preco);
            }
        }

        private void cbxAssento_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAssento.Checked == true)
            {
                nupAssento.Enabled = true;
                decimal Valor = decimal.Parse(lblValorTotal.Text);
                decimal Preco = Valor + ((20.00m * Int32.Parse(nupAssento.Text)) * totalDias);
                lblValorTotal.Text = Preco.ToString();
                precosemkm = (Preco);
            }

            else if (cbxAssento.Checked == false)
            {
                nupAssento.Enabled = false;
                decimal Valor = decimal.Parse(lblValorTotal.Text);
                decimal Preco = Valor - ((20.00m * Int32.Parse(nupAssento.Text)) * totalDias);
                lblValorTotal.Text = Preco.ToString();
                precosemkm = (Preco);
            }
        }

        public decimal Preco;
        public decimal PrecoKM;
        public decimal PrecoKMFinal;
        public int totalDias;
        public decimal precosemkm;
        public decimal precosemopcional;

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal Valor = decimal.Parse(lblValorTotal.Text);

            if (lblValor.Text != "0,00")
            {
                lblValorTotal.Text = "0,00";

                Valor = decimal.Parse(lblValorTotal.Text);

                if (cbxAssento.Checked == true)
                {
                    Preco += 20 * totalDias;
                }

                if (cbxBebeConforto.Checked == true)
                {
                    Preco += 20 * totalDias;
                }

                if (cbxCadeiraBebe.Checked == true)
                {
                    Preco += 20 * totalDias;
                }

            }



            if (cmbCategoria.Text == "Hatch - R$40,00/dia")
            {

                Preco = 40.00m * totalDias;

                if (cmbKM.Text != null)
                {
                    if (cmbKM.Text == "3000")
                    {
                        PrecoKM = 0.45m;
                        PrecoKMFinal = 900;

                        lblKM.Text = PrecoKM.ToString();

                        lblValorTotal.Text = (Valor + PrecoKMFinal).ToString();

                        lblKMD.Text = PrecoKMFinal.ToString();
                    }

                    else if (cmbKM.Text == "4000")
                    {
                        PrecoKM = 0.47m;
                        PrecoKMFinal = 1280;

                        lblKM.Text = PrecoKM.ToString();

                        lblValorTotal.Text = (Valor + PrecoKMFinal).ToString();

                        lblKMD.Text = PrecoKMFinal.ToString();
                    }

                    else if (cmbKM.Text == "5000")
                    {
                        PrecoKM = 0.49m;
                        PrecoKMFinal = 1700;

                        lblKM.Text = PrecoKM.ToString();

                        lblValorTotal.Text = (Valor + PrecoKMFinal).ToString();

                        lblKMD.Text = PrecoKMFinal.ToString();
                    }
                }

            }

            else if (cmbCategoria.Text == "Premium - R$150,00/dia")
            {

                Preco = 150.00m * totalDias;

                if (cmbKM.Text != null)
                {
                    if (cmbKM.Text == "3000")
                    {
                        PrecoKM = 0.45m;
                        PrecoKMFinal = 900;

                        lblKM.Text = PrecoKM.ToString();

                        lblValorTotal.Text = (Valor + PrecoKMFinal).ToString();

                        lblKMD.Text = PrecoKMFinal.ToString();
                    }
                }

            }

            else if (cmbCategoria.Text == "Sedan - R$60,00/dia")
            {

                Preco = 60.00m * totalDias;

                if (cmbKM.Text != null)
                {
                    if (cmbKM.Text == "3000")
                    {
                        PrecoKM = 0.45m;
                        PrecoKMFinal = 900;

                        lblKM.Text = PrecoKM.ToString();

                        lblValorTotal.Text = (Valor + PrecoKMFinal).ToString();

                        lblKMD.Text = PrecoKMFinal.ToString();
                    }
                }

            }

            else if (cmbCategoria.Text == "SUV - R$100,00/dia")
            {

                Preco = 100.00m * totalDias;

                if (cmbKM.Text != null)
                {
                    if (cmbKM.Text == "3000")
                    {
                        PrecoKM = 0.45m;
                        PrecoKMFinal = 900;

                        lblKM.Text = PrecoKM.ToString();

                        lblValorTotal.Text = (Valor + PrecoKMFinal).ToString();

                        lblKMD.Text = PrecoKMFinal.ToString();
                    }
                }

            }

            else if (cmbCategoria.Text == "Van - R$140,00/dia")
            {

                Preco = 140.00m * totalDias;

                if (cmbKM.Text != null)
                {
                    if (cmbKM.Text == "3000")
                    {
                        PrecoKM = 0.45m;
                        PrecoKMFinal = 900;

                        lblKM.Text = PrecoKM.ToString();

                        lblValorTotal.Text = (Valor + PrecoKMFinal).ToString();

                        lblKMD.Text = PrecoKMFinal.ToString();
                    }
                }

            }

            if (cbxAssento.Checked == true)
            {
                Preco += 20 * totalDias;

                if (cmbKM.Text != null)
                {
                    if (cmbKM.Text == "3000")
                    {
                        PrecoKM = 0.45m;
                        PrecoKMFinal = 900;

                        lblKM.Text = PrecoKM.ToString();

                        lblValorTotal.Text = (Valor + PrecoKMFinal).ToString();

                        lblKMD.Text = PrecoKMFinal.ToString();
                    }
                }
            }

            if (cbxBebeConforto.Checked == true)
            {
                Preco += 20 * totalDias;

                if (cmbKM.Text != null)
                {
                    if (cmbKM.Text == "3000")
                    {
                        PrecoKM = 0.45m;
                        PrecoKMFinal = 900;

                        lblKM.Text = PrecoKM.ToString();

                        lblValorTotal.Text = (Valor + PrecoKMFinal).ToString();

                        lblKMD.Text = PrecoKMFinal.ToString();
                    }
                }
            }

            if (cbxCadeiraBebe.Checked == true)
            {
                Preco += 20 * totalDias;

                if (cmbKM.Text != null)
                {
                    if (cmbKM.Text == "3000")
                    {
                        PrecoKM = 0.45m;
                        PrecoKMFinal = 900;

                        lblKM.Text = PrecoKM.ToString();

                        lblValorTotal.Text = (Valor + PrecoKMFinal).ToString();

                        lblKMD.Text = PrecoKMFinal.ToString();
                    }
                }
            }

            lblValorTotal.Text = (Preco + Valor).ToString();
            precosemkm = (Preco + Valor);
            precosemopcional = (Preco + Valor);
        }
        public decimal totalSemanas;

        private void cmbKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (decimal.Parse(lblKMD.Text) > 0)
            {
                lblValorTotal.Text = (decimal.Parse(lblValorTotal.Text) - decimal.Parse(lblKMD.Text)).ToString();
                lblKMD.Text = "0";
            }

            decimal Valor = decimal.Parse(lblValorTotal.Text);

            if (cmbKM.Text == "3000")
            {
                if (cmbCategoria.Text == "Hatch - R$40,00/dia")
                {

                    PrecoKM = 0.45m;
                    PrecoKMFinal = 900;

                    lblKM.Text = PrecoKM.ToString();

                    lblValorTotal.Text = (precosemkm + PrecoKMFinal).ToString();

                    precosemopcional = (precosemkm + PrecoKMFinal);

                }

                else if (cmbCategoria.Text == "Premium - R$150,00/dia")
                {

                    PrecoKM = 1.51m;
                    PrecoKMFinal = 4080;

                    lblKM.Text = PrecoKM.ToString();

                    lblValorTotal.Text = (precosemkm + PrecoKMFinal).ToString();

                    precosemopcional = (precosemkm + PrecoKMFinal);
                }

                else if (cmbCategoria.Text == "Sedan - R$60,00/dia")
                {

                    PrecoKM = 0.69m;
                    PrecoKMFinal = 1620;

                    lblKM.Text = PrecoKM.ToString();

                    lblValorTotal.Text = (precosemkm + PrecoKMFinal).ToString();

                    precosemopcional = (precosemkm + PrecoKMFinal);
                }

                else if (cmbCategoria.Text == "SUV - R$100,00/dia")
                {

                    PrecoKM = 0.96m;
                    PrecoKMFinal = 2430;

                    lblKM.Text = PrecoKM.ToString();

                    lblValorTotal.Text = (precosemkm + PrecoKMFinal).ToString();

                    precosemopcional = (precosemkm + PrecoKMFinal);
                }

                else if (cmbCategoria.Text == "Van - R$140,00/dia")
                {

                    PrecoKM = 1.24m;
                    PrecoKMFinal = 3270;

                    lblKM.Text = PrecoKM.ToString();

                    lblValorTotal.Text = (precosemkm + PrecoKMFinal).ToString();

                    precosemopcional = (precosemkm + PrecoKMFinal);
                }
            }

            else if (cmbKM.Text == "4000")
            {
                if (cmbCategoria.Text == "Hatch - R$40,00/dia")
                {

                    PrecoKM = 0.47m;
                    PrecoKMFinal = 1280;

                    lblKM.Text = PrecoKM.ToString();

                    lblValorTotal.Text = (precosemkm + PrecoKMFinal).ToString();

                    precosemopcional = (precosemkm + PrecoKMFinal);
                }

                else if (cmbCategoria.Text == "Premium - R$150,00/dia")
                {

                    PrecoKM = 1.53m;
                    PrecoKMFinal = 5520;

                    lblKM.Text = PrecoKM.ToString();

                    lblValorTotal.Text = (precosemkm + PrecoKMFinal).ToString();

                    precosemopcional = (precosemkm + PrecoKMFinal);
                }

                else if (cmbCategoria.Text == "Sedan - R$60,00/dia")
                {

                    PrecoKM = 0.71m;
                    PrecoKMFinal = 2240;

                    lblKM.Text = PrecoKM.ToString();

                    lblValorTotal.Text = (precosemkm + PrecoKMFinal).ToString();

                    precosemopcional = (precosemkm + PrecoKMFinal);
                }

                else if (cmbCategoria.Text == "SUV - R$100,00/dia")
                {

                    PrecoKM = 0.98m;
                    PrecoKMFinal = 3320;

                    lblKM.Text = PrecoKM.ToString();

                    lblValorTotal.Text = (precosemkm + PrecoKMFinal).ToString();

                    precosemopcional = (precosemkm + PrecoKMFinal);
                }

                else if (cmbCategoria.Text == "Van - R$140,00/dia")
                {

                    PrecoKM = 1.26m;
                    PrecoKMFinal = 4440;

                    lblKM.Text = PrecoKM.ToString();

                    lblValorTotal.Text = (precosemkm + PrecoKMFinal).ToString();

                    precosemopcional = (precosemkm + PrecoKMFinal);
                }
            }

            else if (cmbKM.Text == "5000")
            {
                if (cmbCategoria.Text == "Hatch - R$40,00/dia")
                {

                    PrecoKM = 0.49m;
                    PrecoKMFinal = 1700;

                    lblKM.Text = PrecoKM.ToString();

                    lblValorTotal.Text = (precosemkm + PrecoKMFinal).ToString();

                    precosemopcional = (precosemkm + PrecoKMFinal);
                }

                else if (cmbCategoria.Text == "Premium - R$150,00/dia")
                {

                    PrecoKM = 1.55m;
                    PrecoKMFinal = 7000;

                    lblKM.Text = PrecoKM.ToString();

                    lblValorTotal.Text = (precosemkm + PrecoKMFinal).ToString();

                    precosemopcional = (precosemkm + PrecoKMFinal);
                }

                else if (cmbCategoria.Text == "Sedan - R$60,00/dia")
                {

                    PrecoKM = 0.73m;
                    PrecoKMFinal = 2900;

                    lblKM.Text = PrecoKM.ToString();

                    lblValorTotal.Text = (precosemkm + PrecoKMFinal).ToString();

                    precosemopcional = (precosemkm + PrecoKMFinal);
                }

                else if (cmbCategoria.Text == "SUV - R$100,00/dia")
                {

                    PrecoKM = 1;
                    PrecoKMFinal = 4250;

                    lblKM.Text = PrecoKM.ToString();

                    lblValorTotal.Text = (precosemkm + PrecoKMFinal).ToString();

                    precosemopcional = (precosemkm + PrecoKMFinal);
                }

                else if (cmbCategoria.Text == "Van - R$140,00/dia")
                {

                    PrecoKM = 1.28m;
                    PrecoKMFinal = 5650;

                    lblKM.Text = PrecoKM.ToString();

                    lblValorTotal.Text = (precosemkm + PrecoKMFinal).ToString();

                    precosemopcional = (precosemkm + PrecoKMFinal);
                }
            }


        }

        private void mskDtHDevol_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           
        }

        public int IDPessoa;
        public string Categoria;
        public string Email;

        private void btnAtualizarReserva_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            if (txtNomeCliente.TextLength == 0 || mskCPF.TextLength == 0 || mskCNPJ.TextLength == 0 || mskCelular.TextLength == 0 ||
                mskDtHRetirada.TextLength == 0 || mskDtHDevol.TextLength == 0)
            {
                MessageBox.Show("Há algum campo não preenchido!");
            }

            else
            {
                cmd.CommandText = "pi_nova_reserva";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("IDPessoa", IDPessoa);
                cmd.Parameters.AddWithValue("NomeCliente", txtNomeCliente.Text);
                cmd.Parameters.AddWithValue("CPFCliente", mskCPF.Text);
                cmd.Parameters.AddWithValue("CNPJ", mskCNPJ.Text);
                cmd.Parameters.AddWithValue("RazaoSocial", txtRazaoSocial.Text);
                cmd.Parameters.AddWithValue("CNH", mskCNH.Text);
                cmd.Parameters.AddWithValue("Celular", mskCelular.Text);
                cmd.Parameters.AddWithValue("Categoria", cmbCategoria.Text);
                cmd.Parameters.AddWithValue("DtHoraRetirada", mskDtHRetirada.Text);
                cmd.Parameters.AddWithValue("DtHoraDevol", mskDtHDevol.Text);
                cmd.Parameters.AddWithValue("ValorTotal", lblValorTotal.Text);
                cmd.Parameters.AddWithValue("TotalDias", totalDias.ToString());
                cmd.Parameters.AddWithValue("Situacao", "Reserva");

                if (totalDias >= 30)
                {
                    cmd.Parameters.AddWithValue("KmDesejado", cmbKM.Text);
                    cmd.Parameters.AddWithValue("KmExtra", lblKM.Text);
                }

                if (cbxAssento.Checked == true)
                {
                    cmd.Parameters.AddWithValue("AssentoElevado", "Sim");
                    cmd.Parameters.AddWithValue("QuantidadeAssento", nupAssento.Value.ToString());
                }

                else
                {
                    cmd.Parameters.AddWithValue("AssentoElevado", "Não");
                }

                if (cbxBebeConforto.Checked == true)
                {
                    cmd.Parameters.AddWithValue("BebeConforto", "Sim");
                    cmd.Parameters.AddWithValue("QuantidadeBebe", nupBebe.Value.ToString());
                }

                else
                {
                    cmd.Parameters.AddWithValue("BebeConforto", "Não");
                }

                if (cbxCadeiraBebe.Checked == true)
                {
                    cmd.Parameters.AddWithValue("CadeiraBebe", "Sim");
                    cmd.Parameters.AddWithValue("QuantidadeCadeira", nupCadeira.Value.ToString());
                }

                else
                {
                    cmd.Parameters.AddWithValue("CadeiraBebe", "Não");
                }

                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Reserva cadastrada com sucesso!");
            }
        }

        private void AtualizarReserva_Load(object sender, EventArgs e)
        {

        }

        private void mskDtHDevol_TextChanged(object sender, EventArgs e)
        {
            if (mskDtHDevol.MaskCompleted || mskDtHDevol.Text != "")
            {
                string dataInicial = mskDtHRetirada.Text;

                string dataFinal = mskDtHDevol.Text;

                TimeSpan date = Convert.ToDateTime(dataFinal) - Convert.ToDateTime(dataInicial);

                totalDias = date.Days;

                totalSemanas = decimal.Round((totalDias / 7), 2);
            }

            if (totalDias >= 30)
            {
                cmbKM.Enabled = true;
            }

            else
            {
                cmbKM.Enabled = false;
            }
        }
    }
}