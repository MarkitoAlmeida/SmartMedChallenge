using Microsoft.EntityFrameworkCore;
using SmartMedChallenge.Application.Interfaces.Repositories;
using SmartMedChallenge.Data.Context;
using SmartMedChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedChallenge.Data.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly SmartMedChallengeContext _context;

        public MedicationRepository(SmartMedChallengeContext context) =>
            _context = context;

        public async Task<List<Medication>> GetAllMedications()
        {
            return await _context.Medications
                                    .AsNoTracking()
                                    .Where(m => !m.Excluded
                                           && m.Active
                                           && m.Quantity > 0)
                                    .ToListAsync();
        }
    }
}
