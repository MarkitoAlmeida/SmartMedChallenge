using SmartMedChallenge.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMedChallenge.Application.Interfaces.Repositories
{
    public interface IMedicationRepository
    {
        Task<List<Medication>> GetAllMedications();
    }
}
