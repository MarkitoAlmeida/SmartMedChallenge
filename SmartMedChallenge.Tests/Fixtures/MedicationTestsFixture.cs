using Moq.AutoMock;
using SmartMedChallenge.Application.Services;
using SmartMedChallenge.Application.ViewModels.MedicationViewModels;
using SmartMedChallenge.Domain.Models;
using System;

namespace SmartMedChallenge.Tests.Fixtures
{
    public class MedicationTestsFixture
    {
        #region Properties

        public MedicationService MedicationService;
        public AutoMocker Mocker;

        #endregion

        #region Methods

        public MedicationService GetMedicationService()
        {
            Mocker = new AutoMocker();
            MedicationService = Mocker.CreateInstance<MedicationService>();

            return MedicationService;
        }

        #endregion

        #region Entity

        public Medication GenerateInvalidMedication()
        {
            return new Medication(
                null,
                new Random().Next()
            );
        }

        public Medication GenerateInvalidMedication(string medicationName, int quantity)
        {
            return new Medication(
                medicationName,
                quantity
            );
        }

        public Medication GenerateValidMedication()
        {
            return new Medication(
                $"MedicationName_{new Random().Next()}",
                new Random().Next()
            );
        }

        public Medication GenerateValidMedication(string medicationName, int quantity)
        {
            return new Medication(
                medicationName,
                quantity
            );
        }

        #endregion

        #region ViewModel / DTO

        public CreateMedicationViewModel GenerateInvalidCreateMedicationViewModel()
        {
            return new CreateMedicationViewModel()
            {
                Name = "A",
                Quantity = 0
            };
        }

        public CreateMedicationViewModel GenerateInvalidCreateMedicationViewModel(string medicationName, int quantity)
        {
            var medicationVM = new CreateMedicationViewModel()
            {
                Name = medicationName,
                Quantity = quantity
            };

            return medicationVM;
        }

        public CreateMedicationViewModel GenerateValidCreateMedicationViewModel()
        {
            var medicationVM = new CreateMedicationViewModel()
            {
                Name = $"MedicationVM_{new Random().Next()}",
                Quantity = new Random().Next()
            };

            return medicationVM;
        }

        public CreateMedicationViewModel GenerateValidCreateMedicationViewModel(string medicationName, int quantity)
        {
            return new CreateMedicationViewModel()
            {
                Name = medicationName,
                Quantity = quantity
            };
        }

        #endregion
    }
}
