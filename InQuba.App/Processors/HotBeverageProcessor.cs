using InQuba.App.Inferfaces;

namespace InQuba.App.Processors
{
    public class HotBeverageProcessor
    {
        private IHotBeverage HotBeverage;

        public HotBeverageProcessor(IHotBeverage hotBeverage)
        {
            HotBeverage = hotBeverage;
        }

        public string PrepareBeverage(bool addMilk = true)
        {
            return HotBeverage.PrepareBeverage(addMilk);
        }

        public int GetNumberOfBeansLeft()
        {
            return HotBeverage.GetNumberOfBeansLeft();
        }

        public int GetNumberOfMilkUnitsLeft()
        {
            return HotBeverage.GetNumberOfMilkUnitsLeft();
        }

        public bool IsEnoughBeansForBeverage()
        {
            return HotBeverage.IsEnoughBeansForBeverage();
        }

        public bool IsEnoughMilkUnitsForBeverage()
        {
            return HotBeverage.IsEnoughMilkUnitsForBeverage();
        }
    }
}