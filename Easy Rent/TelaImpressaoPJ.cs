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
    public partial class TelaImpressaoPJ : Form
    {
        public TelaImpressaoPJ(string RazaoSocial, string Cidade, string Logradouro, string Numero, string Bairro, string CEP, string UF, string CNPJ,
            string Nome, string Marca, string Veiculo, string Ano, string Placa, string Categoria, string Dias, DateTime DtRetirada, DateTime DtDevol, string Multa,
            string NomeFuncionario, string RGFuncionario)
        {
            InitializeComponent();

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Easy_Rent.locacaoPJ.rdlc";

            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[24];

            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("RazaoSocial", RazaoSocial);
            p[1] = new Microsoft.Reporting.WinForms.ReportParameter("Cidade", Cidade);
            p[2] = new Microsoft.Reporting.WinForms.ReportParameter("Loradouro", Logradouro);
            p[3] = new Microsoft.Reporting.WinForms.ReportParameter("Numero", Numero);
            p[4] = new Microsoft.Reporting.WinForms.ReportParameter("Bairro", Bairro);
            p[5] = new Microsoft.Reporting.WinForms.ReportParameter("CEP", CEP);
            p[6] = new Microsoft.Reporting.WinForms.ReportParameter("UF", UF);
            p[7] = new Microsoft.Reporting.WinForms.ReportParameter("CNPJ", CNPJ);
            p[8] = new Microsoft.Reporting.WinForms.ReportParameter("Nome", Nome);
            p[9] = new Microsoft.Reporting.WinForms.ReportParameter("Marca", Marca);
            p[10] = new Microsoft.Reporting.WinForms.ReportParameter("Ano", Ano);
            p[11] = new Microsoft.Reporting.WinForms.ReportParameter("Placa", Placa);
            p[12] = new Microsoft.Reporting.WinForms.ReportParameter("Numero", Numero);
            p[13] = new Microsoft.Reporting.WinForms.ReportParameter("Marca", Marca);
            p[14] = new Microsoft.Reporting.WinForms.ReportParameter("Veiculo", Veiculo);
            p[15] = new Microsoft.Reporting.WinForms.ReportParameter("Ano", Ano);
            p[16] = new Microsoft.Reporting.WinForms.ReportParameter("Placa", Placa);
            p[17] = new Microsoft.Reporting.WinForms.ReportParameter("Categoria", Categoria);
            p[18] = new Microsoft.Reporting.WinForms.ReportParameter("Dias", Dias);
            p[19] = new Microsoft.Reporting.WinForms.ReportParameter("DtRetirada", DtRetirada.ToString());
            p[20] = new Microsoft.Reporting.WinForms.ReportParameter("DtDevol", DtDevol.ToString());
            p[21] = new Microsoft.Reporting.WinForms.ReportParameter("Multa", Multa);
            p[22] = new Microsoft.Reporting.WinForms.ReportParameter("NomeFuncionario", NomeFuncionario);
            p[23] = new Microsoft.Reporting.WinForms.ReportParameter("RGFuncionario", RGFuncionario);

            reportViewer1.LocalReport.SetParameters(p);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }

        private void TelaImpressaoPJ_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
