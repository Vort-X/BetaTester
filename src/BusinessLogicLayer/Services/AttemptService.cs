using BusinessLogicLayer.Domain;
using BusinessLogicLayer.Interfaces;
using DataLayer.Interfaces;
using Mappers;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class AttemptService : IAttemptService
    {
        //protected readonly IAttemptRepository attemptRepository;

        //public AttemptService(IAttemptRepository attemptRepository)
        //{
        //    this.attemptRepository = attemptRepository;
        //}

        protected readonly IUnitOfWork unitOfWork;

        public AttemptService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<AttemptInfo> GetTopTen()
        {
            return unitOfWork.AttemptRepository
                .GetLeaders(10)
                .Select(a => new AttemptInfo(a.TesterName, a.TestingDate, unitOfWork.AttemptRepository.GetPoints(a.Id)))
                .ToList();
        }

        public void SaveAttempt(Attempt attempt)
        {
            unitOfWork.AttemptRepository.Add(attempt.ToEntity());
            unitOfWork.Save();
        }
    }
}
