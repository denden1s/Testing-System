using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using testing_system.Classes;

namespace testing_system
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Encryption encryption = new Encryption();
            bool logIn = false;
            
            using (ApplicationContext db = new ApplicationContext())
            {
               if(db.Users.Count() == 0)
               {
                    User administrator = new Admin("Admin", "123","администратор");
                    db.Users.Add(administrator);
                    db.SaveChanges();
               }
                foreach (User us in db.Users)
                {
                    if (us.IsAuthorized == true) logIn = true;
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (logIn)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    //var user = db.Users.Find(true);
                    //использование запроса для определения статуса 
                    //авторизованного пользователя
                    //Linq 
                    var _user = db.Users.FirstOrDefault(i => i.IsAuthorized == true);
                        //from b in db.Users
                        //        where b.IsAuthorized == true
                        //        select b;
                    //User user = new User();
                    //user = (User)_user.Single();
                    //foreach(User user in _user)
                    //{
                    //    user1 = user;
                    //}
                    if (_user.UserStatus == "администратор") //is Admin)
                    {
                        Application.Run(new FormForAdmin());
                    }
                    else if (_user.UserStatus =="пользователь")
                    {
                        Application.Run(new FormForUser(_user));
                    }
                } 
            }
            else
            {
                Application.Run(new Form1());
            }
        }
    }
}