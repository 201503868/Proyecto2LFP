namespace Proyecto1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analisisLexicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.analisisSintacticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.listaDeErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeErroresSintacticosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtb_entrada = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_archivo = new System.Windows.Forms.Label();
            this.label_tokens = new System.Windows.Forms.Label();
            this.label_errores = new System.Windows.Forms.Label();
            this.boton_analisis = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ejecutarToolStripMenuItem,
            this.exportarToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(517, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.BackColor = System.Drawing.Color.Khaki;
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.toolStripSeparator1,
            this.guardarToolStripMenuItem,
            this.toolStripSeparator2,
            this.abrirToolStripMenuItem});
            this.archivoToolStripMenuItem.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archivoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.nuevoToolStripMenuItem.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuevoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.guardarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarToolStripMenuItem1,
            this.guardarComoToolStripMenuItem});
            this.guardarToolStripMenuItem.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            // 
            // guardarToolStripMenuItem1
            // 
            this.guardarToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.guardarToolStripMenuItem1.Name = "guardarToolStripMenuItem1";
            this.guardarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.guardarToolStripMenuItem1.Size = new System.Drawing.Size(234, 22);
            this.guardarToolStripMenuItem1.Text = "Guardar";
            this.guardarToolStripMenuItem1.Click += new System.EventHandler(this.guardarToolStripMenuItem1_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar Como...";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.abrirToolStripMenuItem.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abrirToolStripMenuItem.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // ejecutarToolStripMenuItem
            // 
            this.ejecutarToolStripMenuItem.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ejecutarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analisisLexicoToolStripMenuItem,
            this.toolStripSeparator4,
            this.analisisSintacticoToolStripMenuItem});
            this.ejecutarToolStripMenuItem.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ejecutarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ejecutarToolStripMenuItem.Name = "ejecutarToolStripMenuItem";
            this.ejecutarToolStripMenuItem.ShortcutKeyDisplayString = "ctrl+R";
            this.ejecutarToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.ejecutarToolStripMenuItem.Text = "Ejecutar";
            // 
            // analisisLexicoToolStripMenuItem
            // 
            this.analisisLexicoToolStripMenuItem.BackColor = System.Drawing.Color.Azure;
            this.analisisLexicoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.analisisLexicoToolStripMenuItem.Name = "analisisLexicoToolStripMenuItem";
            this.analisisLexicoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.analisisLexicoToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.analisisLexicoToolStripMenuItem.Text = "Analisis Lexico";
            this.analisisLexicoToolStripMenuItem.Click += new System.EventHandler(this.analisisLexicoToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(321, 6);
            // 
            // analisisSintacticoToolStripMenuItem
            // 
            this.analisisSintacticoToolStripMenuItem.BackColor = System.Drawing.Color.Azure;
            this.analisisSintacticoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.analisisSintacticoToolStripMenuItem.Name = "analisisSintacticoToolStripMenuItem";
            this.analisisSintacticoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.analisisSintacticoToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.analisisSintacticoToolStripMenuItem.Text = "Analisis Sintactico";
            this.analisisSintacticoToolStripMenuItem.Click += new System.EventHandler(this.analisisSintacticoToolStripMenuItem_Click);
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.BackColor = System.Drawing.Color.SteelBlue;
            this.exportarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeTokensToolStripMenuItem,
            this.toolStripSeparator3,
            this.listaDeErroresToolStripMenuItem,
            this.listaDeErroresSintacticosToolStripMenuItem});
            this.exportarToolStripMenuItem.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.exportarToolStripMenuItem.Text = "Exportar";
            // 
            // listaDeTokensToolStripMenuItem
            // 
            this.listaDeTokensToolStripMenuItem.BackColor = System.Drawing.Color.Lavender;
            this.listaDeTokensToolStripMenuItem.Font = new System.Drawing.Font("Georgia", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaDeTokensToolStripMenuItem.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.listaDeTokensToolStripMenuItem.Name = "listaDeTokensToolStripMenuItem";
            this.listaDeTokensToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.listaDeTokensToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.listaDeTokensToolStripMenuItem.Text = "Lista de Tokens";
            this.listaDeTokensToolStripMenuItem.Click += new System.EventHandler(this.listaDeTokensToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(324, 6);
            // 
            // listaDeErroresToolStripMenuItem
            // 
            this.listaDeErroresToolStripMenuItem.BackColor = System.Drawing.Color.Lavender;
            this.listaDeErroresToolStripMenuItem.Font = new System.Drawing.Font("Georgia", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaDeErroresToolStripMenuItem.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.listaDeErroresToolStripMenuItem.Name = "listaDeErroresToolStripMenuItem";
            this.listaDeErroresToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.listaDeErroresToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.listaDeErroresToolStripMenuItem.Text = " Lista de Errores Lexicos";
            this.listaDeErroresToolStripMenuItem.Click += new System.EventHandler(this.listaDeErroresToolStripMenuItem_Click);
            // 
            // listaDeErroresSintacticosToolStripMenuItem
            // 
            this.listaDeErroresSintacticosToolStripMenuItem.BackColor = System.Drawing.Color.Lavender;
            this.listaDeErroresSintacticosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.listaDeErroresSintacticosToolStripMenuItem.Name = "listaDeErroresSintacticosToolStripMenuItem";
            this.listaDeErroresSintacticosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.listaDeErroresSintacticosToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.listaDeErroresSintacticosToolStripMenuItem.Text = "Lista de Errores Sintacticos";
            this.listaDeErroresSintacticosToolStripMenuItem.Click += new System.EventHandler(this.listaDeErroresSintacticosToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.BackColor = System.Drawing.Color.SlateGray;
            this.acercaDeToolStripMenuItem.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acercaDeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.ShortcutKeyDisplayString = "ctrl+I";
            this.acercaDeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de..";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // rtb_entrada
            // 
            this.rtb_entrada.BackColor = System.Drawing.Color.Ivory;
            this.rtb_entrada.Location = new System.Drawing.Point(12, 39);
            this.rtb_entrada.Name = "rtb_entrada";
            this.rtb_entrada.Size = new System.Drawing.Size(340, 454);
            this.rtb_entrada.TabIndex = 1;
            this.rtb_entrada.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 11.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(358, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total de Tokens:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 11.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(357, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total de Errores:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 11.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(357, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Archivo Actual:";
            // 
            // label_archivo
            // 
            this.label_archivo.AutoSize = true;
            this.label_archivo.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_archivo.Location = new System.Drawing.Point(383, 69);
            this.label_archivo.Name = "label_archivo";
            this.label_archivo.Size = new System.Drawing.Size(101, 16);
            this.label_archivo.TabIndex = 5;
            this.label_archivo.Text = "Sin Guardar*";
            // 
            // label_tokens
            // 
            this.label_tokens.AutoSize = true;
            this.label_tokens.Font = new System.Drawing.Font("Georgia", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tokens.Location = new System.Drawing.Point(419, 178);
            this.label_tokens.Name = "label_tokens";
            this.label_tokens.Size = new System.Drawing.Size(18, 18);
            this.label_tokens.TabIndex = 6;
            this.label_tokens.Text = "0";
            // 
            // label_errores
            // 
            this.label_errores.AutoSize = true;
            this.label_errores.Font = new System.Drawing.Font("Georgia", 11.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_errores.Location = new System.Drawing.Point(419, 282);
            this.label_errores.Name = "label_errores";
            this.label_errores.Size = new System.Drawing.Size(18, 18);
            this.label_errores.TabIndex = 7;
            this.label_errores.Text = "0";
            // 
            // boton_analisis
            // 
            this.boton_analisis.Image = global::Proyecto1.Properties.Resources.icono;
            this.boton_analisis.Location = new System.Drawing.Point(367, 329);
            this.boton_analisis.Name = "boton_analisis";
            this.boton_analisis.Size = new System.Drawing.Size(138, 134);
            this.boton_analisis.TabIndex = 8;
            this.boton_analisis.UseVisualStyleBackColor = true;
            this.boton_analisis.Click += new System.EventHandler(this.boton_analisis_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(517, 504);
            this.Controls.Add(this.boton_analisis);
            this.Controls.Add(this.label_errores);
            this.Controls.Add(this.label_tokens);
            this.Controls.Add(this.label_archivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtb_entrada);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(533, 543);
            this.MinimumSize = new System.Drawing.Size(533, 543);
            this.Name = "Form1";
            this.Text = "Proyecto 2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rtb_entrada;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_archivo;
        private System.Windows.Forms.Label label_tokens;
        private System.Windows.Forms.Label label_errores;
        private System.Windows.Forms.ToolStripMenuItem listaDeTokensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeErroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button boton_analisis;
        private System.Windows.Forms.ToolStripMenuItem analisisLexicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analisisSintacticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem listaDeErroresSintacticosToolStripMenuItem;
    }
}

