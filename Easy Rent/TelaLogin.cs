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
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
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
              
                if (dr.GetString(28) == "Ativo")
                {
                    Form p = new TelaInicial();

                    foreach (Control l in p.Controls)
                    {
                        if (l is Label)
                        {
                            if (l.Name == "lbPerfil")
                            {
                                l.Text = dr.GetString(22).ToString();
                            }
                        }

                    }

                    foreach (Control i in p.Controls)
                    {
                        if (i is Label)
                        {
                            if (i.Name == "lbID")
                            {
                                i.Text = dr.GetInt32(25).ToString();
                            }
                        }

                    }

                    foreach (Control n in p.Controls)
                    {
                        if (n is Label)
                        {
                            if (n.Name == "nomefu")
                            {
                                n.Text = dr.GetString(2).ToString();
                            }
                        }

                    }

                    foreach (Control r in p.Controls)
                    {
                        if (r is Label)
                        {
                            if (r.Name == "rgfu")
                            {
                                r.Text = dr.GetString(26).ToString();
                            }
                        }

                    }

                    p.Show();
                    this.Hide();
                }
                
                else if (dr.GetString(28) == "Desativado")
                {
                    MessageBox.Show("Usuário desativado!");
                }

            }
            else
            {
                MessageBox.Show("Usuário e/ou senha inválido(s).");
            }

            con.Close();

           // this.Hide();
            //Form inicio = new Form2();
            //inicio.Closed += (s, args) => this.Close();
           // inicio.Show();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ConfirmarAcesso confirmarAcesso = new ConfirmarAcesso();
            confirmarAcesso.Show();

            //CadastroFuncionario cadastroFuncionario = new CadastroFuncionario();
            //cadastroFuncionario.Show();
        }

        private void TelaLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogar_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TelaLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogar.PerformClick();
            }
        }
    }
}
