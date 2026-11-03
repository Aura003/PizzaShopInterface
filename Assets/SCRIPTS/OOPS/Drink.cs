using System.Threading;
using UnityEngine;

public enum DrinkType { Coke=0, FruitJuice, BobaTea}
public class Drink : MenuItem
{
    public int Quantity = 1;
    public DrinkType Type;
    public override float GetPrice()
    {
        return Price * Quantity;
    }
    public Drink(DrinkType type)
    {
        switch (type)
        {
            case DrinkType.Coke:
                {
                    this.Type = DrinkType.Coke;
                    Name = "CokeaCola";
                    Price = 60f;
                    break;
                }
            case DrinkType.FruitJuice:
                {
                    this.Type = DrinkType.FruitJuice;
                    Name = "FreshFruitJuice";
                    Price = 70f;
                    break;
                }
            case DrinkType.BobaTea:
                {
                    this.Type = DrinkType.BobaTea;
                    Name = "BobaTea";
                    Price = 90f;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
