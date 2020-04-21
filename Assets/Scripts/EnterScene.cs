using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles puppy variables and the initiation of a new puppy
public class EnterScene : MonoBehaviour
{
	// seat locations
    private Vector3 seat1 = new Vector3(2.87f, -3.61f, 0f);
    private Vector3 seat2 = new Vector3(-0.1f, -3.61f, 0f);
    private Vector3 seat3 = new Vector3(-3.14f, -3.61f, 0f);

    private Vector3 moveToPos;
    PuppyDragAndDrop script;

    void Start() {
        transform.position = new Vector3(10f, -3.75f, 0);
        script = GetComponent<PuppyDragAndDrop>();

        // Check for a seat, and go to it or leave if there's no space
        int check = ChooseSeat.checkSeat();
        switch(check) {
            case 1:
                moveToPos = seat1;
                script.setSeat(1);
                script.setPreviousPos(seat1);
                break;
            case 2:
                moveToPos = seat2;
                script.setSeat(2);
                script.setPreviousPos(seat2);
                break;
            case 3:
                moveToPos = seat3;
                script.setSeat(3);
                script.setPreviousPos(seat3);
                break;
            default:
                Destroy(gameObject);
                break;
        }
    }

    void finished() {
        script.setMove();
        GetComponent<PuppyCustomer>().pauseHappiness();
        Destroy(this);
    }

    // Moves to the chair and then destroys the script
    void Update() {
        if(transform.position.x > moveToPos.x) {
            transform.position = Vector2.MoveTowards(transform.position, moveToPos, 3f * Time.deltaTime);
        }
        else {
        	finished();
        }
    }
}
