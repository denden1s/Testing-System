using System.Linq;

namespace testing_system.Classes.ForDataBase
{
    class UserAnswer
    {
        public UserAnswer() { }

        public UserAnswer(int _testID, int _questionID, int _userID, string _answer, string _illustration)
        {
            TestID = _testID;
            QuestionID = _questionID;
            UserID = _userID;
            Answer = _answer;
            IllustrationOfAnswer = _illustration;
            using (ApplicationContext db = new ApplicationContext())
            {
                var atempt = from b in db.userAnswers
                             where b.TestID == TestID && b.UserID == UserID
                             select b;
                if(atempt.Count() > 0)
                {
                    var max = atempt.Max(i => i.Attempt);
                    if (atempt == null)
                        Attempt = 0;
                    else
                        Attempt = max + 1;
                }
                else
                    Attempt = 0;
            }
        }

        public int TestID { get; set; }
        public int QuestionID { get; set; }
        public int UserID { get; set; }
        public string Answer { get; set; }
        
        public string IllustrationOfAnswer { get; set; }

        public int Attempt { get; set; }
    }
}
