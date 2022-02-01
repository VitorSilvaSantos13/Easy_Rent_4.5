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
    public partial class TelaImpressao : Form
    {
        public TelaImpressao(string Nome, string CPF, string CNH, string RG, DateTime DtRetirada, DateTime DtDevol, string Categoria, string Veiculo,
            string Placa, string Uf, string Bairro, string Cidade, string Cep, string Logradouro, string Numero, string Marca, string Ano,
            string Dias, string Multa, string NomeFuncionario, string RGFuncionrio)
        {
            InitializeComponent();

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Easy_Rent.locacao.rdlc";

            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[21];

            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("Nome", Nome);
            p[1] = new Microsoft.Reporting.WinForms.ReportParameter("CPF", CPF);
            p[2] = new Microsoft.Reporting.WinForms.ReportParameter("CNH", CNH);
            p[3] = new Microsoft.Reporting.WinForms.ReportParameter("RG", RG);
            p[4] = new Microsoft.Reporting.WinForms.ReportParameter("DtRetirada", DtRetirada.ToString());
            p[5] = new Microsoft.Reporting.WinForms.ReportParameter("DtDevol", DtDevol.ToString());
            p[6] = new Microsoft.Reporting.WinForms.ReportParameter("Categoria", Categoria);
            p[7] = new Microsoft.Reporting.WinForms.ReportParameter("Veiculo", Veiculo);
            p[8] = new Microsoft.Reporting.WinForms.ReportParameter("Placa", Placa);
            p[9] = new Microsoft.Reporting.WinForms.ReportParameter("Uf", Uf);
            p[10] = new Microsoft.Reporting.WinForms.ReportParameter("Bairro", Bairro);
            p[11] = new Microsoft.Reporting.WinForms.ReportParameter("Cidade", Cidade);
            p[12] = new Microsoft.Reporting.WinForms.ReportParameter("Cep", Cep);
            p[13] = new Microsoft.Reporting.WinForms.ReportParameter("Logradouro", Logradouro);
            p[14] = new Microsoft.Reporting.WinForms.ReportParameter("Numero", Numero);
            p[15] = new Microsoft.Reporting.WinForms.ReportParameter("Marca", Marca);
            p[16] = new Microsoft.Reporting.WinForms.ReportParameter("Ano", Ano);
            p[17] = new Microsoft.Reporting.WinForms.ReportParameter("Dias", Dias);
            p[18] = new Microsoft.Reporting.WinForms.ReportParameter("Multa", Multa);
            p[19] = new Microsoft.Reporting.WinForms.ReportParameter("NomeFuncionario", NomeFuncionario);
            p[20] = new Microsoft.Reporting.WinForms.ReportParameter("RGFuncionario", RGFuncionrio);

            reportViewer1.LocalReport.SetParameters(p);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }

        private void TelaImpressao_Load(object sender, EventArgs e)
        {            
            this.reportViewer1.RefreshReport();
        }
    }
}
