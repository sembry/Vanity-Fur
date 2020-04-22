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
    private float multiplier = 1;
    public AudioClip soundFile;

    private bool musicStarted = false;

    void Start() {
        moveToPos = transform.position;
        if(GameObject.Find("LevelController").GetComponent<SwitchLevels>().getCurrentLevel() >= 4) {
            multiplier = 1.5f;
        }
    }

    // Move towards new location
    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, moveToPos, 3f * Time.deltaTime * multiplier);
        if(transform.position == moveToPos) {
            if(!sendToMachine) {
                sendToMachine = true;
                addToMachine();
                stopMusic();
                musicStarted = false;
            }
        }
        else {
            if(!musicStarted) {
                startMusic();
                musicStarted = true;
            }
        }
    }

    public void startMusic() {
        GetComponent<AudioSource>().Play();
    }

    public void stopMusic() {
        GetComponent<AudioSource>().Stop();
    }

    // When move starts, update variables
    public void startMove(Vector3 pos, GameObject machine_) {
        moveToPos = pos;
        machine = machine_;
        sendToMachine = false;
    }

    public void addToMachine() {
        switch(machine.tag) {
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
                machine.GetComponent<CashWork>().send(gameObject);
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
