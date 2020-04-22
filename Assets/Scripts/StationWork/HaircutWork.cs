using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Haircut functionality
public class HaircutWork : MonoBehaviour
{
    private float timer = 0f;
    private GameObject person;
    private GameObject puppy;

    private bool isPerson = false;
    private bool isPuppy = false;
    private bool newCustomer = true;
    private bool changeMove = false;

    void Update() {
        // If puppy and person is there
        if(isPerson && isPuppy && newCustomer && puppy) {
            // If the puppy is not currently leaving and it hasn't been served yet, prevent them from moving,
            // pause happiness degradation, and alter attributes
            if(!puppy.GetComponent<PuppyCustomer>().puppyLeaving() && !changeMove) {
                person.GetComponent<PlayerClickToMove>().setMove();
                puppy.GetComponent<PuppyDragAndDrop>().setMove();
                puppy.GetComponent<PuppyCustomer>().pauseHappiness();
                puppy.GetComponent<PuppyCustomer>().destroyThought();
                puppy.GetComponent<PuppyCustomer>().instantiateCloud();
                changeMove = true;
            }
            // After 4 seconds, they can leave, and unpause happiness
            timer += (Time.deltaTime)%60;
            if(timer >= 4) {
                newCustomer = false;
                person.GetComponent<PlayerClickToMove>().setMove();
                puppy.GetComponent<PuppyDragAndDrop>().setMove();
                puppy.GetComponent<PuppyCustomer>().pauseHappiness();
                puppy.GetComponent<PuppyCustomer>().destroyCloud();
                puppy.GetComponent<PuppyCustomer>().removeStation(2);
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
