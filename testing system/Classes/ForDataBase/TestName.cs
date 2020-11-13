namespace testing_system.Classes
{
    public class TestName
    {
        public TestName()
        { }

        public TestName(string _name)
        {
            Name = _name;
        }
        public TestName (string _name, int _testId):this(_name)
        {
            TestID = _testId;
        }
        public int TestID { get; set; }
        public string Name { get; set; }
    }
}