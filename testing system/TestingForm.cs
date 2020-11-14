using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testing_system.Classes;
using testing_system.Classes.ForDataBase;

namespace testing_system
{

    public partial class TestingForm : Form
    {
        //Необходимы для передачи информации о пользователе и 
        //тесте с формы пользователя
        private User user;
        private TestName test;

        //Необходим для выгрузки всех вопросов теста и 
        // их последующего перемешивания
        private List<QuestionName> questionNames;

        //Необходим для выгрузки ответов на вопросы
        private List<QuestionAndAnswer> AnswersList;

        //Необходим для сохранения ответов пользователя
        private List<UserAnswer> userAnswers;

        //Необходим для хранения правильных ответов на 10 вопросов из теста
        private List<string> tenAnswers;

        //Необходим для хранения перемешанных ответов на вопросы 
        private string[,] answers; 

        //Необходимо для слежкой за количеством отвеченных вопросов
        private int numberOfQuestion;

        //Необходимо для перехода к предыдущей форме после прохождения теста
        private FormForUser form;

        //необходимо для подсчета отметки за тест
        private int mark;

        //Необходимы для организации лимита времени на ответ
        private Stopwatch timerForAnswers;
        private double secondsOnAnswer;

        //организация блокирования функции перетаскивания формы
        const int SC_CLOSE = 0xF010;
        const int MF_BYCOMMAND = 0;
        const int WM_NCLBUTTONDOWN = 0x00A1;
        const int WM_NCHITTEST = 0x0084;
        const int HTCAPTION = 2;
        [DllImport("User32.dll")]
        static extern int SendMessage(IntPtr hWnd,
        int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32.dll")]
        static extern bool RemoveMenu(IntPtr hMenu, int uPosition, int uFlags);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDOWN)
            {
                int result = SendMessage(m.HWnd, WM_NCHITTEST,
                IntPtr.Zero, m.LParam);
                if (result == HTCAPTION)
                    return;
            }
            base.WndProc(ref m);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            IntPtr hMenu = GetSystemMenu(Handle, false);
            RemoveMenu(hMenu, SC_CLOSE, MF_BYCOMMAND);
        }
        public TestingForm()
        {
            InitializeComponent();     
            this.Width = DesktopScreen.Width;
            this.Height = DesktopScreen.Height;
            this.TopMost = true;
            questionNames = new List<QuestionName>();
            tenAnswers = new List<string>();
            AnswersList = new List<QuestionAndAnswer>();
            numberOfQuestion = 0;
            mark = 0;
            secondsOnAnswer = 120;
            timerForAnswers = new Stopwatch();
            userAnswers = new List<UserAnswer>();
        }

        public TestingForm(User _user, TestName _test)
            :this()
        {
            user = _user;
            test = _test;
        }

        private void TestingForm_Load(object sender, EventArgs e)
        {
            radioButton5.Visible = false;
            radioButton5.Text = "Истекло время ответа";
            SystemFunctions.GetList(AnswersList, test.Name, questionNames);
            questionNames = SystemFunctions.PrepareQuestions(test.TestID);
            answers = new string[questionNames.Count, 4];
            for (int i = 0; i < questionNames.Count; i++)
            {
                answers[i, 0] = AnswersList[i].RightAnswer;
                answers[i, 1] = AnswersList[i].WrongAnswer_1;
                answers[i, 2] = AnswersList[i].WrongAnswer_2;
                answers[i, 3] = AnswersList[i].WrongAnswer_3;  
            }
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            NumberOfQuestion.Visible = false;
            label2.Visible = false;
            radioButton1.Text = "";
            radioButton2.Text = "";
            radioButton3.Text = "";
            radioButton4.Text = "";
            this.Text = test.Name;
        }

        //Необходим для запуска теста и задания параметров после
        //ответов на вопросы
        private void button1_Click(object sender, EventArgs e)
        {
            timerForAnswers.Stop();
            timerForAnswers.Reset();
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            NumberOfQuestion.Visible = true;
            label2.Visible = true;
            tenAnswers.Add(answers[questionNames[numberOfQuestion].QuestionID, 0]);
            SystemFunctions.MixAnswers(ref answers, questionNames[numberOfQuestion].QuestionID);
            radioButton1.Text = answers[questionNames[numberOfQuestion].QuestionID, 0];
            radioButton2.Text = answers[questionNames[numberOfQuestion].QuestionID, 1];
            radioButton3.Text = answers[questionNames[numberOfQuestion].QuestionID, 2];
            radioButton4.Text = answers[questionNames[numberOfQuestion].QuestionID, 3];
            QuestionContent.Text = questionNames[numberOfQuestion].Name;
            UsersThoughts.Clear();
            button1.Enabled = false;
            timerForAnswers.Start();
            timer1.Enabled = true;
            label2.Text = Convert.ToString(secondsOnAnswer - timerForAnswers.ElapsedMilliseconds / 1000 + "c");
        }

        //Необходим для добавления и сохранения вопросов пользователя
        private void AddAndSaveAnswer(RadioButton radioButton)
        {

            object sender = new object();
            EventArgs e = new EventArgs();
            UserAnswer answer = new UserAnswer(test.TestID, questionNames[numberOfQuestion].QuestionID,
                user.Id, radioButton.Text, UsersThoughts.Text);
            userAnswers.Add(answer);     
            numberOfQuestion++;
            NumberOfQuestion.Text = Convert.ToString(numberOfQuestion + 1);
            if (numberOfQuestion == 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (userAnswers[i].Answer == tenAnswers[i])
                        mark++;
                }
                timer1.Stop();
                MessageBox.Show($"Правильно были решены {mark} из 10 вопросов.");
                SystemFunctions.SaveUserStatistic(user.Id, test.TestID, mark, userAnswers[0].Attempt);
                SaveChanges();
                form = new FormForUser(user);
                form.Show();
                this.Hide();
            }
            else
                button1_Click(sender, e);
        }

        //Необходим для сохранения данных в базу
        private void SaveChanges()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var i in userAnswers)
                {
                    db.userAnswers.Add(i);
                }
                db.SaveChanges();
            }
        }

        //Необходим для сохранения данных при закрытии формы
        private void TestingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if((QuestionContent.TextLength != 0) && (numberOfQuestion != 10))
            {
                SaveChanges();
                for (int i = 0; i < userAnswers.Count; i++)
                {
                    if (userAnswers[i].Answer == tenAnswers[i])
                        mark++;
                }
                if(userAnswers.Count > 0)
                {
                    SystemFunctions.SaveUserStatistic(user.Id, test.TestID, mark, userAnswers[0].Attempt);
                }  
            }
            form = new FormForUser(user);
            form.Show();
            this.Hide();
        }
        
        //Необходимы для вызова метода добавления вопроса
        private void radioButton4_Click(object sender, EventArgs e)
        {
            AddAndSaveAnswer(radioButton4);
            radioButton4.Checked = false;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            AddAndSaveAnswer(radioButton3);
            radioButton3.Checked = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            AddAndSaveAnswer(radioButton2);
            radioButton2.Checked = false;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            AddAndSaveAnswer(radioButton1);
            radioButton1.Checked = false;
        }

        //Необходим для визуального представления оставшегося времени
        //для ответа на вопрос
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = Convert.ToString(secondsOnAnswer - timerForAnswers.ElapsedMilliseconds / 1000 + "c");
            if ((secondsOnAnswer - timerForAnswers.ElapsedMilliseconds / 1000) <= 0)
            {
                timer1.Stop();
                AddAndSaveAnswer(radioButton5);
            }
        }
    }
}