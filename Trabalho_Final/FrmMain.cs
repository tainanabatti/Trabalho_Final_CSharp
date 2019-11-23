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
using System.Net;
using System.Net.Mail;

namespace Trabalho_Final
{

    public enum EnumEstado
    {
        DADOS_VEICULO,
        //DADOS_VEIC_COMP,
        DADOS_CONTRATO,
        RESUMO,
        DADOS_CLIENTE,
        FINALIZAR
    }

    public partial class FrmMain : Form
    {

        EnumEstado estadoBotao;
        DBProjetoFinalEntities db = new DBProjetoFinalEntities();
        Apolices apolice;
        int fipe_id = 0;
        int combustivel_id;
        public int id_cliente_finaliza = 0;
        public FrmMain()
        {
            InitializeComponent();

            //if (tabControl1.SelectedTab.Name == "tabPage9")
            //{
            //    if (edtChassi.Text == "")
            //    {
            //        tabControl1.SelectedTab = tabPage2;
            //        MessageBox.Show("Primeiro informe os dados principais do produto !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            
            setEstado(EnumEstado.DADOS_VEICULO);
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
            //combustivel_id = (int)cbCombustivel.SelectedValue;

            var categoriaMot = new Dictionary<string, string>();
            categoriaMot.Add("Categoria A", "A");
            categoriaMot.Add("Categoria B", "B");
            categoriaMot.Add("Categoria C", "C");
            categoriaMot.Add("Categoria D", "D");
            categoriaMot.Add("Categoria E", "E");
            cbbCategoria.DataSource = new BindingSource(categoriaMot, null);
            cbbCategoria.DisplayMember = "Key";
            cbbCategoria.ValueMember = "Value";
        }

        private void CbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = ((ComboBox)sender);
            if (cb.SelectedIndex >= 0)
            {
                int value = ((Marcas)cb.SelectedItem).Id;
                var modelos = db.Modelos.Where(m => m.MarcaId.Equals(value)).ToList();
                cbModelo.DataSource = modelos;
                cbModelo.DisplayMember = "Nome";
                cbModelo.ValueMember = "Id";
                cbModelo.Enabled = true;
            }
        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void CbbCombustivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            combustivel_id = (int)cbCombustivel.SelectedValue;
        }

        private void BtnProximo_Click(object sender, EventArgs e)
        {
            switch (this.estadoBotao)
            {
                case EnumEstado.DADOS_VEICULO:
                    if (edtChassi.Text == "" || edtPlaca.Text == "")
                    {
                        MessageBox.Show("Preencha todos os campos obrigatórios antes de prosseguir!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        //tabControl1.Controls.Remove(tabPageDadosComp);
                        //tabControl1.Controls.Add(tabPageCobertura);
                        setEstado(EnumEstado.DADOS_CONTRATO);
                    }

                    break;
                case EnumEstado.DADOS_CONTRATO:
                    setEstado(EnumEstado.RESUMO);
                    break;
                case EnumEstado.RESUMO:
                    setEstado(EnumEstado.DADOS_CLIENTE);
                    break;
                case EnumEstado.DADOS_CLIENTE:

                    if (edtNome.Text == "" || edtCpf.Text == "" || edtEmail.Text == "")
                    {
                        MessageBox.Show("Preencha todos os campos obrigatórios antes de prosseguir!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        finalizarESalvar();
                        setEstado(EnumEstado.FINALIZAR);
                    }
                    break;
                case EnumEstado.FINALIZAR:
                    break;
            }
        }

       
        private void calculaValoresApolice()
        {
            double valorVeic = (double)edtValorVeiculo.Value;
            double valorApolice = valorVeic + (valorVeic * 0.10);
            double valorFranquia = (valorVeic * 0.06);
            double valorPremioInicial = valorApolice * 0.015;
            double valorPremio = valorPremioInicial;
            if (cboxRoubos.Checked)
            {
                valorPremio += (valorPremioInicial * 0.12);
            }
            if (cboxVidros.Checked)
            {
                valorPremio += (valorPremioInicial * 0.01);
            }
            if (cboxAcidentes.Checked)
            {
                valorPremio += (valorPremioInicial * 0.04);
            }
            if (cboxTerceiros.Checked)
            {
                valorPremio += (valorPremioInicial * 0.05);
            }
            if (cboxFranqRed.Checked)
            {
                valorPremio += (valorPremioInicial * 0.03);
                valorFranquia = valorFranquia / 2;
            }
            edtValorApolice.Value = (decimal)valorApolice;
            edtValorFranquia.Value = (decimal)valorFranquia;
            edtValorPremio.Value = (decimal)valorPremio;
        }

        private void setEstado(EnumEstado estadoBotao)
        {
            this.estadoBotao = estadoBotao;
            tabControl1.SelectedIndex = (int)estadoBotao;
            btnAnterior.Enabled = this.estadoBotao != EnumEstado.DADOS_VEICULO;
            btnProximo.Visible = this.estadoBotao != EnumEstado.FINALIZAR;
            btnAnterior.Visible = this.estadoBotao != EnumEstado.FINALIZAR;
            if (this.estadoBotao == EnumEstado.RESUMO)
            {
                tabControl1.Controls.Add(tabPageCalculo);
                tabControl1.Controls.Remove(tbPageDadosVeic);
                tabControl1.Controls.Remove(tabPageCobertura);
                tabControl1.Controls.Remove(tabPageRelatorio);
                tabControl1.Controls.Remove(tabPageCadastro);
                calculaValoresApolice();
                btnProximo.Text = "Contratar";
            }
            else if(this.estadoBotao == EnumEstado.DADOS_VEICULO)
            {
                tabControl1.Controls.Remove(tabPageCalculo);
                tabControl1.Controls.Remove(tabPageCobertura);
                tabControl1.Controls.Remove(tabPageRelatorio);
                tabControl1.Controls.Remove(tabPageCadastro);
                tabControl1.Controls.Remove(tbPageDadosVeic);
                tabControl1.Controls.Add(tbPageDadosVeic);

            }
            //else if(this.estadoBotao == EnumEstado.DADOS_VEIC_COMP)
            //{
            //    tabControl1.Controls.Add(tabPageDadosComp);
            //    tabControl1.Controls.Remove(tbPageDadosVeic);
            //    tabControl1.Controls.Remove(tabPageCalculo);
            //    tabControl1.Controls.Remove(tabPageCobertura);
            //    tabControl1.Controls.Remove(tabPageRelatorio);
            //    tabControl1.Controls.Remove(tabPageCadastro);
            //}
            else if (this.estadoBotao == EnumEstado.DADOS_CONTRATO)
            {
                tabControl1.Controls.Add(tabPageCobertura);
                tabControl1.Controls.Remove(tbPageDadosVeic);
                tabControl1.Controls.Remove(tabPageCalculo);
                tabControl1.Controls.Remove(tabPageRelatorio);
                tabControl1.Controls.Remove(tabPageCadastro);
            }
            else if (this.estadoBotao == EnumEstado.DADOS_CLIENTE)
            {
                tabControl1.Controls.Add(tabPageCadastro);
                tabControl1.Controls.Remove(tbPageDadosVeic);
                tabControl1.Controls.Remove(tabPageCalculo);
                //tabControl1.Controls.Remove(tabPageDadosComp);
                tabControl1.Controls.Remove(tabPageRelatorio);
                tabControl1.Controls.Remove(tabPageCobertura);
                btnProximo.Text = "Confirmar Contratação";
                btnAnterior.Visible = false;
                btnSair.Text = "Cancelar";
            }
            else if (this.estadoBotao == EnumEstado.FINALIZAR)
            {
                tabControl1.Controls.Add(tabPageRelatorio);
                tabControl1.Controls.Remove(tbPageDadosVeic);
                tabControl1.Controls.Remove(tabPageCalculo);
                //tabControl1.Controls.Remove(tabPageDadosComp);
                tabControl1.Controls.Remove(tabPageCadastro);
                tabControl1.Controls.Remove(tabPageCobertura);
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
            switch (this.estadoBotao)
            {
                //case EnumEstado.DADOS_VEIC_COMP:
                //    setEstado(EnumEstado.DADOS_VEICULO);
                //    break;
                case EnumEstado.DADOS_CONTRATO:
                    //tabControl1.Controls.Remove(tabPageCobertura);
                    //tabControl1.Controls.Add(tabPageDadosComp);
                    setEstado(EnumEstado.DADOS_VEICULO);
                    break;
                case EnumEstado.RESUMO:
                    setEstado(EnumEstado.DADOS_CONTRATO);
                    break;
                case EnumEstado.DADOS_CLIENTE:
                    setEstado(EnumEstado.RESUMO);
                    break;
                case EnumEstado.FINALIZAR:
                    setEstado(EnumEstado.DADOS_CLIENTE);
                    break;
            }
        }

        private void CbModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedIndex >= 0)
            {
                int value = ((Modelos)cb.SelectedItem).Id;
                var itensFipe = db.FIPE.Where(f => f.ModeloId.Equals(value)).ToList();
                cbAnoModelo.DataSource = itensFipe;
                cbAnoModelo.DisplayMember = "Ano";
                cbAnoModelo.ValueMember = "Id";
                cbAnoModelo.Enabled = true;
            }
        }

        private void CbAnoModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedIndex >= 0)
            {
                fipe_id = ((FIPE)cb.SelectedItem).Id;
                double vlr = ((FIPE)cb.SelectedItem).Valor;
                edtValorVeiculo.Value = (decimal)vlr;
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {

            for (int intIndex = Application.OpenForms.Count - 1; intIndex >= 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
        }

        private int getNewIdCliente()
        {
            List<Clientes> clientes = this.db.Clientes.ToList();
            int id_cliente = 0;
            if (clientes != null && clientes.Count > 0)
            {
                id_cliente = clientes.Last().Id;
            }
            id_cliente = id_cliente + 1;
            return id_cliente;
        }
        private void finalizarESalvar()
        {
            id_cliente_finaliza = getNewIdCliente();
            Clientes cliente = new Clientes()
            {
                Id = id_cliente_finaliza,
                Nome = edtNome.Text,
                CPF = edtCpf.Text,
                RG = edtRg.Text,
                OrgaoEmissor = edtOrgaoEmissor.Text,
                DataNascimento = edtDataNascimento.Value,
                CartMotorista = edtCnh.Text,
                EmissaoCartMot = edtEmissaoCnh.Value,
                CategoriaMot = cbbCategoria.SelectedValue.ToString(),
                Telefone = edtTelefone.Text,
                Celular = edtCelular.Text,
                Email = edtEmail.Text,
                Endereco = edtEndereco.Text,
                CEP = edtCep.Text,
                Cidade = edtCidade.Text,
                UF = edtUf.Text
            };
            this.db.Clientes.Add(cliente);
            Apolices ap = fillApoliceWithData(id_cliente_finaliza);
            this.db.Apolices.Add(ap);
            this.db.SaveChanges();
            this.apolice = ap;

            MessageBox.Show("Dados Salvos Com Sucesso", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Apolices fillApoliceWithData(int id_cliente)
        {
            Apolices apolice = new Apolices();
            apolice.ClienteId = id_cliente;
            apolice.FIPEId = fipe_id;
            apolice.AnoFabricacao = (int)edtAnoFabricacao.Value;
            apolice.Chassi = edtChassi.Text;
            apolice.Placa = edtPlaca.Text;
            if (combustivel_id != 0)
            {
                apolice.Combustivel = combustivel_id;
            }
            else
            {
                apolice.Combustivel = 1;
            }
            apolice.Roubo = cboxRoubos.Checked;
            apolice.Vidros = cboxVidros.Checked;
            apolice.Acidentes = cboxAcidentes.Checked;
            apolice.DanosTerceiros = cboxTerceiros.Checked;
            apolice.FranquiaRed = cboxFranqRed.Checked;
            apolice.ValorDoBem = (double)edtValorVeiculo.Value;
            apolice.ValorApolice = (double)edtValorApolice.Value;
            apolice.ValorPremio = (double)edtValorPremio.Value;
            apolice.ValorFranquia = (double)edtValorFranquia.Value;
            return apolice;
        }

        private string geraEmail()
        {
            Clientes c = this.db.Clientes.Where(cl => cl.Id.Equals(this.apolice.ClienteId)).ToList()[0];
            StringBuilder sb = new StringBuilder();
            sb.Append("<br>Apólice Número: </br>").Append(this.apolice.Id)
                .Append("<br>----------------------</br>")
                .Append("<br>DADOS DO CLIENTE</br>")
                .Append("<br>Nome: ").Append(c.Nome).Append("</br>")
                .Append("<br>Data de Nascimento: ").Append(c.DataNascimento).Append("</br>")
                .Append("<br>CPF: ").Append(c.CPF).Append("</br>")
                .Append("<br>Endereço:").Append(c.Endereco).Append(" - ").Append(c.CEP).Append(" - ").Append(c.Cidade)
                        .Append(" - ").Append(c.UF).Append("</br>")
                .Append("<br>Telefone: ").Append(c.Telefone).Append("</br>")
                .Append("<br> ---------------------- </br>")
                .Append("<br>DADOS DO CONTRATO</br>")
                .Append("<br>Vidros: ").Append(apolice.Vidros ? "Sim" : "Não").Append("</br>")
                .Append("<br>Roubos: ").Append(apolice.Roubo ? "Sim" : "Não").Append("</br>")
                .Append("<br>Acidentes:").Append(apolice.Acidentes ? "Sim" : "Não").Append("</br>")
                .Append("<br>Danos Terceiros:").Append(apolice.DanosTerceiros ? "Sim" : "Não").Append("</br>")
                .Append("<br>Franquia Reduzida: ").Append(apolice.FranquiaRed ? "Sim" : "Não").Append("</br>")
                .Append("<br>Valor do Bem: ").Append(apolice.ValorDoBem).Append("</br>")
                .Append("<br>Valor da Apólice: ").Append(apolice.ValorApolice).Append("</br>")
                .Append("<br>Valor do Prêmio: ").Append(apolice.ValorPremio).Append("</br>")
                .Append("<br>Valor do Franquia: ").Append(apolice.ValorFranquia).Append("</br>");
            return sb.ToString();

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FrmImprimeDoc frm = new FrmImprimeDoc(this);
            frm.ShowDialog();
            
        }

        private void enviarEmail()
        {
            try
            {
                Clientes c = this.db.Clientes.Where(cl => cl.Id.Equals(this.apolice.ClienteId)).ToList()[0];
                MailMessage objEmail = new MailMessage();
                objEmail.From = new MailAddress("testedesktoputfpr@gmail.com");
                objEmail.To.Add(c.Email);
                objEmail.Priority = MailPriority.Normal;
                objEmail.IsBodyHtml = true;
                objEmail.Subject = "Relatório da Apólice";
                objEmail.Body = geraEmail();
                objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                SmtpClient objSmtp = new SmtpClient();
                objSmtp.Host = "smtp.gmail.com";
                objSmtp.EnableSsl = true;
                objSmtp.Port = 587;
                objSmtp.Credentials = new NetworkCredential("testedesktoputfpr@gmail.com", "testedesktop123");
                objSmtp.Send(objEmail);
            }
            catch (Exception e)
            {
                
            }

        }


        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                button2.Enabled = false;
                enviarEmail();
                MessageBox.Show("E-mail enviado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                button2.Enabled = true;
            } catch (Exception exc)
            {
                MessageBox.Show("Erro ao enviar e-mail!\n" + exc.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GboxDadosContrato_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
