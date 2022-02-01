using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net.Mail;
using System.Drawing.Printing;
using System.Drawing;

namespace Easy_Rent
{
    public partial class NovaReserva : Form
    {
        private Button printButton = new Button();
        private PrintDocument printDocument2 = new PrintDocument();

        public NovaReserva()
        {
            InitializeComponent();

            printButton.Text = "Print Form";
            printButton.Click += new EventHandler(btnImprimir_Click);
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            this.Controls.Add(printButton);
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

        private void mskDtHDevol_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {


        }

        private void NovaReserva_Load(object sender, EventArgs e)
        {
            mskDtHDevol.Enabled = false;
            cmbKM.Enabled = false;
            mskBuscaPF.Visible = false;
            mskBuscarPJ.Visible = false;

        }


        private void mskDthRetirada_TextChanged(object sender, EventArgs e)
        {
            if (mskDtHRetirada.TextLength > 0)
            {
                mskDtHDevol.Enabled = true;
            }

            else
            {
                mskDtHDevol.Enabled = false;
            }


        }

        public decimal totalSemanas;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (decimal.Parse(lblKMD.Text) > 0)
            {
                lblValorTotal.Text = (decimal.Parse(lblValorTotal.Text) - decimal.Parse(lblKMD.Text)).ToString();
                lblKMD.Text = "0";
            }

            decimal Valor = decimal.Parse(lblValorTotal.Text);



            //if (lblValor.Text != "0,00")
            //{
            //    lblValorTotal.Text = "0,00";

            //    if (cbxAssento.Checked == true)
            //    {
            //        Preco += 20 * totalDias;
            //    }

            //    if (cbxBebeConforto.Checked == true)
            //    {
            //        Preco += 20 * totalDias;
            //    }

            //    if (cbxCadeiraBebe.Checked == true)
            //    {
            //        Preco += 20 * totalDias;
            //    }

            //    if (cmbCategoria.Text == "Hatch - R$40,00/dia")
            //    {

            //        Preco = 40.00 * totalDias;

            //    }

            //    else if (cmbCategoria.Text == "Premium - R$150,00/dia")
            //    {

            //        Preco = 150.00 * totalDias;

            //    }

            //    else if (cmbCategoria.Text == "Sedan - R$60,00/dia")
            //    {

            //        Preco = 60.00 * totalDias;

            //    }

            //    else if (cmbCategoria.Text == "SUV - R$100,00/dia")
            //    {

            //        Preco = 100.00 * totalDias;

            //    }

            //    else if (cmbCategoria.Text == "Van - R$140,00/dia")
            //    {

            //        Preco = 140.00 * totalDias;

            //    }

            //}

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

        private void mskDtHDevol_TextChanged(object sender, EventArgs e)
        {
            if (mskDtHDevol.MaskCompleted)
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

        private void rdbPF_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPF.Checked == true)
            {
                mskBuscaPF.Visible = true;
            }

            else
            {
                mskBuscaPF.Visible = false;
            }
        }

        private void rdbPJ_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPJ.Checked == true)
            {
                mskBuscarPJ.Visible = true;
            }

            else
            {
                mskBuscarPJ.Visible = false;
            }
        }

        public int IDPessoa;
        public string Categoria;
        public string Email;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            if (rdbPF.Checked == false & rdbPJ.Checked == false)
            {
                MessageBox.Show("Escolha uma categoria");
            }

            else
            {
                if (rdbPF.Checked == true)
                {
                    cmd.CommandText = "ps_cliente_pf_pj";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("CPF", mskBuscaPF.Text);

                }

                else if (rdbPJ.Checked == true)
                {
                    cmd.CommandText = "ps_cliente_pf_pj";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("CNPJ", mskBuscarPJ.Text);

                }

                con.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (dr.GetString(1).ToString() == "PF")
                    {
                        IDPessoa = dr.GetInt32(0);
                        txtNomeCliente.Text = dr.GetString(2).ToString();
                        mskCPF.Text = dr.GetString(5).ToString();
                        mskCNH.Text = dr.GetString(7).ToString();
                        mskCelular.Text = dr.GetString(17).ToString();
                        Email = dr.GetString(19);

                        mskCNPJ.Enabled = false;
                        txtRazaoSocial.Enabled = false;
                    }

                    else if (dr.GetString(1).ToString() == "PJ")
                    {
                        IDPessoa = dr.GetInt32(0);
                        txtNomeCliente.Text = dr.GetString(2).ToString();
                        mskCNPJ.Text = dr.GetString(8).ToString();
                        mskCelular.Text = dr.GetString(17).ToString();
                        txtRazaoSocial.Text = dr.GetSqlString(9).ToString();
                        Email = dr.GetString(19);

                        mskCPF.Enabled = false;
                        mskCNH.Enabled = false;
                    }

                    else
                    {
                        MessageBox.Show("Cliente não existe!");
                    }

                    con.Close();                    
                }
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
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
                if(rdbPF.Checked == true)
                {
                    cmd.CommandText = "pi_nova_reserva";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("IDPessoa", IDPessoa);
                    cmd.Parameters.AddWithValue("NomeCliente", txtNomeCliente.Text);
                    cmd.Parameters.AddWithValue("CPFCliente", mskCPF.Text);
                    cmd.Parameters.AddWithValue("CNH", mskCNH.Text);
                    cmd.Parameters.AddWithValue("Celular", mskCelular.Text);
                    cmd.Parameters.AddWithValue("Categoria", cmbCategoria.Text);
                    cmd.Parameters.AddWithValue("DtHoraRetirada", mskDtHRetirada.Text);
                    cmd.Parameters.AddWithValue("DtHoraDevol", mskDtHDevol.Text);
                    cmd.Parameters.AddWithValue("ValorTotal", lblValorTotal.Text);
                    cmd.Parameters.AddWithValue("TotalDias", totalDias.ToString());
                    cmd.Parameters.AddWithValue("Situacao", "Reserva");

                    if(totalDias >= 30)
                    {
                        cmd.Parameters.AddWithValue("KmDesejado", cmbKM.Text);
                        cmd.Parameters.AddWithValue("KmExtra", lblKM.Text);
                    }

                    if(cbxAssento.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("AssentoElevado", "Sim");
                        cmd.Parameters.AddWithValue("QuantidadeAssento", nupAssento.Value.ToString());
                    }

                    else
                    {
                        cmd.Parameters.AddWithValue("AssentoElevado", "Não");
                    }

                    if(cbxBebeConforto.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("BebeConforto", "Sim");
                        cmd.Parameters.AddWithValue("QuantidadeBebe", nupBebe.Value.ToString());
                    }

                    else
                    {
                        cmd.Parameters.AddWithValue("BebeConforto", "Não");
                    }

                    if(cbxCadeiraBebe.Checked == true)
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

                    MailMessage mail = new MailMessage();
                    MailAddress recepetor = new MailAddress("computerdigitalvision@gmail.com");
                    mail.To.Add(Email);
                    mail.From = recepetor;
                    mail.Subject = "Nova Reserva!";
                    mail.Body = "<h2>" + "Olá " + txtNomeCliente.Text + "</h2>" + "<br/>" + "<br/>" + "<h4>" + "Você acabou de fazer uma reserva de " +
                        "locação e preparamos um resumo " + "para você:" + "</h4>" + "<br/>" + "<br/>" + "Data e hora da retirada:" + "<br/>" + 
                        mskDtHRetirada.Text + "<br/>" + "<br/>" + "Data e hora da devolução:" + "<br/>" + mskDtHDevol.Text + "<br/>" + "<br/>" + 
                        "Categoria escolhida:" + "<br/>" + cmbCategoria.Text + "<br/>" + "<br/>" + "Valor total:" + "<br/>" + "R$" + lblValorTotal.Text +
                        "<br/>" + "<br/>" + "<br/>" + "<i>" + "Para mais informaçoes acesse o nosso site e entre na área do cliente para visualizar a sua" +
                        " reserva, ou, " + "ligue no nosso" + " canal de atendimnto" + "</i>";
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;
                    SmtpClient client = new SmtpClient();
                    client.Credentials = new System.Net.NetworkCredential("computerdigitalvision@gmail.com", "vcv010729");
                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Send(mail);

                    MessageBox.Show("Reserva cadastrada com sucesso!");
                                        
                    txtNomeCliente.Text = "";
                    txtRazaoSocial.Text = "";
                    mskBuscaPF.Text = "";
                    mskBuscarPJ.Text = "";
                    mskCelular.Text = "";
                    mskCNH.Text = "";
                    mskCNPJ.Text = "";
                    mskCPF.Text = "";
                    mskDtHDevol.Text = "";
                    mskDtHRetirada.Text = "";
                    cmbCategoria.Text = "";
                    cmbKM.Text = "";
                    cbxAssento.Checked = false;
                    cbxBebeConforto.Checked = false;
                    cbxCadeiraBebe.Checked = false;
                    nupAssento.Value = 0;
                    nupBebe.Value = 0;
                    nupCadeira.Value = 0;
                    mskDtHDevol.Enabled = false;
                    cmbKM.Enabled = false;
                    mskBuscaPF.Visible = false;
                    mskBuscarPJ.Visible = false;
                    rdbPF.Checked = false;
                    rdbPJ.Checked = false;
                }

                if(rdbPJ.Checked == true)
                {
                    cmd.CommandText = "pi_nova_reserva";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("IDPessoa", IDPessoa);
                    cmd.Parameters.AddWithValue("NomeCliente", txtNomeCliente.Text);
                    cmd.Parameters.AddWithValue("CNPJ", mskCNPJ.Text);
                    cmd.Parameters.AddWithValue("RazaoSocial", txtRazaoSocial.Text);
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

                    MailMessage mail = new MailMessage();
                    MailAddress recepetor = new MailAddress("computerdigitalvision@gmail.com");
                    mail.To.Add(Email);
                    mail.From = recepetor;
                    mail.Subject = "Nova Reserva!";
                    mail.Body = "Olá " + txtNomeCliente.Text + "<br/>" + "<br/>" + "Você acabou de fazer uma reserva de locação e preparamos um resumo " +
                        "para você:" + "<br/>" + "<br/>" + "Data e hora da retirada:" + "<br/>" + mskDtHRetirada.Text + "<br/>" + "<br/>" +
                        "Data e hora da devolução:" + "<br/>" + mskDtHDevol.Text + "<br/>" + "<br/>" + "Categoria escolhida:" + "<br/>" +
                        cmbCategoria.Text + "<br/>" + "<br/>" + "Valor total:" + "<br/>" + "R$" + lblValorTotal.Text + "<br/>" + "<br/>" + "<br/>" +
                        "Para mais informaçoes acesse o nosso site e entre na área do cliente para visualizar a sua reserva, ou, ligue no nosso" +
                        " canal de atendimnto";
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;
                    SmtpClient client = new SmtpClient();
                    client.Credentials = new System.Net.NetworkCredential("computerdigitalvision@gmail.com", "vcv010729");
                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Send(mail);

                    MessageBox.Show("Reserva cadastrada com sucesso!");
                    
                    txtNomeCliente.Text = "";
                    txtRazaoSocial.Text = "";
                    mskBuscaPF.Text = "";
                    mskBuscarPJ.Text = "";
                    mskCelular.Text = "";
                    mskCNH.Text = "";
                    mskCNPJ.Text = "";
                    mskCPF.Text = "";
                    mskDtHDevol.Text = "";
                    mskDtHRetirada.Text = "";
                    cmbCategoria.Text = "";
                    cmbKM.Text = "";
                    cbxAssento.Checked = false;
                    cbxBebeConforto.Checked = false;
                    cbxCadeiraBebe.Checked = false;
                    nupAssento.Value = 0;
                    nupBebe.Value = 0;
                    nupCadeira.Value = 0;
                    mskDtHDevol.Enabled = false;
                    cmbKM.Enabled = false;
                    mskBuscaPF.Visible = false;
                    mskBuscarPJ.Visible = false;
                    rdbPF.Checked = false;
                    rdbPJ.Checked = false;
                }

            }
        }

        decimal PrecoComOpicional;

        private void nupBebe_ValueChanged(object sender, EventArgs e)
        {
            PrecoComOpicional = decimal.Parse(lblValorTotal.Text);

            decimal quantidade = nupBebe.Value;

            decimal valor = decimal.Parse(lblValorTotal.Text);

            decimal PrecoOpcional = (20 * quantidade) * totalDias;

            if(cbxAssento.Checked == true || cbxCadeiraBebe.Checked == true)
            {
                if(nupBebe.Value < decimal.Parse(nupBebe.Text))
                {
                    lblValorTotal.Text = (PrecoComOpicional - PrecoOpcional).ToString();
                }

                else
                {
                    lblValorTotal.Text = (PrecoComOpicional + PrecoOpcional).ToString();
                }
                
            }

            else
            {
                lblValorTotal.Text = (precosemopcional + PrecoOpcional).ToString();
            }                       
        }

        private void nupCadeira_ValueChanged(object sender, EventArgs e)
        {
            PrecoComOpicional = decimal.Parse(lblValorTotal.Text);

            decimal quantidade = nupBebe.Value;

            decimal PrecoOpcional = (20 * quantidade) * totalDias;
            if (cbxAssento.Checked == true || cbxCadeiraBebe.Checked == true)
            {
                lblValorTotal.Text = (PrecoComOpicional + PrecoOpcional).ToString();
            }

            else
            {
                lblValorTotal.Text = (precosemopcional + PrecoOpcional).ToString();
            }
        }

        private void nupAssento_ValueChanged(object sender, EventArgs e)
        {
            PrecoComOpicional = decimal.Parse(lblValorTotal.Text);

            decimal quantidade = nupBebe.Value;

            decimal PrecoOpcional = (20 * quantidade) * totalDias;
            if (cbxAssento.Checked == true || cbxCadeiraBebe.Checked == true)
            {
                lblValorTotal.Text = (PrecoComOpicional + PrecoOpcional).ToString();
            }

            else
            {
                lblValorTotal.Text = (precosemopcional + PrecoOpcional).ToString();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.Print();
        }

        Bitmap bmp;

        private void CaptureScreen()
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void mskDtHRetirada_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
