using System;
using System.Collections.Generic;

namespace PresentationLayer.Models
{
    public class AttemptModel : BaseModel
    {
        public string TesterName { get; private set; }
        public DateTime TestingDate { get; private set; }
        public List<TestItemModel> TestItems { get; private set; }

        public AttemptModel(int id, string testerName, DateTime testingDate)
        {
            Id = id;
            TesterName = testerName;
            TestingDate = testingDate;

            TestItems = new List<TestItemModel>();
        }
    }
}
