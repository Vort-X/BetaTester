using BusinessLogicLayer.Domain;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAttemptService
    {
        List<AttemptInfo> GetTopTen();
        void SaveAttempt(Attempt attempt);
    }
}
