using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CORE;

namespace Trabalho_Final
{
    public partial class FrmImprimeDoc : Form
    {
        FrmMain main;
        public FrmImprimeDoc(FrmMain frm)
        {
            InitializeComponent();
            reportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
            main = frm;
        }

        private void FrmImprimeDoc_Load(object sender, EventArgs e)
        {


            DBProjetoFinalEntities db = new DBProjetoFinalEntities();

            var ret = db.Apolices.AsNoTracking()
             .Where(b => b.ClienteId.Equals(main.id_cliente_finaliza))
             .ToList()
             .Select(x => new Apolices
             {
                 ValorApolice = x.ValorApolice,
                 ValorDoBem = x.ValorDoBem,
                 ValorFranquia = x.ValorFranquia,
                 ValorPremio = x.ValorPremio,
                 Placa = x.Placa,
                 Chassi = x.Chassi,
                 Roubo = x.Roubo,

             }).ToList();



            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DadosRelatorio", ret));

            this.reportViewer1.RefreshReport();

    }
        void LocalReport_SubreportProcessing(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        {
            DBProjetoFinalEntities db = new DBProjetoFinalEntities();

            
           
             //   var ret = db.Apolices.AsNoTracking()
             //.Where(b => b.ClienteId.Equals(main.id_cliente_finaliza))
             //.ToList()
             //.Select(x => new Apolices
             //{
             //    ValorApolice = x.ValorApolice,
             //    ValorDoBem = x.ValorDoBem,
             //    ValorFranquia = x.ValorFranquia,
             //    ValorPremio = x.ValorPremio,
             //    Placa = x.Placa,
             //    Chassi = x.Chassi,

             //}).ToList();
             //   e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DadosRelatorio", ret));

            var retCliente = db.Clientes.AsNoTracking()
                .Where(b => b.Id.Equals(main.id_cliente_finaliza))
                .ToList()
                .Select(x => new Clientes
                {
                    Nome = x.Nome,
                    CPF = x.CPF,
                    Email = x.Email,
                    CartMotorista = x.CartMotorista,
                    CategoriaMot = x.CategoriaMot,
                    Celular = x.Celular,

                }).ToList();
            e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DadosCliente", retCliente));
        }


        private void ReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
