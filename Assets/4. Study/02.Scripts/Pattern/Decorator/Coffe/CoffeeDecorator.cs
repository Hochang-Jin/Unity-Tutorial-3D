using UnityEngine;

public class CoffeeDecorator : ICoffee
{
    protected ICoffee coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }
    public string Name()
    {
        return coffee.Name();
    }

    public int Cost()
    {
        return coffee.Cost();
    }
}
