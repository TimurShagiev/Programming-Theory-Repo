using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    public Transform target;
    public TextMeshProUGUI cursor;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
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
            }
            else
            {
                cursor.text = ".";
            }
        }
    }
}
