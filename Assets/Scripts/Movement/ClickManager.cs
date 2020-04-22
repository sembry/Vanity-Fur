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
        machineTaken.Add("Bath2", false);
        machineTaken.Add("Haircut", false);
        machineTaken.Add("Haircut2", false);
        machineTaken.Add("Massage", false);
        machineTaken.Add("Massage2", false);
        machineTaken.Add("Cash", false);
        machineTaken.Add("Treats", false);
        machineTaken.Add("Playpen", false);

        machineLoc.Add("pBath", new Vector3(-5f, 4.04f, 0));
        machineLoc.Add("dBath", new Vector3(-7.37f, 5.08f, 0));
        machineLoc.Add("pBath2", new Vector3(-5f, 0.88f, 0));
        machineLoc.Add("dBath2", new Vector3(-7.37f, 1.8f, 0));

        machineLoc.Add("pHaircut", new Vector3(-0.07f, 3.76f, 0));
        machineLoc.Add("dHaircut", new Vector3(-1.95f, 4.52f, 0));
        machineLoc.Add("pHaircut2", new Vector3(3.88f, 3.76f, 0));
        machineLoc.Add("dHaircut2", new Vector3(1.95f, 4.49f, 0));

        machineLoc.Add("pMassage", new Vector3(5.15f, 4.35f, 0));
        machineLoc.Add("dMassage", new Vector3(7.46f, 4.35f, 0));
        machineLoc.Add("pMassage2", new Vector3(5.15f, 2.06f, 0));
        machineLoc.Add("dMassage2", new Vector3(7.46f, 2.06f, 0));

        machineLoc.Add("pCash", new Vector3(8.39f, -1.68f, 0));
        machineLoc.Add("dCash", new Vector3(4.53f, -2.18f, 0));
        machineLoc.Add("dTreats", new Vector3(-5.92f, -4.54f, 0));
        machineLoc.Add("dPlaypen", new Vector3(2.25f, -0.42f, 0));
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
                        if((puppy.GetComponent<PuppyCustomer>().getStation() == col.tag) || col.tag == "Treats" 
                            || col.tag == "Playpen") {
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
        switch(machine.tag) {
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
