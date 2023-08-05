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

    public GameObject hitted;
    public GameObject field;

    private RaycastHit Hit;
    public bool creatingField;

    public Texture2D basicCursor, fieldCursor, seedCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public GameObject goldSystem;

    public int fieldPrice;

    public GameObject Seed;

    void Awake()
    {
        Cursor.SetCursor(basicCursor, hotSpot, cursorMode);
    }

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
                    Debug.Log("Get crops +1");
                }
            }
        }

        if (creatingField == true)
        {
            Cursor.SetCursor(fieldCursor, hotSpot, cursorMode);
            Product.isSowing = false;
        }
        else
        {
            Cursor.SetCursor(basicCursor, hotSpot, cursorMode);
        }

        if (Shop.beInShop == true)
        {
            creatingField = false;
            Cursor.SetCursor(basicCursor, hotSpot, cursorMode);
        }

        if(Product.isSowing== true)
        {
            creatingField = false;
            Cursor.SetCursor(seedCursor, hotSpot, cursorMode);
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

        Cursor.SetCursor(basicCursor, hotSpot, cursorMode);
    }
}
