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
    public partial class FormForUser : Form
    {
        private Form1 form1;
        private bool themeIsSelect; //пока не помню для чего

        //необходима для хранения информации об авторизованном пользователе
        private User authorizedUser;

        //необходима для преобразования информации из БД
        private List<TestName> TestName;
        private StatisticOfTest statistic;
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
            InitializeComponent();
            authorizedUser = user;
            using (ApplicationContext db = new ApplicationContext())
            {
                if(db.testNames.Count() != 0)
                {
                    foreach (TestName tn in db.testNames)
                    {
                        TestName.Add(new TestName(tn.Name));
                    }
                }
                if (db.informationAboutMaths.Count() > 0)
                {
                    foreach (InformationAboutMath info in db.informationAboutMaths)
                    {
                        MathematicInfo.Add(info);
                        comboBox1.Items.Add(info.Name);
                    }
                }
                //if (db.informationAboutMaths.Count() != 0)
                //{
                //    foreach (InformationAboutMath info in db.informationAboutMaths)
                //    {
                //        MathematicInfo.Add(new InformationAboutMath(info.ThemeID, info.Name, info.ThemeContent));
                //    }
                //}
                //else MessageBox.Show("Информация отсутствует");
            }
        }

        /// <summary>
        /// Необходим для задания определенных параметров при загрузке формы
        /// </summary>
        private void FormForUser_Load(object sender, EventArgs e)
        {
            //TBInformation.LoadFile("sha2562.rtf");
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
            form1 = new Form1();
            form1.Show();
            this.Visible = false;
        }

        /// <summary>
        /// Необходим для получения математической информации
        /// </summary>
        private void учебнаяИнформацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseElement.Visible = false;
            LabelForComboBox.Visible = true;
            comboBox1.Visible = true;
            ButtonForTest.Visible = false;
        }

        /// <summary>
        /// Необходим для представления математической информации
        /// </summary>
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            TBInformation.Visible = true;
            //если нужна проверка по индексам
            //int removeUserID = Users[listBoxUserId].Id;
            //var item = db.Users.Find(removeUserID);
            //if (item != null)
            //{
            //    db.Users.Remove(item);
            //    Users.Remove(Users[listBoxUserId]);
            //    db.SaveChanges();
            //    EditInformation.Items.RemoveAt(listBoxUserId);
            if (MathematicInfo[comboBox1.SelectedIndex].ThemeContent.Contains(".rtf"))
                TBInformation.LoadFile(MathematicInfo[comboBox1.SelectedIndex].ThemeContent);
            else
                TBInformation.Text = MathematicInfo[comboBox1.SelectedIndex].ThemeContent;
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
            ChooseElement.Visible = false;
            LabelForComboBox.Visible = true;
            comboBox1.Visible = true;
            ButtonForTest.Visible = true;
        }

        /// <summary>
        /// Необходим для запуска теста
        /// </summary>
        private void ButtonForTest_Click(object sender, EventArgs e)
        {

        }
    }
}