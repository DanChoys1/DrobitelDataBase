namespace Views
{
    partial class EmployeeSelection
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.managerChoiceButton = new System.Windows.Forms.Button();
            this.managerInOutChoiceButton = new System.Windows.Forms.Button();
            this.logisticianChoiceButton = new System.Windows.Forms.Button();
            this.treasurerChoiceButton = new System.Windows.Forms.Button();
            this.factoryWorkerChoiceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // managerChoiceButton
            // 
            this.managerChoiceButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.managerChoiceButton.Location = new System.Drawing.Point(0, 0);
            this.managerChoiceButton.Name = "managerChoiceButton";
            this.managerChoiceButton.Size = new System.Drawing.Size(432, 100);
            this.managerChoiceButton.TabIndex = 0;
            this.managerChoiceButton.Text = "Менеджер";
            this.managerChoiceButton.UseVisualStyleBackColor = true;
            this.managerChoiceButton.Click += new System.EventHandler(this.managerChoiceButton_Click);
            // 
            // managerInOutChoiceButton
            // 
            this.managerInOutChoiceButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.managerInOutChoiceButton.Location = new System.Drawing.Point(0, 100);
            this.managerInOutChoiceButton.Name = "managerInOutChoiceButton";
            this.managerInOutChoiceButton.Size = new System.Drawing.Size(432, 100);
            this.managerInOutChoiceButton.TabIndex = 1;
            this.managerInOutChoiceButton.Text = "Менеджер по продажам / закупкам";
            this.managerInOutChoiceButton.UseVisualStyleBackColor = true;
            // 
            // logisticianChoiceButton
            // 
            this.logisticianChoiceButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.logisticianChoiceButton.Location = new System.Drawing.Point(0, 200);
            this.logisticianChoiceButton.Name = "logisticianChoiceButton";
            this.logisticianChoiceButton.Size = new System.Drawing.Size(432, 100);
            this.logisticianChoiceButton.TabIndex = 2;
            this.logisticianChoiceButton.Text = "Логист";
            this.logisticianChoiceButton.UseVisualStyleBackColor = true;
            // 
            // treasurerChoiceButton
            // 
            this.treasurerChoiceButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.treasurerChoiceButton.Location = new System.Drawing.Point(0, 300);
            this.treasurerChoiceButton.Name = "treasurerChoiceButton";
            this.treasurerChoiceButton.Size = new System.Drawing.Size(432, 100);
            this.treasurerChoiceButton.TabIndex = 3;
            this.treasurerChoiceButton.Text = "Кладовщик";
            this.treasurerChoiceButton.UseVisualStyleBackColor = true;
            // 
            // factoryWorkerChoiceButton
            // 
            this.factoryWorkerChoiceButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.factoryWorkerChoiceButton.Location = new System.Drawing.Point(0, 400);
            this.factoryWorkerChoiceButton.Name = "factoryWorkerChoiceButton";
            this.factoryWorkerChoiceButton.Size = new System.Drawing.Size(432, 100);
            this.factoryWorkerChoiceButton.TabIndex = 4;
            this.factoryWorkerChoiceButton.Text = "Начальник цеха";
            this.factoryWorkerChoiceButton.UseVisualStyleBackColor = true;
            // 
            // EmployeeSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 503);
            this.Controls.Add(this.factoryWorkerChoiceButton);
            this.Controls.Add(this.treasurerChoiceButton);
            this.Controls.Add(this.logisticianChoiceButton);
            this.Controls.Add(this.managerInOutChoiceButton);
            this.Controls.Add(this.managerChoiceButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeSelection";
            this.Text = "Выбор сотрудника";
            this.ResumeLayout(false);

        }

        #endregion

        private Button managerChoiceButton;
        private Button managerInOutChoiceButton;
        private Button logisticianChoiceButton;
        private Button treasurerChoiceButton;
        private Button factoryWorkerChoiceButton;
    }
}