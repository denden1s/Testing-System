using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using testing_system.Classes;
using testing_system.Classes.ForDataBase;

namespace testing_system
{
    public partial class FormForAdmin : Form
    {
        //Необходимо для перехода к окну авторизации
        private AuthorizationForm form1;

        //необходимы для хранения информации из БД
        private List<InformationAboutMath> MathematicInfo;
        private List<QuestionAndAnswer> QuestionAndAnswers;
        private List<QuestionName> QuestionNames;
        private List<TestName> TestNames;
        private List<User> Users;

        //необходима для хранения идентификатора пользователя в LisBox-е 
        private int listBoxUserId;

        //аналогично полю listBoxUserId;
        private int listBoxMathId;

        //аналогично полю listBoxUserId;
        private int listBoxTestId;

        //аналогично полю listBoxUserId;
        private int lisboxQuestionId;

        //необходимо для подсчета количества вопросов в тесте при его создании
        private int numbersOfQuestions;

        //необходимо для хранения списка ответов на вопросы теста при создании
        private string[,] questions;

        //необходимо для хранения наименований вопросов при создании теста
        private string[] qNames;

        public FormForAdmin()
        {
            Users = new List<User>();
            MathematicInfo = new List<InformationAboutMath>();
            QuestionAndAnswers = new List<QuestionAndAnswer>();
            QuestionNames = new List<QuestionName>();
            TestNames = new List<TestName>();
            questions = new string[10, 4];
            qNames = new string[10];
            InitializeComponent();
        }

        private void выйтиИзУчётнойЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form1 = new AuthorizationForm();
            form1.Show();
            this.Hide();
        }

        private void FormForAdmin_Load(object sender, EventArgs e)
        {
            this.HelpButton = true;
            MathInformation.Enabled = false;
            EnumQuestions.Visible = false;
            label13.Visible = false;
            ChangeButtonEnabled(false, EditUserButton, 
                EditTestButton, EditThemeButton, AddThemeButton, EditQuestionButton);
            EnabledTextBoxes(false, EnterUserName, EnterPassword, ThemeName,
                textBox1, textBox2, textBox3, textBox4, EnterQuestion, EnterTestName);
            OperatingMode.Text = "Режим работы";
            openFileDialog1.Filter = "Rich Text Format|*.rtf";
            numbersOfQuestions = 0;
            ShowUsers();
            ShowMathThemes();
            ShowTest();
        }

        private void FormForAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Необходимы для изменения кнопок
        private void ButtonAdd(Button _button)
        {
            _button.Text = "Добавить";
            _button.BackColor = Color.LimeGreen;
        }

        private void ButtonRemove(Button _button)
        {
            _button.Text = "Удалить";
            _button.BackColor = Color.Red;
        }

        private void ButtonModification(Button _button)
        {
            _button.Text = "Изменить";
            _button.BackColor = Color.LightBlue;
        }

        private void RemoveUser_EnabledChanged(object sender, EventArgs e)
        {
            EditUserButton.Enabled = true;
            ButtonRemove(EditUserButton);
            OperatingMode.Text = "Удаление пользователя";
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            EnterUserName.Text = EnterUserName.Text.Trim();
            if (EditUserButton.Text == "Добавить")
                SystemFunctions.Add(Users, EnterUserName, EnterPassword); 
            else 
                SystemFunctions.Remove(Users, listBoxUserId);

            ShowUsers();
            if(EditUserButton.Text == "Удалить")
                ListOfUsers.SetSelected(0, true);
        }

        private void AddUser_CheckedChanged(object sender, EventArgs e)
        {
            EnterUserName_TextChanged(sender, e);
            EditUserButton.Text = "Добавить";
            OperatingMode.Text = "Добавление пользователя";
            EnabledTextBoxes(true, EnterUserName, EnterPassword);
            ListOfUsers.ClearSelected();
        }

        private void RemoveUser_CheckedChanged(object sender, EventArgs e)
        {
            EditUserButton.Enabled = true;
            ButtonRemove(EditUserButton);
            OperatingMode.Text = "Удаление пользователя";
            EnabledTextBoxes(false, EnterUserName, EnterPassword);
            SystemFunctions.ClearTextBox(EnterUserName, EnterPassword);
            ListOfUsers.SetSelected(0, true);
        }

        private void ListOfUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxUserId = ListOfUsers.SelectedIndex;          
        }

        private void EditThemeButton_Click(object sender, EventArgs e)
        {
            if (OperatingMode.Text == "Удаление информации")
            {
                if ((ListOfThemes.Items.Count > 0) && (ListOfThemes.SelectedIndex != -1))
                {
                    SystemFunctions.Remove(MathematicInfo, listBoxMathId);
                    MathInformation.Clear();
                    ThemeName.Clear();
                }
                else MessageBox.Show("Нечего удалять");
            }
            else if(OperatingMode.Text == "Изменение информации") 
            {
                if ((ListOfThemes.SelectedItems.Count > 0) && (ListOfThemes.SelectedIndex != -1))
                {
                    SystemFunctions.Edit(MathematicInfo, ThemeName, MathInformation, listBoxMathId);
                    MathInformation.Clear();
                    ThemeName.Clear();
                }
                else
                    MessageBox.Show("Нечего изменять");
            }
            ShowMathThemes();
        }

        private void AddThemeButton_Click(object sender, EventArgs e)
        {
            MathInformation.Text = MathInformation.Text.Trim();
            ThemeName.Text = ThemeName.Text.Trim();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            SystemFunctions.Add(MathematicInfo, ThemeName, filename);
            ShowMathThemes();
            ThemeName.Clear();
        }

        private void ListOfThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxMathId = ListOfThemes.SelectedIndex;
            if(ListOfThemes.Items.Count > 0)
            {
                if ((EditTheme.Checked) || (RemoveTheme.Checked))
                {
                    if ((ListOfThemes.SelectedIndex == -1)&&(ListOfQuestions.SelectedIndex == -1))
                    {
                        ListOfThemes.SetSelected(ListOfThemes.Items.Count - 1, true);
                        listBoxMathId = 0;
                    }
                    ThemeName.Text = MathematicInfo[listBoxMathId].Name;
                    if (MathematicInfo[listBoxMathId].ThemeContent.Contains("rtf"))
                    {
                        MathInformation.LoadFile(MathematicInfo[listBoxMathId].ThemeContent);
                    }
                }
            }            
        }

        private void AddTheme_CheckedChanged(object sender, EventArgs e)
        {
            ListOfThemes.ClearSelected();
            AddThemeButton.Enabled = false;
            OperatingMode.Text = "Добавление информации";
            ThemeName.Enabled = true;
            MathInformation.Enabled = false;
            MathInformation.ReadOnly = true;
            EditThemeButton.Enabled = false;
            ListOfUsers.ClearSelected();
        }

        private void RemoveTheme_CheckedChanged(object sender, EventArgs e)
        {
            AddThemeButton.BackColor = Color.DarkGray;
            SystemFunctions.ClearTextBox(ThemeName);
            MathInformation.Text = "";
            OperatingMode.Text = "Удаление информации";
            EditThemeButton.Text = "Удалить";
            AddThemeButton.Enabled = false;
            ThemeName.Enabled = false;
            MathInformation.Enabled = true;
            MathInformation.ReadOnly = true;
            if ((ListOfThemes.Items.Count != 0) && (ListOfThemes.SelectedIndex == -1))
                ListOfThemes.SetSelected(ListOfThemes.Items.Count - 1, true);
            else
                ListOfThemes_SelectedIndexChanged(sender, e);
        }

        private void ThemeName_TextChanged(object sender, EventArgs e)
        {
            if (AddTheme.Checked)
            {
                if(ThemeName.TextLength > 6)
                {
                    AddThemeButton.Enabled = true;
                    ButtonAdd(AddThemeButton);
                }
                else
                {
                    AddThemeButton.Enabled = false;
                    AddThemeButton.BackColor = Color.DarkGray;
                }
            }
            if (RemoveTheme.Checked)              
            {
                if(ThemeName.TextLength > 6)
                {
                    EditThemeButton.Enabled = true;
                    ButtonRemove(EditThemeButton);
                }
                else
                {
                    EditThemeButton.Enabled = false;
                    EditThemeButton.BackColor = Color.DarkGray;
                }
            }
            if(EditTheme.Checked) 
            {
                if ((ThemeName.TextLength > 6) && (ListOfThemes.SelectedIndex != -1))
                {
                    EditThemeButton.Enabled = true;
                    ButtonModification(EditThemeButton);
                }
                else
                {
                    EditThemeButton.Enabled = false;
                    EditThemeButton.BackColor = Color.DarkGray;
                }
            }
        }

        private void EditTheme_CheckedChanged(object sender, EventArgs e)
        {
            AddThemeButton.BackColor = Color.DarkGray;
            ThemeName.Clear();
            MathInformation.Clear();
            OperatingMode.Text = "Изменение информации";
            EditThemeButton.Text = "Изменить";
            ThemeName.Enabled = true;
            MathInformation.Enabled = true;
            MathInformation.Enabled = true;
            MathInformation.ReadOnly = false;
            if ((ListOfThemes.Items.Count != 0) && (ListOfThemes.SelectedIndex == -1))
                ListOfThemes.SetSelected(ListOfThemes.Items.Count - 1, true);
            else
                ListOfThemes_SelectedIndexChanged(sender, e);
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            if (AddUser.Checked)
                OperatingMode.Text = "Добавление пользователя";
            else if (RemoveUser.Checked)
                OperatingMode.Text = "Удаление пользователя";
            else
                OperatingMode.Text = "Взаимодействие с пользователями";
            OperatingMode_TextChanged(sender, e);
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            if (AddTest.Checked)
                OperatingMode.Text = "Добавление теста";
            else if (RemoveTest.Checked)
                OperatingMode.Text = "Удаление теста";           
            else if (AddQuestion.Checked)
                OperatingMode.Text = "Добавление вопроса";
            else if (RemoveQuestion.Checked)
                OperatingMode.Text = "Удаление вопроса";
            else if(ChangeQuestion.Checked)
                OperatingMode.Text = "Изменение вопроса";
            else
                OperatingMode.Text = "Взаимодействие с тестом";
            OperatingMode_TextChanged(sender, e);
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            if (AddTheme.Checked)
                OperatingMode.Text = "Добавление информации";
            else if (RemoveTheme.Checked)
                OperatingMode.Text = "Удаление информации";
            else if (EditTheme.Checked)
                OperatingMode.Text = "Изменение информации";
            else
                OperatingMode.Text = "Взаимодействие с информацией";
            OperatingMode_TextChanged(sender, e);
        }

        private void OperatingMode_TextChanged(object sender, EventArgs e)
        {
            if(OperatingMode.Text.Contains("Добавление"))
                OperatingMode.BackColor = Color.LimeGreen;
            else if(OperatingMode.Text.Contains("Удаление"))
                OperatingMode.BackColor = Color.Red;
            else if(OperatingMode.Text.Contains("Изменение"))
                OperatingMode.BackColor = Color.LightBlue;
            else OperatingMode.BackColor = Color.White;
        }

        private void AddTest_CheckedChanged(object sender, EventArgs e)
        {
            OperatingMode.Text = "Добавление теста";

            EnterTestName.Clear();
            EditTestButton.Text = "Добавить";
            EditTestButton.BackColor = Color.DarkGray;
            ListOfTests.ClearSelected();
            ListOfQuestions.Items.Clear();
            EnterTestName.Enabled = true;
            EditTestButton.Enabled = false;
        }

        private void RemoveTest_CheckedChanged(object sender, EventArgs e)
        {
            OperatingMode.Text = "Удаление теста";
            EditTestButton.Text = "Удалить";
            EnterTestName.Enabled = false;
            if ((ListOfTests.SelectedIndex == -1) && (ListOfTests.Items.Count > 0))
            {
                ListOfTests.SetSelected(ListOfTests.Items.Count - 1, true);
                EnterTestName.Text = TestNames[ListOfTests.SelectedIndex].Name;
                EditTestButton.Enabled = true;
            }    
        }

        private void EditTest_CheckedChanged(object sender, EventArgs e)
        {
            OperatingMode.Text = "Изменение теста";
            ButtonModification(EditTestButton);
        }

        private void EditTestButton_Click(object sender, EventArgs e)
        {
            if(AddTest.Checked)
            {
                if (numbersOfQuestions == 10)
                {
                    EditTestButton.Enabled = true;
                    EnterTestName.Enabled = true;
                    EnterTestName.Text.Trim();
                    SystemFunctions.Add(TestNames, QuestionAndAnswers,
                        EnterTestName.Text, qNames, questions);
                    EditQuestionButton.Enabled = false;
                    label13.Visible = false;
                    EnumQuestions.Visible = false;
                    EnumQuestions.Text = "10";
                    EnumQuestions.ForeColor = Color.Black;
                    label13.ForeColor = Color.Black;
                    AddQuestion.Checked = false;
                    EnabledTextBoxes(false, textBox1, textBox2, textBox3, textBox4);
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        QuestionNames.Clear();
                        ListOfQuestions.Items.Clear();
                        foreach (QuestionName qn in db.questionNames)
                        {
                            QuestionNames.Add(qn);
                        }
                    }
                    ShowTest();
                    numbersOfQuestions = 0;
                }
                else
                {
                    EditTestButton.Enabled = false;
                    EnterTestName.Enabled = false;
                    EnumQuestions.Text = Convert.ToString(10 - numbersOfQuestions);
                    label13.ForeColor = Color.Red;
                    label13.Text = "Осталось вопросов:";
                    label13.Visible = true;
                    EnumQuestions.Visible = true;
                    EnumQuestions.ForeColor = Color.Red; 
                    EnabledTextBoxes(true, textBox1, textBox2, textBox3, textBox4, EnterQuestion);
                    AddQuestion.Checked = true;
                }
            }
            else
            {
                if ((ListOfTests.Items.Count > 0) && (ListOfTests.SelectedIndex != -1))
                {
                    SystemFunctions.Remove(TestNames, ListOfTests.SelectedIndex);
                    ListOfQuestions.Items.Clear();
                    ShowTest();
                    if (ListOfTests.Items.Count == 0)
                        EditTestButton.BackColor = Color.DarkGray;
                    EnumQuestions.Visible = false;
                    label13.Visible = false;
                }
                else
                    MessageBox.Show("Не выбрана информация для удаления");   
            }
        }

        private void AddQuestion_CheckedChanged(object sender, EventArgs e)
        {
            if(RemoveTest.Checked)
            {
                RemoveTest.Checked = false;
                EditTestButton.Enabled = false;
                EnterTestName.Clear();
                EditTestButton.Text = "";
                EditTestButton.BackColor = Color.DarkGray;
            }
            EditQuestionButton.Text = "Добавить";
            EnabledTextBoxes(true, textBox1, textBox2, textBox3, textBox4, EnterQuestion);
            if ((ListOfTests.SelectedIndex == -1) && (ListOfTests.Items.Count > 0))
            {
                EditQuestionButton.Enabled = false;
                EnabledTextBoxes(false, textBox1, textBox2, textBox3, textBox4, EnterQuestion);
                ListOfTests.SetSelected(0, true);
            }
            SystemFunctions.ClearTextBox(textBox1, textBox2, textBox3, textBox4, EnterQuestion);
            OperatingMode.Text = "Добавление вопроса";
            if(ListOfQuestions.Items.Count > 10)
            {
                label13.Text = "Всего вопросов в тесте";
                EnumQuestions.Text = Convert.ToString(ListOfQuestions.Items.Count);
            }       
        }

        private void EditQuestionButton_Click(object sender, EventArgs e)
        {
            textBox1.Text.Trim();
            textBox2.Text.Trim();
            textBox3.Text.Trim();
            textBox4.Text.Trim();
            if ((AddQuestion.Checked)&&(ListOfQuestions.Items.Count < 10))
            {
                if (numbersOfQuestions < 10)
                {
                    if ((textBox1.TextLength > 0) && (textBox2.TextLength > 0) &&
                       (textBox3.TextLength > 0) && (textBox4.TextLength > 0) && (EnterQuestion.TextLength > 0))
                    {
                        questions[numbersOfQuestions, 0] = textBox1.Text;
                        questions[numbersOfQuestions, 1] = textBox2.Text;
                        questions[numbersOfQuestions, 2] = textBox3.Text;
                        questions[numbersOfQuestions, 3] = textBox4.Text;

                        EnumQuestions.Text = Convert.ToString(10 - numbersOfQuestions - 1);
                        qNames[numbersOfQuestions] = EnterQuestion.Text;
                        SystemFunctions.ClearTextBox(EnterQuestion, textBox1,
                            textBox2, textBox3, textBox4);
                        numbersOfQuestions++;
                    }
                    else
                        MessageBox.Show("Не все поля были заполнены");
                }
                if (numbersOfQuestions == 10)
                {

                    EditTestButton_Click(sender, e);
                }
            }
            else if ((AddQuestion.Checked)&&(ListOfQuestions.Items.Count >= 10))
            {
                    if ((textBox1.TextLength > 0) && (textBox2.TextLength > 0) &&
                       (textBox3.TextLength > 0) && (textBox4.TextLength > 0) && (EnterQuestion.TextLength > 0))
                    {
                    string[] questions = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text };
                ListOfQuestions.Items.Clear();

                    SystemFunctions.Add(QuestionAndAnswers, EnterQuestion.Text, QuestionAndAnswers[0].TestID,
                        QuestionAndAnswers[QuestionAndAnswers.Count - 1].QuestionID, questions);

                    SystemFunctions.ClearTextBox(textBox1, textBox2, textBox3, textBox4, EnterQuestion);

                    SystemFunctions.GetList(QuestionAndAnswers,
                        TestNames[ListOfTests.SelectedIndex].Name, QuestionNames);

                    ListOfQuestions.Items.Clear();
                    foreach (var item in QuestionNames)
                    {
                        ListOfQuestions.Items.Add(item.Name);
                    }
                    EnumQuestions.Text = Convert.ToString(ListOfQuestions.Items.Count);
                    }
                    else
                        MessageBox.Show("Не все поля были заполнены");
            }
            else if (RemoveQuestion.Checked)
            {
                if (ListOfQuestions.SelectedIndex != -1)
                {
                    if (QuestionAndAnswers.Count <= 10)
                    {
                        MessageBox.Show("Невозможно удалить вопросы т.к. их должно быть минимум 10");
                    }
                    else 
                    {
                        SystemFunctions.Remove(QuestionAndAnswers, lisboxQuestionId);
                        ListOfQuestions.Items.Clear();
                        foreach (var item in QuestionNames)
                        {
                            ListOfQuestions.Items.Add(item.Name);
                        }
                        SystemFunctions.ClearTextBox(textBox1, textBox2, textBox3, textBox4, EnterQuestion);
                        SystemFunctions.GetList(QuestionAndAnswers, TestNames[listBoxTestId].Name, QuestionNames);
                        ListOfQuestions.Items.Clear();
                        foreach (var item in QuestionNames)
                        {
                            ListOfQuestions.Items.Add(item.Name);
                        }
                        EnumQuestions.Text = Convert.ToString(ListOfQuestions.Items.Count);
                    }
                }
                else
                    MessageBox.Show("Не выбран вопрос для удаления");
            }
            else if(ChangeQuestion.Checked)
            {
                if (ListOfQuestions.SelectedIndex != -1)
                {
                    SystemFunctions.Edit(QuestionAndAnswers, ListOfQuestions.SelectedIndex,
                   textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, EnterQuestion.Text);
                    ListOfQuestions.Items.Clear();
                    foreach (var item in QuestionNames)
                    {
                        ListOfQuestions.Items.Add(item.Name);
                    }
                    SystemFunctions.ClearTextBox(textBox1, textBox2, textBox3, textBox4, EnterQuestion);
                }
                else
                    MessageBox.Show("Не выбран вопрос для изменения");  
            }
        }

        private void EnterTestName_TextChanged(object sender, EventArgs e)
        {

            if (AddTest.Checked)
            {
                if (EnterTestName.TextLength > 6)
                {
                    ButtonAdd(EditTestButton);
                    EditTestButton.Enabled = true;
                }
                else
                {
                    EditTestButton.Enabled = false;
                    EditTestButton.BackColor = Color.DarkGray;
                }
            }   
        }

        private void ListOfTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxTestId = ListOfTests.SelectedIndex;
            if ((listBoxTestId == -1) && (ListOfTests.Items.Count > 0))
            {
                listBoxTestId = 0;
                ListOfTests.SetSelected(0, true);
            }
            if (ListOfTests.Items.Count > 0)
                ShowQuestions();

            if (QuestionNames.Count >= 10)
            {
                label13.Text = "Всего вопросов в тесте";
                EnumQuestions.Text = Convert.ToString(ListOfQuestions.Items.Count);
                label13.Visible = true;
                EnumQuestions.Visible = true;
            }
            SystemFunctions.ClearTextBox(textBox1, textBox2, textBox3, textBox4, EnterQuestion);
            if (RemoveTest.Checked)
            {
                if(ListOfTests.Items.Count > 0)
                {
                    ButtonRemove(EditTestButton);
                    EditTestButton.Enabled = true;
                }
                else
                {
                    EditTestButton.Enabled = false;
                    EditTestButton.BackColor = Color.DarkGray;
                }     
            }
        }

        private void ListOfQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            lisboxQuestionId = ListOfQuestions.SelectedIndex;
            if (lisboxQuestionId == -1)
                lisboxQuestionId = 0;
            if ((ChangeQuestion.Checked) || (RemoveQuestion.Checked))
            {
                if ((ListOfThemes.SelectedIndex == -1) && (ListOfQuestions.SelectedIndex == -1))
                {
                    ListOfQuestions.SetSelected(ListOfQuestions.Items.Count - 1, true);
                    listBoxTestId = 0;
                }
                EditQuestionButton.Enabled = true;
                if((ListOfQuestions.Items.Count > 0)&&(ListOfQuestions.SelectedIndex != -1))
                {
                    SystemFunctions.Show(QuestionNames, textBox1, textBox2,
                    textBox3, textBox4, lisboxQuestionId);                  
                    EnterQuestion.Text = QuestionNames[lisboxQuestionId].Name;
                }
            }
        }

        private void RemoveQuestion_CheckedChanged(object sender, EventArgs e)
        {
            if (RemoveTest.Checked)
            {
                RemoveTest.Checked = false;
                EditTestButton.Enabled = false;
                EnterTestName.Clear();
                EditTestButton.Text = "";
                EditTestButton.BackColor = Color.DarkGray;
            }
            EditQuestionButton.Text = "Удалить";
            OperatingMode.Text = "Удаление вопроса";
            EnabledTextBoxes(false, textBox1, textBox2, textBox3, textBox4, EnterQuestion);
            if (ListOfTests.SelectedIndex == -1)
            {
                EditQuestionButton.Enabled = false;
                EditQuestionButton.BackColor = Color.DarkGray;
            }
            if ((EnterTestName.Enabled == false)&& (EnterTestName.TextLength != 0))
                AddQuestion.Checked = true;

            if((ListOfTests.SelectedIndex != -1) && (ListOfQuestions.SelectedIndex != -1))
            {
                SystemFunctions.Show(QuestionNames, textBox1, textBox2,
                    textBox3, textBox4, lisboxQuestionId);
                EnterQuestion.Text = QuestionNames[lisboxQuestionId].Name;
                EditQuestionButton.BackColor = Color.Red;
            }
            if((ListOfQuestions.SelectedIndex == -1) && (ListOfQuestions.Items.Count > 0))
            {
                ListOfQuestions.SetSelected(ListOfQuestions.Items.Count - 1, true);  
            }
        }

        private void ChangeQuestion_CheckedChanged(object sender, EventArgs e)
        {
            if (RemoveTest.Checked)
            {
                RemoveTest.Checked = false;
                EditTestButton.Enabled = false;
                EnterTestName.Clear();
                EditTestButton.Text = "";
                EditTestButton.BackColor = Color.DarkGray;
            }
            if ((EnterTestName.Enabled == false) && (EnterTestName.TextLength != 0))
                AddQuestion.Checked = true;
            else
            {
                if ((ListOfQuestions.SelectedIndex == -1) && 
                    (ListOfTests.SelectedIndex != -1) && (ListOfQuestions.Items.Count > 0))
                    ListOfQuestions.SetSelected(ListOfQuestions.Items.Count - 1, true);

                EnabledTextBoxes(true, textBox1, textBox2, textBox3,
                          textBox4, EnterQuestion);
                OperatingMode.Text = "Изменение вопроса";
                EditQuestionButton.Text = "Изменить";
                if (ListOfQuestions.SelectedIndex == -1)
                {
                    EditQuestionButton.Enabled = false;
                    EnabledTextBoxes(false, textBox1, textBox2, textBox3, textBox4, EnterQuestion);
                }
                if ((ListOfTests.SelectedIndex != -1) && (ListOfQuestions.SelectedIndex != -1))
                {
                    SystemFunctions.Show(QuestionNames, textBox1, textBox2,
                        textBox3, textBox4, lisboxQuestionId);
                    EnterQuestion.Text = QuestionNames[lisboxQuestionId].Name;
                    EditQuestionButton.BackColor = Color.LightBlue;
                }
            }   
        }

        private void EnabledTextBoxes(bool _status, params TextBox[] _textBoxes)
        {
            var objects = _textBoxes;
            for (int i = 0; i < _textBoxes.Length; i++)
            {
                _textBoxes[i].Enabled = _status;
            }
        }

        private void EnterTestName_EnabledChanged(object sender, EventArgs e)
        {
            if(EnterTestName.TextLength > 0)
            {
                ListOfQuestions.Items.Clear();
                ListOfTests.Items.Clear();
            }
        }

        private void FormForAdmin_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            string fbPath = Application.StartupPath;
            string fname = "NewProject.chm";
            string filename = fbPath + @"\" + fname;
            Help.ShowHelp(this, filename, HelpNavigator.Find, "");
        }

        private void ChangeButtonEnabled(bool _status, params Button[] _buttons)
        {
            for (int i = 0; i < _buttons.Length; i++)
                _buttons[i].Enabled = _status;
        }

        private void ShowUsers()
        {
            ListOfUsers.Items.Clear(); 
            Users.Clear();
            SystemFunctions.GetList(Users);
            foreach (User u in Users)
            {
                ListOfUsers.Items.Add(u.Name);
            }
            SystemFunctions.ClearTextBox(EnterPassword, EnterUserName);
        }

        private void ShowMathThemes()
        {
            ListOfThemes.Items.Clear();
            MathematicInfo.Clear();
            SystemFunctions.GetList(MathematicInfo);
            foreach (InformationAboutMath info in MathematicInfo)
            {
                ListOfThemes.Items.Add(info.Name);
            }
            SystemFunctions.ClearTextBox(ThemeName);
            MathInformation.Clear();
        }

        private void ShowTest()
        {
            ListOfTests.Items.Clear();
            TestNames.Clear();
            SystemFunctions.GetList(TestNames);
            foreach (TestName item in TestNames)
            {
                ListOfTests.Items.Add(item.Name);
            }
            SystemFunctions.ClearTextBox(EnterTestName);
            MathInformation.Clear();
        }

        private void ShowQuestions()
        {
            ListOfQuestions.Items.Clear();
            SystemFunctions.GetList(QuestionAndAnswers, TestNames[listBoxTestId].Name, QuestionNames);
            ListOfQuestions.Items.Clear();
            foreach (var item in QuestionNames)
            {
                ListOfQuestions.Items.Add(item.Name);
            }
        }

        private void EnterUserName_TextChanged(object sender, EventArgs e)
        {
            if ((EnterUserName.TextLength > 2) && (EnterPassword.TextLength > 0))
            {
                EditUserButton.Enabled = true;
                ButtonAdd(EditUserButton);
            }
            else
            {
                EditUserButton.BackColor = Color.DarkGray;
                EditUserButton.Enabled = false;
            }

        }

        private void EnterPassword_TextChanged(object sender, EventArgs e)
        {
            EnterUserName_TextChanged(sender, e);
        }

        private void EnterQuestion_TextChanged(object sender, EventArgs e)
        {
            if((EnterQuestion.TextLength == 0) || (textBox1.TextLength == 0) || (textBox2.TextLength == 0)
                    || (textBox3.TextLength == 0) || (textBox4.TextLength == 0))
            {
                EditQuestionButton.BackColor = Color.DarkGray;
                EditQuestionButton.Enabled = false;
            }
            else
            {
                EditQuestionButton.Enabled = true;
                if (ChangeQuestion.Checked)
                    ButtonModification(EditQuestionButton);
                if (RemoveQuestion.Checked)
                    ButtonRemove(EditQuestionButton);
                if (AddQuestion.Checked)
                    ButtonAdd(EditQuestionButton);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            EnterQuestion_TextChanged(sender, e);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            EnterQuestion_TextChanged(sender, e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            EnterQuestion_TextChanged(sender, e);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            EnterQuestion_TextChanged(sender, e);
        }
    }
}