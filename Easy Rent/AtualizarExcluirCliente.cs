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
    public partial class AtualizarExcluirCliente : Form
    {
        public AtualizarExcluirCliente()
        {
            InitializeComponent();
        }

        public int IDPessoa;
        public string Categoria;

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
                        mskBuscarPJ.Text = ("");
                        mskCNPJ.Text = ("");
                        txtRazaoSocial.Text = ("");

                        Categoria = dr.GetString(1).ToString();
                        IDPessoa = dr.GetInt32(0);
                        txtNome.Text = dr.GetString(2).ToString();
                        mskDNasc.Text = dr.GetDateTime(4).ToString();
                        mskCPF.Text = dr.GetString(5).ToString();
                        mskRG.Text = dr.GetString(6).ToString();
                        mskCNH.Text = dr.GetSqlString(7).ToString();
                        mskTelefone.Text = dr.GetString(18).ToString();
                        mskCelular.Text = dr.GetString(17).ToString();
                        txtEmail.Text = dr.GetSqlString(19).ToString();
                        txtEndereco.Text = dr.GetString(10).ToString();
                        txtBairro.Text = dr.GetString(14).ToString();
                        txtCidade.Text = dr.GetString(13).ToString();
                        mskCEP.Text = dr.GetString(16).ToString();
                        cmbUF.Text = dr.GetString(15).ToString();
                        txtNumero.Text = dr.GetString(11).ToString();
                        txtComplemento.Text = dr.GetString(12).ToString();                        
                        rdbFisica.Checked = true;
                        mskCNPJ.Enabled = false;
                        txtRazaoSocial.Enabled = false;
                        mskCPF.Enabled = false;
                        mskRG.Enabled = false;
                        mskCNH.Enabled = false;
                        rdbPF.Checked = true;

                        if (dr.GetString(3).ToString() == "F")
                        {
                            rdbFeminino.Checked = true;
                        }

                        else if (dr.GetString(3).ToString() == "M")
                        {
                            rdbMasculino.Checked = true;
                        }

                    }

                    else if (dr.GetString(1).ToString() == "PJ")
                    {
                        mskBuscaPF.Text = ("");
                        mskCNH.Text = ("");
                        mskCPF.Text = ("");
                        mskRG.Text = ("");
                        rdbFeminino.Checked = false;
                        rdbMasculino.Checked = false;

                        Categoria = dr.GetString(1).ToString();
                        IDPessoa = dr.GetInt32(0);
                        txtNome.Text = dr.GetString(2).ToString();
                        mskCNPJ.Text = dr.GetString(8).ToString();
                        txtRazaoSocial.Text = dr.GetString(9).ToString();
                        mskTelefone.Text = dr.GetString(18).ToString();
                        mskCelular.Text = dr.GetString(17).ToString();
                        txtEmail.Text = dr.GetSqlString(19).ToString();
                        txtEndereco.Text = dr.GetString(10).ToString();
                        txtBairro.Text = dr.GetString(14).ToString();
                        txtCidade.Text = dr.GetString(13).ToString();
                        mskCEP.Text = dr.GetString(16).ToString();
                        cmbUF.Text = dr.GetString(15).ToString();
                        txtNumero.Text = dr.GetString(11).ToString();
                        txtComplemento.Text = dr.GetString(12).ToString();                        
                        rdbJuridica.Checked = true;
                        mskCNPJ.Enabled = false;
                        mskCNH.Enabled = false;
                        mskCPF.Enabled = false;
                        mskRG.Enabled = false;
                        mskCNH.Enabled = false;
                        txtRazaoSocial.Enabled = true;
                        rdbPJ.Checked = true;
                    }

                }

                else
                {
                    MessageBox.Show("Cliente não existe!");
                }

                con.Close();

            }
        }
            

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            if (rdbFisica.Checked)
            {
                cmd.CommandText = "pu_cliente";
                cmd.Parameters.AddWithValue("Categoria", Categoria);
                cmd.Parameters.AddWithValue("IDPessoa", IDPessoa);
                cmd.Parameters.AddWithValue("Nome", txtNome.Text);
                cmd.Parameters.AddWithValue("CPF", mskCPF.Text);
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

                if (rdbFeminino.Checked)
                {
                    cmd.Parameters.AddWithValue("Sexo", "F");
                }

                else if (rdbMasculino.Checked)
                {
                    cmd.Parameters.AddWithValue("Sexo", "M");
                }
            }

            else
            {
                cmd.CommandText = "pu_cliente";
                cmd.Parameters.AddWithValue("Categoria", Categoria);
                cmd.Parameters.AddWithValue("IDPessoa", IDPessoa);
                cmd.Parameters.AddWithValue("CNPJ", mskCNPJ.Text);
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
                cmd.Parameters.AddWithValue("RazaoSocial", txtRazaoSocial.Text);
                cmd.Parameters.AddWithValue("UF", cmbUF.Text);

            }


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;



            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Usuário atualizado com sucesso!");

            mskBuscaPF.Text = ("");
            mskBuscarPJ.Text = ("");
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
            rdbFisica.Checked = false;
            rdbJuridica.Checked = false;
            rdbFeminino.Checked = false;
            rdbMasculino.Checked = false;
            mskCNPJ.Text = ("");
            txtRazaoSocial.Text = ("");
            mskCPF.Text = ("");
            mskRG.Text = ("");
            mskCNH.Text = ("");
            rdbPF.Checked = false;
            rdbPJ.Checked = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            SqlCommand cmd = new SqlCommand();

            DialogResult dialogResult = MessageBox.Show("Deseja mesmo excluir esse Cliente?", "", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                
                if (rdbFisica.Checked)
                {
                    cmd.CommandText = "pd_cliente";
                    cmd.Parameters.AddWithValue("CPF", mskCPF.Text);
                    cmd.Parameters.AddWithValue("IDPessoa", IDPessoa);
                }

                if (rdbJuridica.Checked)
                {
                    cmd.CommandText = "pd_cliente";
                    cmd.Parameters.AddWithValue("CNPJ", mskCNPJ.Text);
                    cmd.Parameters.AddWithValue("IDPessoa", IDPessoa);
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Cliente excluído com sucesso!");

                mskBuscaPF.Text = ("");
                mskBuscarPJ.Text = ("");
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
                rdbFisica.Checked = false;
                rdbJuridica.Checked = false;
                rdbFeminino.Checked = false;
                rdbMasculino.Checked = false;
                mskCNPJ.Text = ("");
                txtRazaoSocial.Text = ("");
                mskCPF.Text = ("");
                mskRG.Text = ("");
                mskCNH.Text = ("");
                rdbPF.Checked = false;
                rdbPJ.Checked = false;

            }

            else
            {

            }
        }

        private void AtualizarExcluirCliente_Load(object sender, EventArgs e)
        {
            mskBuscaPF.Visible = false;
            mskBuscarPJ.Visible = false;
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

        private void btnCEP_Click(object sender, EventArgs e)
        {
            {
                DataSet ds = new DataSet();

                string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", mskCEP.Text);

                ds.ReadXml(xml);

                txtEndereco.Text = ds.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = ds.Tables[0].Rows[0]["cidade"].ToString();
                cmbUF.Text = ds.Tables[0].Rows[0]["uf"].ToString();

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void mskCelular_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
    
}
