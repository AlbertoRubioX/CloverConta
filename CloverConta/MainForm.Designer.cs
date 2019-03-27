namespace CloverConta
{
    partial class MainForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmInicio = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCatalogos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCuentas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpera = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBalanza = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Gray;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(161, 17);
            this.toolStripStatusLabel1.Text = "Clover Accounting Manager";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmInicio,
            this.tsmCatalogos,
            this.tsmOpera,
            this.tsmExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmInicio
            // 
            this.tsmInicio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConfig});
            this.tsmInicio.Name = "tsmInicio";
            this.tsmInicio.Size = new System.Drawing.Size(48, 20);
            this.tsmInicio.Text = "&Inicio";
            // 
            // tsmConfig
            // 
            this.tsmConfig.Name = "tsmConfig";
            this.tsmConfig.Size = new System.Drawing.Size(150, 22);
            this.tsmConfig.Text = "&Configuración";
            // 
            // tsmCatalogos
            // 
            this.tsmCatalogos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCuentas});
            this.tsmCatalogos.Name = "tsmCatalogos";
            this.tsmCatalogos.Size = new System.Drawing.Size(72, 20);
            this.tsmCatalogos.Text = "&Catálogos";
            // 
            // tsmCuentas
            // 
            this.tsmCuentas.Name = "tsmCuentas";
            this.tsmCuentas.Size = new System.Drawing.Size(173, 22);
            this.tsmCuentas.Text = "C&uentas Contables";
            // 
            // tsmOpera
            // 
            this.tsmOpera.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmBalanza});
            this.tsmOpera.Name = "tsmOpera";
            this.tsmOpera.Size = new System.Drawing.Size(85, 20);
            this.tsmOpera.Text = "&Operaciones";
            // 
            // tsmBalanza
            // 
            this.tsmBalanza.Name = "tsmBalanza";
            this.tsmBalanza.Size = new System.Drawing.Size(185, 22);
            this.tsmBalanza.Text = "&Balanza Comparativa";
            this.tsmBalanza.Click += new System.EventHandler(this.tsmBalanza_Click);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(41, 20);
            this.tsmExit.Text = "&Salir";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::CloverConta.Properties.Resources._110_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clover Cierre Contable";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmInicio;
        private System.Windows.Forms.ToolStripMenuItem tsmConfig;
        private System.Windows.Forms.ToolStripMenuItem tsmCatalogos;
        private System.Windows.Forms.ToolStripMenuItem tsmCuentas;
        private System.Windows.Forms.ToolStripMenuItem tsmOpera;
        private System.Windows.Forms.ToolStripMenuItem tsmBalanza;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
    }
}

