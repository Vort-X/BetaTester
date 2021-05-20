using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class AttemptInfoModel
    {
        public AttemptInfoModel(string testerName, DateTime testingDate, int points)
        {
            TesterName = testerName;
            TestingDate = testingDate;
            Points = points;
        }

        public string TesterName { get; private set; }
        public DateTime TestingDate { get; private set; }
        public int Points { get; private set; }
    }
}
