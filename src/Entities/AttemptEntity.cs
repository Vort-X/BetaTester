using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class AttemptEntity : BaseEntity
    {
        public string TesterName { get; private set; }
        public DateTime TestingDate { get; private set; }
        public List<TestItemEntity> TestItems { get; private set; }

        private AttemptEntity()
        {

        }

        public AttemptEntity(int id, string testerName, DateTime testingDate) : base(id)
        {
            TesterName = testerName;
            TestingDate = testingDate;

            TestItems = new List<TestItemEntity>();
        }
    }
}
