using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using testing_system.Classes;

namespace testing_system
{
    /// <summary>
    /// Класс необходим для организации формы
    /// </summary>
    public partial class AuthorizationForm : Form
    {

        //необходима для преобразования введенного пароля, на сравнение с базой
        private Encryption encryption;

        private FormForUser formForUser;
        private FormForAdmin formForAdmin;

        //необходима для сообщения о неправильно введённых данных
        private bool logIn;

        private List<User> Users;
        
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public AuthorizationForm()
        {
            logIn = false;
            //заполнение списка пользователей
            Users = new List<User>();
            encryption = new Encryption();
            using (ApplicationContext db = new ApplicationContext())
            {
                if(db.Users.Count() != 0)
                {
                    foreach (User u in db.Users)
                    {
                        u.IsAuthorized = false;
                        Users.Add(new User(u.Id, u.Name, u.Password, u.IsAuthorized, u.UserStatus));
                    }
                }
                db.SaveChanges();
            }
            InitializeComponent();
        }

        /// <summary>
        /// Метод необходим для входа пользователя в систему
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (User us in Users)
            {
                if((us.Name.ToLower() == EnterLogin.Text.ToLower())&&
                    (us.Password == encryption.EncryptPassword(EnterPassword.Text, us.Name)))
                {
                    logIn = true;
                    //обновление авторизованного пользователя в бд
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var itemUpdate = db.Users.Find(us.Id);
                        itemUpdate.IsAuthorized = true;
                        us.IsAuthorized = true;
                        db.SaveChanges();
                        if (itemUpdate.UserStatus == "администратор")
                        {
                            formForAdmin = new FormForAdmin();
                            formForAdmin.Show();
                            //this.Visible = false;
                            //создание формы для администратора
                            this.Hide();
                        }
                        else
                        {
                            formForUser = new FormForUser(itemUpdate);//нужно передавать авторизированного пользователя
                            formForUser.Show();
                            this.Hide();
                            //this.Visible = false;
                        }
                    }
                    break;
                }
                //else
                //    MessageBox.Show("Неверный логин или пароль!");
            }
            if (!logIn)
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        /// <summary>
        /// Метод нужен для выполнения действий при загрузке формы
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            EnterLogin.Text = "";
            EnterPassword.Text = "";
            this.Text = "Меню авторизации";
        }

        /// <summary>
        /// Метод нужен для закрытия программы полностью
        /// </summary>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}