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
    public partial class CadastroFuncionario : Form
    {
        public CadastroFuncionario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            if (txtNome.TextLength == 0 || mskDNasc.TextLength == 0 || mskRG.TextLength == 0 || mskCPF.TextLength == 0
                    || txtLogin.TextLength == 0 || txtEndereco.TextLength == 0 || txtBairro.TextLength == 0
                    || txtCidade.TextLength == 0 || cmbUF.SelectedIndex == 0 || mskCEP.TextLength == 0 || txtEmail.TextLength == 0
                    || txtSenha.TextLength == 0 || cmbCargo.Text.Length == 0 || txtNumero.TextLength == 0)
            {
                MessageBox.Show("Há algum campo não preenchido!");
            }

             if (rdbMasculino.Checked == false & rdbFeminino.Checked == false)
            {
                MessageBox.Show("Escolha um sexo!");
            }

            else
            {
                cmd.CommandText = "pi_Funcionario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("Nome", txtNome.Text);      
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
                cmd.Parameters.AddWithValue("dataNascimento", mskDNasc.Text);
                cmd.Parameters.AddWithValue("RG", mskRG.Text);
                cmd.Parameters.AddWithValue("CPF", mskCPF.Text);
                cmd.Parameters.AddWithValue("Cargo", cmbCargo.Text);
                cmd.Parameters.AddWithValue("LoginPessoa", txtLogin.Text);
                cmd.Parameters.AddWithValue("SenhaPessoa", txtSenha.Text);
                cmd.Parameters.AddWithValue("Categoria", "FU");
                cmd.Parameters.AddWithValue("Situacao", "Ativo");

                if (rdbFeminino.Checked)
                {
                    cmd.Parameters.AddWithValue("Sexo", "F");
                }

                else if (rdbMasculino.Checked)
                {
                    cmd.Parameters.AddWithValue("Sexo", "M");
                }

                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Funcionário cadastrado com sucesso!");

                txtNome.Text = ("");
                mskDNasc.Text = ("");
                mskCPF.Text = ("");
                mskRG.Text = ("");
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
                txtLogin.Text = ("");
                txtSenha.Text = ("");
                cmbCargo.Text = ("");
                rdbMasculino.Checked = false;
                rdbFeminino.Checked = false;
            }
        }

        private void btnCEP_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", mskCEP.Text);

            ds.ReadXml(xml);

            txtEndereco.Text = ds.Tables[0].Rows[0]["logradouro"].ToString();
            txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
            txtCidade.Text = ds.Tables[0].Rows[0]["cidade"].ToString();
            cmbUF.Text = ds.Tables[0].Rows[0]["uf"].ToString();
        }

        private void CadastroFuncionario_Load(object sender, EventArgs e)
        {

        }
    }
}
