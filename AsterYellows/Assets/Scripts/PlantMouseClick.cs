using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMouseClick : MonoBehaviour
{
    public GameObject spawnObject;

    // Update is called once per frame
    void Update()
    {
        if (Dialogue.enableActions)
        {
            // Check if the mouse is over the game object
            if (IsMouseOverObject())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 offset = new Vector3(0, 0, 10);
                    Instantiate(spawnObject, pos + offset, Quaternion.identity);
                }
            }
        }
    }

    // Check if the mouse is over the game object
    bool IsMouseOverObject()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        return hit.collider != null && hit.collider.gameObject == gameObject;
    }
}
