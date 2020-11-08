namespace testing_system
{
    partial class FormForUser
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.учебнаяИнформацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикаТестовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиИзУчетнойЗаписиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChooseElement = new System.Windows.Forms.Label();
            this.LabelForComboBox = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.TBInformation = new System.Windows.Forms.RichTextBox();
            this.ButtonForTest = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.учебнаяИнформацияToolStripMenuItem,
            this.тестыToolStripMenuItem,
            this.статистикаТестовToolStripMenuItem,
            this.выйтиИзУчетнойЗаписиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(916, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // учебнаяИнформацияToolStripMenuItem
            // 
            this.учебнаяИнформацияToolStripMenuItem.Name = "учебнаяИнформацияToolStripMenuItem";
            this.учебнаяИнформацияToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.учебнаяИнформацияToolStripMenuItem.Text = "Учебная информация";
            this.учебнаяИнформацияToolStripMenuItem.Click += new System.EventHandler(this.учебнаяИнформацияToolStripMenuItem_Click);
            // 
            // тестыToolStripMenuItem
            // 
            this.тестыToolStripMenuItem.Name = "тестыToolStripMenuItem";
            this.тестыToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.тестыToolStripMenuItem.Text = "Тесты";
            this.тестыToolStripMenuItem.Click += new System.EventHandler(this.тестыToolStripMenuItem_Click);
            // 
            // статистикаТестовToolStripMenuItem
            // 
            this.статистикаТестовToolStripMenuItem.Name = "статистикаТестовToolStripMenuItem";
            this.статистикаТестовToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.статистикаТестовToolStripMenuItem.Text = "Статистика тестов";
            // 
            // выйтиИзУчетнойЗаписиToolStripMenuItem
            // 
            this.выйтиИзУчетнойЗаписиToolStripMenuItem.Name = "выйтиИзУчетнойЗаписиToolStripMenuItem";
            this.выйтиИзУчетнойЗаписиToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.выйтиИзУчетнойЗаписиToolStripMenuItem.Text = "Выйти из учетной записи";
            this.выйтиИзУчетнойЗаписиToolStripMenuItem.Click += new System.EventHandler(this.выйтиИзУчетнойЗаписиToolStripMenuItem_Click);
            // 
            // ChooseElement
            // 
            this.ChooseElement.AutoSize = true;
            this.ChooseElement.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseElement.Location = new System.Drawing.Point(175, 258);
            this.ChooseElement.Name = "ChooseElement";
            this.ChooseElement.Size = new System.Drawing.Size(632, 37);
            this.ChooseElement.TabIndex = 2;
            this.ChooseElement.Text = "Выберите один из элементов управления";
            this.ChooseElement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelForComboBox
            // 
            this.LabelForComboBox.AutoSize = true;
            this.LabelForComboBox.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelForComboBox.Location = new System.Drawing.Point(322, 40);
            this.LabelForComboBox.Name = "LabelForComboBox";
            this.LabelForComboBox.Size = new System.Drawing.Size(73, 27);
            this.LabelForComboBox.TabIndex = 3;
            this.LabelForComboBox.Text = "Темы:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(401, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // TBInformation
            // 
            this.TBInformation.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBInformation.Location = new System.Drawing.Point(12, 74);
            this.TBInformation.Name = "TBInformation";
            this.TBInformation.ReadOnly = true;
            this.TBInformation.Size = new System.Drawing.Size(891, 467);
            this.TBInformation.TabIndex = 5;
            this.TBInformation.Text = "";
            // 
            // ButtonForTest
            // 
            this.ButtonForTest.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonForTest.Location = new System.Drawing.Point(544, 44);
            this.ButtonForTest.Name = "ButtonForTest";
            this.ButtonForTest.Size = new System.Drawing.Size(117, 24);
            this.ButtonForTest.TabIndex = 6;
            this.ButtonForTest.Text = "Начать тест";
            this.ButtonForTest.UseVisualStyleBackColor = true;
            // 
            // FormForUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 553);
            this.Controls.Add(this.ButtonForTest);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ChooseElement);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.LabelForComboBox);
            this.Controls.Add(this.TBInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormForUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню пользователя";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormForUser_FormClosed);
            this.Load += new System.EventHandler(this.FormForUser_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem учебнаяИнформацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиИзУчетнойЗаписиToolStripMenuItem;
        private System.Windows.Forms.Label ChooseElement;
        private System.Windows.Forms.Label LabelForComboBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem статистикаТестовToolStripMenuItem;
        private System.Windows.Forms.RichTextBox TBInformation;
        private System.Windows.Forms.Button ButtonForTest;
    }
}