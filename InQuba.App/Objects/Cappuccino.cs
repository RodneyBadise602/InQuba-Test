namespace InQuba.App.Objects
{
    public class Cappuccino : HotBeverage
    {
        public Cappuccino()
        { }

        public override bool IsEnoughBeansForBeverage()
        {
            return NumberOfBeans >= 5;
        }

        public override bool IsEnoughMilkUnitsForBeverage()
        {
            return MilkUnits > 3;
        }

        public override string PrepareBeverage(bool addMilk)
        {
            if(!IsEnoughMilkUnitsForBeverage())
            {
                return "There is not enough Milk to make a Cappuccino cup\n";
            }

            if (!IsEnoughBeansForBeverage())
            {
                return "There is not enough Beans to make a Cappuccino cup\n";
            }

            NumberOfBeans -= - 5;
            MilkUnits -= - 3;

            return "Your Cappuccino is ready...\n";
        }
    }
}