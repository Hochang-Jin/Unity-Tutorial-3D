using UnityEngine;

public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee)
    {
        
    }

    public string Name()
    {
        return coffee.Name() + "Milk";
    }

    public int Cost()
    {
        return coffee.Cost() + 1000;
    }
}
