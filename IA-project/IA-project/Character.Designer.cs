namespace IA_project
{
    partial class Character
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
            this.groupBoxCharacters = new System.Windows.Forms.GroupBox();
            this.dataGridViewTerrains = new System.Windows.Forms.DataGridView();
            this.charactersLabel = new System.Windows.Forms.Label();
            this.nextCharacterBtn = new System.Windows.Forms.Button();
            this.charactersDisplayer = new System.Windows.Forms.ListView();
            this.loadCharactersButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.errorProviderCharacter = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxCharacters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTerrains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCharacter)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCharacters
            // 
            this.groupBoxCharacters.Controls.Add(this.dataGridViewTerrains);
            this.groupBoxCharacters.Controls.Add(this.charactersLabel);
            this.groupBoxCharacters.Controls.Add(this.nextCharacterBtn);
            this.groupBoxCharacters.Controls.Add(this.charactersDisplayer);
            this.groupBoxCharacters.Controls.Add(this.loadCharactersButton);
            this.groupBoxCharacters.Location = new System.Drawing.Point(26, 31);
            this.groupBoxCharacters.Name = "groupBoxCharacters";
            this.groupBoxCharacters.Size = new System.Drawing.Size(1079, 462);
            this.groupBoxCharacters.TabIndex = 0;
            this.groupBoxCharacters.TabStop = false;
            this.groupBoxCharacters.Text = "Configuración de seres";
            // 
            // dataGridViewTerrains
            // 
            this.dataGridViewTerrains.AllowUserToAddRows = false;
            this.dataGridViewTerrains.AllowUserToResizeColumns = false;
            this.dataGridViewTerrains.AllowUserToResizeRows = false;
            this.dataGridViewTerrains.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTerrains.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewTerrains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTerrains.Location = new System.Drawing.Point(10, 81);
            this.dataGridViewTerrains.Name = "dataGridViewTerrains";
            this.dataGridViewTerrains.RowHeadersVisible = false;
            this.dataGridViewTerrains.RowHeadersWidth = 51;
            this.dataGridViewTerrains.RowTemplate.Height = 24;
            this.dataGridViewTerrains.Size = new System.Drawing.Size(542, 206);
            this.dataGridViewTerrains.TabIndex = 17;
            // 
            // charactersLabel
            // 
            this.charactersLabel.AutoSize = true;
            this.charactersLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.charactersLabel.Location = new System.Drawing.Point(6, 29);
            this.charactersLabel.Name = "charactersLabel";
            this.charactersLabel.Size = new System.Drawing.Size(217, 24);
            this.charactersLabel.TabIndex = 1;
            this.charactersLabel.Text = "Numero de seres creados: 0";
            // 
            // nextCharacterBtn
            // 
            this.nextCharacterBtn.Location = new System.Drawing.Point(16, 348);
            this.nextCharacterBtn.Name = "nextCharacterBtn";
            this.nextCharacterBtn.Size = new System.Drawing.Size(121, 46);
            this.nextCharacterBtn.TabIndex = 15;
            this.nextCharacterBtn.Text = "Siguiente";
            this.nextCharacterBtn.UseVisualStyleBackColor = true;
            this.nextCharacterBtn.Click += new System.EventHandler(this.nextCharacterBtn_Click);
            // 
            // charactersDisplayer
            // 
            this.charactersDisplayer.HideSelection = false;
            this.charactersDisplayer.Location = new System.Drawing.Point(631, 21);
            this.charactersDisplayer.MultiSelect = false;
            this.charactersDisplayer.Name = "charactersDisplayer";
            this.charactersDisplayer.Size = new System.Drawing.Size(292, 266);
            this.charactersDisplayer.TabIndex = 13;
            this.charactersDisplayer.UseCompatibleStateImageBehavior = false;
            // 
            // loadCharactersButton
            // 
            this.loadCharactersButton.Enabled = false;
            this.loadCharactersButton.Location = new System.Drawing.Point(160, 348);
            this.loadCharactersButton.Name = "loadCharactersButton";
            this.loadCharactersButton.Size = new System.Drawing.Size(121, 46);
            this.loadCharactersButton.TabIndex = 14;
            this.loadCharactersButton.Text = "Cargar";
            this.loadCharactersButton.UseVisualStyleBackColor = true;
            this.loadCharactersButton.Click += new System.EventHandler(this.loadCharactersButton_Click);
            // 
            // errorProviderCharacter
            // 
            this.errorProviderCharacter.ContainerControl = this;
            // 
            // Character
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 526);
            this.Controls.Add(this.groupBoxCharacters);
            this.Name = "Character";
            this.Text = "Character";
            this.Load += new System.EventHandler(this.Character_Load);
            this.groupBoxCharacters.ResumeLayout(false);
            this.groupBoxCharacters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTerrains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCharacter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCharacters;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button nextCharacterBtn;
        private System.Windows.Forms.ListView charactersDisplayer;
        private System.Windows.Forms.Button loadCharactersButton;
        private System.Windows.Forms.Label charactersLabel;
        private System.Windows.Forms.DataGridView dataGridViewTerrains;
        private System.Windows.Forms.ErrorProvider errorProviderCharacter;
    }
}