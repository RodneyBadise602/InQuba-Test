using InQuba.App.Inferfaces;
using InQuba.App.Objects;
using Xunit;

namespace InQuba.Tests
{
    public class BeverageTests
    {
        IHotBeverage coffee = new Coffee();
        IHotBeverage cappuccino = new Cappuccino();
        IHotBeverage latte = new Latte();

        [Fact]
        public void IsNotNull()
        {
            Assert.NotNull(coffee);
            Assert.NotNull(cappuccino);
            Assert.NotNull(latte);
        }

        [Fact]
        public void CanBewBeverage()
        {
            Assert.True(coffee.IsEnoughBeansForBeverage() && coffee.IsEnoughMilkUnitsForBeverage());
            Assert.True(cappuccino.IsEnoughBeansForBeverage() && cappuccino.IsEnoughMilkUnitsForBeverage());
            Assert.True(latte.IsEnoughBeansForBeverage() && latte.IsEnoughMilkUnitsForBeverage());
        }


        [Fact]
        public void CanPrepareBeverage()
        {
            Assert.Equal("Your Coffee is ready...\n", coffee.PrepareBeverage());
            Assert.Equal("Your Cappuccino is ready...\n", cappuccino.PrepareBeverage());
            Assert.Equal("Your Latte is ready...\n", latte.PrepareBeverage());
        }
    }
}