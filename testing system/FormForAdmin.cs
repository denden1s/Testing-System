using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testing_system.Classes;
using testing_system.Classes.ForDataBase;

namespace testing_system
{
    public partial class FormForAdmin : Form
    {
        private Form1 form1;
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

        /// <summary>
        /// Конструктор формы администратора
        /// </summary>
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
            form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void FormForAdmin_Load(object sender, EventArgs e)
        {
            MathInformation.Enabled = false;
            EnumQuestions.Visible = false;
            label13.Visible = false;
            EditUserButton.Enabled = false;
            EditTestButton.Enabled = false;
            EditQuestionButton.Enabled = false;
            EditTestButton.Enabled = false;
            EditThemeButton.Enabled = false;
            AddThemeButton.Enabled = false;
            EnabledTextBoxes(false, EnterUserName, EnterPassword, ThemeName,
                textBox1, textBox2, textBox3, textBox4, EnterQuestion, EnterTestName);
            OperatingMode.Text = "Режим работы";
            openFileDialog1.Filter = "Rich Text Format|*.rtf";
            numbersOfQuestions = 0;
            SystemFunctions.Show(Users, ListOfUsers);
            SystemFunctions.Show(MathematicInfo, ListOfThemes);
            SystemFunctions.Show(TestNames, ListOfTests);

        }

        private void FormForAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //можно сделать сохранение данных несохраненных
            Application.Exit();
        }

        /// <summary>
        /// Необходим для визуального преобразования кнопки 
        /// </summary>
        private void ButtonAdd(Button _button)
        {
            _button.Text = "Добавить";
            _button.BackColor = Color.LimeGreen;
        }

        /// <summary>
        /// Необходим для визуального преобразования кнопки 
        /// </summary>
        private void ButtonRemove(Button _button)
        {
            _button.Text = "Удалить";
            _button.BackColor = Color.Red;
        }

        /// <summary>
        /// Необходим для графического преобразования кнопки "Изменение"
        /// </summary>
        private void ButtonModification(Button _button)
        {
            _button.Text = "Изменить";
            _button.BackColor = Color.LightSlateGray;
        }

        private void RemoveUser_EnabledChanged(object sender, EventArgs e)
        {
            EditUserButton.Enabled = true;
            ButtonRemove(EditUserButton);
            OperatingMode.Text = "Удаление пользователя";
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            //int[] a = new int[1000];
            //for (int i = 0; i < 1000; i++)
            //{
            //    a[i] = i;
            //}
            //SystemFunctions.MixQuestionsOrAnswers(a);
            //string q = "";
            //foreach (int aa in a)
            //{
            //    q += " " + Convert.ToString(aa);
            //}
            //MessageBox.Show(q);
            EnterUserName.Text = EnterUserName.Text.Trim();
            if (EditUserButton.Text == "Добавить")
            {
                SystemFunctions.Add(Users, EnterUserName, EnterPassword, ListOfUsers);
                SystemFunctions.ClearTextBox(EnterUserName, EnterPassword);
            }   
            else 
            {
                if ((ListOfUsers.Items.Count > 0)&&(ListOfUsers.SelectedIndex != -1))
                {
                    SystemFunctions.Remove(Users, listBoxUserId, ListOfUsers);
                    this.TopMost = true;
                    ListOfUsers.SetSelected(ListOfUsers.Items.Count - 1, true);
                }
                else
                    MessageBox.Show("Нечего удалять");
            }
        }

        private void AddUser_CheckedChanged(object sender, EventArgs e)
        {
            EditUserButton.Enabled = true;
            ButtonAdd(EditUserButton);
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
            //if ((ListOfUsers.Items.Count != 0) && (ListOfUsers.SelectedItems.Count == 0))
            //    ListOfUsers.SetSelected(ListOfUsers.Items.Count - 1, true);
            ListOfUsers.ClearSelected();
        }

        private void ListOfUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxUserId = ListOfUsers.SelectedIndex;          
        }

        private void EditThemeButton_Click(object sender, EventArgs e)
        {
            if (OperatingMode.Text == "Удаление информации")
            {                
                    SystemFunctions.Remove(MathematicInfo, listBoxMathId, ListOfThemes);
                    MathInformation.Clear();
                    ThemeName.Clear();
            }
            else if(OperatingMode.Text == "Изменение информации") 
            {
                SystemFunctions.Edit(MathematicInfo, ThemeName, MathInformation, listBoxMathId, ListOfThemes);
            }
            this.TopMost = true;
        }

        private void AddThemeButton_Click(object sender, EventArgs e)
        {
            MathInformation.Text = MathInformation.Text.Trim();
            ThemeName.Text = ThemeName.Text.Trim();
            ThemeName.Enabled = false;

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            MessageBox.Show("Файл добавлен");
            using (ApplicationContext db = new ApplicationContext())
            {
                SystemFunctions.Add(MathematicInfo, ThemeName, filename, ListOfThemes);
                db.SaveChanges();
                ThemeName.Clear();
            }
        }

        private void ListOfThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxMathId = ListOfThemes.SelectedIndex;
            if(ListOfThemes.Items.Count > 0)
            {
                if ((EditTheme.Checked) || (RemoveTheme.Checked))
                {
                    if (ListOfThemes.SelectedIndex == -1)
                    {
                        ListOfThemes.SetSelected(0, true);
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
            ButtonModification(EditThemeButton);
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
            ButtonRemove(EditThemeButton);
            SystemFunctions.ClearTextBox(ThemeName);
            MathInformation.Text = "";
            OperatingMode.Text = "Удаление информации";
            EditThemeButton.Enabled = true;
            AddThemeButton.Enabled = false;
            ThemeName.Enabled = false;
            MathInformation.Enabled = true;
            MathInformation.ReadOnly = true;
            if (ListOfThemes.Items.Count != 0)
                ListOfThemes.SetSelected(ListOfThemes.Items.Count - 1, true);
        }

        private void ThemeName_TextChanged(object sender, EventArgs e)
        {
            if ((ThemeName.TextLength > 6)&&(AddTheme.Checked))
                AddThemeButton.Enabled = true;
        }

        private void EditTheme_CheckedChanged(object sender, EventArgs e)
        {
            ThemeName.Clear();
            MathInformation.Clear();
            OperatingMode.Text = "Изменение информации";
            ThemeName.Enabled = true;
            MathInformation.Enabled = true;
            MathInformation.Enabled = true;
            MathInformation.ReadOnly = false;
            ButtonModification(EditThemeButton);
            EditThemeButton.Enabled = true;
            if (ListOfThemes.Items.Count != 0)
                ListOfThemes.SetSelected(ListOfThemes.Items.Count - 1, true);
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
                OperatingMode.BackColor = Color.Gray;
            else OperatingMode.BackColor = Color.White;
        }

        private void AddTest_CheckedChanged(object sender, EventArgs e)
        {
            OperatingMode.Text = "Добавление теста";
            ButtonAdd(EditTestButton);
            EnterTestName.Enabled = true;
            ListOfTests.ClearSelected();
            ListOfQuestions.Items.Clear();
            EditTestButton.Enabled = true;
            EnterTestName.Enabled = true;
            //if ((ListOfTests.SelectedIndex == -1)&&(ListOfTests.Items.Count > 0))
            //  ListOfTests.SetSelected(0, true);
        }

        private void RemoveTest_CheckedChanged(object sender, EventArgs e)
        {
            OperatingMode.Text = "Удаление теста";
            ButtonRemove(EditTestButton);
            EnterTestName.Enabled = false;
            if ((listBoxTestId == -1) && (ListOfTests.Items.Count > 0))
                ListOfTests.SetSelected(ListOfTests.Items.Count - 1, true);

            EditTestButton.Enabled = true;
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
                    EnterTestName.Clear();
                    EditQuestionButton.Enabled = false;
                    label13.Visible = false;
                    EnumQuestions.Visible = false;
                    EnumQuestions.Text = "10";
                    AddQuestion.Checked = false;
                    EnabledTextBoxes(false, textBox1, textBox2, textBox3, textBox4);
                    EditQuestionButton.Enabled = false;
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        QuestionNames.Clear();
                        ListOfQuestions.Items.Clear();
                        foreach (QuestionName qn in db.questionNames)
                        {
                            QuestionNames.Add(qn);
                        }
                    }
                    ListOfTests.Items.Clear();
                    foreach (TestName test in TestNames)
                    {
                        ListOfTests.Items.Add(test.Name);
                    }
                    numbersOfQuestions = 0;
                }
                else
                {
                    EditTestButton.Enabled = false;
                    EnterTestName.Enabled = false;
                    EnumQuestions.Text = Convert.ToString(10 - numbersOfQuestions);
                    label13.Visible = true;
                    EnumQuestions.Visible = true;
                    EnabledTextBoxes(true, textBox1, textBox2, textBox3, textBox4, EnterQuestion);
                    AddQuestion.Checked = true;
                }
            }
            else
            {
                if (ListOfTests.Items.Count > 0)
                {
                    SystemFunctions.Remove(TestNames, listBoxTestId, ListOfTests, ListOfQuestions);
                    //ListOfTests.SetSelected(ListOfTests.Items.Count - 1, true);
                    EnumQuestions.Visible = false;
                    label13.Visible = false;
                }
                else
                    MessageBox.Show("Нечего удалять");
                    
            }

        }

        private void AddQuestion_CheckedChanged(object sender, EventArgs e)
        {
            ButtonAdd(EditQuestionButton);
            EditQuestionButton.Enabled = true;
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
                        SystemFunctions.Add(QuestionAndAnswers, EnterQuestion.Text,
                            QuestionAndAnswers[0].TestID, QuestionAndAnswers[QuestionAndAnswers.Count - 1].QuestionID,
                            questions, ListOfQuestions);
                        SystemFunctions.ClearTextBox(textBox1, textBox2,
                                                  textBox3, textBox4, EnterQuestion);
                        SystemFunctions.Show(QuestionAndAnswers,
                            TestNames[ListOfTests.SelectedIndex].Name, ListOfQuestions, QuestionNames);
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
                        EditQuestionButton.Enabled = false;
                        MessageBox.Show("Невозможно удалить вопросы т.к. их должно быть минимум 10");
                    }
                    else
                    {
                        SystemFunctions.Remove(QuestionAndAnswers, lisboxQuestionId, ListOfQuestions);
                        EnumQuestions.Text = Convert.ToString(ListOfQuestions.Items.Count);
                    }
                }
                else
                    MessageBox.Show("Не выбран вопрос для удаления");
            }
            else if(ChangeQuestion.Checked)
            {
                SystemFunctions.Edit(QuestionAndAnswers, QuestionNames, lisboxQuestionId, ListOfQuestions,
                    ListOfTests, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, EnterQuestion.Text);
            }
        }

        private void EnterTestName_TextChanged(object sender, EventArgs e)
        {
            if (EnterTestName.TextLength > 6)
                EditTestButton.Enabled = true;
        }

        private void ListOfTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxTestId = ListOfTests.SelectedIndex;
            if ((listBoxTestId == -1) &&(ListOfTests.Items.Count > 0))
                listBoxTestId = 0;
            if(ListOfTests.Items.Count > 0)
                SystemFunctions.Show(QuestionAndAnswers,
                    TestNames[listBoxTestId].Name, ListOfQuestions, QuestionNames);
            if(QuestionNames.Count >= 10)
            {
                label13.Text = "Всего вопросов в тесте";
                EnumQuestions.Text = Convert.ToString(ListOfQuestions.Items.Count);
                label13.Visible = true;
                EnumQuestions.Visible = true;
            }
            SystemFunctions.ClearTextBox(textBox1, textBox2, textBox3, textBox4, EnterQuestion);
        }

        private void ListOfQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            lisboxQuestionId = ListOfQuestions.SelectedIndex;
            if (lisboxQuestionId == -1)
                lisboxQuestionId = 0;
            if ((RemoveQuestion.Checked) || (ChangeQuestion.Checked))
            {
                EditQuestionButton.Enabled = true;
                if(ListOfQuestions.Items.Count > 0)
                {
                    SystemFunctions.Show(QuestionNames, textBox1, textBox2,
                    textBox3, textBox4, lisboxQuestionId);
                    EnterQuestion.Text = QuestionNames[lisboxQuestionId].Name;
                }
            }
        }

        private void RemoveQuestion_CheckedChanged(object sender, EventArgs e)
        {
            if ((ListOfQuestions.SelectedIndex == -1) && (ListOfTests.Items.Count > 0))
                ListOfQuestions.SetSelected(ListOfQuestions.Items.Count - 1, true);
            ButtonRemove(EditQuestionButton);
            OperatingMode.Text = "Удаление вопроса";
            EnabledTextBoxes(false, textBox1, textBox2, textBox3, textBox4, EnterQuestion);
            if (ListOfTests.SelectedIndex == -1)
            {
                EditQuestionButton.Enabled = false;
            }
            if ((ListOfQuestions.Items.Count > 0) && (ListOfQuestions.SelectedIndex == -1))
                ListOfQuestions.SetSelected(ListOfQuestions.Items.Count - 1, true);
            if (EnterTestName.Enabled == false)
                AddQuestion.Checked = true;
        }

        private void ChangeQuestion_CheckedChanged(object sender, EventArgs e)
        {
            if ((ListOfTests.SelectedIndex == -1) && (ListOfTests.Items.Count > 0))
        {
            ListOfTests.SetSelected(ListOfTests.Items.Count - 1, true);
        }
            ListOfQuestions.SetSelected(0, true);
            EnabledTextBoxes(true, textBox1, textBox2, textBox3,
                      textBox4, EnterQuestion);

            ButtonModification(EditQuestionButton);
            OperatingMode.Text = "Изменение вопроса";
            if (ListOfTests.SelectedIndex == -1)
            {
                EditQuestionButton.Enabled = false;
                EnabledTextBoxes(false, textBox1, textBox2, textBox3, textBox4, EnterQuestion);
            }
            //if (EnterTestName.Enabled == false)
            //    AddQuestion.Checked = true;

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

    }
}