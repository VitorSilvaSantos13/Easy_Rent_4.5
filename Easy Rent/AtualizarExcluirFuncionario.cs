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
    public partial class AtualizarExcluirFuncionario : Form
    {
        public AtualizarExcluirFuncionario()
        {
            InitializeComponent();
        }

        public int IDPessoa;
        public string Categoria = "FU";
        public int IDFuncionario;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ps_funcionario_atualizar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("CPF", mskBusca.Text);
            con.Open();

            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {



                IDFuncionario = dr.GetInt32(25);
                IDPessoa = dr.GetInt32(0);
                txtNome.Text = dr.GetString(2).ToString();
                mskCPF.Text = dr.GetString(23).ToString();
                mskRG.Text = dr.GetString(26).ToString();
                mskTelefone.Text = dr.GetString(18).ToString();
                mskCelular.Text = dr.GetString(17).ToString();
                mskDNasc.Text = dr.GetDateTime(24).ToString();
                txtEmail.Text = dr.GetString(19).ToString();
                txtEndereco.Text = dr.GetString(10).ToString();
                txtBairro.Text = dr.GetString(14).ToString();
                txtCidade.Text = dr.GetString(13).ToString();
                mskCEP.Text = dr.GetString(16).ToString();
                cmbUF.Text = dr.GetString(15).ToString();
                txtNumero.Text = dr.GetString(11).ToString();
                txtComplemento.Text = dr.GetString(12).ToString();
                txtLogin.Text = dr.GetString(20).ToString();
                txtSenha.Text = dr.GetString(21).ToString();
                cmbCargo.Text = dr.GetString(22).ToString();



                if (dr.GetString(27).ToString() == "F")
                {
                    rdbFeminino.Checked = true;
                }

                else if (dr.GetString(27).ToString() == "M")
                {
                    rdbMasculino.Checked = true;
                }




                else
                {
                    MessageBox.Show("Funcionário não existe!");
                }

                
            }
            con.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            
                cmd.CommandText = "pu_funcionario";
                cmd.Parameters.AddWithValue("IDPessoa", IDPessoa);
                cmd.Parameters.AddWithValue("Categoria", Categoria);
                cmd.Parameters.AddWithValue("CPF", mskBusca.Text);
                cmd.Parameters.AddWithValue("Nome", txtNome.Text);
                cmd.Parameters.AddWithValue("Logradouro", txtEndereco.Text);
                cmd.Parameters.AddWithValue("CEP", mskCEP.Text);
                cmd.Parameters.AddWithValue("Bairro", txtBairro.Text);
                cmd.Parameters.AddWithValue("Cidade", txtCidade.Text);
                cmd.Parameters.AddWithValue("Telefone", mskTelefone.Text);
                cmd.Parameters.AddWithValue("Celular", mskCelular.Text);
                cmd.Parameters.AddWithValue("Numero", txtNumero.Text);
                cmd.Parameters.AddWithValue("Complemento", txtComplemento.Text);
                cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("UF", cmbUF.Text);
                cmd.Parameters.AddWithValue("Cargo", cmbCargo.Text);
                cmd.Parameters.AddWithValue("LoginPessoa", txtLogin.Text);
                cmd.Parameters.AddWithValue("SenhaPessoa", txtSenha.Text);





            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;



            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Funcionário atualizado com sucesso!");

            txtNome.Text = ("");
            mskCPF.Text = ("");
            mskRG.Text = ("");
            mskDNasc.Text = ("");
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            DialogResult dialogResult = MessageBox.Show("Deseja mesmo desativar esse Funcionário?", "", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                cmd.CommandText = "desativar_funcionario";
                cmd.Parameters.AddWithValue("IDFuncionario", IDFuncionario);
                cmd.Parameters.AddWithValue("Situacao", "Desativado");
            }



            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Funcionário desativado com sucesso!");

            txtNome.Text = ("");
            mskCPF.Text = ("");
            mskRG.Text = ("");
            mskDNasc.Text = ("");
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

        private void AtualizarExcluirFuncionario_Load(object sender, EventArgs e)
        {

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

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
