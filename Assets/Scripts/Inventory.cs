using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Inventory : MonoBehaviour
{
    private List<GameObject> spawnPoints = new List<GameObject>();
    public List<GameObject> productsInGame = new List<GameObject>();
    public List<GameObject> products = new List<GameObject>();
    public List<GameObject> productsInventory = new List<GameObject>();
    public List<GameObject> productsToBuy = new List<GameObject>();

    private float m_money = 100; 
    public float money
    {
        get { return m_money; }
        set 
        { 
            if (value < 0.0f)
            {
                Debug.LogError("Money can't be negative. Setting to 0");
                m_money = 0.0f;
            } 
            else
            {
                m_money = value;
            }
        }
    }

    public TextMeshProUGUI inventory;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI shopList;

    [SerializeField] private GameObject winText;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn Point").ToList();
        UpdateMoney();
        CreateShopList();
        CreateProducts();
    }

    // Update is called once per frame
    void Update()
    {
        if (shopList.text == "Shop List:\n")
        {
            winText.SetActive(true);
        } else
        {
            winText.SetActive(false);
        }
    }

    public void UpdateInventory()
    {
        string inventoryText = "";
        foreach (GameObject product in productsInventory)
        {
            inventoryText += product.name.Replace("(Clone)", "") + "\n";
        }
        inventory.text = "Inventory: \n" + inventoryText;
    }

    public bool UpdateShoppingList(string product)
    {
        if (shopList.text.Contains(product))
        {
            shopList.text = shopList.text.Replace(product, "<s>" + product + "</s>");
            return true;
        } else
        {
            return false;
        }
        
    }
    public void RemoveFromShoppingList()
    {
        foreach (GameObject product in productsInventory)
        {
            shopList.text = shopList.text.Replace("<s>" + product.name.Replace("(Clone)", "") + "</s>\n", "");
        }
    }

    public void UpdateMoney()
    {
        foreach (GameObject product in productsInventory)
        {
            Product productCost = product.GetComponent<Product>();
            money -= productCost.price;
        }
        productsInventory.Clear();
        UpdateInventory();
        moneyText.text = "Money: " + money;
    }

    public void CreateShopList()
    {
        string shopListText = "";
        for (int i = 0; i < 5; i++)
        {
            int index = Random.Range(0, products.Count);
            if (productsToBuy.Contains(products[index]))
            {
                i--;
            } else
            {
                productsToBuy.Add(products[index]);
                shopListText += products[index].name + "\n";
            }
        }
        shopList.text += "\n" + shopListText;
    }
    public void CreateProducts()
    {
        foreach(GameObject point in spawnPoints)
        {
            SpawnPoint spawnPoint = point.GetComponent<SpawnPoint>();
            spawnPoint.SpawnProduct();
        }
        productsInGame = GameObject.FindGameObjectsWithTag("Product").ToList();
        // CheckProducts();
    }

    /*public void CheckProducts()
    {
        foreach (GameObject product in productsInGame)
        {
            if (!productsToBuy.Contains(product))
            {
                Debug.Log("Balls");
                foreach (GameObject productInGame in productsInGame)
                {
                    Destroy(productInGame);
                }
                CreateProducts();
            }
        }
    }*/
}
