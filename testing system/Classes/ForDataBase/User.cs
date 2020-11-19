using testing_system.Classes;

namespace testing_system
{

    public class User
    {
        private Encryption encryption = new Encryption();

        public int Id { get; set; }

        public string Name { get; private set; }

        public string Password { get; private set; }

        public bool IsAuthorized { get; set; } = false;

        public string UserStatus { get; set; }

        public User()
        { }

        public User(string _name, string _password, string _status)
        {
            Name = _name;
            Password = encryption.EncryptPassword(_password, _name);
            UserStatus = _status;
        }

        public User(int _id, string _name, string _password, bool _isAuthorized, string _status)
            : this(_name, _password, _status)
        {
            Id = _id;
            IsAuthorized = _isAuthorized;
        }
    }
}