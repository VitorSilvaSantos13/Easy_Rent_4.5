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
    public partial class Locacao : Form
    {
        public Locacao()
        {
            InitializeComponent();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            mskDtHDevol.Enabled = true;
            mskCelular.Enabled = true;
            cmbCategoria.Enabled = true;
            cbxAssento.Enabled = true;
            cbxBebeConforto.Enabled = true;
            cbxCadeiraBebe.Enabled = true;
            nupAssento.Enabled = true;
            nupBebe.Enabled = true;
            nupCadeira.Enabled = true;
        }

        public string categoria;
        public int IDCarro;
        public int IDPessoa;
        public string RG;
        public string Logradouro;
        public string Numero;
        public string Bairro;
        public string Cidade;
        public string Cep;
        public string Uf;
        public string Categoriapessoa;

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
                            txtRazao.Text = dr.GetString(3).ToString();
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
        }

        public string Marca;
        public int Ano;

        private void btnBuscarVeiculo_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ps_carro_locacao";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("Placa", mskBuscaVeiculo.Text);
            cmd.Parameters.AddWithValue("Categoria", categoria);

            con.Open();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                IDCarro = dr.GetInt32(0);
                txtVeiculo.Text = dr.GetString(2).ToString();
                mskPlaca.Text = dr.GetString(1).ToString();
                txtKmInicial.Text = dr.GetString(18).ToString();
                Ano = dr.GetInt32(3);
                Marca = dr.GetString(4);
            }

            else
            {
                MessageBox.Show("O veiculo não pertence a essa categoria / O veículo não existe");
            }
            
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            if (txtNomeCliente.TextLength == 0 || txtVeiculo.TextLength == 0 || mskDtHDevol.TextLength == 0 || mskDtHRetirada.TextLength == 0
                || mskValor.TextLength == 0 || mskPlaca.TextLength == 0)
            {
                cmd.CommandText = "dados_contrato";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("IDPessoa", IDPessoa);

                con.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Categoriapessoa = dr.GetString(1);

                    if (Categoriapessoa == "PF")
                    {
                        RG = dr.GetString(6);
                        Logradouro = dr.GetString(10);
                        Numero = dr.GetString(11);
                        Bairro = dr.GetString(14);
                        Cep = dr.GetString(16);
                        Cidade = dr.GetString(13);
                        Uf = dr.GetString(15);
                    }

                    else if (Categoriapessoa == "PJ")
                    {
                        Logradouro = dr.GetString(10);
                        Numero = dr.GetString(11);
                        Bairro = dr.GetString(14);
                        Cep = dr.GetString(16);
                        Cidade = dr.GetString(13);
                        Uf = dr.GetString(15);
                    }

                }



                con.Close();

                if (opcionais == null)
                {
                    opcionais = "Não";
                }

                string Multa = (decimal.Parse(lblValorTotal.Text) * 3).ToString();

                string dataInicial = mskDtHRetirada.Text;

                string dataFinal = mskDtHDevol.Text;

                TimeSpan date = Convert.ToDateTime(dataFinal) - Convert.ToDateTime(dataInicial);

                totalDias = date.Days;

                totalSemanas = decimal.Round((totalDias / 7), 2);

                if (Categoriapessoa == "PF")
                {
                    TelaImpressao telaImpressao = new TelaImpressao(txtNomeCliente.Text, mskCPF.Text, mskCNH.Text, RG, DateTime.Parse(mskDtHRetirada.Text),
                    DateTime.Parse(mskDtHDevol.Text), categoria, txtVeiculo.Text, mskPlaca.Text, Uf, Bairro, Cidade, Cep, Logradouro, Numero, Marca,
                    Ano.ToString(), totalDias.ToString(), Multa, nomefu.Text, rgfu.Text);

                    telaImpressao.Show();

                    cmd.Parameters.Clear();

                    cmd.CommandText = "pi_locacao";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("IDFuncionario", Int32.Parse(txtIDFuncionario.Text));
                    cmd.Parameters.AddWithValue("IDCarro", IDCarro);
                    cmd.Parameters.AddWithValue("IDReserva", Int32.Parse(txtBusca.Text));
                    cmd.Parameters.AddWithValue("ValorSinal", decimal.Parse(mskValor.Text));
                    cmd.Parameters.AddWithValue("Situacao", "Em Andamento");
                    cmd.Parameters.AddWithValue("ValorTotal", decimal.Parse(lblValorTotal.Text));
                    cmd.Parameters.AddWithValue("Placa", mskPlaca.Text);
                    cmd.Parameters.AddWithValue("StatusVeiculo", "Locação");
                    cmd.Parameters.AddWithValue("SituacaoReserva", "Locação");
                    cmd.Parameters.AddWithValue("FormaPagamento", cmbPagamento.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Locação cadastrada com sucesso!");

                    txtBusca.Text = "";
                    txtKmInicial.Text = "";
                    txtNomeCliente.Text = "";
                    txtRazao.Text = "";
                    txtVeiculo.Text = "";
                    mskBuscaVeiculo.Text = "";
                    mskCelular.Text = "";
                    mskCNH.Text = "";
                    mskCNPJ.Text = "";
                    mskCPF.Text = "";
                    mskDtHDevol.Text = "";
                    mskDtHRetirada.Text = "";
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
                    lblValorTotal.Text = "0";
                    cmbPagamento.Text = "";
                }

                else if (Categoriapessoa == "PJ")
                {
                    TelaImpressaoPJ telaImpressaoPJ = new TelaImpressaoPJ(txtRazao.Text, Cidade, Logradouro, Numero, Bairro, Cep, Uf, mskCNPJ.Text,
                        txtNomeCliente.Text, Marca, txtVeiculo.Text, Ano.ToString(), mskPlaca.Text, categoria, totalDias.ToString(), DateTime.Parse(mskDtHRetirada.Text),
                    DateTime.Parse(mskDtHDevol.Text), Multa, nomefu.Text, rgfu.Text);

                    telaImpressaoPJ.Show();

                    cmd.Parameters.Clear();

                    cmd.CommandText = "pi_locacao";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("IDFuncionario", Int32.Parse(txtIDFuncionario.Text));
                    cmd.Parameters.AddWithValue("IDCarro", IDCarro);
                    cmd.Parameters.AddWithValue("IDReserva", Int32.Parse(txtBusca.Text));
                    cmd.Parameters.AddWithValue("ValorSinal", decimal.Parse(mskValor.Text));
                    cmd.Parameters.AddWithValue("Situacao", "Em Andamento");
                    cmd.Parameters.AddWithValue("ValorTotal", decimal.Parse(lblValorTotal.Text));
                    cmd.Parameters.AddWithValue("Placa", mskPlaca.Text);
                    cmd.Parameters.AddWithValue("StatusVeiculo", "Locação");
                    cmd.Parameters.AddWithValue("SituacaoReserva", "Locação");
                    cmd.Parameters.AddWithValue("FormaPagamento", cmbPagamento.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Locação cadastrada com sucesso!");

                    txtBusca.Text = "";
                    txtKmInicial.Text = "";
                    txtNomeCliente.Text = "";
                    txtRazao.Text = "";
                    txtVeiculo.Text = "";
                    mskBuscaVeiculo.Text = "";
                    mskCelular.Text = "";
                    mskCNH.Text = "";
                    mskCNPJ.Text = "";
                    mskCPF.Text = "";
                    mskDtHDevol.Text = "";
                    mskDtHRetirada.Text = "";
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
                    lblValorTotal.Text = "0";
                    cmbPagamento.Text = "";
                }


            }
            
        }

        public decimal Preco;
        public int totalDias;
        public decimal totalSemanas;
        public decimal PrecoKMFinal;
        public decimal PrecoKM;
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

        private void mskDataDevolução_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (mskDtHDevol.MaskCompleted)
            {
                string dataInicial = mskDtHRetirada.Text;

                string dataFinal = mskDtHDevol.Text;

                TimeSpan date = Convert.ToDateTime(dataFinal) - Convert.ToDateTime(dataInicial);

                totalDias = date.Days;

                totalSemanas = decimal.Round((totalDias / 7), 2);
            }
        }

        public string opcionais;

        private void cbxBebeConforto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxBebeConforto.Checked == true)
            {
                opcionais += " Bebe Conforto";

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
                opcionais += " Cadeira de bebe";

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
                opcionais += " Assento Elevado";

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

        private void lblValorTotal_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            
        }
    }
}
