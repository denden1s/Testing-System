using System;
using System.Linq;
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
                    User administrator = new User("Admin", "123","администратор");
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
                    var _user = db.Users.FirstOrDefault(i => i.IsAuthorized == true);
                    if (_user.UserStatus == "администратор")
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
                Application.Run(new AuthorizationForm());
            }
        }
    }
}