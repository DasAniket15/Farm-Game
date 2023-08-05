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
    //public GameObject productPrefab;

    public GameObject[] products;

    public int pagenumber;

    public static bool Beinshop;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            products[i].SetActive(false);
        }
        Refresh();
    }

    // Update is called once per frame
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

        Beinshop = true;

        Refresh();
    }

    public void CloseShop()
    {
        shopWindow.SetActive(false);

        Beinshop = false;
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

}
