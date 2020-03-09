namespace IA_project
{
    partial class mainWindow
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
            this.menuPanel = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.configPlayerBtn = new System.Windows.Forms.Button();
            this.configMapBtn = new System.Windows.Forms.Button();
            this.mainBtn = new System.Windows.Forms.Button();
            this.logoPicBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(44)))), ((int)(((byte)(60)))));
            this.menuPanel.Controls.Add(this.buttonPanel);
            this.menuPanel.Controls.Add(this.logoPicBox);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(316, 777);
            this.menuPanel.TabIndex = 0;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.configPlayerBtn);
            this.buttonPanel.Controls.Add(this.configMapBtn);
            this.buttonPanel.Controls.Add(this.mainBtn);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPanel.Location = new System.Drawing.Point(0, 161);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.buttonPanel.Size = new System.Drawing.Size(316, 218);
            this.buttonPanel.TabIndex = 1;
            // 
            // configPlayerBtn
            // 
            this.configPlayerBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPlayerBtn.FlatAppearance.BorderSize = 0;
            this.configPlayerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.configPlayerBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configPlayerBtn.ForeColor = System.Drawing.Color.White;
            this.configPlayerBtn.Image = global::IA_project.Properties.Resources.man_icon;
            this.configPlayerBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.configPlayerBtn.Location = new System.Drawing.Point(0, 151);
            this.configPlayerBtn.Name = "configPlayerBtn";
            this.configPlayerBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.configPlayerBtn.Size = new System.Drawing.Size(316, 68);
            this.configPlayerBtn.TabIndex = 2;
            this.configPlayerBtn.Text = "           Configurar ser";
            this.configPlayerBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.configPlayerBtn.UseVisualStyleBackColor = true;
            // 
            // configMapBtn
            // 
            this.configMapBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.configMapBtn.FlatAppearance.BorderSize = 0;
            this.configMapBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.configMapBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configMapBtn.ForeColor = System.Drawing.Color.White;
            this.configMapBtn.Image = global::IA_project.Properties.Resources.map_icon;
            this.configMapBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.configMapBtn.Location = new System.Drawing.Point(0, 83);
            this.configMapBtn.Name = "configMapBtn";
            this.configMapBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.configMapBtn.Size = new System.Drawing.Size(316, 68);
            this.configMapBtn.TabIndex = 1;
            this.configMapBtn.Text = "           Configurar mapa";
            this.configMapBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.configMapBtn.UseVisualStyleBackColor = true;
            // 
            // mainBtn
            // 
            this.mainBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainBtn.FlatAppearance.BorderSize = 0;
            this.mainBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainBtn.ForeColor = System.Drawing.Color.White;
            this.mainBtn.Image = global::IA_project.Properties.Resources.home;
            this.mainBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mainBtn.Location = new System.Drawing.Point(0, 15);
            this.mainBtn.Name = "mainBtn";
            this.mainBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.mainBtn.Size = new System.Drawing.Size(316, 68);
            this.mainBtn.TabIndex = 0;
            this.mainBtn.Text = "           Principal";
            this.mainBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mainBtn.UseVisualStyleBackColor = true;
            // 
            // logoPicBox
            // 
            this.logoPicBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPicBox.Image = global::IA_project.Properties.Resources.logo;
            this.logoPicBox.Location = new System.Drawing.Point(0, 0);
            this.logoPicBox.Name = "logoPicBox";
            this.logoPicBox.Size = new System.Drawing.Size(316, 161);
            this.logoPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPicBox.TabIndex = 0;
            this.logoPicBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(316, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 777);
            this.panel1.TabIndex = 1;
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 777);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuPanel);
            this.MaximizeBox = false;
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inteligencia Artificial";
            this.menuPanel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button mainBtn;
        private System.Windows.Forms.PictureBox logoPicBox;
        private System.Windows.Forms.Button configPlayerBtn;
        private System.Windows.Forms.Button configMapBtn;
        private System.Windows.Forms.Panel panel1;
    }
}

