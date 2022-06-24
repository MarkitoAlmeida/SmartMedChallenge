using SmartMedChallenge.Tests.Fixtures;
using Xunit;

namespace SmartMedChallenge.Tests.Collections
{
    [CollectionDefinition(nameof(MedicationCollection))]
    public class MedicationCollection : ICollectionFixture<MedicationTestsFixture>
    {
    }
}
