using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_system.Classes
{
    class TestName
    {
        public TestName()
        { }

        public TestName( string _name)
        {
            Name = _name;
        }
        public int TestID { get; set; }
        public string Name { get; set; }
    }
}