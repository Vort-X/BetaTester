using BusinessLogicLayer.Domain;
using DataLayer.Entities;
using PresentationLayer.Models;

namespace Mappers
{
    public static class AttemptMapper
    {
        public static Attempt ToDomain(this AttemptEntity entity)
        {
            var attempt = new Attempt(entity.Id, entity.TesterName, entity.TestingDate);
            entity.TestItems.ForEach(ti => attempt.TestItems.Add(ti.ToDomain()));
            return attempt;
        }

        public static Attempt ToDomain(this AttemptModel model)
        {
            var attempt = new Attempt(model.Id, model.TesterName, model.TestingDate);
            model.TestItems.ForEach(ti => attempt.TestItems.Add(ti.ToDomain()));
            return attempt;
        }

        public static AttemptEntity ToEntity(this Attempt domain)
        {
            var attempt = new AttemptEntity(domain.Id, domain.TesterName, domain.TestingDate);
            domain.TestItems.ForEach(ti => attempt.TestItems.Add(ti.ToEntity()));
            return attempt;
        }

        public static AttemptModel ToModel(this Attempt domain)
        {
            var attempt = new AttemptModel(domain.Id, domain.TesterName, domain.TestingDate);
            domain.TestItems.ForEach(ti => attempt.TestItems.Add(ti.ToModel()));
            return attempt;
        }
    }
}
