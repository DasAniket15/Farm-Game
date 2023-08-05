using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int[] id;
    public string[] productName;
    public int[] price;
    
    public int numberofProduct;
    public GameObject shopWindow;
    // public GameObject productPrefab;

    public GameObject[] products;

    public int pagenumber;

    public static bool beInShop;

    void Start()
    {
        for (int i = 0; i < numberofProduct; i++)
        {
            products[i].SetActive(false);
        }

        Refresh();
    }

    void Update()
    {
        if (Product.isSowing == true)
        {
            CloseShop();
        }
    }

    public void OpenShop()
    {
        shopWindow.SetActive(true);

        beInShop = true;

        Refresh();
    }

    public void CloseShop()
    {
        shopWindow.SetActive(false);

        beInShop = false;
    }

    public void Refresh()
    {
        for (int i = 0; i < numberofProduct; i++)
        {
            products[i].SetActive(false);
        }

        if (pagenumber == 1)
        {
            for (int i = 0; i < numberofProduct; i++)
            {
                products[i].GetComponent<Product>().id = id[i];
                products[i].SetActive(true);
            }
        }
    }

    public void Left()
    {

    }

    public void Right()
    {

    }
}
