
namespace Programmentwurf_Banking_Client.Forms
{
    partial class CreateKonto
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
            this.BicComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.KontostandBox = new System.Windows.Forms.TextBox();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank:";
            // 
            // BicComboBox
            // 
            this.BicComboBox.FormattingEnabled = true;
            this.BicComboBox.Location = new System.Drawing.Point(13, 32);
            this.BicComboBox.Name = "BicComboBox";
            this.BicComboBox.Size = new System.Drawing.Size(172, 23);
            this.BicComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kontostand:";
            // 
            // KontostandBox
            // 
            this.KontostandBox.Location = new System.Drawing.Point(13, 81);
            this.KontostandBox.Name = "KontostandBox";
            this.KontostandBox.Size = new System.Drawing.Size(172, 23);
            this.KontostandBox.TabIndex = 3;
            // 
            // CreateBtn
            // 
            this.CreateBtn.Location = new System.Drawing.Point(13, 111);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(102, 23);
            this.CreateBtn.TabIndex = 4;
            this.CreateBtn.Text = "Konto erstellen";
            this.CreateBtn.UseVisualStyleBackColor = true;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // CreateKonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 150);
            this.Controls.Add(this.CreateBtn);
            this.Controls.Add(this.KontostandBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BicComboBox);
            this.Controls.Add(this.label1);
            this.Name = "CreateKonto";
            this.Text = "CreateKonto";
            this.Load += new System.EventHandler(this.CreateKonto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BicComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KontostandBox;
        private System.Windows.Forms.Button CreateBtn;
    }
}