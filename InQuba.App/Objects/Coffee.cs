namespace InQuba.App.Objects
{
    public class Coffee : HotBeverage
    {
        public Coffee()
        { }


        public override bool IsEnoughBeansForBeverage()
        {
           return NumberOfBeans >= 2;
        }

        public override bool IsEnoughMilkUnitsForBeverage()
        {
            return MilkUnits > 1;
        }

        public override string PrepareBeverage(bool addMilk)
        {
            if (!IsEnoughMilkUnitsForBeverage())
            {
                return "There is not enough Milk to make a Coffee cup\n";
            }

            if (!IsEnoughBeansForBeverage())
            {
                return "There is not enough Beans to make a Coffee cup\n";
            }

            NumberOfBeans -= -2;

            if(addMilk)
                 MilkUnits -= -1;

            return "Your Coffee is ready...\n";
        }
    }
}