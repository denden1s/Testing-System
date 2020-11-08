using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_system.Classes.ForDataBase
{
    class UserAnswer
    {
        public int TestID { get; set; }
        public int QuestionID { get; set; }
        public int UserID { get; set; }
        public string Answer { get; set; }
        
        //пояснение к ответу
        public string IllustrationOfAnswer { get; set; }
    }
}
