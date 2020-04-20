using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyDragAndDrop : MonoBehaviour
{
    public float startPosX;
    public float startPosY;
    public bool isBeingHeld = false;
    public bool snapBack = false;

    public Vector3 moveToPos;

    void Update()
    {
        if(Input.GetMouseButtonUp(0) && isBeingHeld) {
            isBeingHeld = false;
            this.gameObject.transform.localPosition = moveToPos;
        }
        // While clicked, update the position
        if(isBeingHeld == true) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, 
                mousePos.y - startPosY, 0);
        }
    }
}
