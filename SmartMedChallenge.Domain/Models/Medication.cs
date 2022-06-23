namespace SmartMedChallenge.Domain.Models
{
    public class Medication : Entity
    {
        #region Constructor

        public Medication() { }

        public Medication(string name,
                          int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        #endregion

        #region Properties

        public string Name { get; private set; }
        public int Quantity { get; private set; }

        #endregion

        #region Methods



        #endregion
    }
}
