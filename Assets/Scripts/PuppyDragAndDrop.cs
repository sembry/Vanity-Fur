using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles movement for the puppy
public class PuppyDragAndDrop : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private string machine = "";
    private int seat;

    private bool isBeingHeld = false;
    private bool canMove = false;

    public Vector3 previousPos;

    void Update()
    {
        if(Input.GetMouseButtonUp(0) && isBeingHeld) {
            isBeingHeld = false;
        }
        // While clicked, update the position
        if(isBeingHeld) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
    }

    public void startDrag(Vector3 mousePos) {
        if(canMove) {
            isBeingHeld = true;
            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;
        }
    }

    public void endDrag(Vector3 machinePos, string machineName) {
        previousPos = machinePos;
        transform.position = previousPos;
        machine = machineName;
        if(seat != -1) {
            ChooseSeat.leaveSeat(seat);
            seat = -1;
        }
    }

    public void sendBack() {
        transform.position = previousPos;
    }

    // Getter & setter functions
    public string getMachine() {
        return machine;
    }
    
    public void setSeat(int i) {
        seat = i;
    }

    public void setPreviousPos(Vector3 pos) {
        previousPos = pos;
    }

    public bool getMove() {
        return canMove;
    }

    public void setMove() {
        canMove ^= true;
    }
}
