
using Programmentwurf_Banking_Client.Models;

namespace Programmentwurf_Banking_Client.Forms
{
    partial class BankOverview
    {
        private UserModel User;
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
            User = (UserModel) Cache.cache.Get("User");
            this.AmountLabel = new System.Windows.Forms.Label();
            this.BankGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.ReloadBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BankGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Location = new System.Drawing.Point(13, 13);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(49, 15);
            this.AmountLabel.TabIndex = 0;
            this.AmountLabel.Text = "Banken:";
            // 
            // BankGridView
            // 
            this.BankGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BankGridView.Location = new System.Drawing.Point(13, 32);
            this.BankGridView.Name = "BankGridView";
            this.BankGridView.RowTemplate.Height = 25;
            this.BankGridView.Size = new System.Drawing.Size(526, 200);
            this.BankGridView.TabIndex = 1;
            // 
            // button1
            // 
            if (User.IsAdmin)
            {
                this.button1.Location = new System.Drawing.Point(13, 239);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(96, 23);
                this.button1.TabIndex = 2;
                this.button1.Text = "Neue Bank...";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
            }
            else
            {
                this.button1.Visible = false;
            }


            // 
            // ReloadBtn
            // 
            this.ReloadBtn.Location = new System.Drawing.Point(443, 239);
            this.ReloadBtn.Name = "ReloadBtn";
            this.ReloadBtn.Size = new System.Drawing.Size(95, 23);
            this.ReloadBtn.TabIndex = 3;
            this.ReloadBtn.Text = "Aktualisieren";
            this.ReloadBtn.UseVisualStyleBackColor = true;
            this.ReloadBtn.Click += new System.EventHandler(this.ReloadBtn_Click);
            // 
            // BankOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 270);
            this.Controls.Add(this.ReloadBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BankGridView);
            this.Controls.Add(this.AmountLabel);
            this.Name = "BankOverview";
            this.Text = "BankOverview";
            this.Load += new System.EventHandler(this.BankOverview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BankGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.DataGridView BankGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ReloadBtn;
    }
}