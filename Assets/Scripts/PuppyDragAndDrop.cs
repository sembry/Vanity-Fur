using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyDragAndDrop : MonoBehaviour
{
    bool canMove;
    bool dragging;
    Collider2D collider;
    Vector2 origPos;
    bool collided;
    Collision2D obj;

    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;

    private void OnMouseDown() {
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
        isBeingHeld = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(isBeingHeld == true) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, 
                mousePos.y - startPosY, 0);
        }
    }
}
