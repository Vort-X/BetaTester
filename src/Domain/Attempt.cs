using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Domain
{
    public class Attempt : Base
    {
        public string TesterName { get; private set; }
        public DateTime TestingDate { get; private set; }
        public List<TestItem> TestItems { get; private set; }

        public Attempt(int id, string testerName, DateTime testingDate)
        {
            Id = id;
            TesterName = testerName;
            TestingDate = testingDate;

            TestItems = new List<TestItem>();
        }

        public void UpdateTime()
        {
            TestingDate = DateTime.Now;
        }
    }
}
