namespace Views
{
    partial class TransferOrderChangeInformation
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
            this.dateComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.stateComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.idOrderComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idRouteСomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateComboBox
            // 
            this.dateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.dateComboBox.Enabled = false;
            this.dateComboBox.FormattingEnabled = true;
            this.dateComboBox.Location = new System.Drawing.Point(160, 150);
            this.dateComboBox.Name = "dateComboBox";
            this.dateComboBox.Size = new System.Drawing.Size(248, 28);
            this.dateComboBox.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "Дата";
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(316, 353);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(94, 29);
            this.nextButton.TabIndex = 36;
            this.nextButton.Text = "Далее";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(216, 353);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 29);
            this.cancelButton.TabIndex = 35;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // stateComboBox
            // 
            this.stateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stateComboBox.Enabled = false;
            this.stateComboBox.FormattingEnabled = true;
            this.stateComboBox.Location = new System.Drawing.Point(160, 110);
            this.stateComboBox.Name = "stateComboBox";
            this.stateComboBox.Size = new System.Drawing.Size(248, 28);
            this.stateComboBox.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Статус";
            // 
            // idOrderComboBox
            // 
            this.idOrderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.idOrderComboBox.Enabled = false;
            this.idOrderComboBox.FormattingEnabled = true;
            this.idOrderComboBox.Location = new System.Drawing.Point(160, 22);
            this.idOrderComboBox.Name = "idOrderComboBox";
            this.idOrderComboBox.Size = new System.Drawing.Size(248, 28);
            this.idOrderComboBox.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "ID Заказа";
            // 
            // idRouteСomboBox
            // 
            this.idRouteСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.idRouteСomboBox.FormattingEnabled = true;
            this.idRouteСomboBox.Location = new System.Drawing.Point(160, 66);
            this.idRouteСomboBox.Name = "idRouteСomboBox";
            this.idRouteСomboBox.Size = new System.Drawing.Size(248, 28);
            this.idRouteСomboBox.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "ID Маршрута";
            // 
            // TransferOrderChangeInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 398);
            this.Controls.Add(this.dateComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.stateComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.idOrderComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idRouteСomboBox);
            this.Controls.Add(this.label1);
            this.Name = "TransferOrderChangeInformation";
            this.Text = "Заказ перемещения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComboBox dateComboBox;
        private Label label5;
        private Button nextButton;
        private Button cancelButton;
        private ComboBox stateComboBox;
        private Label label3;
        private ComboBox idOrderComboBox;
        private Label label2;
        private ComboBox idRouteСomboBox;
        private Label label1;
    }
}