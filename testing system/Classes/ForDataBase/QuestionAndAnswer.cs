namespace testing_system.Classes.ForDataBase
{
    class QuestionAndAnswer
    {
        public QuestionAndAnswer()
        { }

        public QuestionAndAnswer(int _testId, int _questionId, string _rightA, 
            string _wrong1, string _wrong2, string _wrong3)
        {
            TestID = _testId;
            QuestionID = _questionId;
            RightAnswer = _rightA;
            WrongAnswer_1 = _wrong1;
            WrongAnswer_2 = _wrong2;
            WrongAnswer_3 = _wrong3;
        }

        public int TestID { get; set; }
        public int QuestionID { get; set; }

        //правильный ответ
        public string RightAnswer { get; set; }

        //неправильные ответы
        public string WrongAnswer_1 { get; set; }
        public string WrongAnswer_2 { get; set; }
        public string WrongAnswer_3 { get; set; }
    }
}