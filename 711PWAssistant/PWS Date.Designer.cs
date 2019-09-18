namespace _711PWAssistant
{
    partial class PWSDateForm
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
            this.pwsTimePicker = new System.Windows.Forms.DateTimePicker();
            this.retrievePWS = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pwsTimePicker
            // 
            this.pwsTimePicker.Location = new System.Drawing.Point(12, 12);
            this.pwsTimePicker.Name = "pwsTimePicker";
            this.pwsTimePicker.Size = new System.Drawing.Size(200, 20);
            this.pwsTimePicker.TabIndex = 0;
            // 
            // retrievePWS
            // 
            this.retrievePWS.Location = new System.Drawing.Point(12, 38);
            this.retrievePWS.Name = "retrievePWS";
            this.retrievePWS.Size = new System.Drawing.Size(91, 23);
            this.retrievePWS.TabIndex = 1;
            this.retrievePWS.Text = "Retrieve PWS";
            this.retrievePWS.UseVisualStyleBackColor = true;
            this.retrievePWS.Click += new System.EventHandler(this.retrievePWS_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(137, 38);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // PWSDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(225, 70);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.retrievePWS);
            this.Controls.Add(this.pwsTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PWSDateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PWS Date";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker pwsTimePicker;
        private System.Windows.Forms.Button retrievePWS;
        private System.Windows.Forms.Button cancelButton;
    }
}