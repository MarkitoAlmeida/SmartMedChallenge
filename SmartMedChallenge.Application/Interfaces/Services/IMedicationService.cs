using SmartMedChallenge.Application.ViewModels.MedicationViewModels;
using System;
using System.Threading.Tasks;

namespace SmartMedChallenge.Application.Interfaces.Services
{
    public interface IMedicationService
    {
        Task<MedicationViewModel> CreateMedication(CreateMedicationViewModel request);
        Task<bool> DeleteMedication(Guid medicationId);
    }
}
