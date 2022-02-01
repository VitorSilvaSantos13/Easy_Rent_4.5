using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Easy_Rent
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        public string nome;
        public string rg;

        private void Form2_Load(object sender, EventArgs e)
        {


            if (lbPerfil.Text == "Administrador" || lbPerfil.Text == "ADM")
            {
                TSMadministrador.Visible = true;
            }

            else
            {
                TSMadministrador.Visible = false;
            }            

        }

        private void cadastrarUsuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CadastroCliente Cliente = new CadastroCliente();
            Cliente.Show();
        }

        private void cadastrarCarrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroCarro Carro = new CadastroCarro();
            Carro.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void atualizarExcluirClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtualizarExcluirCliente Atualizar = new AtualizarExcluirCliente();
            Atualizar.Show();
        }

        private void visualizarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisualizarCliente visualizarCliente = new VisualizarCliente();
            visualizarCliente.Show();
        }

        private void excluirUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtualizarExcluirFuncionario atualizarExcluirFuncionario = new AtualizarExcluirFuncionario();
            atualizarExcluirFuncionario.Show();
        }

        private void novaLocaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void excluirCarroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtualizarExcluirCarro atualizarExcluirCarro = new AtualizarExcluirCarro();
            atualizarExcluirCarro.Show();
        }

        private void cadastrarUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroFuncionario cadastroFuncionario = new CadastroFuncionario();
            cadastroFuncionario.Show();
        }

        private void novaLocaçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Locacao locacao = new Locacao();

            foreach (Control i in locacao.Controls)
            {
                if (i is TextBox)
                {
                    if (i.Name == "txtIDFuncionario")
                    {
                        i.Text = lbID.Text;
                    }
                }

            }

            foreach (Control n in locacao.Controls)
            {
                if (n is Label)
                {
                    if (n.Name == "nomefu")
                    {
                        n.Text = nomefu.Text;
                    }
                }

            }

            foreach (Control r in locacao.Controls)
            {
                if (r is Label)
                {
                    if (r.Name == "rgfu")
                    {
                        r.Text = rgfu.Text;
                    }
                }

            }

            locacao.Show();
        }

        private void novaReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NovaReserva novaReserva = new NovaReserva();
            novaReserva.Show();
        }

        private void visualizarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VicualizarReserva vicualizarReserva = new VicualizarReserva();
            vicualizarReserva.Show();
        }

        private void visualizarCarrosDisponiveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisualizarCarroDisponivel visualizarCarro = new VisualizarCarroDisponivel();
            visualizarCarro.Show();
        }

        private void visualizarLocaçãoEmAndamenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisualizarLocacaoEmAndamento visualizarLocacaoEmAndamento = new VisualizarLocacaoEmAndamento();
            visualizarLocacaoEmAndamento.Show();
        }

        private void finalizarLocaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinalizarLocacao finalizarLocacao = new FinalizarLocacao();
            finalizarLocacao.Show();
        }

        private void visualizarCarrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisualizarTodosCarros visualizarTodosCarros = new VisualizarTodosCarros();
            visualizarTodosCarros.Show();
        }

        private void visualizarLocaçõesFinalizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisualizarLocacaoFinalizada visualizarLocacaoFinalizada = new VisualizarLocacaoFinalizada();
            visualizarLocacaoFinalizada.Show();
        }

        private void informaçõesDoSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sobre sobre = new Sobre();
            sobre.Show();
        }

        private void cadastroClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroCliente Cliente = new CadastroCliente();
            Cliente.Show();
        }

        private void atualizarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtualizarExcluirCliente Atualizar = new AtualizarExcluirCliente();
            Atualizar.Show();
        }

        private void visualizarClienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VisualizarCliente visualizarCliente = new VisualizarCliente();
            visualizarCliente.Show();
        }

        private void atualzarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtualizarReserva atualizarReserva = new AtualizarReserva();
            atualizarReserva.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que você quer sair?", "", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Form l = new TelaLogin();
                l.Show();
                this.Hide();
            }

            else
            {

            }
        }

        private void visualizarFuncinárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisualizarFuncionario visualizarFuncionario = new VisualizarFuncionario();
            visualizarFuncionario.Show();
        }
    }
}
