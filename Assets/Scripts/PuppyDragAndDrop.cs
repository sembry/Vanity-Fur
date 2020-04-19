using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyDragAndDrop : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;

    private void OnMouseDown() {
        // If clicked, update bool + get position
        if(Input.GetMouseButtonDown(0)) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp() {
        // If unclicked, update bool
        isBeingHeld = false;
    }

    void Update()
    {
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
