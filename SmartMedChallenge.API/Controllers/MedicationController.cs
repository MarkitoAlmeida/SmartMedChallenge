using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartMedChallenge.Application.Interfaces.Repositories;
using SmartMedChallenge.Application.Interfaces.Services;
using SmartMedChallenge.Application.ViewModels.MedicationViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMedChallenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationController : ControllerBase
    {
        #region Properties

        private readonly IMedicationService _medicationService;
        private readonly IMedicationRepository _medicationRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public MedicationController(IMedicationService medicationService,
                                    IMedicationRepository medicationRepository,
                                    IMapper mapper)
        {
            _medicationService = medicationService;
            _medicationRepository = medicationRepository;
            _mapper = mapper;
        }

        #endregion

        #region Get

        /// <summary>
        /// Get all medications which are not excluded, is active and the quantity bigger than 0
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet(Name = "GetAllMedications")]
        public async Task<IActionResult> GetAllMedications()
        {
            var result = _mapper.Map<List<MedicationViewModel>>(await _medicationRepository.GetAllMedications());

            if (!result.Any())
                return NoContent();

            return Ok(result);
        }

        #endregion

        #region Post



        #endregion

        #region Put



        #endregion

        #region Delete



        #endregion
    }
}
