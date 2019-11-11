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
    public partial class Carro : Form
    {
        DBProjetoFinalEntities db = new DBProjetoFinalEntities();
        public Carro()
        {
            InitializeComponent();
            cbMarca.DataSource = db.Marcas.ToList();
            cbMarca.DisplayMember = "Nome";
            cbMarca.ValueMember = "Id";
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

   

        private void Next_Click(object sender, EventArgs e)
        {
            DadosComp FormDados = new DadosComp();
            FormDados.ShowDialog();

            
        }

        private void Prev_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {

            for (int intIndex = Application.OpenForms.Count - 1; intIndex >= 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
        }

        private void CbModelo_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
