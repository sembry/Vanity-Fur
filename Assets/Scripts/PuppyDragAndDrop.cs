using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles movement for the puppy
public class PuppyDragAndDrop : MonoBehaviour
{
    private GameObject machine;
    private GameObject thought;
    private GameObject slider;
    private int seat;

    private bool isBeingHeld = false;
    private bool canMove = false;

    private Vector3 previousPos;
    private Vector3 startPos;

    void Update()
    {
        // While clicked, puppy, thought, and happiness bar should follow the mouse
        if(isBeingHeld) {
            transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPos;
            if(thought) {
                thought.transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPos
                + new Vector3(0, 1, 0);
            }
            if(slider) {
                slider.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPos
                + new Vector3(0f, -0.72f, 0);
            }
        }
        // If mouse released, puppy and thought should stop following the mouse
        if(Input.GetMouseButtonUp(0) && isBeingHeld) {
            isBeingHeld = false;
        }
    }

    // When starting to drag, update variables
    public void startDrag(Vector3 mousePos) {
        isBeingHeld = true;
        startPos = mousePos - transform.localPosition;
    }

    // When drag ends, update variables and position
    public void endDrag(Vector3 machinePos, GameObject machine_) {
        isBeingHeld = false;
        previousPos = machinePos;
        transform.position = previousPos;
        if(thought) {
            thought.transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPos
            + new Vector3(0, 1, 0);
            }
        if(slider) {
            slider.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPos
            + new Vector3(0f, -0.72f, 0);
        }
        machine = machine_;
        if(seat != -1) {
            ChooseSeat.leaveSeat(seat);
            seat = -1;
        }
    }

    // If dragged to an invalid location, go back to orig location
    public void sendBack() {
      isBeingHeld = false;
      transform.position = previousPos;
      if(thought) {
      thought.transform.position = previousPos + new Vector3(0, 1, 0);
      }
      if(slider) {
        slider.transform.position = previousPos + new Vector3(0f, -0.72f, 0);
      }
    }

    // Getter & setter functions
    public void setThought(GameObject thought_) {
        thought = thought_;
    }

    public void setSlider(GameObject slider_) {
        slider = slider_;
    }

    public GameObject getMachine() {
        return machine;
    }

    public int getSeat() {
        return seat;
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
