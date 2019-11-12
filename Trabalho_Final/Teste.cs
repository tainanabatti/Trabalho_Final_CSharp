using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_Final
{
    public partial class Teste : Form
    {
        public Teste()
        {
            InitializeComponent();

            if(tabControl1.SelectedTab.Name == "tabPage2" )
            {
                if(edtValorVeiculo.Value == 0)
                {
                    tabControl1.SelectedTab = tabPage1;

                    MessageBox.Show("Primeiro informe os dados principais do produto !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void CbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
