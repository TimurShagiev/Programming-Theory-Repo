using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    private Inventory inventory;

    public TextMeshProUGUI cursor;
    public GameObject dontNeedText;

    public bool onCursor { get; private set; } = false;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        cam = GetComponent<Camera>();
        Debug.Log(Screen.width / 2 + " - " + Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        CursorCheck();
    }

    public void CursorCheck()
    {
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Product")
            {
                cursor.text = "Take the " + hit.transform.gameObject.name.Replace("(Clone)", "") + "?";
                if (hit.collider.GetComponent<Alcohol>() != null) {
                    onCursor = true;
                }
                if(Input.GetMouseButtonDown(0))
                {
                    if (inventory.UpdateShoppingList(hit.collider.gameObject.name.Replace("(Clone)", "")))
                    {
                        inventory.productsInventory.Add(hit.collider.gameObject);
                        inventory.UpdateInventory();
                        hit.collider.gameObject.SetActive(false);
                    } else
                    {
                        dontNeedText.SetActive(true);
                    }
                }
            } else if (hit.collider.tag == "Cash Register")
            {
                cursor.text = "Buy products?";
                if(Input.GetMouseButtonDown(0))
                {
                    inventory.RemoveFromShoppingList();
                    inventory.UpdateMoney();
                }
            }
            else
            {
                dontNeedText.SetActive(false);
                onCursor = false;
                cursor.text = ".";
            }
        }
    }
}
