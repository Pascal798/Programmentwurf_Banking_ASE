
namespace Programmentwurf_Banking_Client.Forms
{
    partial class EditMoney
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
            this.KontoId = new System.Windows.Forms.ComboBox();
            this.KontostandLabel = new System.Windows.Forms.Label();
            this.BicLabel = new System.Windows.Forms.Label();
            this.EditLabel = new System.Windows.Forms.Label();
            this.EditTextbox = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.IdLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KontoId
            // 
            this.KontoId.FormattingEnabled = true;
            this.KontoId.Location = new System.Drawing.Point(12, 30);
            this.KontoId.Name = "KontoId";
            this.KontoId.Size = new System.Drawing.Size(121, 23);
            this.KontoId.TabIndex = 0;
            this.KontoId.SelectedIndexChanged += new System.EventHandler(this.KontoId_SelectedIndexChanged);
            // 
            // KontostandLabel
            // 
            this.KontostandLabel.AutoSize = true;
            this.KontostandLabel.Location = new System.Drawing.Point(12, 60);
            this.KontostandLabel.Name = "KontostandLabel";
            this.KontostandLabel.Size = new System.Drawing.Size(71, 15);
            this.KontostandLabel.TabIndex = 1;
            this.KontostandLabel.Text = "Kontostand:";
            // 
            // BicLabel
            // 
            this.BicLabel.AutoSize = true;
            this.BicLabel.Location = new System.Drawing.Point(12, 79);
            this.BicLabel.Name = "BicLabel";
            this.BicLabel.Size = new System.Drawing.Size(28, 15);
            this.BicLabel.TabIndex = 2;
            this.BicLabel.Text = "BIC:";
            // 
            // EditLabel
            // 
            this.EditLabel.AutoSize = true;
            this.EditLabel.Location = new System.Drawing.Point(12, 98);
            this.EditLabel.Name = "EditLabel";
            this.EditLabel.Size = new System.Drawing.Size(130, 15);
            this.EditLabel.TabIndex = 3;
            this.EditLabel.Text = "Kontostand bearbeiten:";
            // 
            // EditTextbox
            // 
            this.EditTextbox.Location = new System.Drawing.Point(12, 117);
            this.EditTextbox.Name = "EditTextbox";
            this.EditTextbox.Size = new System.Drawing.Size(100, 23);
            this.EditTextbox.TabIndex = 4;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(119, 117);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "Speichern";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(12, 9);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(20, 15);
            this.IdLabel.TabIndex = 6;
            this.IdLabel.Text = "Id:";
            // 
            // EditMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 147);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.EditTextbox);
            this.Controls.Add(this.EditLabel);
            this.Controls.Add(this.BicLabel);
            this.Controls.Add(this.KontostandLabel);
            this.Controls.Add(this.KontoId);
            this.Name = "EditMoney";
            this.Text = "EditMoney";
            this.Load += new System.EventHandler(this.EditMoney_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox KontoId;
        private System.Windows.Forms.Label KontostandLabel;
        private System.Windows.Forms.Label BicLabel;
        private System.Windows.Forms.Label EditLabel;
        private System.Windows.Forms.TextBox EditTextbox;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label IdLabel;
    }
}