using AutoMapper;
using Moq;
using SmartMedChallenge.Application.Interfaces.Repositories;
using SmartMedChallenge.Application.Services;
using SmartMedChallenge.Application.ViewModels.MedicationViewModels;
using SmartMedChallenge.Tests.Collections;
using SmartMedChallenge.Tests.Fixtures;
using Xunit;

namespace SmartMedChallenge.Tests.UnitTests.Medication
{
    [Collection(nameof(MedicationCollection))]
    public class MedicationServiceTest
    {
        /* ANNOTATIONS:
            - Nome do Método: ObjetoEmTeste_MetodoComportamentoEmTeste_ComportamentoEsperado -> Resumo: Objeto_Comportamento_Resultado
            - MOCK: Utilizar o Moq (NuGet Package)
              - Utilizado o Mock para simular as injeções de dependência que são obrigatórias para as classes testadas, mas não são importadas/utilizadas para os Testes Unitários
            - Utilizado a Fixture para reaproveitamento de código
            - Utilizado o AutoMocker (NuGet Package) para tratar das injeções de dependência de forma mais automática
         */

        #region Properties

        private readonly MedicationTestsFixture _medicationTestsFixture;
        private readonly MedicationService _medicationService;

        #endregion

        #region Constructor

        public MedicationServiceTest(MedicationTestsFixture medicationTestsFixture)
        {
            _medicationTestsFixture = medicationTestsFixture;
            _medicationService = _medicationTestsFixture.GetMedicationService();
        }

        #endregion

        #region Post

        [Fact(DisplayName = "Create New Medication Successfuly")]
        [Trait("Category", "Medication Trait Test")]
        public void Medication_CreateMedication_ReturnWrongParameters()
        {
            // Arrange
            var medicationVM = _medicationTestsFixture.GenerateValidCreateMedicationViewModel();
            var medication = _medicationTestsFixture.GenerateValidMedication();

            _medicationTestsFixture.Mocker.GetMock<IMapper>().Setup(m => m.Map<Domain.Models.Medication>(It.IsAny<CreateMedicationViewModel>())).Returns(medication);

            // Act
            _medicationService.CreateMedication(medicationVM).GetAwaiter();

            // Assert
            _medicationTestsFixture.Mocker.GetMock<IMedicationRepository>().Verify(x => x.Insert(medication), Times.Once);
        }

        #endregion
    }
}
