using System;

namespace SmartMedChallenge.Application.ViewModels.MedicationViewModels
{
    public class MedicationViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
