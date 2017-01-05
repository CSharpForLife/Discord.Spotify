namespace SpotifyBot {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tbToken = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbToken
            // 
            this.tbToken.Location = new System.Drawing.Point(59, 6);
            this.tbToken.Name = "tbToken";
            this.tbToken.PasswordChar = '*';
            this.tbToken.Size = new System.Drawing.Size(191, 20);
            this.tbToken.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Token:";
            // 
            // btnMain
            // 
            this.btnMain.Location = new System.Drawing.Point(15, 32);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(235, 23);
            this.btnMain.TabIndex = 2;
            this.btnMain.Text = "Start";
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 63);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbToken);
            this.Name = "Form1";
            this.Text = "Spotify SelfBot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox tbToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMain;
    }
}

