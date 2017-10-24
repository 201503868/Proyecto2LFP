namespace Proyecto1
{
    partial class Datos
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
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Nickname = new System.Windows.Forms.TextBox();
            this.CB_Nickname = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Nivel = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 11.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ingrese o seleccione un nickname:";
            // 
            // TB_Nickname
            // 
            this.TB_Nickname.Location = new System.Drawing.Point(15, 52);
            this.TB_Nickname.Name = "TB_Nickname";
            this.TB_Nickname.Size = new System.Drawing.Size(146, 20);
            this.TB_Nickname.TabIndex = 6;
            // 
            // CB_Nickname
            // 
            this.CB_Nickname.FormattingEnabled = true;
            this.CB_Nickname.Location = new System.Drawing.Point(15, 88);
            this.CB_Nickname.Name = "CB_Nickname";
            this.CB_Nickname.Size = new System.Drawing.Size(121, 21);
            this.CB_Nickname.TabIndex = 7;
            this.CB_Nickname.Click += new System.EventHandler(this.CB_Nickname_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 11.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Seleccione el nivel del juego:";
            // 
            // CB_Nivel
            // 
            this.CB_Nivel.FormattingEnabled = true;
            this.CB_Nivel.Location = new System.Drawing.Point(15, 183);
            this.CB_Nivel.Name = "CB_Nivel";
            this.CB_Nivel.Size = new System.Drawing.Size(121, 21);
            this.CB_Nivel.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 27);
            this.button1.TabIndex = 10;
            this.button1.Text = "Jugar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Datos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 311);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CB_Nivel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_Nickname);
            this.Controls.Add(this.TB_Nickname);
            this.Controls.Add(this.label3);
            this.MaximumSize = new System.Drawing.Size(375, 350);
            this.MinimumSize = new System.Drawing.Size(375, 350);
            this.Name = "Datos";
            this.Text = "Datos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Nickname;
        private System.Windows.Forms.ComboBox CB_Nickname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Nivel;
        private System.Windows.Forms.Button button1;
    }
}