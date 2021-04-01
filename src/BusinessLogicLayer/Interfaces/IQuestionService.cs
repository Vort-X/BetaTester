using BusinessLogicLayer.Domain;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IQuestionService
    {
        void AddQuestion(Question questionModel);
        TestConfig CreateConfig();
        List<Question> GenerateTest(TestConfig testConfig);
    }
}
