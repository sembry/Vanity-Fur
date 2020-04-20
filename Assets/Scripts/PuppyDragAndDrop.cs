using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyDragAndDrop : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    private string machine = "";
    public bool done = false;

    public Vector3 moveToPos;

    void Update()
    {
        if(Input.GetMouseButtonUp(0) && isBeingHeld) {
            isBeingHeld = false;
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

    // tells puppy to snap to a position
    public void changePos() {
        this.gameObject.transform.position = moveToPos;
    }

        // Getter & setter functions
    public void setStartPos(float a, float b) {
        startPosX = a;
        startPosY = b;
    }

    public void setMovePos(Vector3 pos) {
        moveToPos = pos;
    }

    public void setHeld(bool a) {
        isBeingHeld = a;
    }

    public void setMachine(string machine_) {
        machine = machine_;
    }

    public string getMachine() {
        return machine;
    }
}
