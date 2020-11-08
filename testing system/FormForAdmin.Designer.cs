namespace testing_system
{
    partial class FormForAdmin
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
            this.выйтиИзУчётнойЗаписиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListOfUsers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EnterUserName = new System.Windows.Forms.TextBox();
            this.EnterPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EditUserButton = new System.Windows.Forms.Button();
            this.OperatingMode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MathInformation = new System.Windows.Forms.RichTextBox();
            this.ThemeName = new System.Windows.Forms.TextBox();
            this.AddUser = new System.Windows.Forms.RadioButton();
            this.RemoveUser = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.RemoveQuestion = new System.Windows.Forms.RadioButton();
            this.AddQuestion = new System.Windows.Forms.RadioButton();
            this.ChangeQuestion = new System.Windows.Forms.RadioButton();
            this.EnumQuestions = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.EditQuestionButton = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.EnterQuestion = new System.Windows.Forms.TextBox();
            this.ListOfQuestions = new System.Windows.Forms.ListBox();
            this.ListOfTests = new System.Windows.Forms.ListBox();
            this.AddTest = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.EditTestButton = new System.Windows.Forms.Button();
            this.RemoveTest = new System.Windows.Forms.RadioButton();
            this.EnterTestName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.AddThemeButton = new System.Windows.Forms.Button();
            this.EditThemeButton = new System.Windows.Forms.Button();
            this.AddTheme = new System.Windows.Forms.RadioButton();
            this.RemoveTheme = new System.Windows.Forms.RadioButton();
            this.EditTheme = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ListOfThemes = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выйтиИзУчётнойЗаписиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1282, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выйтиИзУчётнойЗаписиToolStripMenuItem
            // 
            this.выйтиИзУчётнойЗаписиToolStripMenuItem.Name = "выйтиИзУчётнойЗаписиToolStripMenuItem";
            this.выйтиИзУчётнойЗаписиToolStripMenuItem.Size = new System.Drawing.Size(198, 23);
            this.выйтиИзУчётнойЗаписиToolStripMenuItem.Text = "Выйти из учётной записи";
            this.выйтиИзУчётнойЗаписиToolStripMenuItem.Click += new System.EventHandler(this.выйтиИзУчётнойЗаписиToolStripMenuItem_Click);
            // 
            // ListOfUsers
            // 
            this.ListOfUsers.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListOfUsers.FormattingEnabled = true;
            this.ListOfUsers.ItemHeight = 22;
            this.ListOfUsers.Location = new System.Drawing.Point(8, 48);
            this.ListOfUsers.Name = "ListOfUsers";
            this.ListOfUsers.Size = new System.Drawing.Size(278, 312);
            this.ListOfUsers.TabIndex = 2;
            this.ListOfUsers.SelectedIndexChanged += new System.EventHandler(this.ListOfUsers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(324, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnterUserName
            // 
            this.EnterUserName.Location = new System.Drawing.Point(327, 123);
            this.EnterUserName.Name = "EnterUserName";
            this.EnterUserName.Size = new System.Drawing.Size(245, 22);
            this.EnterUserName.TabIndex = 4;
            // 
            // EnterPassword
            // 
            this.EnterPassword.Location = new System.Drawing.Point(327, 212);
            this.EnterPassword.Name = "EnterPassword";
            this.EnterPassword.Size = new System.Drawing.Size(245, 22);
            this.EnterPassword.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(324, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пароль";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EditUserButton
            // 
            this.EditUserButton.BackColor = System.Drawing.Color.Black;
            this.EditUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditUserButton.Location = new System.Drawing.Point(327, 320);
            this.EditUserButton.Name = "EditUserButton";
            this.EditUserButton.Size = new System.Drawing.Size(246, 40);
            this.EditUserButton.TabIndex = 7;
            this.EditUserButton.UseVisualStyleBackColor = false;
            this.EditUserButton.Click += new System.EventHandler(this.EditUserButton_Click);
            // 
            // OperatingMode
            // 
            this.OperatingMode.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OperatingMode.Location = new System.Drawing.Point(0, 28);
            this.OperatingMode.Name = "OperatingMode";
            this.OperatingMode.Size = new System.Drawing.Size(1290, 30);
            this.OperatingMode.TabIndex = 8;
            this.OperatingMode.Text = "Режим работы";
            this.OperatingMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OperatingMode.TextChanged += new System.EventHandler(this.OperatingMode_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(4, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(283, 36);
            this.label3.TabIndex = 9;
            this.label3.Text = "Все пользователи";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MathInformation
            // 
            this.MathInformation.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MathInformation.Location = new System.Drawing.Point(528, 42);
            this.MathInformation.Name = "MathInformation";
            this.MathInformation.Size = new System.Drawing.Size(711, 333);
            this.MathInformation.TabIndex = 10;
            this.MathInformation.Text = "";
            // 
            // ThemeName
            // 
            this.ThemeName.Location = new System.Drawing.Point(261, 81);
            this.ThemeName.Name = "ThemeName";
            this.ThemeName.Size = new System.Drawing.Size(261, 22);
            this.ThemeName.TabIndex = 12;
            this.ThemeName.TextChanged += new System.EventHandler(this.ThemeName_TextChanged);
            // 
            // AddUser
            // 
            this.AddUser.AutoSize = true;
            this.AddUser.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddUser.Location = new System.Drawing.Point(327, 16);
            this.AddUser.Name = "AddUser";
            this.AddUser.Size = new System.Drawing.Size(47, 31);
            this.AddUser.TabIndex = 13;
            this.AddUser.TabStop = true;
            this.AddUser.Text = "+";
            this.AddUser.UseVisualStyleBackColor = true;
            this.AddUser.CheckedChanged += new System.EventHandler(this.AddUser_CheckedChanged);
            // 
            // RemoveUser
            // 
            this.RemoveUser.AutoSize = true;
            this.RemoveUser.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveUser.Location = new System.Drawing.Point(528, 15);
            this.RemoveUser.Name = "RemoveUser";
            this.RemoveUser.Size = new System.Drawing.Size(41, 31);
            this.RemoveUser.TabIndex = 14;
            this.RemoveUser.TabStop = true;
            this.RemoveUser.Text = "-";
            this.RemoveUser.UseVisualStyleBackColor = true;
            this.RemoveUser.CheckedChanged += new System.EventHandler(this.RemoveUser_CheckedChanged);
            this.RemoveUser.EnabledChanged += new System.EventHandler(this.RemoveUser_EnabledChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.ListOfUsers);
            this.panel1.Controls.Add(this.RemoveUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.AddUser);
            this.panel1.Controls.Add(this.EnterUserName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.EnterPassword);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.EditUserButton);
            this.panel1.Location = new System.Drawing.Point(12, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 380);
            this.panel1.TabIndex = 15;
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.EnumQuestions);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.EditQuestionButton);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.EnterQuestion);
            this.panel2.Controls.Add(this.ListOfQuestions);
            this.panel2.Controls.Add(this.ListOfTests);
            this.panel2.Controls.Add(this.AddTest);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.EditTestButton);
            this.panel2.Controls.Add(this.RemoveTest);
            this.panel2.Controls.Add(this.EnterTestName);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(640, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 380);
            this.panel2.TabIndex = 16;
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.RemoveQuestion);
            this.panel4.Controls.Add(this.AddQuestion);
            this.panel4.Controls.Add(this.ChangeQuestion);
            this.panel4.Location = new System.Drawing.Point(275, 152);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(331, 36);
            this.panel4.TabIndex = 37;
            // 
            // RemoveQuestion
            // 
            this.RemoveQuestion.AutoSize = true;
            this.RemoveQuestion.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveQuestion.Location = new System.Drawing.Point(128, 2);
            this.RemoveQuestion.Name = "RemoveQuestion";
            this.RemoveQuestion.Size = new System.Drawing.Size(41, 31);
            this.RemoveQuestion.TabIndex = 24;
            this.RemoveQuestion.TabStop = true;
            this.RemoveQuestion.Text = "-";
            this.RemoveQuestion.UseVisualStyleBackColor = true;
            this.RemoveQuestion.CheckedChanged += new System.EventHandler(this.RemoveQuestion_CheckedChanged);
            // 
            // AddQuestion
            // 
            this.AddQuestion.AutoSize = true;
            this.AddQuestion.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddQuestion.Location = new System.Drawing.Point(2, 2);
            this.AddQuestion.Name = "AddQuestion";
            this.AddQuestion.Size = new System.Drawing.Size(47, 31);
            this.AddQuestion.TabIndex = 23;
            this.AddQuestion.TabStop = true;
            this.AddQuestion.Text = "+";
            this.AddQuestion.UseVisualStyleBackColor = true;
            this.AddQuestion.CheckedChanged += new System.EventHandler(this.AddQuestion_CheckedChanged);
            // 
            // ChangeQuestion
            // 
            this.ChangeQuestion.AutoSize = true;
            this.ChangeQuestion.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeQuestion.Location = new System.Drawing.Point(216, 6);
            this.ChangeQuestion.Name = "ChangeQuestion";
            this.ChangeQuestion.Size = new System.Drawing.Size(99, 23);
            this.ChangeQuestion.TabIndex = 25;
            this.ChangeQuestion.TabStop = true;
            this.ChangeQuestion.Text = "Изменить";
            this.ChangeQuestion.UseVisualStyleBackColor = true;
            this.ChangeQuestion.CheckedChanged += new System.EventHandler(this.ChangeQuestion_CheckedChanged);
            // 
            // EnumQuestions
            // 
            this.EnumQuestions.AutoSize = true;
            this.EnumQuestions.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnumQuestions.Location = new System.Drawing.Point(197, 335);
            this.EnumQuestions.Name = "EnumQuestions";
            this.EnumQuestions.Size = new System.Drawing.Size(18, 19);
            this.EnumQuestions.TabIndex = 36;
            this.EnumQuestions.Text = "1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(4, 335);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(152, 19);
            this.label13.TabIndex = 35;
            this.label13.Text = "Осталось вопросов:";
            // 
            // EditQuestionButton
            // 
            this.EditQuestionButton.BackColor = System.Drawing.Color.Black;
            this.EditQuestionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditQuestionButton.Location = new System.Drawing.Point(432, 331);
            this.EditQuestionButton.Name = "EditQuestionButton";
            this.EditQuestionButton.Size = new System.Drawing.Size(174, 42);
            this.EditQuestionButton.TabIndex = 34;
            this.EditQuestionButton.UseVisualStyleBackColor = false;
            this.EditQuestionButton.Click += new System.EventHandler(this.EditQuestionButton_Click);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(233, 335);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(184, 27);
            this.textBox4.TabIndex = 33;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(432, 299);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(175, 27);
            this.textBox3.TabIndex = 32;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(233, 302);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(184, 27);
            this.textBox2.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(245, 23);
            this.label6.TabIndex = 30;
            this.label6.Text = "Остальные ответы:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(432, 262);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 27);
            this.textBox1.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(271, 263);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 23);
            this.label10.TabIndex = 28;
            this.label10.Text = "Правильный ответ:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(271, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(336, 23);
            this.label9.TabIndex = 27;
            this.label9.Text = "Вопрос";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnterQuestion
            // 
            this.EnterQuestion.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterQuestion.Location = new System.Drawing.Point(271, 210);
            this.EnterQuestion.Multiline = true;
            this.EnterQuestion.Name = "EnterQuestion";
            this.EnterQuestion.Size = new System.Drawing.Size(336, 39);
            this.EnterQuestion.TabIndex = 26;
            // 
            // ListOfQuestions
            // 
            this.ListOfQuestions.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListOfQuestions.FormattingEnabled = true;
            this.ListOfQuestions.ItemHeight = 22;
            this.ListOfQuestions.Location = new System.Drawing.Point(4, 183);
            this.ListOfQuestions.Name = "ListOfQuestions";
            this.ListOfQuestions.Size = new System.Drawing.Size(244, 114);
            this.ListOfQuestions.TabIndex = 22;
            this.ListOfQuestions.SelectedIndexChanged += new System.EventHandler(this.ListOfQuestions_SelectedIndexChanged);
            // 
            // ListOfTests
            // 
            this.ListOfTests.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListOfTests.FormattingEnabled = true;
            this.ListOfTests.ItemHeight = 22;
            this.ListOfTests.Location = new System.Drawing.Point(3, 54);
            this.ListOfTests.Name = "ListOfTests";
            this.ListOfTests.Size = new System.Drawing.Size(245, 92);
            this.ListOfTests.TabIndex = 11;
            this.ListOfTests.SelectedIndexChanged += new System.EventHandler(this.ListOfTests_SelectedIndexChanged);
            // 
            // AddTest
            // 
            this.AddTest.AutoSize = true;
            this.AddTest.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddTest.Location = new System.Drawing.Point(271, 15);
            this.AddTest.Name = "AddTest";
            this.AddTest.Size = new System.Drawing.Size(47, 31);
            this.AddTest.TabIndex = 14;
            this.AddTest.TabStop = true;
            this.AddTest.Text = "+";
            this.AddTest.UseVisualStyleBackColor = true;
            this.AddTest.CheckedChanged += new System.EventHandler(this.AddTest_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(-1, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(249, 27);
            this.label8.TabIndex = 21;
            this.label8.Text = "Вопросы по тесту";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(-1, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(249, 36);
            this.label5.TabIndex = 10;
            this.label5.Text = "Все тесты";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EditTestButton
            // 
            this.EditTestButton.BackColor = System.Drawing.Color.Black;
            this.EditTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditTestButton.Location = new System.Drawing.Point(271, 110);
            this.EditTestButton.Name = "EditTestButton";
            this.EditTestButton.Size = new System.Drawing.Size(336, 38);
            this.EditTestButton.TabIndex = 20;
            this.EditTestButton.UseVisualStyleBackColor = false;
            this.EditTestButton.Click += new System.EventHandler(this.EditTestButton_Click);
            // 
            // RemoveTest
            // 
            this.RemoveTest.AutoSize = true;
            this.RemoveTest.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveTest.Location = new System.Drawing.Point(557, 14);
            this.RemoveTest.Name = "RemoveTest";
            this.RemoveTest.Size = new System.Drawing.Size(41, 31);
            this.RemoveTest.TabIndex = 16;
            this.RemoveTest.TabStop = true;
            this.RemoveTest.Text = "-";
            this.RemoveTest.UseVisualStyleBackColor = true;
            this.RemoveTest.CheckedChanged += new System.EventHandler(this.RemoveTest_CheckedChanged);
            // 
            // EnterTestName
            // 
            this.EnterTestName.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterTestName.Location = new System.Drawing.Point(271, 81);
            this.EnterTestName.Name = "EnterTestName";
            this.EnterTestName.Size = new System.Drawing.Size(336, 27);
            this.EnterTestName.TabIndex = 19;
            this.EnterTestName.EnabledChanged += new System.EventHandler(this.EnterTestName_EnabledChanged);
            this.EnterTestName.TextChanged += new System.EventHandler(this.EnterTestName_TextChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(271, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(336, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "Наименование";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.AddThemeButton);
            this.panel3.Controls.Add(this.EditThemeButton);
            this.panel3.Controls.Add(this.AddTheme);
            this.panel3.Controls.Add(this.RemoveTheme);
            this.panel3.Controls.Add(this.EditTheme);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.ListOfThemes);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.MathInformation);
            this.panel3.Controls.Add(this.ThemeName);
            this.panel3.Location = new System.Drawing.Point(11, 444);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1259, 397);
            this.panel3.TabIndex = 17;
            this.panel3.MouseEnter += new System.EventHandler(this.panel3_MouseEnter);
            // 
            // AddThemeButton
            // 
            this.AddThemeButton.BackColor = System.Drawing.Color.LimeGreen;
            this.AddThemeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddThemeButton.Location = new System.Drawing.Point(261, 128);
            this.AddThemeButton.Name = "AddThemeButton";
            this.AddThemeButton.Size = new System.Drawing.Size(261, 35);
            this.AddThemeButton.TabIndex = 37;
            this.AddThemeButton.Text = "Загрузить из файла";
            this.AddThemeButton.UseVisualStyleBackColor = false;
            this.AddThemeButton.Click += new System.EventHandler(this.AddThemeButton_Click);
            // 
            // EditThemeButton
            // 
            this.EditThemeButton.BackColor = System.Drawing.Color.Black;
            this.EditThemeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditThemeButton.Location = new System.Drawing.Point(258, 180);
            this.EditThemeButton.Name = "EditThemeButton";
            this.EditThemeButton.Size = new System.Drawing.Size(264, 43);
            this.EditThemeButton.TabIndex = 36;
            this.EditThemeButton.UseVisualStyleBackColor = false;
            this.EditThemeButton.Click += new System.EventHandler(this.EditThemeButton_Click);
            // 
            // AddTheme
            // 
            this.AddTheme.AutoSize = true;
            this.AddTheme.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddTheme.Location = new System.Drawing.Point(264, 7);
            this.AddTheme.Name = "AddTheme";
            this.AddTheme.Size = new System.Drawing.Size(47, 31);
            this.AddTheme.TabIndex = 33;
            this.AddTheme.TabStop = true;
            this.AddTheme.Text = "+";
            this.AddTheme.UseVisualStyleBackColor = true;
            this.AddTheme.CheckedChanged += new System.EventHandler(this.AddTheme_CheckedChanged);
            // 
            // RemoveTheme
            // 
            this.RemoveTheme.AutoSize = true;
            this.RemoveTheme.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveTheme.Location = new System.Drawing.Point(337, 5);
            this.RemoveTheme.Name = "RemoveTheme";
            this.RemoveTheme.Size = new System.Drawing.Size(41, 31);
            this.RemoveTheme.TabIndex = 34;
            this.RemoveTheme.TabStop = true;
            this.RemoveTheme.Text = "-";
            this.RemoveTheme.UseVisualStyleBackColor = true;
            this.RemoveTheme.CheckedChanged += new System.EventHandler(this.RemoveTheme_CheckedChanged);
            // 
            // EditTheme
            // 
            this.EditTheme.AutoSize = true;
            this.EditTheme.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditTheme.Location = new System.Drawing.Point(416, 10);
            this.EditTheme.Name = "EditTheme";
            this.EditTheme.Size = new System.Drawing.Size(99, 23);
            this.EditTheme.TabIndex = 35;
            this.EditTheme.TabStop = true;
            this.EditTheme.Text = "Изменить";
            this.EditTheme.UseVisualStyleBackColor = true;
            this.EditTheme.CheckedChanged += new System.EventHandler(this.EditTheme_CheckedChanged);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(261, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(261, 36);
            this.label12.TabIndex = 32;
            this.label12.Text = "Наименование";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 36);
            this.label4.TabIndex = 31;
            this.label4.Text = "Все темы";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListOfThemes
            // 
            this.ListOfThemes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListOfThemes.FormattingEnabled = true;
            this.ListOfThemes.ItemHeight = 22;
            this.ListOfThemes.Location = new System.Drawing.Point(8, 42);
            this.ListOfThemes.Name = "ListOfThemes";
            this.ListOfThemes.Size = new System.Drawing.Size(241, 334);
            this.ListOfThemes.TabIndex = 30;
            this.ListOfThemes.SelectedIndexChanged += new System.EventHandler(this.ListOfThemes_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(529, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(706, 30);
            this.label11.TabIndex = 29;
            this.label11.Text = "Информация по теме";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormForAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 853);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.OperatingMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormForAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню администратора";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormForAdmin_FormClosed);
            this.Load += new System.EventHandler(this.FormForAdmin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выйтиИзУчётнойЗаписиToolStripMenuItem;
        private System.Windows.Forms.ListBox ListOfUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EnterUserName;
        private System.Windows.Forms.TextBox EnterPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EditUserButton;
        private System.Windows.Forms.Label OperatingMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox MathInformation;
        private System.Windows.Forms.TextBox ThemeName;
        private System.Windows.Forms.RadioButton AddUser;
        private System.Windows.Forms.RadioButton RemoveUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox EnterQuestion;
        private System.Windows.Forms.RadioButton AddQuestion;
        private System.Windows.Forms.RadioButton RemoveQuestion;
        private System.Windows.Forms.RadioButton ChangeQuestion;
        private System.Windows.Forms.ListBox ListOfQuestions;
        private System.Windows.Forms.ListBox ListOfTests;
        private System.Windows.Forms.RadioButton AddTest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button EditTestButton;
        private System.Windows.Forms.RadioButton RemoveTest;
        private System.Windows.Forms.TextBox EnterTestName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button EditQuestionButton;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button EditThemeButton;
        private System.Windows.Forms.RadioButton RemoveTheme;
        private System.Windows.Forms.RadioButton EditTheme;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox ListOfThemes;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button AddThemeButton;
        private System.Windows.Forms.RadioButton AddTheme;
        private System.Windows.Forms.Label EnumQuestions;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel4;
    }
}