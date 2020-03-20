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
            this.groupBoxCharacters = new System.Windows.Forms.GroupBox();
            this.nextCharacterBtn = new System.Windows.Forms.Button();
            this.charactersDisplayer = new System.Windows.Forms.ListView();
            this.loadCharactersButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.valueOfTerrainLbl = new System.Windows.Forms.Label();
            this.valueOfTerrainTextBox = new System.Windows.Forms.TextBox();
            this.valueTxt = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.terrainLabel = new System.Windows.Forms.Label();
            this.groupBoxCharacters.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCharacters
            // 
            this.groupBoxCharacters.Controls.Add(this.terrainLabel);
            this.groupBoxCharacters.Controls.Add(this.nextCharacterBtn);
            this.groupBoxCharacters.Controls.Add(this.charactersDisplayer);
            this.groupBoxCharacters.Controls.Add(this.loadCharactersButton);
            this.groupBoxCharacters.Controls.Add(this.label2);
            this.groupBoxCharacters.Controls.Add(this.valueOfTerrainLbl);
            this.groupBoxCharacters.Controls.Add(this.valueOfTerrainTextBox);
            this.groupBoxCharacters.Controls.Add(this.valueTxt);
            this.groupBoxCharacters.Location = new System.Drawing.Point(26, 31);
            this.groupBoxCharacters.Name = "groupBoxCharacters";
            this.groupBoxCharacters.Size = new System.Drawing.Size(698, 368);
            this.groupBoxCharacters.TabIndex = 0;
            this.groupBoxCharacters.TabStop = false;
            this.groupBoxCharacters.Text = "Configuración de seres";
            // 
            // nextCharacterBtn
            // 
            this.nextCharacterBtn.Location = new System.Drawing.Point(39, 297);
            this.nextCharacterBtn.Name = "nextCharacterBtn";
            this.nextCharacterBtn.Size = new System.Drawing.Size(121, 46);
            this.nextCharacterBtn.TabIndex = 15;
            this.nextCharacterBtn.Text = "Siguiente";
            this.nextCharacterBtn.UseVisualStyleBackColor = true;
            // 
            // charactersDisplayer
            // 
            this.charactersDisplayer.HideSelection = false;
            this.charactersDisplayer.Location = new System.Drawing.Point(353, 77);
            this.charactersDisplayer.MultiSelect = false;
            this.charactersDisplayer.Name = "charactersDisplayer";
            this.charactersDisplayer.Size = new System.Drawing.Size(292, 266);
            this.charactersDisplayer.TabIndex = 13;
            this.charactersDisplayer.UseCompatibleStateImageBehavior = false;
            // 
            // loadCharactersButton
            // 
            this.loadCharactersButton.Location = new System.Drawing.Point(183, 297);
            this.loadCharactersButton.Name = "loadCharactersButton";
            this.loadCharactersButton.Size = new System.Drawing.Size(121, 46);
            this.loadCharactersButton.TabIndex = 14;
            this.loadCharactersButton.Text = "Cargar";
            this.loadCharactersButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Valor:";
            // 
            // valueOfTerrainLbl
            // 
            this.valueOfTerrainLbl.AutoSize = true;
            this.valueOfTerrainLbl.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueOfTerrainLbl.Location = new System.Drawing.Point(35, 178);
            this.valueOfTerrainLbl.Name = "valueOfTerrainLbl";
            this.valueOfTerrainLbl.Size = new System.Drawing.Size(74, 24);
            this.valueOfTerrainLbl.TabIndex = 10;
            this.valueOfTerrainLbl.Text = "Nombre:";
            // 
            // valueOfTerrainTextBox
            // 
            this.valueOfTerrainTextBox.Location = new System.Drawing.Point(39, 215);
            this.valueOfTerrainTextBox.Name = "valueOfTerrainTextBox";
            this.valueOfTerrainTextBox.Size = new System.Drawing.Size(121, 22);
            this.valueOfTerrainTextBox.TabIndex = 12;
            // 
            // valueTxt
            // 
            this.valueTxt.Location = new System.Drawing.Point(39, 113);
            this.valueTxt.Name = "valueTxt";
            this.valueTxt.ReadOnly = true;
            this.valueTxt.Size = new System.Drawing.Size(121, 22);
            this.valueTxt.TabIndex = 11;
            // 
            // terrainLabel
            // 
            this.terrainLabel.AutoSize = true;
            this.terrainLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terrainLabel.Location = new System.Drawing.Point(6, 29);
            this.terrainLabel.Name = "terrainLabel";
            this.terrainLabel.Size = new System.Drawing.Size(208, 24);
            this.terrainLabel.TabIndex = 1;
            this.terrainLabel.Text = "Terreno n de m detectados";
            // 
            // Character
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxCharacters);
            this.Name = "Character";
            this.Text = "Character";
            this.groupBoxCharacters.ResumeLayout(false);
            this.groupBoxCharacters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCharacters;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button nextCharacterBtn;
        private System.Windows.Forms.ListView charactersDisplayer;
        private System.Windows.Forms.Button loadCharactersButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label valueOfTerrainLbl;
        private System.Windows.Forms.TextBox valueOfTerrainTextBox;
        private System.Windows.Forms.TextBox valueTxt;
        private System.Windows.Forms.Label terrainLabel;
    }
}