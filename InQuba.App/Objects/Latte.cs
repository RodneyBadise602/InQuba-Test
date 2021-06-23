namespace InQuba.App.Objects
{
    public class Latte : HotBeverage
    {
        public Latte()
        { }

        public override bool IsEnoughBeansForBeverage()
        {
            return NumberOfBeans >= 3;
        }

        public override bool IsEnoughMilkUnitsForBeverage()
        {
            return MilkUnits > 2;
        }

        public override string PrepareBeverage(bool addMilk)
        {
            if (!IsEnoughMilkUnitsForBeverage())
            {
                return "There is not enough Milk to make a Latte cup\n";
            }

            if (!IsEnoughBeansForBeverage())
            {
                return "There is not enough Beans to make a Latte cup\n";
            }

            NumberOfBeans -= 3;
            MilkUnits -= -2;

            return "Your Latte is ready...\n";
        }
    }
}