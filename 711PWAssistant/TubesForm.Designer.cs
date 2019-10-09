namespace _711PWAssistant
{
    partial class TubesForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FrontOnes = new System.Windows.Forms.TextBox();
            this.BackOnes = new System.Windows.Forms.TextBox();
            this.BackFives = new System.Windows.Forms.TextBox();
            this.FrontFives = new System.Windows.Forms.TextBox();
            this.BackTens = new System.Windows.Forms.TextBox();
            this.FrontTens = new System.Windows.Forms.TextBox();
            this.BackTwenties = new System.Windows.Forms.TextBox();
            this.FrontTwenties = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label63 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(105, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gas Safe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Diesel Safe";
            // 
            // FrontOnes
            // 
            this.FrontOnes.Location = new System.Drawing.Point(65, 104);
            this.FrontOnes.Name = "FrontOnes";
            this.FrontOnes.Size = new System.Drawing.Size(51, 20);
            this.FrontOnes.TabIndex = 4;
            this.FrontOnes.Enter += new System.EventHandler(this.SelectUponTab);
            this.FrontOnes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxInputChecker);
            // 
            // BackOnes
            // 
            this.BackOnes.Location = new System.Drawing.Point(122, 104);
            this.BackOnes.Name = "BackOnes";
            this.BackOnes.Size = new System.Drawing.Size(51, 20);
            this.BackOnes.TabIndex = 5;
            this.BackOnes.Enter += new System.EventHandler(this.SelectUponTab);
            this.BackOnes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxInputChecker);
            // 
            // BackFives
            // 
            this.BackFives.Location = new System.Drawing.Point(122, 130);
            this.BackFives.Name = "BackFives";
            this.BackFives.Size = new System.Drawing.Size(51, 20);
            this.BackFives.TabIndex = 7;
            this.BackFives.Enter += new System.EventHandler(this.SelectUponTab);
            this.BackFives.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxInputChecker);
            // 
            // FrontFives
            // 
            this.FrontFives.Location = new System.Drawing.Point(65, 130);
            this.FrontFives.Name = "FrontFives";
            this.FrontFives.Size = new System.Drawing.Size(51, 20);
            this.FrontFives.TabIndex = 6;
            this.FrontFives.Enter += new System.EventHandler(this.SelectUponTab);
            this.FrontFives.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxInputChecker);
            // 
            // BackTens
            // 
            this.BackTens.Location = new System.Drawing.Point(122, 156);
            this.BackTens.Name = "BackTens";
            this.BackTens.Size = new System.Drawing.Size(51, 20);
            this.BackTens.TabIndex = 9;
            this.BackTens.Enter += new System.EventHandler(this.SelectUponTab);
            this.BackTens.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxInputChecker);
            // 
            // FrontTens
            // 
            this.FrontTens.Location = new System.Drawing.Point(65, 156);
            this.FrontTens.Name = "FrontTens";
            this.FrontTens.Size = new System.Drawing.Size(51, 20);
            this.FrontTens.TabIndex = 8;
            this.FrontTens.Enter += new System.EventHandler(this.SelectUponTab);
            this.FrontTens.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxInputChecker);
            // 
            // BackTwenties
            // 
            this.BackTwenties.Location = new System.Drawing.Point(122, 182);
            this.BackTwenties.Name = "BackTwenties";
            this.BackTwenties.Size = new System.Drawing.Size(51, 20);
            this.BackTwenties.TabIndex = 11;
            this.BackTwenties.Enter += new System.EventHandler(this.SelectUponTab);
            this.BackTwenties.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxInputChecker);
            // 
            // FrontTwenties
            // 
            this.FrontTwenties.Location = new System.Drawing.Point(65, 182);
            this.FrontTwenties.Name = "FrontTwenties";
            this.FrontTwenties.Size = new System.Drawing.Size(51, 20);
            this.FrontTwenties.TabIndex = 10;
            this.FrontTwenties.Enter += new System.EventHandler(this.SelectUponTab);
            this.FrontTwenties.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxInputChecker);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label63
            // 
            this.label63.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label63.Location = new System.Drawing.Point(12, 92);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(161, 2);
            this.label63.TabIndex = 164;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 165;
            this.label3.Text = "Ones";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 166;
            this.label4.Text = "Fives";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 167;
            this.label5.Text = "Tens";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 168;
            this.label6.Text = "Twenties";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(16, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(157, 54);
            this.richTextBox1.TabIndex = 170;
            this.richTextBox1.Text = "Here you can change how much money is in each tube for each safe.";
            // 
            // TubesForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(185, 252);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label63);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BackTwenties);
            this.Controls.Add(this.FrontTwenties);
            this.Controls.Add(this.BackTens);
            this.Controls.Add(this.FrontTens);
            this.Controls.Add(this.BackFives);
            this.Controls.Add(this.FrontFives);
            this.Controls.Add(this.BackOnes);
            this.Controls.Add(this.FrontOnes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TubesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Safe Adjuster";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.TextBox FrontOnes;
        public System.Windows.Forms.TextBox BackOnes;
        public System.Windows.Forms.TextBox BackFives;
        public System.Windows.Forms.TextBox FrontFives;
        public System.Windows.Forms.TextBox BackTens;
        public System.Windows.Forms.TextBox FrontTens;
        public System.Windows.Forms.TextBox BackTwenties;
        public System.Windows.Forms.TextBox FrontTwenties;
    }
}