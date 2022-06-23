using AutoMapper;
using FluentValidation;
using SmartMedChallenge.Application.Interfaces;
using SmartMedChallenge.Application.Interfaces.Repositories;
using SmartMedChallenge.Application.Interfaces.Services;
using SmartMedChallenge.Application.Resources;
using SmartMedChallenge.Application.ViewModels.MedicationViewModels;
using SmartMedChallenge.Domain.Models;
using SmartMedChallenge.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedChallenge.Application.Services
{
    public class MedicationService : BaseService, IMedicationService
    {
        #region Properties

        private readonly IMedicationRepository _medicationRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public MedicationService(INotificator notificator,
                                 IMedicationRepository medicationRepository,
                                 IMapper mapper) : base(notificator)
        {
            _medicationRepository = medicationRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<MedicationViewModel> CreateMedication(CreateMedicationViewModel request)
        {
            var medication = _mapper.Map<Medication>(request);

            if (!ExecuteValidation(new MedicationValidation(), medication))
                return null;

            var medicationExists = _mapper.Map<MedicationViewModel>(await _medicationRepository.GetMedicationByName(request.Name));
            if (medicationExists is not null)
            {
                Notify(SystemMsgs.MedicationAlreadyExists);
                return medicationExists;
            }

            await _medicationRepository.Insert(medication);

            var response = _mapper.Map<MedicationViewModel>(medication);

            return response;
        }

        public async Task<bool> DeleteMedication(Guid medicationId)
        {
            var medication = await _medicationRepository.GetMedictionById(medicationId);

            if (medication is null)
            {
                Notify(SystemMsgs.MedicationDoesNotExists);
                return false;
            }

            await _medicationRepository.Delete(medication);

            return true;
        }

        #endregion
    }
}
