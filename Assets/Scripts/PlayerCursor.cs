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

    public bool isClicked;

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
                cursor.text = "Take the " + hit.transform.gameObject.name + "?";
                if(Input.GetMouseButtonDown(0))
                {
                    inventory.products.Add(hit.collider.gameObject);
                    inventory.UpdateInventory();
                    hit.collider.gameObject.SetActive(false);
                    isClicked = true;
                }
            } else if (hit.collider.tag == "Cash Register")
            {
                cursor.text = "Buy products?";
                if(Input.GetMouseButtonDown(0))
                {
                    inventory.UpdateMoney();
                }
            }
            else
            {
                cursor.text = ".";
                isClicked = false;
            }
        }
    }
}
