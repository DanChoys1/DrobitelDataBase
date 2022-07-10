namespace Views
{
    partial class StockChangeInformation
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
            this.phoneComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.idScladaComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.adressСomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // phoneComboBox
            // 
            this.phoneComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.phoneComboBox.FormattingEnabled = true;
            this.phoneComboBox.Location = new System.Drawing.Point(134, 118);
            this.phoneComboBox.Name = "phoneComboBox";
            this.phoneComboBox.Size = new System.Drawing.Size(248, 28);
            this.phoneComboBox.TabIndex = 11;
            this.phoneComboBox.SelectedIndexChanged += new System.EventHandler(this.phoneComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Телефон";
            // 
            // idScladaComboBox
            // 
            this.idScladaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.idScladaComboBox.Enabled = false;
            this.idScladaComboBox.FormattingEnabled = true;
            this.idScladaComboBox.Location = new System.Drawing.Point(134, 30);
            this.idScladaComboBox.Name = "idScladaComboBox";
            this.idScladaComboBox.Size = new System.Drawing.Size(248, 28);
            this.idScladaComboBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "ID Склада";
            // 
            // adressСomboBox
            // 
            this.adressСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.adressСomboBox.FormattingEnabled = true;
            this.adressСomboBox.Location = new System.Drawing.Point(134, 74);
            this.adressСomboBox.Name = "adressСomboBox";
            this.adressСomboBox.Size = new System.Drawing.Size(248, 28);
            this.adressСomboBox.TabIndex = 7;
            this.adressСomboBox.SelectedIndexChanged += new System.EventHandler(this.adressСomboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Адрес";
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(316, 350);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(94, 29);
            this.nextButton.TabIndex = 15;
            this.nextButton.Text = "Далее";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(216, 350);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 29);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // StockChangeInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 391);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.phoneComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.idScladaComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.adressСomboBox);
            this.Controls.Add(this.label1);
            this.Name = "StockChangeInformation";
            this.Text = "Склад";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox phoneComboBox;
        private Label label3;
        private ComboBox idScladaComboBox;
        private Label label2;
        private ComboBox adressСomboBox;
        private Label label1;
        private Button nextButton;
        private Button cancelButton;
    }
}