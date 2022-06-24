using AutoMapper;
using SmartMedChallenge.Application.ViewModels.MedicationViewModels;
using SmartMedChallenge.Domain.Models;

namespace SmartMedChallenge.Application.Mapper
{
    public class DomainToViewModelMap : Profile
    {
        public DomainToViewModelMap()
        {
            // Medication
            CreateMap<Medication, MedicationViewModel>();
        }
    }
}
