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
    public partial class ConfirmarAcesso : Form
    {
        public ConfirmarAcesso()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(txtLogin.TextLength == 0 || txtSenha.TextLength == 0)
            {
                MessageBox.Show("Você esqueceu de preencher o Login ou a Senha");
            }

            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "ps_Login_Pessoa";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("LoginPessoa", txtLogin.Text);
                cmd.Parameters.AddWithValue("SenhaPessoa", txtSenha.Text);

                con.Open();

                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    {
                        CadastroFuncionario cadastroFuncionario = new CadastroFuncionario();

                        if (dr.GetString(22).ToString() == "Administrador" || dr.GetString(22).ToString() == "ADM")
                        {
                            cadastroFuncionario.Show();
                            this.Hide();
                        }

                        else
                        {
                            MessageBox.Show("Somente Administradores!");
                        }

                    }


                    con.Close();
                }
            }

            
        }

        private void ConfirmarAcesso_Load(object sender, EventArgs e)
        {

        }

        private void ConfirmarAcesso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirmar.PerformClick();
            }
        }
    }
}
