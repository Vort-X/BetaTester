using BusinessLogicLayer.Domain;
using DataLayer.Entities;

namespace DataLayer.Mappers
{
    internal static class AttemptMapper
    {
        public static Attempt ToDomain(this AttemptEntity entity)
        {
            var attempt = new Attempt(entity.Id, entity.TesterName, entity.TestingDate);
            entity.TestItems.ForEach(a => attempt.TestItems.Add(a.ToDomain()));
            return attempt;
        }

        public static AttemptEntity ToEntity(this Attempt domain)
        {
            var attempt = new AttemptEntity(domain.Id, domain.TesterName, domain.TestingDate);
            domain.TestItems.ForEach(a => attempt.TestItems.Add(a.ToEntity()));
            return attempt;
        }
    }
}
