using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingTests
{
    public class Test
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public TestAnswer RightAnswer { get; set; }
        public TestAnswer SelectedAnswer { get; set; }
        public enum TestAnswer
        {
            First = 1,
            Second = 2,
            Third = 3,
        }
    }
}