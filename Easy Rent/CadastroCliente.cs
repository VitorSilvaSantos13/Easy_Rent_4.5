using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Correios.Net;
using System.Net.Mail;

namespace Easy_Rent
{
    public partial class CadastroCliente : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5OD8FA7\SQLEXPRESS;Initial Catalog=EasyRent;Integrated Security=True");
        SqlCommand comm = new SqlCommand();
        

        public CadastroCliente()
        {
            InitializeComponent();
        }

        private void LocalizarCEP()
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void lblCEP_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            mskRG.Enabled = false;
            mskCPF.Enabled = false;
            mskCNH.Enabled = false;
            mskCNPJ.Enabled = false;
            mskCEP.Enabled = false;
            txtEndereco.Enabled = false;
            txtNumero.Enabled = false;
            txtComplemento.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            cmbUF.Enabled = false;
            txtRazaoSocial.Enabled = false;
            txtEmail.Enabled = false;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rdbFisica_CheckedChanged(object sender, EventArgs e)
        {
            mskRG.Enabled = true;
            mskCPF.Enabled = true;
            mskCNH.Enabled = true;
            mskCNPJ.Enabled = false;
            mskCEP.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtComplemento.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            cmbUF.Enabled = true;
            txtRazaoSocial.Enabled = false;
            txtEmail.Enabled = true;
        }

        private void rdbJuridica_CheckedChanged(object sender, EventArgs e)
        {
            mskRG.Enabled = false;
            mskCPF.Enabled = false;
            mskCNH.Enabled = false;
            mskCNPJ.Enabled = true;
            mskCEP.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtComplemento.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            cmbUF.Enabled = true;
            txtRazaoSocial.Enabled = true;
            txtEmail.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
           // try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
                SqlCommand cmd = new SqlCommand();

                if (txtNome.TextLength == 0 || mskDNasc.TextLength == 0)
                {
                    MessageBox.Show("Há algum campo não preenchido!");
                }


                else
                {
                    if (txtNome.TextLength == 0 || mskDNasc.TextLength == 0 || mskRG.TextLength == 0 || mskCPF.TextLength == 0
                    || mskCNH.TextLength == 0 || txtEndereco.TextLength == 0 || txtBairro.TextLength == 0
                    || txtCidade.TextLength == 0 || cmbUF.SelectedIndex == 0 || mskCEP.TextLength == 0)
                    {
                        MessageBox.Show("Há algum campo não preenchido!");
                    }

                    else if (rdbFisica.Checked)
                    {
                        cmd.CommandText = "pi_Cliente";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("Nome", txtNome.Text);
                        cmd.Parameters.AddWithValue("dataNascimento", mskDNasc.Text);                        
                        cmd.Parameters.AddWithValue("CPF", (mskCPF.Text.Replace(",",".")));
                        cmd.Parameters.AddWithValue("RG", mskRG.Text);
                        cmd.Parameters.AddWithValue("CNH", mskCNH.Text);
                        cmd.Parameters.AddWithValue("Logradouro", txtEndereco.Text);
                        cmd.Parameters.AddWithValue("CEP", mskCEP.Text);
                        cmd.Parameters.AddWithValue("Bairro", txtBairro.Text);
                        cmd.Parameters.AddWithValue("Cidade", txtCidade.Text);
                        cmd.Parameters.AddWithValue("Telefone", mskTelefone.Text);
                        cmd.Parameters.AddWithValue("Celular", mskCelular.Text);
                        cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("UF", cmbUF.Text);
                        cmd.Parameters.AddWithValue("Numero", txtNumero.Text);
                        cmd.Parameters.AddWithValue("Complemento", txtComplemento.Text);
                        cmd.Parameters.AddWithValue("LoginPessoa", txtLogin.Text);
                        cmd.Parameters.AddWithValue("SenhaPessoa", txtSenha.Text);

                        if (rdbFeminino.Checked)
                        {
                            cmd.Parameters.AddWithValue("Sexo", "F");
                        }

                        else if (rdbMasculino.Checked)
                        {
                            cmd.Parameters.AddWithValue("Sexo", "M");
                        }

                        if (rdbFisica.Checked)
                        {
                            cmd.Parameters.AddWithValue("Categoria", "PF");
                        }

                        con.Open();

                        cmd.ExecuteNonQuery();
                        con.Close();

                        MailMessage mail = new MailMessage();
                        MailAddress recepetor = new MailAddress("computerdigitalvision@gmail.com");
                        mail.To.Add(txtEmail.Text);
                        mail.From = recepetor;
                        mail.Subject = "Seja Bem Vindo a Easy Rent!";
                        mail.Body = "Olá " + txtNome.Text + ", Bem vindo a Easy Rent!" + "<br/>" + "Comece agora mesmo a fazer locações de carros!" +
                            "<br/>" + "Você pode fazer reservas de locações, visualizar sua reservas e atualizar o seu cadastro em nosso site," +
                            " basta acessar a área do cliente com o seu login e senha!" + "<br/>" + "<br/>" + "<br/>" + "Login: " + txtLogin.Text +
                            "<br/>" + "Senha: " + txtSenha.Text + "<br/>" + "(Quando você realizar o seu primeiro acesso, terá que mudar seu login e " +
                            "sua senha.)";
                        mail.BodyEncoding = System.Text.Encoding.UTF8;
                        mail.IsBodyHtml = true;
                        mail.Priority = MailPriority.High;
                        SmtpClient client = new SmtpClient();
                        client.Credentials = new System.Net.NetworkCredential("computerdigitalvision@gmail.com", "");
                        client.Port = 587;
                        client.Host = "smtp.gmail.com";
                        client.EnableSsl = true;
                        client.Send(mail);

                        MessageBox.Show("Cliente cadastrado com sucesso!");

                        txtNome.Text = ("");
                        mskDNasc.Text = ("");
                        mskCPF.Text = ("");
                        mskRG.Text = ("");
                        mskCNH.Text = ("");
                        mskTelefone.Text = ("");
                        mskCelular.Text = ("");
                        txtEmail.Text = ("");
                        txtEndereco.Text = ("");
                        txtBairro.Text = ("");
                        txtCidade.Text = ("");
                        mskCEP.Text = ("");
                        cmbUF.Text = ("");
                        txtNumero.Text = ("");
                        txtComplemento.Text = ("");
                        mskCNPJ.Text = ("");
                        txtRazaoSocial.Text = ("");
                        txtLogin.Text = ("");
                        txtSenha.Text = ("");
                        rdbJuridica.Checked = false;
                        rdbFisica.Checked = false;
                        rdbMasculino.Checked = false;
                        rdbFeminino.Checked = false;
                    }



                    else if (rdbJuridica.Checked)
                    {
                        if (txtNome.TextLength == 0 || mskDNasc.TextLength == 0 || mskRG.TextLength == 0 || mskCPF.TextLength == 0
                        || mskCNH.TextLength == 0 || mskCNPJ.TextLength == 0 || txtRazaoSocial.TextLength == 0 || txtEndereco.TextLength == 0
                        || txtBairro.TextLength == 0 || txtCidade.TextLength == 0 || cmbUF.SelectedIndex == 0 || mskCEP.TextLength == 0)
                        {
                            MessageBox.Show("Há algum campo não preenchido!");
                        }

                        else
                        {
                            cmd.CommandText = "pi_Cliente";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;

                            cmd.Parameters.AddWithValue("Nome", txtNome.Text);
                            cmd.Parameters.AddWithValue("CNPJ", mskCNPJ.Text.Replace(",","."));
                            cmd.Parameters.AddWithValue("RazaoSocial", txtRazaoSocial.Text);
                            cmd.Parameters.AddWithValue("Logradouro", txtEndereco.Text);
                            cmd.Parameters.AddWithValue("CEP", mskCEP.Text);
                            cmd.Parameters.AddWithValue("Bairro", txtBairro.Text);
                            cmd.Parameters.AddWithValue("Cidade", txtCidade.Text);
                            cmd.Parameters.AddWithValue("Telefone", mskTelefone.Text);
                            cmd.Parameters.AddWithValue("Celular", mskCelular.Text);
                            cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("UF", cmbUF.Text);
                            cmd.Parameters.AddWithValue("Numero", txtNumero.Text);
                            cmd.Parameters.AddWithValue("Complemento", txtComplemento.Text);
                            cmd.Parameters.AddWithValue("Categoria", "PJ");
                            cmd.Parameters.AddWithValue("LoginPessoa", txtLogin.Text);
                            cmd.Parameters.AddWithValue("SenhaPessoa", txtSenha.Text);

                            con.Open();

                            cmd.ExecuteNonQuery();
                            con.Close();

                            MailMessage mail = new MailMessage();
                            MailAddress recepetor = new MailAddress("computerdigitalvision@gmail.com");
                            mail.To.Add(txtEmail.Text);
                            mail.From = recepetor;
                            mail.Subject = "Seja Bem Vindo a Easy Rent!";
                            mail.Body = "Olá " + txtNome.Text + ", Bem vindo a Easy Rent!" + "<br/>" + "Comece agora mesmo a fazer locações de carros!" +
                                "<br/>" + "Você pode fazer reservas de locações, visualizar sua reservas e atualizar o seu cadastro em nosso site," +
                                " basta acessar a área do cliente com o seu login e senha!" + "<br/>" + "<br/>" + "<br/>" + "Login: " + txtLogin.Text +
                                "<br/>" + "Senha: " + txtSenha.Text + "<br/>" + "(Quando você realizar o seu primeiro acesso, terá que mudar seu login e " +
                                "sua senha.)";
                            mail.BodyEncoding = System.Text.Encoding.UTF8;
                            mail.IsBodyHtml = true;
                            mail.Priority = MailPriority.High;
                            SmtpClient client = new SmtpClient();
                            client.Credentials = new System.Net.NetworkCredential("computerdigitalvision@gmail.com", "vcv010729");
                            client.Port = 587;
                            client.Host = "smtp.gmail.com";
                            client.EnableSsl = true;
                            client.Send(mail);

                            MessageBox.Show("Cliente cadastrado com sucesso!");

                            txtNome.Text = ("");
                            mskDNasc.Text = ("");
                            mskCPF.Text = ("");
                            mskRG.Text = ("");
                            mskCNH.Text = ("");
                            mskTelefone.Text = ("");
                            mskCelular.Text = ("");
                            txtEmail.Text = ("");
                            txtEndereco.Text = ("");
                            txtBairro.Text = ("");
                            txtCidade.Text = ("");
                            mskCEP.Text = ("");
                            cmbUF.Text = ("");
                            txtNumero.Text = ("");
                            txtComplemento.Text = ("");
                            mskCNPJ.Text = ("");
                            txtRazaoSocial.Text = ("");
                            txtLogin.Text = ("");
                            txtSenha.Text = ("");
                            rdbJuridica.Checked = false;
                            rdbFisica.Checked = false;
                            rdbMasculino.Checked = false;
                            rdbFeminino.Checked = false;
                        }

                    }
                }                
            }

            //catch (Exception ex)
            //{
            //    MessageBox.Show("Há algum campo vazio!");
            //}
                
        }

        private void mskCEP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            LocalizarCEP();
        }

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCEP_Leave(object sender, EventArgs e)
        {
           
        }

        private void txt(object sender, EventArgs e)
        {

        }

        private void btnCEP_Click(object sender, EventArgs e)
        {
            //try
            {
                DataSet ds = new DataSet();

                string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", mskCEP.Text);

ds.ReadXml(xml);

                txtEndereco.Text = ds.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = ds.Tables[0].Rows[0]["cidade"].ToString();
                cmbUF.Text = ds.Tables[0].Rows[0]["uf"].ToString();

            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Foi dedectado um erro!");
            //}
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
