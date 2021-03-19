using BusinessLogicLayer.Domain;
using PresentationLayer.Models;

namespace BusinessLogicLayer.Mappers
{
    internal static class AttemptMapper
    {
        public static Attempt ToDomain(this AttemptModel model)
        {
            var attempt = new Attempt(model.Id, model.TesterName, model.TestingDate);
            model.TestItems.ForEach(ti => attempt.TestItems.Add(ti.ToDomain()));
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
