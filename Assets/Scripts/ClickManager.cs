using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
 	private Vector3 personPos;
    private Vector3 puppyPos;
    public GameObject player;
    public GameObject westie;

 	private Vector3 pBathPos = new Vector3(-2.64f, 4.01f, 0);
    private Vector3 dBathPos = new Vector3(-5.61f, 2.25f, 0);
    private Vector3 pHaircutPos = new Vector3(1.93f, 3.86f, 0);
    private Vector3 dHaircutPos = new Vector3(-0.95f, 0.39f, 0);
    private Vector3 pMassagePos = new Vector3(7.53f, 3.77f, 0);
    private Vector3 dMassagePos = new Vector3(4.72f, 1.77f, 0);
    private Vector3 pCashPos = new Vector3(3.59f, -1.43f, 0);
    private Vector3 dCashPos = new Vector3(5.13f, -2.11f, 0);

    private bool bathTaken = false;
    private bool haircutTaken = false;
    private bool massageTaken = false;
    private bool cashTaken = false;
    private bool newMachine = false;
    private bool isBeingHeld = false;

    void Start() {
        player = GameObject.Find("Player");
        westie = GameObject.Find("Westie");
        personPos = player.transform.position;
        puppyPos = westie.transform.position;
    } 

    void Update()
    {
        if(Input.GetMouseButtonUp(0)) {
            if(isBeingHeld) {
                isBeingHeld = false;
                newMachine = false;
                Collider2D clickedCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

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
                }

                if(!newMachine) {
                    // westie.GetComponent<PuppyDragAndDrop>().snapBack = true;
                }
                else {
                    switch(westie.GetComponent<PuppyDragAndDrop>().machine) {
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
                    }

                    westie.GetComponent<PuppyDragAndDrop>().machine = clickedCollider.name;
                    westie.GetComponent<PuppyDragAndDrop>().moveToPos = puppyPos;
                }
            }
        }

        if(Input.GetMouseButtonDown(0)) {
        	Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        	// Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        	// RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            Collider2D[] clickedCollider = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            string name = "";
            
            foreach(Collider2D col in clickedCollider) {
                name = col.name;
            }

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
                case "Westie":
                    isBeingHeld = true;
                    westie.GetComponent<PuppyDragAndDrop>().isBeingHeld = true;
                    westie.GetComponent<PuppyDragAndDrop>().startPosX = mousePos.x - 
                    westie.transform.localPosition.x;
                    westie.GetComponent<PuppyDragAndDrop>().startPosY = mousePos.y - 
                    westie.transform.localPosition.y;
                    break;
        	}
            player.GetComponent<PlayerClickToMove>().moveToPos = personPos;
        }
    }
}
