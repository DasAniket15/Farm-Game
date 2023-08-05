using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Product : MonoBehaviour
{
    public GameObject shop;
    public GameObject goldSystem;
    
    public int id;
    public string productName;
    public int price;
    
    public Text nameText, PriceText;

    public static bool placeSeeds;
    public static int whichSeed;

    public static bool isSowing;

    public static int currentProductPrice;

    void Start()
    {
        shop = GameObject.Find("Shop");
        goldSystem = GameObject.Find("GoldSystem");
    }

    void Update()
    {
       nameText.text = "" + productName;
       PriceText.text = price + "£";

       productName = shop.GetComponent<Shop>().productName[id];
       price = shop.GetComponent<Shop>().price[id];
    }

    public void Buy()
    {
        if (goldSystem.GetComponent<GoldSystem>().gold >= price)
        {
            placeSeeds = true;
            whichSeed = id;

            currentProductPrice = price;

            isSowing = true;
        }
    }
}
