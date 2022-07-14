
namespace NotasDeEscritorio
{
    partial class FrmPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPassword));
            this.btnCambiarPassword = new System.Windows.Forms.Button();
            this.btnQuitarPassword = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtIngresarPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmarPassword = new System.Windows.Forms.TextBox();
            this.lblIngresarPassword = new System.Windows.Forms.Label();
            this.lblConfirmarPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCambiarPassword
            // 
            this.btnCambiarPassword.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCambiarPassword.Location = new System.Drawing.Point(461, 113);
            this.btnCambiarPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCambiarPassword.Name = "btnCambiarPassword";
            this.btnCambiarPassword.Size = new System.Drawing.Size(156, 58);
            this.btnCambiarPassword.TabIndex = 2;
            this.btnCambiarPassword.Text = "Activar contraseña";
            this.btnCambiarPassword.UseVisualStyleBackColor = true;
            this.btnCambiarPassword.Click += new System.EventHandler(this.btnCambiarPassword_Click);
            // 
            // btnQuitarPassword
            // 
            this.btnQuitarPassword.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuitarPassword.Location = new System.Drawing.Point(223, 113);
            this.btnQuitarPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuitarPassword.Name = "btnQuitarPassword";
            this.btnQuitarPassword.Size = new System.Drawing.Size(156, 58);
            this.btnQuitarPassword.TabIndex = 3;
            this.btnQuitarPassword.Text = "Quitar contraseña";
            this.btnQuitarPassword.UseVisualStyleBackColor = true;
            this.btnQuitarPassword.Click += new System.EventHandler(this.btnQuitarPassword_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(10, 113);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(156, 58);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtIngresarPassword
            // 
            this.txtIngresarPassword.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtIngresarPassword.Location = new System.Drawing.Point(332, 15);
            this.txtIngresarPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIngresarPassword.MaxLength = 10;
            this.txtIngresarPassword.Name = "txtIngresarPassword";
            this.txtIngresarPassword.PasswordChar = '*';
            this.txtIngresarPassword.Size = new System.Drawing.Size(285, 29);
            this.txtIngresarPassword.TabIndex = 0;
            // 
            // txtConfirmarPassword
            // 
            this.txtConfirmarPassword.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtConfirmarPassword.Location = new System.Drawing.Point(332, 56);
            this.txtConfirmarPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConfirmarPassword.MaxLength = 10;
            this.txtConfirmarPassword.Name = "txtConfirmarPassword";
            this.txtConfirmarPassword.PasswordChar = '*';
            this.txtConfirmarPassword.Size = new System.Drawing.Size(285, 29);
            this.txtConfirmarPassword.TabIndex = 1;
            // 
            // lblIngresarPassword
            // 
            this.lblIngresarPassword.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIngresarPassword.Location = new System.Drawing.Point(26, 17);
            this.lblIngresarPassword.Name = "lblIngresarPassword";
            this.lblIngresarPassword.Size = new System.Drawing.Size(301, 29);
            this.lblIngresarPassword.TabIndex = 5;
            this.lblIngresarPassword.Text = "Ingrese nueva contraseña:";
            // 
            // lblConfirmarPassword
            // 
            this.lblConfirmarPassword.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmarPassword.Location = new System.Drawing.Point(26, 58);
            this.lblConfirmarPassword.Name = "lblConfirmarPassword";
            this.lblConfirmarPassword.Size = new System.Drawing.Size(301, 29);
            this.lblConfirmarPassword.TabIndex = 6;
            this.lblConfirmarPassword.Text = "Confirme nueva contraseña:";
            // 
            // FrmPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 182);
            this.Controls.Add(this.lblConfirmarPassword);
            this.Controls.Add(this.lblIngresarPassword);
            this.Controls.Add(this.txtConfirmarPassword);
            this.Controls.Add(this.txtIngresarPassword);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnQuitarPassword);
            this.Controls.Add(this.btnCambiarPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FrmPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCambiarPassword;
        private System.Windows.Forms.Button btnQuitarPassword;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtIngresarPassword;
        private System.Windows.Forms.TextBox txtConfirmarPassword;
        private System.Windows.Forms.Label lblIngresarPassword;
        private System.Windows.Forms.Label lblConfirmarPassword;
    }
}