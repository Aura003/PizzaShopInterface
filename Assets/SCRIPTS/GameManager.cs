using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { private set; get; }
    public Customer CurrentCustomer;

    private void Awake()
    {
        if (Instance != this && Instance!=null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
    private void OnDestroy()
    {
        Instance = null;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Customer MyOrder = new Customer("John","9886667812");
        //MyOrder.AddItemsToOrder(new Pizza(PizzaType.Pepperoni));
        //MyOrder.AddItemsToOrder(new Drink(DrinkType.Coke));
        //MyOrder.ShowAllItems();
        CurrentCustomer = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class Customer
{    public List<MenuItem> orderBag = new List<MenuItem>();
    public string CustomerName;
    public string ContactNo;
    public float Total;
    public bool HasPaymentMade = false;
    public Customer(string name, string contact)
    {
        this.CustomerName = name;
        this.ContactNo = contact;
    }
    public int GetOrderCount()
    {
        if (orderBag.Count <= 0)
            return 0;

        return orderBag.Count;
    }
    public void AddItemsToOrder(MenuItem myitem)
    {
        orderBag.Add(myitem);
    }
    public void ShowAllItems()
    {
        Debug.Log("\nCustomer Name : " + CustomerName);
        Debug.Log("\nCustomer Contact : " + ContactNo);
        foreach (MenuItem x in orderBag)
        {
            Debug.Log(x.Name + " : " +x.Price.ToString());
            Total += x.Price;
        }
        Debug.Log("\nTotal : " + Total.ToString());
        Total = 0;
    }
}
