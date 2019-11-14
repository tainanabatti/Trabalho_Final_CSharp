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
             }).ToList();

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DadosRelatorio", ret));

            this.reportViewer1.RefreshReport();

    }

        private void ReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
