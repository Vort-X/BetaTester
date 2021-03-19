using BusinessLogicLayer.Domain;
using PresentationLayer.Models;

namespace BusinessLogicLayer.Mappers
{
    internal static class TestItemMapper
    {
        public static TestItem ToDomain(this TestItemModel model)
        {
            return new TestItem(model.Id, model.GotRightAnswer, model.Question.ToDomain());
        }

        public static TestItemModel ToModel(this TestItem domain)
        {
            return new TestItemModel(domain.Id, domain.GotRightAnswer, domain.Question.ToModel());
        }
    }
}
