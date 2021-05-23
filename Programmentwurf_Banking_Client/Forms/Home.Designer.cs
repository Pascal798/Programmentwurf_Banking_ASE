
namespace Programmentwurf_Banking_Client.Forms
{
    partial class Home
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
            this.KontoGridView = new System.Windows.Forms.DataGridView();
            this.NameLabel = new System.Windows.Forms.Label();
            this.KontozahlLabel = new System.Windows.Forms.Label();
            this.EditKontoBtn = new System.Windows.Forms.Button();
            this.NewKontoBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ReloadBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.KontoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // KontoGridView
            // 
            this.KontoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KontoGridView.Location = new System.Drawing.Point(12, 30);
            this.KontoGridView.Name = "KontoGridView";
            this.KontoGridView.RowTemplate.Height = 25;
            this.KontoGridView.Size = new System.Drawing.Size(618, 212);
            this.KontoGridView.TabIndex = 0;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(13, 9);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 15);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "label1";
            // 
            // KontozahlLabel
            // 
            this.KontozahlLabel.AutoSize = true;
            this.KontozahlLabel.Location = new System.Drawing.Point(591, 9);
            this.KontozahlLabel.Name = "KontozahlLabel";
            this.KontozahlLabel.Size = new System.Drawing.Size(38, 15);
            this.KontozahlLabel.TabIndex = 2;
            this.KontozahlLabel.Text = "label1";
            // 
            // EditKontoBtn
            // 
            this.EditKontoBtn.Location = new System.Drawing.Point(491, 262);
            this.EditKontoBtn.Name = "EditKontoBtn";
            this.EditKontoBtn.Size = new System.Drawing.Size(137, 23);
            this.EditKontoBtn.TabIndex = 3;
            this.EditKontoBtn.Text = "Kontostand bearbeiten";
            this.EditKontoBtn.UseVisualStyleBackColor = true;
            this.EditKontoBtn.Click += new System.EventHandler(this.EditKontoBtn_Click);
            // 
            // NewKontoBtn
            // 
            this.NewKontoBtn.Location = new System.Drawing.Point(12, 262);
            this.NewKontoBtn.Name = "NewKontoBtn";
            this.NewKontoBtn.Size = new System.Drawing.Size(111, 23);
            this.NewKontoBtn.TabIndex = 4;
            this.NewKontoBtn.Text = "Neues Konto";
            this.NewKontoBtn.UseVisualStyleBackColor = true;
            this.NewKontoBtn.Click += new System.EventHandler(this.NewKontoBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(491, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Banken-Übersicht";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ReloadBtn
            // 
            this.ReloadBtn.Location = new System.Drawing.Point(13, 292);
            this.ReloadBtn.Name = "ReloadBtn";
            this.ReloadBtn.Size = new System.Drawing.Size(110, 23);
            this.ReloadBtn.TabIndex = 6;
            this.ReloadBtn.Text = "Aktualisieren";
            this.ReloadBtn.UseVisualStyleBackColor = true;
            this.ReloadBtn.Click += new System.EventHandler(this.ReloadBtn_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 431);
            this.Controls.Add(this.ReloadBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NewKontoBtn);
            this.Controls.Add(this.EditKontoBtn);
            this.Controls.Add(this.KontozahlLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.KontoGridView);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KontoGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView KontoGridView;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label KontozahlLabel;
        private System.Windows.Forms.Button EditKontoBtn;
        private System.Windows.Forms.Button NewKontoBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ReloadBtn;
    }
}