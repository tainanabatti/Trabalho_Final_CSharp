namespace Trabalho_Final
{
    partial class DadosComp
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
            this.next = new System.Windows.Forms.Button();
            this.prev = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // next
            // 
            this.next.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next.Location = new System.Drawing.Point(1052, 746);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(197, 69);
            this.next.TabIndex = 12;
            this.next.Text = "Avançar";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.Next_Click);
            // 
            // prev
            // 
            this.prev.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prev.Location = new System.Drawing.Point(831, 746);
            this.prev.Name = "prev";
            this.prev.Size = new System.Drawing.Size(197, 69);
            this.prev.TabIndex = 11;
            this.prev.Text = "Voltar";
            this.prev.UseVisualStyleBackColor = true;
            this.prev.Click += new System.EventHandler(this.Prev_Click);
            // 
            // exit
            // 
            this.exit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Location = new System.Drawing.Point(42, 746);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(197, 69);
            this.exit.TabIndex = 10;
            this.exit.Text = "Sair";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1097, 91);
            this.label1.TabIndex = 7;
            this.label1.Text = "Preencha os dados do veículo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(304, 91);
            this.label6.TabIndex = 6;
            this.label6.Text = "Chassi:";
            this.label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 91);
            this.label2.TabIndex = 8;
            this.label2.Text = "Placa:";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(498, 91);
            this.label3.TabIndex = 9;
            this.label3.Text = "Combustível:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(509, 399);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(551, 99);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // DadosComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 718);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.next);
            this.Controls.Add(this.prev);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DadosComp";
            this.Text = "DadosComp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button prev;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}