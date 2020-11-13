using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using testing_system.Classes;
using testing_system.Classes.ForDataBase;

namespace testing_system
{
    public partial class FormForUser : Form
    {
        //Необходимо для перехода к окну авторизации 
        private AuthorizationForm form1;

        //Необходимо для перехода к онку с тестом
        private TestingForm testForm;

        //Необходимо для проверки какой режим используется в программе
        private bool themeIsSelect; 

        //Необходимо для хранения информации об авторизованном пользователе
        private User authorizedUser;

        //Необходимо для преобразования информации из БД
        private List<TestName> TestNames;
        private List<InformationAboutMath> MathematicInfo;


        /// <summary>
        /// Конструктор для создания формы
        /// </summary>
        public FormForUser()
        {  
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор для создания формы
        /// </summary>
        /// <param name="user">авторизованный пользователь</param>
        public FormForUser(User user)
        {
            MathematicInfo = new List<InformationAboutMath>();
            TestNames = new List<TestName>();
            InitializeComponent();
            authorizedUser = user;         
        }

        /// <summary>
        /// Необходим для задания определенных параметров при загрузке формы
        /// </summary>
        private void FormForUser_Load(object sender, EventArgs e)
        {
            themeIsSelect = false;
            comboBox1.Visible = false;
            LabelForComboBox.Visible = false;
            ButtonForTest.Visible = false;
            TBInformation.Visible = false;
        }

        /// <summary>
        /// Необходим для выхода из учетной записи пользователя
        /// </summary>
        private void выйтиИзУчетнойЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form1 = new AuthorizationForm();
            form1.Show();
            this.Visible = false;
        }

        /// <summary>
        /// Необходим для получения математической информации
        /// </summary>
        private void учебнаяИнформацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeIsSelect = false;
            ChooseElement.Visible = false;
            ButtonForTest.Visible = false;
            LabelForComboBox.Visible = true;
            comboBox1.Visible = true;
            TBInformation.Visible = true;
            TBInformation.Clear();
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            using (ApplicationContext db = new ApplicationContext())
                if (db.informationAboutMaths.Count() > 0)
                {
                    foreach (InformationAboutMath info in db.informationAboutMaths)
                    {
                        MathematicInfo.Add(info);
                        comboBox1.Items.Add(info.Name);
                    }
                }
        }

        /// <summary>
        /// Необходим для представления математической информации
        /// </summary>
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if(themeIsSelect)
                TBInformation.Visible = false;
            else
                TBInformation.Visible = true; 
        }

        /// <summary>
        /// Необходим для закрытия программы, а не только формы
        /// </summary>
        private void FormForUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Необходим для настройки формы для просмотра тестов
        /// </summary>
        private void тестыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TBInformation.Visible = false;
            themeIsSelect = true;
            ChooseElement.Visible = false;
            LabelForComboBox.Visible = true;
            comboBox1.Visible = true;
            ButtonForTest.Visible = true;
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            SystemFunctions.GetList(TestNames);
            foreach (TestName item in TestNames)
            {
                comboBox1.Items.Add(item.Name);
            }
        }

        /// <summary>
        /// Необходим для отображения статистики тестов
        /// </summary>
        private void статистикаТестовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TBInformation.Visible = true;
            themeIsSelect = false;
            ChooseElement.Visible = false;
            LabelForComboBox.Visible = false;
            comboBox1.Visible = false;
            ButtonForTest.Visible = false;
            TBInformation.Text = SystemFunctions.ViewStatisticOfTests(authorizedUser);
        }

        /// <summary>
        /// Необходим для запуска теста
        /// </summary>
        private void ButtonForTest_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                testForm = new TestingForm(authorizedUser, TestNames[comboBox1.SelectedIndex]);
                this.Hide();
                testForm.Show();
            }
        }
    }
}