using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Massage functionality
public class MassageWork : MonoBehaviour
{
    private float timer = 0f;
    private GameObject person;
    private GameObject puppy;

    private bool isPerson = false;
    private bool isPuppy = false;
    private bool newCustomer = true;
    private bool changeMove = false;

    void Update() {
        // If puppy and person is there and it hasn't been served yet, prevent them from leaving
        if(isPerson && isPuppy && newCustomer) {
            if(!changeMove) {
                person.GetComponent<PlayerClickToMove>().setMove();
                puppy.GetComponent<PuppyDragAndDrop>().setMove();
                puppy.GetComponent<PuppyCustomer>().pauseHappiness();
                puppy.GetComponent<PuppyCustomer>().destroyThought();
                changeMove = true;
            }

            // After 5 seconds, they can leave, and unpause happiness
            timer += (Time.deltaTime)%60;
            if(timer >= 5) {
                newCustomer = false;
                person.GetComponent<PlayerClickToMove>().setMove();
                puppy.GetComponent<PuppyDragAndDrop>().setMove();
                puppy.GetComponent<PuppyCustomer>().pauseHappiness();
                // Update puppy's desired stations
                puppy.GetComponent<PuppyCustomer>().removeStation(3);
                timer = 0f;
            }
        }
    }

    // Setter functions
    public void send(GameObject p) {
        if(p.tag == "Puppy") {
            newCustomer = true;
            changeMove = false;
            puppy = p;
            isPuppy = true;
        }
        else {
            person = p;
            isPerson = true;
        }
    }

    public void remove(GameObject p) {
        if(p.tag == "Puppy") {
            puppy = null;
            isPuppy = false;
        }
        else {
            person = null;
            isPerson = false;
        }
    }
}
