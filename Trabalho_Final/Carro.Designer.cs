namespace Trabalho_Final
{
    partial class Carro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btSair = new System.Windows.Forms.Button();
            this.btPrev = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.cbModelo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1392, 113);
            this.label1.TabIndex = 0;
            this.label1.Text = "Preencha os dados do veículo";
            this.label1.Click += new System.EventHandler(this.Label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(806, 113);
            this.label2.TabIndex = 1;
            this.label2.Text = "Marca do veículo";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 308);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(378, 113);
            this.label3.TabIndex = 2;
            this.label3.Text = "Modelo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 494);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(778, 113);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ano Fabricação ";
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 634);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(611, 113);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ano Modelo ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 774);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(677, 113);
            this.label6.TabIndex = 5;
            this.label6.Text = "Valor do carro";
            // 
            // btSair
            // 
            this.btSair.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSair.Location = new System.Drawing.Point(31, 935);
            this.btSair.Margin = new System.Windows.Forms.Padding(4);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(263, 85);
            this.btSair.TabIndex = 6;
            this.btSair.Text = "Sair";
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.Exit_Click);
            // 
            // btPrev
            // 
            this.btPrev.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPrev.Location = new System.Drawing.Point(1083, 935);
            this.btPrev.Margin = new System.Windows.Forms.Padding(4);
            this.btPrev.Name = "btPrev";
            this.btPrev.Size = new System.Drawing.Size(263, 85);
            this.btPrev.TabIndex = 7;
            this.btPrev.Text = "Voltar";
            this.btPrev.UseVisualStyleBackColor = true;
            this.btPrev.Click += new System.EventHandler(this.Prev_Click);
            // 
            // btNext
            // 
            this.btNext.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNext.Location = new System.Drawing.Point(1377, 935);
            this.btNext.Margin = new System.Windows.Forms.Padding(4);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(263, 85);
            this.btNext.TabIndex = 8;
            this.btNext.Text = "Avançar";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.Next_Click);
            // 
            // cbMarca
            // 
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(53, 261);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(430, 24);
            this.cbMarca.TabIndex = 9;
            this.cbMarca.SelectedIndexChanged += new System.EventHandler(this.CbMarca_SelectedIndexChanged);
            // 
            // cbModelo
            // 
            this.cbModelo.FormattingEnabled = true;
            this.cbModelo.Location = new System.Drawing.Point(53, 444);
            this.cbModelo.Name = "cbModelo";
            this.cbModelo.Size = new System.Drawing.Size(430, 24);
            this.cbModelo.TabIndex = 10;
            this.cbModelo.SelectedIndexChanged += new System.EventHandler(this.CbModelo_SelectedIndexChanged);
            // 
            // Carro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1887, 1102);
            this.ControlBox = false;
            this.Controls.Add(this.cbModelo);
            this.Controls.Add(this.cbMarca);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.btPrev);
            this.Controls.Add(this.btSair);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Carro";
            this.Text = "Carro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.Button btPrev;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.ComboBox cbMarca;
        private System.Windows.Forms.ComboBox cbModelo;
    }
}