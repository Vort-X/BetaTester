using PresentationLayer.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IQuestionService
    {
        void AddQuestion(QuestionModel questionModel);
        TestConfigModel CreateConfig();
        List<QuestionModel> GenerateTest(TestConfigModel testConfig);
    }
}
