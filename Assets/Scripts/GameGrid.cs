using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public int columnLength, rowLength;
    public float x_space, z_space;

    public GameObject grass;

    public GameObject[] CurrentGrid;

    public bool gotGrid;

    private GameObject hitted;
    public GameObject field;

    private RaycastHit Hit;
    public bool creatingField;

    public GameObject goldSystem;

    public int fieldPrice;
    public int profit;

    public GameObject Seed;

    void Start()
    {
        for (int i = 0; i < columnLength * rowLength; i++)
        {
            Instantiate(grass, new Vector3(x_space + (x_space * (i % columnLength)), 0, z_space + (z_space * (i / columnLength))), Quaternion.identity);
        }
    }

    void Update()
    {
        if (gotGrid == false)
        {
            CurrentGrid = GameObject.FindGameObjectsWithTag("Grid");
            gotGrid = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out Hit))
            {
                if (creatingField == true)
                {
                    if (Hit.transform.CompareTag("Grid") && goldSystem.GetComponent<GoldSystem>().gold >= fieldPrice)
                    {
                        hitted = Hit.transform.gameObject;
                        Instantiate(field, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        goldSystem.GetComponent<GoldSystem>().gold -= fieldPrice;
                    }
                }
            }

            if(Product.isSowing == true)
            {
                if(Hit.transform != null && Hit.transform.CompareTag("Field") && goldSystem.GetComponent<GoldSystem>().gold >= fieldPrice)
                {
                    hitted = Hit.transform.gameObject;
                    Instantiate(Seed, hitted.transform.position, Quaternion.identity);
                    Destroy(hitted);

                    goldSystem.GetComponent<GoldSystem>().gold -= Product.currentProductPrice;
                }
            }

            if(Hit.transform != null && creatingField == false && Product.isSowing == false)
            {
                if(Hit.transform.CompareTag("Crop"))
                {
                    hitted= Hit.transform.gameObject;
                    Instantiate(field, hitted.transform.position, Quaternion.identity);
                    Destroy(hitted);
                    
                    goldSystem.GetComponent<GoldSystem>().gold += profit;
                }
            }
        }

        if (creatingField == true)
        {
            Product.isSowing = false;
        }

        if (Shop.beInShop == true)
        {
            creatingField = false;
        }

        if(Product.isSowing== true)
        {
            creatingField = false;
        }

        if(Input.GetMouseButtonDown(1))
        {
            ClearCursor();
        }
    }

    public void createField()
    {
        creatingField = true;
    }

    public void StopCreatingField()
    {
        creatingField = false;
    }

    public void returnToNormality()
    {
        creatingField = false;
    }

    public void ClearCursor()
    {
        creatingField= false;
        Product.isSowing= false;
    }
}
