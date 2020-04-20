using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages all clicks for movement
public class ClickManager : MonoBehaviour
{
    private Vector3 personPos;
    private Vector3 puppyPos;
    public GameObject player;
    public GameObject puppy;

    Dictionary<string, bool> machineTaken = new Dictionary<string, bool>();
    Dictionary<string, Vector3> machineLoc = new Dictionary<string, Vector3>();

    private bool isBeingHeld = false;

    void Start() {
        // Find the player and its position
        player = GameObject.Find("Player");
        personPos = player.transform.position;

        // Populate dictionaries
        machineTaken.Add("Bath", false);
        machineTaken.Add("Haircut", false);
        machineTaken.Add("Massage", false);
        machineTaken.Add("Cash", false);
        machineTaken.Add("Treats", false);

        machineLoc.Add("pBath", new Vector3(-2.64f, 4.01f, 0));
        machineLoc.Add("dBath", new Vector3(-5f, 5f, 9));
        machineLoc.Add("pHaircut", new Vector3(1.93f, 3.86f, 0));
        machineLoc.Add("dHaircut", new Vector3(-0.2f, 2f, 0));
        machineLoc.Add("pMassage", new Vector3(7.53f, 3.77f, 0));
        machineLoc.Add("dMassage", new Vector3(5.5f, 4f, 0));
        machineLoc.Add("pCash", new Vector3(3.59f, -1.43f, 0));
        machineLoc.Add("dCash", new Vector3(5.7f, 0f, 0));
        machineLoc.Add("dTreats", new Vector3(-4f, -2f, 0));
    } 

    void Update()
    {
        // If you release the mouse
        if(Input.GetMouseButtonUp(0)) {
            if(isBeingHeld) {
                isBeingHeld = false;
                bool newMachine = false;
                Collider2D[] clickedCollider = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                Collider2D col = null;
            
                // Array because of overlapping colliders
                foreach(Collider2D col_ in clickedCollider) {
                    col = col_;
                    if(col_.tag != "Puppy") {
                        break;
                    }
                }
                if(col) {
                    // If you hit a machine
                    if(machineLoc.ContainsKey("d" + col.name)) {
                        // If it's not taken
                        if(machineTaken[col.name] == false) {
                            Debug.Log(col.name);
                            machineTaken[col.name] = true;
                            newMachine = true;
                            if(puppy.GetComponent<PuppyDragAndDrop>().getMachine()) {
                                // Set previous machine to untaken
                                if(machineTaken.ContainsKey(puppy.GetComponent<PuppyDragAndDrop>().getMachine().name)) {
                                    machineTaken[puppy.GetComponent<PuppyDragAndDrop>().getMachine().name] = false;
                                }
                            }
                            // Send the position and machine back to the puppy
                            puppy.GetComponent<PuppyDragAndDrop>().endDrag(machineLoc["d" + col.name], col.gameObject);
                        }
                    }
                }
                // Otherwise send the same location back
                if(!newMachine) {
                    Debug.Log("snapcback");
                    puppy.GetComponent<PuppyDragAndDrop>().sendBack();
                }
            }
        }

        // If you click the mouse
        if(Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] clickedCollider = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Collider2D col = null;
            
            // Array in case of overlapping colliders
            foreach(Collider2D col_ in clickedCollider) {
                col = col_;
                if(col_.tag == "Puppy") {
                    if(col_.gameObject.GetComponent<PuppyDragAndDrop>().getMove()) {
                        puppy = col_.gameObject;
                        puppy.GetComponent<PuppyDragAndDrop>().startDrag(mousePos);
                        isBeingHeld = true;
                    }
                    break;
                }
            }
            if(col) {
                // If you hit a machine, send the position back to the player
                if(machineLoc.ContainsKey("p" + col.name)) {
                    if(player.GetComponent<PlayerClickToMove>().getMove()) {
                        player.GetComponent<PlayerClickToMove>().startMove(machineLoc["p" + col.name], col.gameObject);
                    }
                }
            }
        }
    }
}
