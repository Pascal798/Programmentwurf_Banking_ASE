
namespace Programmentwurf_Banking_Client.Forms
{
    partial class CreateTransaction
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
            this.KontoIDBox = new System.Windows.Forms.ComboBox();
            this.KontostandLabel = new System.Windows.Forms.Label();
            this.BicLabel = new System.Windows.Forms.Label();
            this.AufLabel = new System.Windows.Forms.Label();
            this.UserBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ToIdBox = new System.Windows.Forms.ComboBox();
            this.TransactBtn = new System.Windows.Forms.Button();
            this.Betraglabel = new System.Windows.Forms.Label();
            this.BetragBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Von Konto:";
            // 
            // KontoIDBox
            // 
            this.KontoIDBox.FormattingEnabled = true;
            this.KontoIDBox.Location = new System.Drawing.Point(13, 32);
            this.KontoIDBox.Name = "KontoIDBox";
            this.KontoIDBox.Size = new System.Drawing.Size(134, 23);
            this.KontoIDBox.TabIndex = 1;
            this.KontoIDBox.SelectedIndexChanged += new System.EventHandler(this.KontoIDBox_SelectedIndexChanged);
            // 
            // KontostandLabel
            // 
            this.KontostandLabel.AutoSize = true;
            this.KontostandLabel.Location = new System.Drawing.Point(13, 62);
            this.KontostandLabel.Name = "KontostandLabel";
            this.KontostandLabel.Size = new System.Drawing.Size(74, 15);
            this.KontostandLabel.TabIndex = 2;
            this.KontostandLabel.Text = "Kontostand: ";
            // 
            // BicLabel
            // 
            this.BicLabel.AutoSize = true;
            this.BicLabel.Location = new System.Drawing.Point(13, 81);
            this.BicLabel.Name = "BicLabel";
            this.BicLabel.Size = new System.Drawing.Size(29, 15);
            this.BicLabel.TabIndex = 3;
            this.BicLabel.Text = "Bic: ";
            // 
            // AufLabel
            // 
            this.AufLabel.AutoSize = true;
            this.AufLabel.Location = new System.Drawing.Point(162, 13);
            this.AufLabel.Name = "AufLabel";
            this.AufLabel.Size = new System.Drawing.Size(139, 15);
            this.AufLabel.TabIndex = 4;
            this.AufLabel.Text = "Auf Konto von Benutzer: ";
            // 
            // UserBox
            // 
            this.UserBox.FormattingEnabled = true;
            this.UserBox.Location = new System.Drawing.Point(162, 32);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(139, 23);
            this.UserBox.TabIndex = 5;
            this.UserBox.SelectedIndexChanged += new System.EventHandler(this.UserBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mit KontoID:";
            // 
            // ToIdBox
            // 
            this.ToIdBox.FormattingEnabled = true;
            this.ToIdBox.Location = new System.Drawing.Point(162, 81);
            this.ToIdBox.Name = "ToIdBox";
            this.ToIdBox.Size = new System.Drawing.Size(139, 23);
            this.ToIdBox.TabIndex = 7;
            // 
            // TransactBtn
            // 
            this.TransactBtn.Location = new System.Drawing.Point(204, 122);
            this.TransactBtn.Name = "TransactBtn";
            this.TransactBtn.Size = new System.Drawing.Size(96, 23);
            this.TransactBtn.TabIndex = 8;
            this.TransactBtn.Text = "Überweisen";
            this.TransactBtn.UseVisualStyleBackColor = true;
            this.TransactBtn.Click += new System.EventHandler(this.TransactBtn_Click);
            // 
            // Betraglabel
            // 
            this.Betraglabel.AutoSize = true;
            this.Betraglabel.Location = new System.Drawing.Point(13, 100);
            this.Betraglabel.Name = "Betraglabel";
            this.Betraglabel.Size = new System.Drawing.Size(44, 15);
            this.Betraglabel.TabIndex = 9;
            this.Betraglabel.Text = "Betrag:";
            // 
            // BetragBox
            // 
            this.BetragBox.Location = new System.Drawing.Point(13, 122);
            this.BetragBox.Name = "BetragBox";
            this.BetragBox.Size = new System.Drawing.Size(134, 23);
            this.BetragBox.TabIndex = 10;
            // 
            // CreateTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 157);
            this.Controls.Add(this.BetragBox);
            this.Controls.Add(this.Betraglabel);
            this.Controls.Add(this.TransactBtn);
            this.Controls.Add(this.ToIdBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserBox);
            this.Controls.Add(this.AufLabel);
            this.Controls.Add(this.BicLabel);
            this.Controls.Add(this.KontostandLabel);
            this.Controls.Add(this.KontoIDBox);
            this.Controls.Add(this.label1);
            this.Name = "CreateTransaction";
            this.Text = "CreateTransaction";
            this.Load += new System.EventHandler(this.CreateTransaction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox KontoIDBox;
        private System.Windows.Forms.Label KontostandLabel;
        private System.Windows.Forms.Label BicLabel;
        private System.Windows.Forms.Label AufLabel;
        private System.Windows.Forms.ComboBox UserBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ToIdBox;
        private System.Windows.Forms.Button TransactBtn;
        private System.Windows.Forms.Label Betraglabel;
        private System.Windows.Forms.TextBox BetragBox;
    }
}