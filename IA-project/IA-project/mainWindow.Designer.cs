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
            this.howToPlayBtn = new System.Windows.Forms.Button();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.configPlayerBtn = new System.Windows.Forms.Button();
            this.configMapBtn = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.logoPicBox = new System.Windows.Forms.PictureBox();
            this.childFormPanel = new System.Windows.Forms.Panel();
            this.AlgorithmsGb = new System.Windows.Forms.GroupBox();
            this.AlgorithmsCb = new System.Windows.Forms.ComboBox();
            this.ExpasionOrderGb = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fourthComboBox = new System.Windows.Forms.ComboBox();
            this.thirdComboBox = new System.Windows.Forms.ComboBox();
            this.secondComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.firstComboBox = new System.Windows.Forms.ComboBox();
            this.stopBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.playerGroupB = new System.Windows.Forms.GroupBox();
            this.playerSelector = new System.Windows.Forms.ComboBox();
            this.playerImage = new System.Windows.Forms.PictureBox();
            this.map = new System.Windows.Forms.TableLayoutPanel();
            this.menuPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).BeginInit();
            this.childFormPanel.SuspendLayout();
            this.AlgorithmsGb.SuspendLayout();
            this.ExpasionOrderGb.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.playerGroupB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(44)))), ((int)(((byte)(60)))));
            this.menuPanel.Controls.Add(this.howToPlayBtn);
            this.menuPanel.Controls.Add(this.buttonPanel);
            this.menuPanel.Controls.Add(this.logoPicBox);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(316, 797);
            this.menuPanel.TabIndex = 0;
            // 
            // howToPlayBtn
            // 
            this.howToPlayBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.howToPlayBtn.FlatAppearance.BorderSize = 0;
            this.howToPlayBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.howToPlayBtn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howToPlayBtn.ForeColor = System.Drawing.Color.White;
            this.howToPlayBtn.Image = global::IA_project.Properties.Resources.qmark_sign;
            this.howToPlayBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.howToPlayBtn.Location = new System.Drawing.Point(0, 379);
            this.howToPlayBtn.Name = "howToPlayBtn";
            this.howToPlayBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.howToPlayBtn.Size = new System.Drawing.Size(316, 68);
            this.howToPlayBtn.TabIndex = 3;
            this.howToPlayBtn.Text = "           Cómo jugar";
            this.howToPlayBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.howToPlayBtn.UseVisualStyleBackColor = true;
            this.howToPlayBtn.Click += new System.EventHandler(this.howToPlayBtn_Click);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.configPlayerBtn);
            this.buttonPanel.Controls.Add(this.configMapBtn);
            this.buttonPanel.Controls.Add(this.resetButton);
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
            this.configPlayerBtn.Text = "           Configurar jugadores";
            this.configPlayerBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.configPlayerBtn.UseVisualStyleBackColor = true;
            this.configPlayerBtn.Click += new System.EventHandler(this.configPlayerBtn_Click);
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
            this.configMapBtn.Text = "           Configurar terrenos";
            this.configMapBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.configMapBtn.UseVisualStyleBackColor = true;
            this.configMapBtn.Click += new System.EventHandler(this.configMapBtn_Click);
            // 
            // resetButton
            // 
            this.resetButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.resetButton.FlatAppearance.BorderSize = 0;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.ForeColor = System.Drawing.Color.White;
            this.resetButton.Image = global::IA_project.Properties.Resources.home;
            this.resetButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.resetButton.Location = new System.Drawing.Point(0, 15);
            this.resetButton.Name = "resetButton";
            this.resetButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.resetButton.Size = new System.Drawing.Size(316, 68);
            this.resetButton.TabIndex = 0;
            this.resetButton.Text = "           Reiniciar";
            this.resetButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
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
            // childFormPanel
            // 
            this.childFormPanel.BackColor = System.Drawing.SystemColors.Control;
            this.childFormPanel.Controls.Add(this.AlgorithmsGb);
            this.childFormPanel.Controls.Add(this.ExpasionOrderGb);
            this.childFormPanel.Controls.Add(this.stopBtn);
            this.childFormPanel.Controls.Add(this.playBtn);
            this.childFormPanel.Controls.Add(this.playerGroupB);
            this.childFormPanel.Controls.Add(this.map);
            this.childFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.childFormPanel.Location = new System.Drawing.Point(316, 0);
            this.childFormPanel.Name = "childFormPanel";
            this.childFormPanel.Size = new System.Drawing.Size(1170, 797);
            this.childFormPanel.TabIndex = 1;
            // 
            // AlgorithmsGb
            // 
            this.AlgorithmsGb.Controls.Add(this.AlgorithmsCb);
            this.AlgorithmsGb.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgorithmsGb.Location = new System.Drawing.Point(887, 648);
            this.AlgorithmsGb.Name = "AlgorithmsGb";
            this.AlgorithmsGb.Size = new System.Drawing.Size(262, 115);
            this.AlgorithmsGb.TabIndex = 5;
            this.AlgorithmsGb.TabStop = false;
            this.AlgorithmsGb.Text = "Algoritmos";
            // 
            // AlgorithmsCb
            // 
            this.AlgorithmsCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgorithmsCb.FormattingEnabled = true;
            this.AlgorithmsCb.Location = new System.Drawing.Point(14, 51);
            this.AlgorithmsCb.Name = "AlgorithmsCb";
            this.AlgorithmsCb.Size = new System.Drawing.Size(232, 30);
            this.AlgorithmsCb.TabIndex = 2;
            // 
            // ExpasionOrderGb
            // 
            this.ExpasionOrderGb.Controls.Add(this.tableLayoutPanel1);
            this.ExpasionOrderGb.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpasionOrderGb.Location = new System.Drawing.Point(887, 431);
            this.ExpasionOrderGb.Name = "ExpasionOrderGb";
            this.ExpasionOrderGb.Size = new System.Drawing.Size(262, 202);
            this.ExpasionOrderGb.TabIndex = 4;
            this.ExpasionOrderGb.TabStop = false;
            this.ExpasionOrderGb.Text = "Orden de expansión";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.fourthComboBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.thirdComboBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.secondComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.firstComboBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(249, 169);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // fourthComboBox
            // 
            this.fourthComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fourthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fourthComboBox.FormattingEnabled = true;
            this.fourthComboBox.Location = new System.Drawing.Point(32, 129);
            this.fourthComboBox.Name = "fourthComboBox";
            this.fourthComboBox.Size = new System.Drawing.Size(214, 30);
            this.fourthComboBox.TabIndex = 8;
            this.fourthComboBox.SelectedIndexChanged += new System.EventHandler(this.fourthComboBox_SelectedIndexChanged);
            // 
            // thirdComboBox
            // 
            this.thirdComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thirdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thirdComboBox.FormattingEnabled = true;
            this.thirdComboBox.Location = new System.Drawing.Point(32, 87);
            this.thirdComboBox.Name = "thirdComboBox";
            this.thirdComboBox.Size = new System.Drawing.Size(214, 30);
            this.thirdComboBox.TabIndex = 7;
            this.thirdComboBox.SelectedIndexChanged += new System.EventHandler(this.thirdComboBox_SelectedIndexChanged);
            // 
            // secondComboBox
            // 
            this.secondComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondComboBox.FormattingEnabled = true;
            this.secondComboBox.Location = new System.Drawing.Point(32, 45);
            this.secondComboBox.Name = "secondComboBox";
            this.secondComboBox.Size = new System.Drawing.Size(214, 30);
            this.secondComboBox.TabIndex = 6;
            this.secondComboBox.SelectedIndexChanged += new System.EventHandler(this.secondComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "1.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 42);
            this.label2.TabIndex = 1;
            this.label2.Text = "2.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 42);
            this.label3.TabIndex = 2;
            this.label3.Text = "3.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 43);
            this.label4.TabIndex = 3;
            this.label4.Text = "4.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // firstComboBox
            // 
            this.firstComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firstComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firstComboBox.FormattingEnabled = true;
            this.firstComboBox.Location = new System.Drawing.Point(32, 3);
            this.firstComboBox.Name = "firstComboBox";
            this.firstComboBox.Size = new System.Drawing.Size(214, 30);
            this.firstComboBox.TabIndex = 5;
            this.firstComboBox.SelectedIndexChanged += new System.EventHandler(this.firstComboBox_SelectedIndexChanged);
            // 
            // stopBtn
            // 
            this.stopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopBtn.Location = new System.Drawing.Point(1042, 58);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(107, 40);
            this.stopBtn.TabIndex = 3;
            this.stopBtn.Text = "Detener";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playBtn.Location = new System.Drawing.Point(887, 58);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(112, 40);
            this.playBtn.TabIndex = 2;
            this.playBtn.Text = "Jugar";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // playerGroupB
            // 
            this.playerGroupB.Controls.Add(this.playerSelector);
            this.playerGroupB.Controls.Add(this.playerImage);
            this.playerGroupB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.playerGroupB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerGroupB.Location = new System.Drawing.Point(887, 121);
            this.playerGroupB.Name = "playerGroupB";
            this.playerGroupB.Size = new System.Drawing.Size(262, 287);
            this.playerGroupB.TabIndex = 1;
            this.playerGroupB.TabStop = false;
            this.playerGroupB.Text = "Jugador";
            // 
            // playerSelector
            // 
            this.playerSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playerSelector.FormattingEnabled = true;
            this.playerSelector.Location = new System.Drawing.Point(17, 247);
            this.playerSelector.Name = "playerSelector";
            this.playerSelector.Size = new System.Drawing.Size(229, 28);
            this.playerSelector.TabIndex = 1;
            this.playerSelector.SelectedValueChanged += new System.EventHandler(this.playerSelector_SelectedValueChanged);
            // 
            // playerImage
            // 
            this.playerImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playerImage.Location = new System.Drawing.Point(17, 26);
            this.playerImage.Name = "playerImage";
            this.playerImage.Size = new System.Drawing.Size(229, 203);
            this.playerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerImage.TabIndex = 0;
            this.playerImage.TabStop = false;
            // 
            // map
            // 
            this.map.AutoScroll = true;
            this.map.AutoSize = true;
            this.map.BackColor = System.Drawing.Color.Silver;
            this.map.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.map.ColumnCount = 2;
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.map.Location = new System.Drawing.Point(7, 13);
            this.map.Margin = new System.Windows.Forms.Padding(0);
            this.map.Name = "map";
            this.map.RowCount = 2;
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.map.Size = new System.Drawing.Size(827, 750);
            this.map.TabIndex = 0;
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 797);
            this.Controls.Add(this.childFormPanel);
            this.Controls.Add(this.menuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inteligencia Artificial";
            this.menuPanel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).EndInit();
            this.childFormPanel.ResumeLayout(false);
            this.childFormPanel.PerformLayout();
            this.AlgorithmsGb.ResumeLayout(false);
            this.ExpasionOrderGb.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.playerGroupB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.playerImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.PictureBox logoPicBox;
        private System.Windows.Forms.Button configPlayerBtn;
        private System.Windows.Forms.Button configMapBtn;
        private System.Windows.Forms.Panel childFormPanel;
        private System.Windows.Forms.TableLayoutPanel map;
        private System.Windows.Forms.GroupBox playerGroupB;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button howToPlayBtn;
        public System.Windows.Forms.PictureBox playerImage;
        public System.Windows.Forms.ComboBox playerSelector;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.GroupBox ExpasionOrderGb;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ComboBox fourthComboBox;
        public System.Windows.Forms.ComboBox thirdComboBox;
        public System.Windows.Forms.ComboBox secondComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox firstComboBox;
        private System.Windows.Forms.GroupBox AlgorithmsGb;
        public System.Windows.Forms.ComboBox AlgorithmsCb;
    }
}

