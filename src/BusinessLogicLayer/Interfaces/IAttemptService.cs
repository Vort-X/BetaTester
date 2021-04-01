using BusinessLogicLayer.Domain;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAttemptService
    {
        List<Attempt> GetTopTen();
        void SaveAttempt(Attempt attempt);
    }
}
