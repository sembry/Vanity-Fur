using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
 	private Vector3 personPos;
    private Vector3 puppyPos;
    public GameObject player;
    public GameObject westie;

    // position vectors
 	private Vector3 pBathPos = new Vector3(-2.64f, 4.01f, 0);
    private Vector3 dBathPos = new Vector3(-5.61f, 2.25f, 0);
    private Vector3 pHaircutPos = new Vector3(1.93f, 3.86f, 0);
    private Vector3 dHaircutPos = new Vector3(-0.95f, 0.39f, 0);
    private Vector3 pMassagePos = new Vector3(7.53f, 3.77f, 0);
    private Vector3 dMassagePos = new Vector3(4.72f, 1.77f, 0);
    private Vector3 pCashPos = new Vector3(3.59f, -1.43f, 0);
    private Vector3 dCashPos = new Vector3(5.13f, -2.11f, 0);
    private Vector3 dTreatsPos = new Vector3(-7.85f, -4.27f, 0);

    private bool bathTaken = false;
    private bool haircutTaken = false;
    private bool massageTaken = false;
    private bool cashTaken = false;
    private bool treatsTaken = false;
    private bool newMachine = false;
    private bool isBeingHeld = false;

    // Find the player and dog and their positions
    void Start() {
        player = GameObject.Find("Player");
        westie = GameObject.Find("Westie");
        personPos = player.transform.position;
        puppyPos = westie.transform.position;
    } 

    void Update()
    {
        // If you unclick the mouse
        if(Input.GetMouseButtonUp(0)) {
            if(isBeingHeld) {
                isBeingHeld = false;
                newMachine = false;
                Collider2D clickedCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

                // Check if you hit a machine, if so update its availability
                switch(clickedCollider.name) {
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

                if(!newMachine) {
                    // do something later
                }
                else {
                    // Update the previous machine's availability
                    switch(westie.GetComponent<PuppyDragAndDrop>().getMachine()) {
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
                    westie.GetComponent<PuppyDragAndDrop>().setMachine(clickedCollider.name);
                    westie.GetComponent<PuppyDragAndDrop>().setMovePos(puppyPos);
                }
            }
        }

        // If you click the mouse
        if(Input.GetMouseButtonDown(0)) {
        	Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] clickedCollider = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            string name = "";
            
            // Array in case of overlapping colliders
            foreach(Collider2D col in clickedCollider) {
                name = col.name;
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
                case "Westie":
                    isBeingHeld = true;
                    westie.GetComponent<PuppyDragAndDrop>().setHeld(true);
                    westie.GetComponent<PuppyDragAndDrop>().setStartPos(mousePos.x - 
                    westie.transform.localPosition.x, mousePos.y - 
                    westie.transform.localPosition.y);
                    break;
        	}
            // Send the position back to the player
            player.GetComponent<PlayerClickToMove>().setPos(personPos);
        }
    }
}
