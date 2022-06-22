using AutoMapper;
using SmartMedChallenge.Application.ViewModels.MedicationViewModels;
using SmartMedChallenge.Domain.Models;

namespace SmartMedChallenge.Application.Mapper
{
    public class ViewModelToDomainMap : Profile
    {
        public ViewModelToDomainMap()
        {
            CreateMap<MedicationViewModel, Medication>();
        }
    }
}
