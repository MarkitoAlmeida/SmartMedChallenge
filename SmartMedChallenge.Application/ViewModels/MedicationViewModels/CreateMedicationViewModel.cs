using System.ComponentModel.DataAnnotations;

namespace SmartMedChallenge.Application.ViewModels.MedicationViewModels
{
    public class CreateMedicationViewModel
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field {0} must have between {1} and {2} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int Quantity { get; set; }
    }
}
