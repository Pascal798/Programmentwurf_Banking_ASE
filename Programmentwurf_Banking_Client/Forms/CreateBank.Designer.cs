
namespace Programmentwurf_Banking_Client.Forms
{
    partial class CreateBank
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
            this.NameBox = new System.Windows.Forms.TextBox();
            this.BicBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LandBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PlzBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.StraßeBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bankname:";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(13, 32);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(189, 23);
            this.NameBox.TabIndex = 1;
            // 
            // BicBox
            // 
            this.BicBox.Location = new System.Drawing.Point(13, 77);
            this.BicBox.Name = "BicBox";
            this.BicBox.Size = new System.Drawing.Size(189, 23);
            this.BicBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "BIC:";
            // 
            // LandBox
            // 
            this.LandBox.Location = new System.Drawing.Point(13, 122);
            this.LandBox.Name = "LandBox";
            this.LandBox.Size = new System.Drawing.Size(189, 23);
            this.LandBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Land:";
            // 
            // PlzBox
            // 
            this.PlzBox.Location = new System.Drawing.Point(12, 167);
            this.PlzBox.Name = "PlzBox";
            this.PlzBox.Size = new System.Drawing.Size(190, 23);
            this.PlzBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Postleitzahl:";
            // 
            // StraßeBox
            // 
            this.StraßeBox.Location = new System.Drawing.Point(12, 212);
            this.StraßeBox.Name = "StraßeBox";
            this.StraßeBox.Size = new System.Drawing.Size(190, 23);
            this.StraßeBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Straße + Hausnummer:";
            // 
            // CreateBtn
            // 
            this.CreateBtn.Location = new System.Drawing.Point(13, 242);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(99, 23);
            this.CreateBtn.TabIndex = 10;
            this.CreateBtn.Text = "Bank erstellen";
            this.CreateBtn.UseVisualStyleBackColor = true;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // Banks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 275);
            this.Controls.Add(this.CreateBtn);
            this.Controls.Add(this.StraßeBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PlzBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LandBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BicBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label1);
            this.Name = "Banks";
            this.Text = "Banks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox BicBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LandBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PlzBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox StraßeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CreateBtn;
    }
}