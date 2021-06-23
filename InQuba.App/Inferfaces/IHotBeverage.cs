namespace InQuba.App.Inferfaces
{
    public interface IHotBeverage
    {
        string PrepareBeverage(bool addMilk = true);
        int GetNumberOfBeansLeft();
        int GetNumberOfMilkUnitsLeft();
        bool IsEnoughBeansForBeverage();
        bool IsEnoughMilkUnitsForBeverage();

    }
}