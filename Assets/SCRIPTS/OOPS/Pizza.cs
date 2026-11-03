using Unity.VisualScripting;
using UnityEngine;

public enum PizzaType { Pepperoni=0, Margarita, Hawaiian, VegSupreme, ChickenRoyal}
public class Pizza : MenuItem
{
    public PizzaType Type;
    public int Quantity =1;
    public override float GetPrice()
    {
        return Price * Quantity;
    }
    public Pizza(PizzaType type)
    {
        switch (type)
        {
            case PizzaType.Pepperoni:
                {
                    this.Type = PizzaType.Pepperoni;
                    Name = "Pepperoni";
                    Price = 200f;
                    break;
                }
            case PizzaType.Margarita:
                {
                    this.Type = PizzaType.Margarita;
                    Name = "Margarita";
                    Price = 150f;
                    break;
                }
            case PizzaType.Hawaiian:
                {
                    this.Type = PizzaType.Hawaiian;
                    Name = "Hawaiian";
                    Price = 170f;
                    break;
                }
            case PizzaType.VegSupreme:
                {
                    this.Type = PizzaType.VegSupreme;
                    Name = "VegSupreme";
                    Price = 120f;
                    break;
                }
            case PizzaType.ChickenRoyal:
                {
                    this.Type = PizzaType.ChickenRoyal;
                    Name = "ChickenRoyal";
                    Price = 140f;
                    break;
                }
            default:
                {
                    break;
                }

                
        }
    }
}
