using InQuba.App.Inferfaces;
using InQuba.App.Objects;
using InQuba.App.Processors;
using System;

namespace InQuba.App
{
    public class Program
    {
        static HotBeverageProcessor hotBeverageProcessor;
        private static int MaxNumberOfBeans
        {
            get { return 25; }
        }

        private static int MaxMilkUnits
        {
            get { return 20; }
        }

        private static int NumberOfBeans;
        private static int MilkUnits;

        private static void Main(string[] args)
        {
            Console.WriteLine("Coffee machine swithed on...\n");

            IHotBeverage coffee = new Coffee();
            IHotBeverage cappuccino = new Cappuccino();
            IHotBeverage latte = new Latte();

            NumberOfBeans = MaxNumberOfBeans;
            MilkUnits = MaxMilkUnits;

            string userInput = GetUserInput().ToLowerInvariant();

            while (userInput != "off")
            {
                bool isValidSelection = int.TryParse(userInput, out int hotBeverageSelection);

                if (!isValidSelection)
                {
                    Console.WriteLine("Invalid entry...");
                    userInput = GetUserInput().ToLowerInvariant();
                }
                else
                {
                    if (NumberOfBeans < 5)
                    {
                        Console.WriteLine("Bean capacity is low.. Please refil");
                        userInput = GetUserInput().ToLowerInvariant();
                    }
                    else
                    {

                        switch (hotBeverageSelection)
                        {
                            case 1:
                                hotBeverageProcessor = new HotBeverageProcessor(coffee);

                                if (hotBeverageProcessor.IsEnoughBeansForBeverage())
                                {
                                    if (hotBeverageProcessor.IsEnoughMilkUnitsForBeverage())
                                    {
                                        string milkEntry = GetMilkInput();
                                        bool validEntry = int.TryParse(milkEntry, out int addMilkInput);

                                        while(addMilkInput != 1 || addMilkInput != 2)
                                        {
                                            if (validEntry)
                                            {
                                                if (addMilkInput == 1 || addMilkInput == 2)
                                                {
                                                    bool addMilk = addMilkInput == 1; 
                                                    Console.WriteLine(hotBeverageProcessor.PrepareBeverage(addMilk));
                                                    NumberOfBeans = hotBeverageProcessor.GetNumberOfBeansLeft();
                                                    MilkUnits = hotBeverageProcessor.GetNumberOfMilkUnitsLeft();
                                                    userInput = GetUserInput().ToLowerInvariant();
                                                    break;
                                                }
                                                else if (addMilkInput != 1)
                                                {
                                                    Console.WriteLine("Invalid entry...");
                                                    milkEntry = GetMilkInput();
                                                    addMilkInput = int.Parse(milkEntry);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid entry...");
                                                userInput = GetUserInput().ToLowerInvariant();
                                            }
                                        }                                       

                                    }
                                    else
                                    {
                                        Console.WriteLine("There isn't enough Milk of a coffee");
                                        userInput = GetUserInput().ToLowerInvariant();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There isn't enough Beans of a coffee");
                                    userInput = GetUserInput().ToLowerInvariant();
                                }
                                break;

                            case 2:
                                hotBeverageProcessor = new HotBeverageProcessor(cappuccino);
                                if (hotBeverageProcessor.IsEnoughBeansForBeverage())
                                {
                                    if (hotBeverageProcessor.IsEnoughMilkUnitsForBeverage())
                                    {
                                        Console.WriteLine("How many sugars would you like in your Cappuccino?");
                                        string sugarEntry = Console.ReadLine();
                                        int numberOfSugars;
                                        bool validEntry = int.TryParse(sugarEntry, out numberOfSugars);

                                        while (!validEntry)
                                        {
                                            Console.WriteLine("Invalid entry...\n\nHow many sugars would you like in your Cappuccino?");
                                            sugarEntry = Console.ReadLine();
                                            validEntry = int.TryParse(sugarEntry, out numberOfSugars);
                                        }
                                        Console.WriteLine(hotBeverageProcessor.PrepareBeverage());
                                        NumberOfBeans = hotBeverageProcessor.GetNumberOfBeansLeft();
                                        MilkUnits = hotBeverageProcessor.GetNumberOfMilkUnitsLeft();
                                        userInput = GetUserInput().ToLowerInvariant();
                                        break;

                                    }
                                    else
                                    {
                                        Console.WriteLine("There isn't enough Milk of a cappuccino\n");
                                        userInput = GetUserInput().ToLowerInvariant();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There isn't enough Beans of a cappuccino\n");
                                    userInput = GetUserInput().ToLowerInvariant();
                                }
                                break;

                            case 3:
                                hotBeverageProcessor = new HotBeverageProcessor(latte);
                                if (hotBeverageProcessor.IsEnoughBeansForBeverage())
                                {
                                    if (hotBeverageProcessor.IsEnoughMilkUnitsForBeverage())
                                    {
                                        Console.WriteLine(hotBeverageProcessor.PrepareBeverage());
                                        NumberOfBeans = hotBeverageProcessor.GetNumberOfBeansLeft();
                                        MilkUnits = hotBeverageProcessor.GetNumberOfMilkUnitsLeft();
                                        userInput = GetUserInput().ToLowerInvariant();
                                    }
                                    else
                                    {
                                        Console.WriteLine("There isn't enough Milk of a latte\n");
                                        userInput = GetUserInput().ToLowerInvariant();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There isn't enough Beans of a latte\n");
                                    userInput = GetUserInput().ToLowerInvariant();
                                }
                                break;

                            case 4:
                                if (NumberOfBeans < MaxNumberOfBeans)
                                {
                                    Console.WriteLine("Please enter the number of Beans to refill by");
                                    string beansEntry = Console.ReadLine();
                                    bool isValidBeansEntry = int.TryParse(beansEntry, out int numberOfBeans);

                                    if (isValidBeansEntry)
                                    {
                                        Console.WriteLine(AddBeans(numberOfBeans));
                                    }

                                    userInput = GetUserInput().ToLowerInvariant();
                                }
                                else
                                {
                                    Console.WriteLine("Beans at full capacity\n");
                                    userInput = GetUserInput().ToLowerInvariant();
                                }

                                break;

                            case 5:
                                if (MilkUnits < MaxMilkUnits)
                                {
                                    Console.WriteLine("Please enter the number of Milk units to refil by");
                                    string milkEntry = Console.ReadLine();
                                    bool isValidMilkEntry = int.TryParse(milkEntry, out int milkUnits);

                                    if (isValidMilkEntry)
                                    {
                                        Console.WriteLine(AddMilk(milkUnits));
                                    }
                                    userInput = GetUserInput().ToLowerInvariant();
                                }
                                else
                                {
                                    Console.WriteLine("Milk at full capacity\n");
                                    userInput = GetUserInput().ToLowerInvariant();
                                }

                                break;

                            default:
                                Console.WriteLine("Invalid entry...");
                                userInput = GetUserInput().ToLowerInvariant();
                                break;
                        }
                    }
                }
            }
        }

        private static string GetUserInput()
        {
            Console.WriteLine("Please enter the option of the hot beverage you want..." +
                "\n\n1. Coffee" +
                "\n2. Cappuccino" +
                "\n3. Latte" +
                "\n4. Refill Beans" +
                "\n5. Refill Milk" +
                "\n\nEnter \"off\" to exit"
                );
            return Console.ReadLine();
        }

        private static string GetMilkInput()
        {
            Console.WriteLine("Would you like Milk in your coffee? " +
                                              "\n1. Yes" +
                                              "\n2. No");
            return Console.ReadLine();

        }

        private static string AddBeans(int numberOfBeans)
        {
            if (NumberOfBeans < MaxNumberOfBeans)
            {
                if (numberOfBeans + NumberOfBeans > MaxNumberOfBeans)
                {
                    return $"Cannot add {numberOfBeans} number of Beans as it passes the maximum capacity of {MaxNumberOfBeans}\n";
                }
                else
                {
                    if (numberOfBeans <= MaxNumberOfBeans)
                    {
                        NumberOfBeans += numberOfBeans;
                        return "Beans Added\n";
                    }
                    return $"Cannot add more than {MaxNumberOfBeans} number of Beans\n";
                }
            }
            return "Bean capacity is full\n";
        }

        private static string AddMilk(int milkUnits)
        {
            if (MilkUnits < MaxMilkUnits)
            {
                if (milkUnits + MilkUnits > MaxMilkUnits)
                {
                    return $"Cannot add {milkUnits} number of Milk units as it passes the maximum capacity of {MaxMilkUnits}\n";
                }
                else
                {
                    if (milkUnits <= MaxMilkUnits)
                    {
                        MilkUnits += milkUnits;
                        return "Milk Added\n";
                    }
                    return $"Cannot add more than {MaxMilkUnits} units of Milk\n";
                }
                   
            }
            return "Milk capacity is full\n";
        }
    }
}