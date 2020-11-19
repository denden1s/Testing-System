using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using testing_system.Classes;

namespace testing_system
{
    public partial class AuthorizationForm : Form
    {

        //необходима для преобразования введенного пароля, на сравнение с базой
        private Encryption encryption;

        private FormForUser formForUser;
        private FormForAdmin formForAdmin;

        //необходима для сообщения о неправильно введённых данных
        private bool logIn;

        private List<User> Users;
        
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
                            //создание формы для администратора
                            this.Hide();
                        }
                        else
                        {
                            formForUser = new FormForUser(itemUpdate);
                            formForUser.Show();
                            this.Hide();
                        }
                    }
                    break;
                }
            }
            if (!logIn)
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            EnterLogin.Text = "";
            EnterPassword.Text = "";
            this.Text = "Меню авторизации";
            button1.Enabled = false;
            button1.BackColor = Color.DarkGray;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void EnterPassword_TextChanged(object sender, EventArgs e)
        {
            ChangeButton();
        }

        private void ChangeButton()
        {
            if((EnterLogin.TextLength > 0) && (EnterPassword.TextLength > 0))
            {
                button1.BackColor = Color.LimeGreen;
                button1.Enabled = true;
            }
            else
            {
                button1.BackColor = Color.DarkGray;
                button1.Enabled = false;
            }
        }

        private void EnterLogin_TextChanged(object sender, EventArgs e)
        {
            ChangeButton();
        }
    }
}