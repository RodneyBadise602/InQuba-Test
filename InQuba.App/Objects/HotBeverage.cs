using InQuba.App.Inferfaces;

namespace InQuba.App.Objects
{
    public abstract class HotBeverage : IHotBeverage
    {
        public HotBeverage()
        {
            NumberOfBeans = 25;
            MilkUnits = 20;
        }

        public int NumberOfBeans { get; set; }
        public int MilkUnits { get; set; }

        public int GetNumberOfBeansLeft()
        {
            return NumberOfBeans;
        }

        public int GetNumberOfMilkUnitsLeft()
        {
            return MilkUnits;
        }

        public abstract bool IsEnoughBeansForBeverage();
        public abstract bool IsEnoughMilkUnitsForBeverage();
        public abstract string PrepareBeverage(bool addMilk = true);

    }
}