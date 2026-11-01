using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("GlobalButtons")]
    public Button CustomerBTN;
    public Button MenuBTN;
    public Button PaymentBTN;
    [Header("MenuPanel")]
    public Image MenuPanel;
    public Button CloseMenuBTN;
    public Button CartBTN;
    public TMP_Text CartItemsTMP;
    [Space]
    public Button PepperoniBTN;
    public Button MargaritaBTN;
    public Button HawaiianBTN;
    public Button VegSupremeBTN;
    public Button ChickenRoyalBTN;
    public Button CokeBTN;
    public Button FruitJuiceBTN;
    public Button BobaTeaBTN;
    [Header("OrdersPanel")]
    public Image OrderPanel;
    public Button CloseOrderBTN;
    public Button ConfirmOrderBTN;
    public TMP_Text CustomerNameTMP;
    public TMP_Text CustomerContactTMP;
    public GameObject OrderDetailsPrefab;
    public Transform DetailsSpawnPointParent;

    [Header("CustomerPanel")]
    public Image CustomerDetailsPanel;
    public TMP_InputField CustomerNameInputField;
    public TMP_InputField CustomerContactInputField;
    public Button ConfirmDetailsBTN;

    [Header("BillingPanel")]
    public Image BillingPanel;
    public Button ProceedToPaymentBTN;
    public Button CloseBillBTN;
    public TMP_Text BillNoTMP;
    public TMP_Text DateTMP;
    public TMP_Text TableNoTMP;
    public TMP_Text SubTotalTMP;
    public TMP_Text TaxTMP;
    public TMP_Text GrandTotalTMP;


    private int orderCount;
    private void OnEnable()
    {
        MenuBTN.interactable = false;
        PaymentBTN.interactable = false;
        

        MenuBTN.onClick.AddListener(delegate { MenuPanel.gameObject.SetActive(true); });
        PaymentBTN.onClick.AddListener(delegate {BillingPanel.gameObject.SetActive(true); });
        CloseMenuBTN.onClick.AddListener(delegate { MenuPanel.gameObject.SetActive(false); });
        CartBTN.onClick.AddListener(delegate {  OrderPanel.gameObject.SetActive(true); });
        CloseOrderBTN.onClick.AddListener(delegate { OrderPanel.gameObject.SetActive(false); });
        CustomerBTN.onClick.AddListener(delegate { CustomerDetailsPanel.gameObject.SetActive(true); });
        CloseBillBTN.onClick.AddListener(delegate {BillingPanel.gameObject.SetActive(false); });

        ConfirmDetailsBTN.onClick.AddListener(CreateNewCustomer);
        ConfirmOrderBTN.onClick.AddListener(ConfirmOrders);
        
    }
    private void OnDisable()
    {
        MenuBTN.onClick.RemoveAllListeners();
        PaymentBTN.onClick.RemoveAllListeners();
        CloseMenuBTN.onClick.RemoveAllListeners();
        CartBTN.onClick.RemoveAllListeners();
        CloseOrderBTN.onClick.RemoveAllListeners();
        CustomerBTN.onClick.RemoveAllListeners();
        CloseBillBTN.onClick.RemoveAllListeners();

        ConfirmDetailsBTN.onClick.RemoveListener(CreateNewCustomer);
        ConfirmOrderBTN.onClick.RemoveListener(ConfirmOrders);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuPanel.gameObject.SetActive(false);
        OrderPanel.gameObject.SetActive(false);
        CustomerDetailsPanel.gameObject.SetActive(false);
        BillingPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPizzaToOrder(int pizzaType)
    {
        if (GameManager.Instance.CurrentCustomer != null)
        {
            Pizza currentPizza = new Pizza((PizzaType)pizzaType);
            GameManager.Instance.CurrentCustomer.AddItemsToOrder(currentPizza);
            orderCount++;
            CartItemsTMP.text = orderCount.ToString();
            GameManager.Instance.CurrentCustomer.ShowAllItems();

            GameObject go = Instantiate(OrderDetailsPrefab, DetailsSpawnPointParent);
            OrderDetails details = go.GetComponent<OrderDetails>();
            details.OrderNameTMP.text = currentPizza.Name;
            details.OrderPriceTMP.text = currentPizza.Price.ToString();
            details.QuantityTMP.text = 1.ToString();
        }
    }
    public void AddDrinkToOrder(int drinkType)
    {
        if (GameManager.Instance.CurrentCustomer != null)
        {
            Drink currentDrink = new Drink((DrinkType)drinkType);
            GameManager.Instance.CurrentCustomer.AddItemsToOrder(currentDrink);
            orderCount++;
            CartItemsTMP.text = orderCount.ToString();
            GameManager.Instance.CurrentCustomer.ShowAllItems();

            GameObject go = Instantiate(OrderDetailsPrefab, DetailsSpawnPointParent);
            OrderDetails details = go.GetComponent<OrderDetails>();
            details.OrderNameTMP.text = currentDrink.Name;
            details.OrderPriceTMP.text = currentDrink.Price.ToString();
            details.QuantityTMP.text = 1.ToString();
        }
    }
    public void CreateNewCustomer()
    {
        if (GameManager.Instance.CurrentCustomer == null)
        {
            string customerName = CustomerNameInputField.text;
            string customerContact = CustomerContactInputField.text;
            CustomerNameTMP.text = "Customer Name : "+ customerName;
            CustomerContactTMP.text = "Contact : " + customerContact;
            GameManager.Instance.CurrentCustomer = new Customer(customerName, customerContact);
        }

        if (GameManager.Instance.CurrentCustomer != null)
        {
            //Save details of previous customer if payment was made
            //Create a new Customer
            //assign new customer to currentCustomer
        }
        CustomerDetailsPanel.gameObject.SetActive(false);
        MenuBTN.interactable = true;
        GameManager.Instance.CurrentCustomer.ShowAllItems();
    }
    public void ConfirmOrders()
    {
        PaymentBTN.interactable = true;
        OrderPanel.gameObject.SetActive(false);
        MenuPanel.gameObject.SetActive(false);
    }
}
