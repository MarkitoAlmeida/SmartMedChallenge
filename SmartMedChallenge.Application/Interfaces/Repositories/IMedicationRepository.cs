using SmartMedChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMedChallenge.Application.Interfaces.Repositories
{
    public interface IMedicationRepository
    {
        Task<List<Medication>> GetAllMedications();
        Task<Medication> GetMedicationByName(string medicationName);
        Task<Medication> GetMedictionById(Guid medicationId);
        Task Insert(Medication medication);
        Task Delete(Medication medication);
    }
}
