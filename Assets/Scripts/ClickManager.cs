using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private Vector3 personPos;
    private Vector3 puppyPos;
    public GameObject player;
    public GameObject puppy;

    // position vectors
    private Vector3 pBathPos = new Vector3(-2.64f, 4.01f, 0);
    private Vector3 dBathPos = new Vector3(-5f, 5f, 0);
    private Vector3 pHaircutPos = new Vector3(1.93f, 3.86f, 0);
    private Vector3 dHaircutPos = new Vector3(-0.25f, 2f, 0);
    private Vector3 pMassagePos = new Vector3(7.53f, 3.77f, 0);
    private Vector3 dMassagePos = new Vector3(5.5f, 4f, 0);
    private Vector3 pCashPos = new Vector3(3.59f, -1.43f, 0);
    private Vector3 dCashPos = new Vector3(5.13f, -2.11f, 0);
    private Vector3 dTreatsPos = new Vector3(-4f, -2f, 0);

    private bool bathTaken = false;
    private bool haircutTaken = false;
    private bool massageTaken = false;
    private bool cashTaken = false;
    private bool treatsTaken = false;
    private bool newMachine = false;
    private bool isBeingHeld = false;

    // Find the player and its position
    void Start() {
        player = GameObject.Find("Player");
        personPos = player.transform.position;
    } 

    void Update()
    {
        // If you release the mouse
        if(Input.GetMouseButtonUp(0)) {
            if(isBeingHeld) {
                isBeingHeld = false;
                newMachine = false;
                Collider2D[] clickedCollider = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                string name = "";
                Collider2D col = null;
            
                // Array because of overlapping colliders
                foreach(Collider2D col_ in clickedCollider) {
                    Debug.Log(col_.name);
                    name = col_.name;
                    col = col_;
                    if(col_.tag != "Puppy") {
                        break;
                    }
                }
                // Check if you hit a machine, if so update its availability
                switch(name) {
                    case "Bath":
                        if(!bathTaken) {
                            newMachine = true;
                            puppyPos = dBathPos;
                            bathTaken = true;
                        }
                        break;
                    case "Haircut":
                        if(!haircutTaken) {
                            newMachine = true;
                            puppyPos = dHaircutPos;
                            haircutTaken = true;
                        }
                        break;
                    case "Massage":
                        if(!massageTaken) {
                            newMachine = true;
                            puppyPos = dMassagePos;
                            massageTaken = true;
                        }
                        break;
                    case "Cash":
                        if(!cashTaken) {
                            newMachine = true;
                            puppyPos = dCashPos;
                            cashTaken = true;
                        }
                        break;
                    case "Treats":
                        if(!treatsTaken) {
                            newMachine = true;
                            puppyPos = dTreatsPos;
                            treatsTaken = true;
                        }
                        break;
                }

                // If you didn't release on a machine or if the machine is already taken, go back
                if(!newMachine) {
                    puppy.GetComponent<PuppyDragAndDrop>().changePos();
                }
                else {
                    // Update the previous machine's availability
                    switch(puppy.GetComponent<PuppyDragAndDrop>().getMachine()) {
                        case "Bath":
                            bathTaken = false;
                            break;
                        case "Haircut":
                            haircutTaken = false;
                            break;
                        case "Massage":
                            massageTaken = false;
                            break;
                        case "Cash":
                            cashTaken = false;
                            break;
                        case "Treats":
                            treatsTaken = false;
                            break;
                    }
                    // Send the position and machine back to the puppy
                    puppy.GetComponent<PuppyDragAndDrop>().setMachine(name);
                    puppy.GetComponent<PuppyDragAndDrop>().setMovePos(puppyPos);
                    puppy.GetComponent<PuppyDragAndDrop>().changePos();
                }
            }
        }

        // If you click the mouse
        if(Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] clickedCollider = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            string name = "";
            Collider2D col = null;
            
            // Array in case of overlapping colliders
            foreach(Collider2D col_ in clickedCollider) {
                name = col_.name;
                col = col_;
                if(col_.tag == "Puppy") {
                    break;
                }
            }

            // Check if you hit a machine, if so, update the target position
            switch(name) {
                case "Bath":
                    personPos = pBathPos;
                    break;
                case "Haircut":
                    personPos = pHaircutPos;
                    break;
                case "Massage":
                    personPos = pMassagePos;
                    break;
                case "Cash":
                    personPos = pCashPos;
                    break;
                // If you click the dog, send it back to the puppy script so they can handle drag
                default:
                    if(col) {
                        if(col.tag == "Puppy") {
                            isBeingHeld = true;
                            puppy = col.gameObject;
                            puppy.GetComponent<PuppyDragAndDrop>().setHeld(true);
                            puppy.GetComponent<PuppyDragAndDrop>().setStartPos(mousePos.x - 
                            puppy.transform.localPosition.x, mousePos.y - 
                            puppy.transform.localPosition.y);
                        }
                    }
                    break;
            }
            // Send the position back to the player
            player.GetComponent<PlayerClickToMove>().setPos(personPos);
        }
    }
}
