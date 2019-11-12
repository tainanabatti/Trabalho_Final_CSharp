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

    public enum EState
    {
        DADOS_VEICULO,
        DADOS_CONTRATO,
        RESUMO,
        DADOS_CLIENTE,
        FINALIZAR
    }

    public partial class FrmMain : Form
    {
        
        EState state;
        DBProjetoFinalEntities db = new DBProjetoFinalEntities();
        public FrmMain()
        {
            InitializeComponent();

            //if (tabControl1.SelectedTab.Name == "tabPage2")
            //{
            //    if(edtValorVeiculo.Value <= 0)
            //    {
            //        tabControl1.SelectedTab = tabPage1;
            //        MessageBox.Show("Primeiro informe os dados principais do produto !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            setState(EState.DADOS_VEICULO);
            cbMarca.DataSource = db.Marcas.ToList();
            cbMarca.DisplayMember = "Nome";
            cbMarca.ValueMember = "Id";
            var combustivelCache = new Dictionary<string, int>();
            combustivelCache.Add("Gasolina", 1);
            combustivelCache.Add("Álcool", 2);
            combustivelCache.Add("Diesel", 3);
            combustivelCache.Add("Flex", 4);
            combustivelCache.Add("GNV", 5);
            combustivelCache.Add("Elétrico", 6);
            combustivelCache.Add("Outro", 7);
            cbCombustivel.DataSource = new BindingSource(combustivelCache, null);
            cbCombustivel.DisplayMember = "Key";
            cbCombustivel.ValueMember = "Value";

            //var categoriaCache = new Dictionary<string, string>();
            //categoriaCache.Add("Categoria A", "A");
            //categoriaCache.Add("Categoria B", "B");
            //categoriaCache.Add("Categoria C", "C");
            //categoriaCache.Add("Categoria D", "D");
            //categoriaCache.Add("Categoria E", "E");
            //cbbCategoria.DataSource = new BindingSource(categoriaCache, null);
            //cbbCategoria.DisplayMember = "Key";
            //cbbCategoria.ValueMember = "Value";
        }

        private void CbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void CbbCombustivel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnProximo_Click(object sender, EventArgs e)
        {

        }

        private void setState(EState state)
        {
            this.state = state;
            tabControl1.SelectedIndex = (int)state;
            btnAnterior.Enabled = this.state != EState.DADOS_VEICULO;
            btnProximo.Visible = this.state != EState.FINALIZAR;
            btnAnterior.Visible = this.state != EState.FINALIZAR;
            if (this.state == EState.RESUMO)
            {
                //calculaValoresApolice();
                btnProximo.Text = "Contratar";
            }
            else if (this.state == EState.DADOS_CLIENTE)
            {
                btnProximo.Text = "Confirmar Contratação";
                btnAnterior.Visible = false;
                btnSair.Text = "Cancelar";
            }
            else if (this.state == EState.FINALIZAR)
            {
                btnSair.Text = "Sair";

            }
            else
            {
                btnProximo.Text = "Próximo";
                btnSair.Text = "Sair";
            }
        }
        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            switch (this.state)
            {
                case EState.DADOS_CONTRATO:
                    setState(EState.DADOS_VEICULO);
                    break;
                case EState.RESUMO:
                    setState(EState.DADOS_CONTRATO);
                    break;
                case EState.DADOS_CLIENTE:
                    setState(EState.RESUMO);
                    break;
                case EState.FINALIZAR:
                    setState(EState.DADOS_CLIENTE);
                    break;
            }
        }
    }
}
