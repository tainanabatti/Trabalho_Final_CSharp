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
    public partial class DadosComp : Form
    {

        public enum BlahEnum
        { Active = 0, Canceled = 3}


    public DadosComp()
        {
            InitializeComponent();

            comboBox1.DataSource = Enum.GetValues(typeof(BlahEnum));



        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Next_Click(object sender, EventArgs e)
        {
            Cobertura FormCob = new Cobertura();
            FormCob.ShowDialog();
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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox1.SelectedItem = BlahEnum.Active;
        }
    }
}
