using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles movement for the puppy
public class PuppyDragAndDrop : MonoBehaviour
{
    private string machine = "";
    private int seat;

    private bool isBeingHeld = false;
    private bool canMove = false;

    private Vector3 previousPos;
    private Vector3 startPos;

    void Update()
    {
        // While clicked, follow the mouse
        if(isBeingHeld) {
            transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPos;
        }
    }

    // When starting to drag, update variables
    public void startDrag(Vector3 mousePos) {
        isBeingHeld = true;
        startPos = mousePos - transform.localPosition;
    }

    // When drag ends, update variables 
    public void endDrag(Vector3 machinePos, string machineName) {
    	isBeingHeld = false;
        previousPos = machinePos;
        transform.position = previousPos;
        machine = machineName;
        if(seat != -1) {
            ChooseSeat.leaveSeat(seat);
            seat = -1;
        }
    }

    // If dragged to an invalid location, go back to orig location
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
