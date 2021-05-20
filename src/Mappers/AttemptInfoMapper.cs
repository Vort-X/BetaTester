using BusinessLogicLayer.Domain;
using PresentationLayer.Models;

namespace Mappers
{
    public static class AttemptInfoMapper
    {
        public static AttemptInfo ToDomain(this AttemptInfoModel model)
        {
            return new AttemptInfo(model.TesterName, model.TestingDate, model.Points);
        }

        public static AttemptInfoModel ToModel(this AttemptInfo domain)
        {
            return new AttemptInfoModel(domain.TesterName, domain.TestingDate, domain.Points);
        }
    }
}
