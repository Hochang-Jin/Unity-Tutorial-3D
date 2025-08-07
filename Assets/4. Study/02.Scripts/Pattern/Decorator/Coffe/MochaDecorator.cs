using UnityEngine;

public class MochaDecorator : CoffeeDecorator
{
    public MochaDecorator(ICoffee coffee) : base(coffee)
    {
        
    }

    public string Name()
    {
        return coffee.Name() + "Mocha";
    }

    public int Cost()
    {
        return coffee.Cost() + 1500;
    }
}
