using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles movement for the player
public class PlayerClickToMove : MonoBehaviour
{
    private Vector3 moveToPos;
    private bool canMove = true;
    private GameObject machine;
    private bool sendToMachine = true;

    void Start() {
        moveToPos = transform.position;
    }

    // Move towards new location
    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, moveToPos, 3f * Time.deltaTime);
        if((transform.position == moveToPos) && !sendToMachine) {
            sendToMachine = true;
            addToMachine();
        }
    }

    // When move starts, update variables
    public void startMove(Vector3 pos, GameObject machine_) {
        moveToPos = pos;
        machine = machine_;
        sendToMachine = false;
    }

    public void addToMachine() {
        switch(machine.name) {
            case "Bath":
                machine.GetComponent<BathWork>().send(gameObject);
                break;
            case "Haircut":
                machine.GetComponent<HaircutWork>().send(gameObject);
                break;
            case "Massage":
                machine.GetComponent<MassageWork>().send(gameObject);
                break;
            case "Cash":
                machine.GetComponent<CashWork>().send(gameObject, null);
                break;
        }
    }

    // Getter & setter functions
    public bool getMove() {
        return canMove;
    }

    public void setMove() {
        canMove ^= true;
    }

    public GameObject getMachine() {
        return machine;
    }
}
