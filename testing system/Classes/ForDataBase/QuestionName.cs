using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_system.Classes.ForDataBase
{
    class QuestionName
    {
        public QuestionName()
        {}
        public QuestionName(int _testId, int _questionId, string _name)
        {
            QuestionID = _questionId;
            TestID = _testId;
            Name = _name;
        }
        public int QuestionID { get; set; }

        public int TestID { get; set; }
        public string Name { get; set; }
    }
}