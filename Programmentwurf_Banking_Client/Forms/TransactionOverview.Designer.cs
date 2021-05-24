
namespace Programmentwurf_Banking_Client.Forms
{
    partial class TransactionOverview
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
            this.KontoLabel = new System.Windows.Forms.Label();
            this.KontoIdBox = new System.Windows.Forms.ComboBox();
            this.TransactionView = new System.Windows.Forms.DataGridView();
            this.SendAsMailBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionView)).BeginInit();
            this.SuspendLayout();
            // 
            // KontoLabel
            // 
            this.KontoLabel.AutoSize = true;
            this.KontoLabel.Location = new System.Drawing.Point(13, 13);
            this.KontoLabel.Name = "KontoLabel";
            this.KontoLabel.Size = new System.Drawing.Size(42, 15);
            this.KontoLabel.TabIndex = 0;
            this.KontoLabel.Text = "Konto:";
            // 
            // KontoIdBox
            // 
            this.KontoIdBox.FormattingEnabled = true;
            this.KontoIdBox.Location = new System.Drawing.Point(13, 32);
            this.KontoIdBox.Name = "KontoIdBox";
            this.KontoIdBox.Size = new System.Drawing.Size(121, 23);
            this.KontoIdBox.TabIndex = 1;
            this.KontoIdBox.SelectedIndexChanged += new System.EventHandler(this.KontoIdBox_SelectedIndexChanged);
            // 
            // TransactionView
            // 
            this.TransactionView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransactionView.Location = new System.Drawing.Point(13, 62);
            this.TransactionView.Name = "TransactionView";
            this.TransactionView.RowTemplate.Height = 25;
            this.TransactionView.Size = new System.Drawing.Size(435, 150);
            this.TransactionView.TabIndex = 2;
            // 
            // SendAsMailBtn
            // 
            this.SendAsMailBtn.Location = new System.Drawing.Point(12, 218);
            this.SendAsMailBtn.Name = "SendAsMailBtn";
            this.SendAsMailBtn.Size = new System.Drawing.Size(170, 23);
            this.SendAsMailBtn.TabIndex = 3;
            this.SendAsMailBtn.Text = "Sende Transaktionen als Mail";
            this.SendAsMailBtn.UseVisualStyleBackColor = true;
            this.SendAsMailBtn.Click += new System.EventHandler(this.SendAsMailBtn_Click);
            // 
            // TransactionOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 248);
            this.Controls.Add(this.SendAsMailBtn);
            this.Controls.Add(this.TransactionView);
            this.Controls.Add(this.KontoIdBox);
            this.Controls.Add(this.KontoLabel);
            this.Name = "TransactionOverview";
            this.Text = "TransactionOverview";
            this.Load += new System.EventHandler(this.TransactionOverview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TransactionView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label KontoLabel;
        private System.Windows.Forms.ComboBox KontoIdBox;
        private System.Windows.Forms.DataGridView TransactionView;
        private System.Windows.Forms.Button SendAsMailBtn;
    }
}