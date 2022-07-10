namespace Views
{
    partial class SupplyMaterialChangeInformation
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
            this.nextButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.countComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.idSupplyComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idMaterialСomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(290, 339);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(94, 29);
            this.nextButton.TabIndex = 23;
            this.nextButton.Text = "Далее";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(190, 339);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 29);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // countComboBox
            // 
            this.countComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.countComboBox.FormattingEnabled = true;
            this.countComboBox.Location = new System.Drawing.Point(125, 110);
            this.countComboBox.Name = "countComboBox";
            this.countComboBox.Size = new System.Drawing.Size(248, 28);
            this.countComboBox.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Кол-во";
            // 
            // idSupplyComboBox
            // 
            this.idSupplyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.idSupplyComboBox.FormattingEnabled = true;
            this.idSupplyComboBox.Location = new System.Drawing.Point(125, 22);
            this.idSupplyComboBox.Name = "idSupplyComboBox";
            this.idSupplyComboBox.Size = new System.Drawing.Size(248, 28);
            this.idSupplyComboBox.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "ID Поставки";
            // 
            // idMaterialСomboBox
            // 
            this.idMaterialСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.idMaterialСomboBox.FormattingEnabled = true;
            this.idMaterialСomboBox.Location = new System.Drawing.Point(125, 66);
            this.idMaterialСomboBox.Name = "idMaterialСomboBox";
            this.idMaterialСomboBox.Size = new System.Drawing.Size(248, 28);
            this.idMaterialСomboBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "ID Материала";
            // 
            // SupplyMaterialChangeInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 380);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.countComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.idSupplyComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idMaterialСomboBox);
            this.Controls.Add(this.label1);
            this.Name = "SupplyMaterialChangeInformation";
            this.Text = "Материал на складе";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button nextButton;
        private Button cancelButton;
        private ComboBox countComboBox;
        private Label label3;
        private ComboBox idSupplyComboBox;
        private Label label2;
        private ComboBox idMaterialСomboBox;
        private Label label1;
    }
}