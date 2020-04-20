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

    private bool didMove = false;
    private bool isBeingHeld = false;
    private bool isMoving = true;

    private Vector3 seat1 = new Vector3(0f, -3.75f, 0f);
    private Vector3 seat2 = new Vector3(-1.6f, -3.75f, 0f);
    private Vector3 seat3 = new Vector3(-3.2f, -3.75f, 0f);

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

            transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
    }

    // tells puppy to snap to a position
    public void changePos() {
        // Check if you are leaving a seat
        if(seat != -1 && didMove) {
            ChooseSeat.leaveSeat(seat);
            seat = -1;
        }
        transform.position = moveToPos;
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

    public void setSeat(int i) {
        seat = i;
    }

    public void setMoving() {
        isMoving = false;
    }

    public bool getMoving() {
        return isMoving;
    }

    public void setMove() {
        didMove = true;
    }
}
