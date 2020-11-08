using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing_system.Classes
{
    class Student : User
    {
        public Student() { }

        //необходим для выполнения задания пользователем
        public override void StartTest() 
        {
           MessageBox.Show("Я ученик");
        }

        //добавить список отметок 
    }
}