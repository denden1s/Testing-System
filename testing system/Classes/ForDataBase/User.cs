using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testing_system.Classes;

namespace testing_system
{
    /// <summary>
    /// Класс необходим для представления информации из БД в виде объектов
    /// </summary>
    public class User
    {
        private Encryption encryption = new Encryption();

        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Необходимо для идентификации
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Необходим для авторизации
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Необходим для проверки есть ли в данный момент авторизованный пользователь
        /// </summary>
        public bool IsAuthorized { get; set; } = false;

        /// <summary>
        /// Нужен для разделения обычных пользователей от администратора в общем списке Users
        /// </summary>
        public string UserStatus { get; set; }

        /// <summary>
        /// Нужен когда нет необходимости заполнять данные сразу
        /// </summary>
        public User()
        { }

        /// <summary>
        /// Нужен для мгновенной настройки данных
        /// </summary>
        public User(string _name, string _password, string _status)
        {
            Name = _name;
            Password = encryption.EncryptPassword(_password, _name);
            UserStatus = _status;
        }

        /// <summary>
        /// Аналогичен предыдущему конструктору
        /// </summary>
        public User(int _id, string _name, string _password, bool _isAuthorized, string _status)
            : this(_name, _password, _status)
        {
            Id = _id;
            //Name = _name;
            //Password = encryption.EncryptPassword(_password, _name);
            IsAuthorized = _isAuthorized;
            //UserStatus = _status;
        }

        /// <summary>
        /// Пока просто существует
        /// </summary>
       public virtual void StartTest()
        {
            MessageBox.Show("Это виртуальный метод");
        }
    }
}