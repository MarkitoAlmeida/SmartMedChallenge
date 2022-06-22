using AutoMapper;
using SmartMedChallenge.Application.Interfaces.Repositories;
using SmartMedChallenge.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedChallenge.Application.Services
{
    public class MedicationService : IMedicationService
    {
        #region Properties

        private readonly IMedicationRepository _medicationRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public MedicationService(IMedicationRepository medicationRepository,
                                 IMapper mapper)
        {
            _medicationRepository = medicationRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods



        #endregion
    }
}
