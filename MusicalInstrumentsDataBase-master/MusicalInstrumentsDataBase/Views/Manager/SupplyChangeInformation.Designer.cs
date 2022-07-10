namespace Views
{
    partial class SupplyChangeInformation
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
            this.stateComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.idSupplyComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idOrderСomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.outDateComboBox = new System.Windows.Forms.ComboBox();
            this.inDateComboBox = new System.Windows.Forms.ComboBox();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.SuspendLayout();
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(304, 357);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(94, 29);
            this.nextButton.TabIndex = 23;
            this.nextButton.Text = "Далее";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(204, 357);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 29);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // stateComboBox
            // 
            this.stateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stateComboBox.FormattingEnabled = true;
            this.stateComboBox.Location = new System.Drawing.Point(148, 114);
            this.stateComboBox.Name = "stateComboBox";
            this.stateComboBox.Size = new System.Drawing.Size(248, 28);
            this.stateComboBox.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Статус";
            // 
            // idSupplyComboBox
            // 
            this.idSupplyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.idSupplyComboBox.Enabled = false;
            this.idSupplyComboBox.FormattingEnabled = true;
            this.idSupplyComboBox.Location = new System.Drawing.Point(148, 26);
            this.idSupplyComboBox.Name = "idSupplyComboBox";
            this.idSupplyComboBox.Size = new System.Drawing.Size(248, 28);
            this.idSupplyComboBox.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "ID Поставки";
            // 
            // idOrderСomboBox
            // 
            this.idOrderСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.idOrderСomboBox.FormattingEnabled = true;
            this.idOrderСomboBox.Location = new System.Drawing.Point(148, 70);
            this.idOrderСomboBox.Name = "idOrderСomboBox";
            this.idOrderСomboBox.Size = new System.Drawing.Size(248, 28);
            this.idOrderСomboBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "ID заказа";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Дата поступления";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Дата отгрузки";
            // 
            // outDateComboBox
            // 
            this.outDateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.outDateComboBox.FormattingEnabled = true;
            this.outDateComboBox.Location = new System.Drawing.Point(148, 154);
            this.outDateComboBox.Name = "outDateComboBox";
            this.outDateComboBox.Size = new System.Drawing.Size(248, 28);
            this.outDateComboBox.TabIndex = 27;
            // 
            // inDateComboBox
            // 
            this.inDateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.inDateComboBox.FormattingEnabled = true;
            this.inDateComboBox.Location = new System.Drawing.Point(150, 193);
            this.inDateComboBox.Name = "inDateComboBox";
            this.inDateComboBox.Size = new System.Drawing.Size(248, 28);
            this.inDateComboBox.TabIndex = 28;
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // SupplyChangeInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 404);
            this.Controls.Add(this.inDateComboBox);
            this.Controls.Add(this.outDateComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.stateComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.idSupplyComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idOrderСomboBox);
            this.Controls.Add(this.label1);
            this.Name = "SupplyChangeInformation";
            this.Text = "Поставка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button nextButton;
        private Button cancelButton;
        private ComboBox stateComboBox;
        private Label label3;
        private ComboBox idSupplyComboBox;
        private Label label2;
        private ComboBox idOrderСomboBox;
        private Label label1;
        private Label label4;
        private Label label5;
        private ComboBox outDateComboBox;
        private ComboBox inDateComboBox;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
    }
}