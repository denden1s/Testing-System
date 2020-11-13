namespace testing_system.Classes
{
    class StatisticOfTest
    {
        public StatisticOfTest() { }

        public StatisticOfTest(params int[] _information)
        {
            UserID = _information[0];
            TestID = _information[1];
            Mark = _information[2];
            Attempt = _information[3];
        }

        public int UserID { get; set; }
        public int TestID { get; set; }
        public int Mark { get; set; }

        public int Attempt { get; set; }
    }
}