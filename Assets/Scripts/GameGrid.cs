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

    public bool gotgrid;


    public GameObject hitted;
    public GameObject field;
    private RaycastHit Hit;
    public bool creatingfield;

    public Texture2D basicCursor, fieldCursor, seedCursor;
    public CursorMode cursormode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public GameObject goldSystem;

    public int fieldprice;

    public GameObject seed;

      void Awake()
    {
        Cursor.SetCursor(basicCursor, hotSpot, cursormode);
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < columnLength * rowLength; i++)
        {
            Instantiate(grass, new Vector3(x_space + (x_space * (i % columnLength)), 0, z_space + (z_space * (i / columnLength))), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gotgrid == false)
        {
            CurrentGrid = GameObject.FindGameObjectsWithTag("grid");
            gotgrid = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out Hit))
            {
                if (creatingfield == true)
                {
                    if (Hit.transform.tag == "grid" && goldSystem.GetComponent<GoldSystem>().gold>=fieldprice)
                    {
                        hitted = Hit.transform.gameObject;
                        Instantiate(field, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);


                        goldSystem.GetComponent<GoldSystem>().gold -= fieldprice;

                    }

                    Cursor.SetCursor(fieldCursor, hotSpot, cursormode);
                }
            }
            if(Product.isSowing ==true)
            {
                if(Hit.transform.tag == "field" && goldSystem.GetComponent<GoldSystem>().gold >= fieldprice)
                {
                    hitted = Hit.transform.gameObject;
                    Instantiate(seed,hitted.transform.position, Quaternion.identity);
                    Destroy(hitted);

                    goldSystem.GetComponent<GoldSystem>().gold -= Product.currentProductPrice;
                }
            }

            if(creatingfield == false &&Product.isSowing == false)
            {
                if(Hit.transform.tag == "crop")
                {
                    hitted= Hit.transform.gameObject;
                    Instantiate(field, hitted.transform.position, Quaternion.identity);
                    Destroy(hitted);
                    print("Get crops +1");
                }
            }
        }


        if (creatingfield == true)
        {
            Cursor.SetCursor(fieldCursor, hotSpot, cursormode);
            Product.isSowing = false;
        }
        if (Shop.Beinshop == true)
        {
            creatingfield = false;
            Cursor.SetCursor(basicCursor, hotSpot, cursormode);
        }
        if(Product.isSowing== true)
        {
            creatingfield = false;
            Cursor.SetCursor(seedCursor, hotSpot, cursormode);
        }

        if(Input.GetMouseButtonDown(1))
        {
            ClearCursor();
        }
    }
    public void createField()
    {
        creatingfield = true;
    }
    public void returnToNormality()
    {
        creatingfield = false;
    }

    public void ClearCursor()
    {
        creatingfield= false;
        Product.isSowing= false;

        Cursor.SetCursor(basicCursor,hotSpot, cursormode);
    }
}
