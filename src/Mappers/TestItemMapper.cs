using BusinessLogicLayer.Domain;
using DataLayer.Entities;
using PresentationLayer.Models;

namespace Mappers
{
    public static class TestItemMapper
    {
        public static TestItem ToDomain(this TestItemEntity entity)
        {
            return new TestItem(entity.Id, entity.GotRightAnswer, entity.QuestionId);
        }

        public static TestItem ToDomain(this TestItemModel model)
        {
            return new TestItem(model.Id, model.GotRightAnswer, model.QuestionId);
        }

        public static TestItemEntity ToEntity(this TestItem domain)
        {
            return new TestItemEntity(domain.Id, domain.GotRightAnswer, domain.QuestionId);
        }

        public static TestItemModel ToModel(this TestItem domain)
        {
            return new TestItemModel(domain.Id, domain.GotRightAnswer, domain.QuestionId);
        }
    }
}
