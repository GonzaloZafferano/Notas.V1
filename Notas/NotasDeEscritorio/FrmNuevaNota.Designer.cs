
namespace NotasDeEscritorio
{
    partial class FrmNuevaNota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevaNota));
            this.rTxtContenidoNota = new System.Windows.Forms.RichTextBox();
            this.barraMenuStrip = new System.Windows.Forms.MenuStrip();
            this.cambiarTítuloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.letraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barraStatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblCantidadCaracteres = new System.Windows.Forms.ToolStripStatusLabel();
            this.barraMenuStrip.SuspendLayout();
            this.barraStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // rTxtContenidoNota
            // 
            this.rTxtContenidoNota.BackColor = System.Drawing.Color.White;
            this.rTxtContenidoNota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtContenidoNota.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rTxtContenidoNota.Location = new System.Drawing.Point(0, 27);
            this.rTxtContenidoNota.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rTxtContenidoNota.MinimumSize = new System.Drawing.Size(307, 151);
            this.rTxtContenidoNota.Name = "rTxtContenidoNota";
            this.rTxtContenidoNota.Size = new System.Drawing.Size(404, 169);
            this.rTxtContenidoNota.TabIndex = 0;
            this.rTxtContenidoNota.Text = "";
            this.rTxtContenidoNota.TextChanged += new System.EventHandler(this.rTxtContenidoNota_TextChanged);
            // 
            // barraMenuStrip
            // 
            this.barraMenuStrip.BackColor = System.Drawing.Color.White;
            this.barraMenuStrip.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.barraMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.barraMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarTítuloToolStripMenuItem,
            this.letraToolStripMenuItem,
            this.temaToolStripMenuItem});
            this.barraMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.barraMenuStrip.Name = "barraMenuStrip";
            this.barraMenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.barraMenuStrip.Size = new System.Drawing.Size(404, 27);
            this.barraMenuStrip.TabIndex = 1;
            this.barraMenuStrip.Text = "menuStrip1";
            // 
            // cambiarTítuloToolStripMenuItem
            // 
            this.cambiarTítuloToolStripMenuItem.Name = "cambiarTítuloToolStripMenuItem";
            this.cambiarTítuloToolStripMenuItem.Size = new System.Drawing.Size(127, 23);
            this.cambiarTítuloToolStripMenuItem.Text = "Cambiar título";
            this.cambiarTítuloToolStripMenuItem.Click += new System.EventHandler(this.CambiarTítuloToolStripMenuItem_Click);
            // 
            // letraToolStripMenuItem
            // 
            this.letraToolStripMenuItem.Name = "letraToolStripMenuItem";
            this.letraToolStripMenuItem.Size = new System.Drawing.Size(169, 23);
            this.letraToolStripMenuItem.Text = "Opciones de fuente";
            this.letraToolStripMenuItem.Click += new System.EventHandler(this.MostrarFuentesToolStripMenuItem_Click);
            // 
            // temaToolStripMenuItem
            // 
            this.temaToolStripMenuItem.Name = "temaToolStripMenuItem";
            this.temaToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
            this.temaToolStripMenuItem.Text = "Tema";
            this.temaToolStripMenuItem.Click += new System.EventHandler(this.MostrarColorToolStripMenuItem_Click);
            // 
            // barraStatusStrip
            // 
            this.barraStatusStrip.BackColor = System.Drawing.Color.White;
            this.barraStatusStrip.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.barraStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.barraStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCantidadCaracteres});
            this.barraStatusStrip.Location = new System.Drawing.Point(0, 174);
            this.barraStatusStrip.Name = "barraStatusStrip";
            this.barraStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.barraStatusStrip.Size = new System.Drawing.Size(404, 22);
            this.barraStatusStrip.TabIndex = 2;
            this.barraStatusStrip.Text = "statusStrip1";
            // 
            // lblCantidadCaracteres
            // 
            this.lblCantidadCaracteres.Name = "lblCantidadCaracteres";
            this.lblCantidadCaracteres.Size = new System.Drawing.Size(15, 17);
            this.lblCantidadCaracteres.Text = "0";
            // 
            // FrmNuevaNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 196);
            this.Controls.Add(this.barraStatusStrip);
            this.Controls.Add(this.rTxtContenidoNota);
            this.Controls.Add(this.barraMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.barraMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(630, 435);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(420, 235);
            this.Name = "FrmNuevaNota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.FrmNuevaNota_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NuevaNota_FormClosing);
            this.Load += new System.EventHandler(this.NuevaNota_Load);
            this.barraMenuStrip.ResumeLayout(false);
            this.barraMenuStrip.PerformLayout();
            this.barraStatusStrip.ResumeLayout(false);
            this.barraStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTxtContenidoNota;
        private System.Windows.Forms.MenuStrip barraMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem letraToolStripMenuItem;
        private System.Windows.Forms.StatusStrip barraStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblCantidadCaracteres;
        private System.Windows.Forms.ToolStripMenuItem temaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarTítuloToolStripMenuItem;
    }
}