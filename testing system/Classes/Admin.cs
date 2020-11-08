using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing_system
{
    class Admin : User // фабричный метод
    {
        public Admin(string _name, string _password, string _status)
            : base(_name, _password, _status)
        { }
        
        //необходим для добавления теста
        public void AddTest() { }

        //необходим для изменения теста
        public void ChangeTest() { }

        //необходим для удаления теста
        public void RemoveTest() { }

        ///
        public override void StartTest()
        {
            MessageBox.Show("Я админ бро");
        }
    }
}