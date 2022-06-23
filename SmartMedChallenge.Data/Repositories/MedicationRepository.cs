using Microsoft.EntityFrameworkCore;
using SmartMedChallenge.Application.Interfaces.Repositories;
using SmartMedChallenge.Data.Context;
using SmartMedChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMedChallenge.Data.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        #region Properties

        private readonly SmartMedChallengeContext _context;

        #endregion

        #region Constructor

        public MedicationRepository(SmartMedChallengeContext context) =>
            _context = context;

        #endregion

        #region Read

        public async Task<List<Medication>> GetAllMedications()
        {
            return await _context.Medications
                                    .AsNoTracking()
                                    .Where(m => !m.Excluded
                                           && m.Active
                                           && m.Quantity > 0)
                                    .OrderBy(m => m.Name)
                                    .ToListAsync();
        }

        public async Task<Medication> GetMedicationByName(string medicationName)
        {
            return await _context.Medications
                                    .Where(m => m.Name.Equals(medicationName)
                                           && !m.Excluded
                                           && m.Active
                                           && m.Quantity > 0)
                                    .FirstOrDefaultAsync();
        }

        public async Task<Medication> GetMedictionById(Guid medicationId)
        {
            return await _context.Medications
                                    .FirstOrDefaultAsync(m => m.Id.Equals(medicationId));
        }

        #endregion

        #region Create

        public async Task Insert(Medication medication)
        {
            _context.Medications.Add(medication);
            await SaveChanges();
        }

        #endregion

        #region Update



        #endregion

        #region Delete

        public async Task Delete(Medication medication)
        {
            _context.Medications.Remove(medication);
            await SaveChanges();
        }

        #endregion

        #region General Methods

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        #endregion
    }
}
