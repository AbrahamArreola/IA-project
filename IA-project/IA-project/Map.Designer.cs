namespace IA_project
{
    partial class Map
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
            this.components = new System.ComponentModel.Container();
            this.loadMapGb = new System.Windows.Forms.GroupBox();
            this.selectFileBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.configTerrainGb = new System.Windows.Forms.GroupBox();
            this.nextBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.imagesDisplayer = new System.Windows.Forms.ListView();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.valueTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.terrainLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.loadMapGb.SuspendLayout();
            this.configTerrainGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // loadMapGb
            // 
            this.loadMapGb.Controls.Add(this.selectFileBtn);
            this.loadMapGb.Dock = System.Windows.Forms.DockStyle.Top;
            this.loadMapGb.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadMapGb.Location = new System.Drawing.Point(0, 0);
            this.loadMapGb.Name = "loadMapGb";
            this.loadMapGb.Size = new System.Drawing.Size(752, 151);
            this.loadMapGb.TabIndex = 0;
            this.loadMapGb.TabStop = false;
            this.loadMapGb.Text = "Cargar Mapa";
            // 
            // selectFileBtn
            // 
            this.selectFileBtn.BackColor = System.Drawing.Color.Gainsboro;
            this.selectFileBtn.ForeColor = System.Drawing.Color.Black;
            this.selectFileBtn.Location = new System.Drawing.Point(276, 64);
            this.selectFileBtn.Name = "selectFileBtn";
            this.selectFileBtn.Size = new System.Drawing.Size(160, 39);
            this.selectFileBtn.TabIndex = 0;
            this.selectFileBtn.Text = "Seleccionar Archivo";
            this.selectFileBtn.UseVisualStyleBackColor = false;
            this.selectFileBtn.Click += new System.EventHandler(this.selectFileBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Archivos txt (*.txt)|*.txt|Archivos csv (*.csv)|*.csv";
            // 
            // configTerrainGb
            // 
            this.configTerrainGb.Controls.Add(this.nextBtn);
            this.configTerrainGb.Controls.Add(this.loadBtn);
            this.configTerrainGb.Controls.Add(this.imagesDisplayer);
            this.configTerrainGb.Controls.Add(this.nameTxt);
            this.configTerrainGb.Controls.Add(this.valueTxt);
            this.configTerrainGb.Controls.Add(this.label3);
            this.configTerrainGb.Controls.Add(this.label2);
            this.configTerrainGb.Controls.Add(this.terrainLabel);
            this.configTerrainGb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configTerrainGb.Enabled = false;
            this.configTerrainGb.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configTerrainGb.Location = new System.Drawing.Point(0, 151);
            this.configTerrainGb.Name = "configTerrainGb";
            this.configTerrainGb.Size = new System.Drawing.Size(752, 492);
            this.configTerrainGb.TabIndex = 1;
            this.configTerrainGb.TabStop = false;
            this.configTerrainGb.Text = "Configurar Terrenos";
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(64, 325);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(121, 46);
            this.nextBtn.TabIndex = 8;
            this.nextBtn.Text = "Siguiente";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(208, 325);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(121, 46);
            this.loadBtn.TabIndex = 7;
            this.loadBtn.Text = "Cargar";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // imagesDisplayer
            // 
            this.imagesDisplayer.Location = new System.Drawing.Point(378, 105);
            this.imagesDisplayer.MultiSelect = false;
            this.imagesDisplayer.Name = "imagesDisplayer";
            this.imagesDisplayer.Size = new System.Drawing.Size(292, 266);
            this.imagesDisplayer.TabIndex = 6;
            this.imagesDisplayer.UseCompatibleStateImageBehavior = false;
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(64, 243);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(121, 27);
            this.nameTxt.TabIndex = 5;
            // 
            // valueTxt
            // 
            this.valueTxt.Location = new System.Drawing.Point(64, 141);
            this.valueTxt.Name = "valueTxt";
            this.valueTxt.ReadOnly = true;
            this.valueTxt.Size = new System.Drawing.Size(121, 27);
            this.valueTxt.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor:";
            // 
            // terrainLabel
            // 
            this.terrainLabel.AutoSize = true;
            this.terrainLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terrainLabel.Location = new System.Drawing.Point(60, 48);
            this.terrainLabel.Name = "terrainLabel";
            this.terrainLabel.Size = new System.Drawing.Size(208, 24);
            this.terrainLabel.TabIndex = 0;
            this.terrainLabel.Text = "Terreno n de m detectados";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(752, 643);
            this.Controls.Add(this.configTerrainGb);
            this.Controls.Add(this.loadMapGb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Map";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurar mapa";
            this.loadMapGb.ResumeLayout(false);
            this.configTerrainGb.ResumeLayout(false);
            this.configTerrainGb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox loadMapGb;
        private System.Windows.Forms.Button selectFileBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox configTerrainGb;
        private System.Windows.Forms.Label terrainLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.TextBox valueTxt;
        private System.Windows.Forms.ListView imagesDisplayer;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}