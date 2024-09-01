using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> products = new List<GameObject>();

    public float money;

    public TextMeshProUGUI inventory;
    public TextMeshProUGUI moneyText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateMoney();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInventory()
    {
        string inventoryText = "";
        foreach (GameObject product in products)
        {
            inventoryText += product.name + "\n";
        }
        inventory.text = "Inventory:\n" + inventoryText;
    }

    public void UpdateMoney()
    {
        foreach (GameObject product in products)
        {
            Product productCost = product.GetComponent<Product>();
            money -= productCost.price;
        }
        products.Clear();
        UpdateInventory();
        moneyText.text = "Money: " + money;
    }
}
