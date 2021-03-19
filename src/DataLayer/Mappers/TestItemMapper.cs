using BusinessLogicLayer.Domain;
using DataLayer.Entities;

namespace DataLayer.Mappers
{
    internal static class TestItemMapper
    {
        public static TestItem ToDomain(this TestItemEntity entity)
        {
            return new TestItem(entity.Id, entity.GotRightAnswer, entity.Question.ToDomain());
        }

        public static TestItemEntity ToEntity(this TestItem domain)
        {
            return new TestItemEntity(domain.Id, domain.GotRightAnswer, domain.Question.ToEntity());
        }
    }
}
