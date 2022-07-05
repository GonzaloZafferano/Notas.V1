
namespace NotasDeEscritorio
{
    partial class FrmNotas
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotas));
            this.dtgvNotas = new System.Windows.Forms.DataGridView();
            this.btnAgregarNota = new System.Windows.Forms.Button();
            this.lblNotas = new System.Windows.Forms.Label();
            this.barraMenu = new System.Windows.Forms.MenuStrip();
            this.btnNotas = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirTodasLasNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarTodasLasNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarTodasLasNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.azulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rosadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verdeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNotas)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvNotas
            // 
            this.dtgvNotas.AllowUserToAddRows = false;
            this.dtgvNotas.AllowUserToDeleteRows = false;
            this.dtgvNotas.AllowUserToResizeColumns = false;
            this.dtgvNotas.AllowUserToResizeRows = false;
            this.dtgvNotas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvNotas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgvNotas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgvNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvNotas.Location = new System.Drawing.Point(3, 84);
            this.dtgvNotas.MultiSelect = false;
            this.dtgvNotas.Name = "dtgvNotas";
            this.dtgvNotas.ReadOnly = true;
            this.dtgvNotas.RowHeadersVisible = false;
            this.dtgvNotas.RowHeadersWidth = 51;
            this.dtgvNotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgvNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvNotas.Size = new System.Drawing.Size(586, 392);
            this.dtgvNotas.TabIndex = 4;
            this.dtgvNotas.TabStop = false;
            this.dtgvNotas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvNotas_CellContentClick);
            this.dtgvNotas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvNotas_CellDoubleClick);
            // 
            // btnAgregarNota
            // 
            this.btnAgregarNota.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregarNota.Location = new System.Drawing.Point(483, 35);
            this.btnAgregarNota.Name = "btnAgregarNota";
            this.btnAgregarNota.Size = new System.Drawing.Size(94, 43);
            this.btnAgregarNota.TabIndex = 5;
            this.btnAgregarNota.TabStop = false;
            this.btnAgregarNota.Text = "+";
            this.btnAgregarNota.UseVisualStyleBackColor = true;
            this.btnAgregarNota.Click += new System.EventHandler(this.btnAgregarNota_Click);
            // 
            // lblNotas
            // 
            this.lblNotas.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNotas.Location = new System.Drawing.Point(3, 35);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(586, 49);
            this.lblNotas.TabIndex = 6;
            this.lblNotas.Text = "Notas";
            this.lblNotas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.barraMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNotas,
            this.temasToolStripMenuItem,
            this.passwordToolStripMenuItem});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(589, 32);
            this.barraMenu.TabIndex = 7;
            this.barraMenu.Text = "menuStrip1";
            // 
            // btnNotas
            // 
            this.btnNotas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirTodasLasNotasToolStripMenuItem,
            this.cerrarTodasLasNotasToolStripMenuItem,
            this.borrarTodasLasNotasToolStripMenuItem});
            this.btnNotas.Name = "btnNotas";
            this.btnNotas.Size = new System.Drawing.Size(79, 28);
            this.btnNotas.Text = "Notas";
            // 
            // abrirTodasLasNotasToolStripMenuItem
            // 
            this.abrirTodasLasNotasToolStripMenuItem.Name = "abrirTodasLasNotasToolStripMenuItem";
            this.abrirTodasLasNotasToolStripMenuItem.Size = new System.Drawing.Size(306, 28);
            this.abrirTodasLasNotasToolStripMenuItem.Text = "Abrir todas las notas";
            this.abrirTodasLasNotasToolStripMenuItem.Click += new System.EventHandler(this.abrirTodasLasNotasToolStripMenuItem_Click);
            // 
            // cerrarTodasLasNotasToolStripMenuItem
            // 
            this.cerrarTodasLasNotasToolStripMenuItem.Name = "cerrarTodasLasNotasToolStripMenuItem";
            this.cerrarTodasLasNotasToolStripMenuItem.Size = new System.Drawing.Size(306, 28);
            this.cerrarTodasLasNotasToolStripMenuItem.Text = "Cerrar todas las notas";
            this.cerrarTodasLasNotasToolStripMenuItem.Click += new System.EventHandler(this.cerrarTodasLasNotasToolStripMenuItem_Click);
            // 
            // borrarTodasLasNotasToolStripMenuItem
            // 
            this.borrarTodasLasNotasToolStripMenuItem.Name = "borrarTodasLasNotasToolStripMenuItem";
            this.borrarTodasLasNotasToolStripMenuItem.Size = new System.Drawing.Size(306, 28);
            this.borrarTodasLasNotasToolStripMenuItem.Text = "Borrar todas las notas";
            this.borrarTodasLasNotasToolStripMenuItem.Click += new System.EventHandler(this.borrarTodasLasNotasToolStripMenuItem1_Click);
            // 
            // temasToolStripMenuItem
            // 
            this.temasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.azulToolStripMenuItem,
            this.rosadoToolStripMenuItem,
            this.verdeToolStripMenuItem});
            this.temasToolStripMenuItem.Name = "temasToolStripMenuItem";
            this.temasToolStripMenuItem.Size = new System.Drawing.Size(86, 28);
            this.temasToolStripMenuItem.Text = "Temas";
            // 
            // azulToolStripMenuItem
            // 
            this.azulToolStripMenuItem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.azulToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.azulToolStripMenuItem.Name = "azulToolStripMenuItem";
            this.azulToolStripMenuItem.Size = new System.Drawing.Size(166, 28);
            this.azulToolStripMenuItem.Text = "Azul";
            this.azulToolStripMenuItem.Click += new System.EventHandler(this.botonTema_Click);
            // 
            // rosadoToolStripMenuItem
            // 
            this.rosadoToolStripMenuItem.BackColor = System.Drawing.Color.LightPink;
            this.rosadoToolStripMenuItem.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.rosadoToolStripMenuItem.Name = "rosadoToolStripMenuItem";
            this.rosadoToolStripMenuItem.Size = new System.Drawing.Size(166, 28);
            this.rosadoToolStripMenuItem.Text = "Rosado";
            this.rosadoToolStripMenuItem.Click += new System.EventHandler(this.botonTema_Click);
            // 
            // verdeToolStripMenuItem
            // 
            this.verdeToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            this.verdeToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGreen;
            this.verdeToolStripMenuItem.Name = "verdeToolStripMenuItem";
            this.verdeToolStripMenuItem.Size = new System.Drawing.Size(166, 28);
            this.verdeToolStripMenuItem.Text = "Verde";
            this.verdeToolStripMenuItem.Click += new System.EventHandler(this.botonTema_Click);
            // 
            // passwordToolStripMenuItem
            // 
            this.passwordToolStripMenuItem.Name = "passwordToolStripMenuItem";
            this.passwordToolStripMenuItem.Size = new System.Drawing.Size(133, 28);
            this.passwordToolStripMenuItem.Text = "Contraseña";
            this.passwordToolStripMenuItem.Click += new System.EventHandler(this.passwordToolStripMenuItem_Click);
            // 
            // FrmNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 481);
            this.Controls.Add(this.lblNotas);
            this.Controls.Add(this.btnAgregarNota);
            this.Controls.Add(this.dtgvNotas);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.barraMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notas";
            this.Load += new System.EventHandler(this.Notas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNotas)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgvNotas;
        private System.Windows.Forms.Button btnAgregarNota;
        private System.Windows.Forms.Label lblNotas;
        private System.Windows.Forms.MenuStrip barraMenu;
        private System.Windows.Forms.ToolStripMenuItem temasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem azulToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rosadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verdeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnNotas;
        private System.Windows.Forms.ToolStripMenuItem abrirTodasLasNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarTodasLasNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarTodasLasNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordToolStripMenuItem;
    }
}

