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
        machineLoc.Add("dBath", new Vector3(-4.88f, 4.75f, 0));
        machineLoc.Add("pHaircut", new Vector3(1.93f, 3.86f, 0));
        machineLoc.Add("dHaircut", new Vector3(-0.17f, 2.55f, 0));
        machineLoc.Add("pMassage", new Vector3(7.53f, 3.77f, 0));
        machineLoc.Add("dMassage", new Vector3(5.5f, 4f, 0));
        machineLoc.Add("pCash", new Vector3(6.52f, -1.86f, 0));
        machineLoc.Add("dCash", new Vector3(4.01f, -1.42f, 0));
        machineLoc.Add("dTreats", new Vector3(-3.59f, -1.7f, 0));
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
                        // If the machine is desired
                        if((puppy.GetComponent<PuppyCustomer>().nextStation() == col.name) || col.name == "Treats") {
                            // If it's not taken
                            if(machineTaken[col.name] == false) {
                                machineTaken[col.name] = true;
                                newMachine = true;
                                if(puppy.GetComponent<PuppyDragAndDrop>().getMachine()) {
                                    // Set previous machine to untaken and remove puppy from previous machine
                                    machineTaken[puppy.GetComponent<PuppyDragAndDrop>().getMachine().name] = false;
                                    sendToMachine(puppy, puppy.GetComponent<PuppyDragAndDrop>().getMachine(), false);
                                }
                                // Send the position and machine back to the puppy and the puppy to the machine
                                puppy.GetComponent<PuppyDragAndDrop>().endDrag(machineLoc["d" + col.name], col.gameObject);
                                sendToMachine(puppy, col.gameObject, true);
                            }
                        }
                    }
                }
                // Otherwise send the same location back
                if(!newMachine) {
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
                        // Remove player from previous machine
                        if(player.GetComponent<PlayerClickToMove>().getMachine()) {
                            sendToMachine(player, player.GetComponent<PlayerClickToMove>().getMachine(), false);
                        }
                        player.GetComponent<PlayerClickToMove>().startMove(machineLoc["p" + col.name], col.gameObject);
                    }
                }
            }
        }
    }

    // Sends player and puppy info to a given machine
    public void sendToMachine(GameObject p, GameObject machine, bool a) {
        switch(machine.name) {
            case "Bath":
                if(a) machine.GetComponent<BathWork>().send(p);
                else machine.GetComponent<BathWork>().remove(p);
                break;
            case "Haircut":
                if(a) machine.GetComponent<HaircutWork>().send(p);
                else machine.GetComponent<HaircutWork>().remove(p);
                break;
            case "Massage":
                if(a) machine.GetComponent<MassageWork>().send(p);
                else machine.GetComponent<MassageWork>().remove(p);
                break;
            case "Cash":
                if(a) machine.GetComponent<CashWork>().send(p);
                else machine.GetComponent<CashWork>().remove(p);
                break;
            case "Treats":
                if(a) machine.GetComponent<TreatWork>().send(p);
                else machine.GetComponent<TreatWork>().remove(p);
                break;
        }
    }

    // Frees up cash after a puppy has left
    public void freeMachine(string machine) {
        machineTaken[machine] = false;
    }
}
