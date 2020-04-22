using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Treat functionality
public class TreatWork : MonoBehaviour
{
    private float timer = 0f;
    private GameObject puppy;

    private bool isPuppy = false;
    private bool newCustomer = true;
    private bool changeMove = false;

    void Update() {
    	// If puppy is there
        if(isPuppy && newCustomer) {
            // If the puppy is not currently leaving and it hasn't been served yet, prevent it from moving,
            // pause happiness degradation, and alter attributes
            if(!puppy.GetComponent<PuppyCustomer>().puppyLeaving() && !changeMove) {
                puppy.GetComponent<PuppyDragAndDrop>().setMove();
                puppy.GetComponent<PuppyCustomer>().pauseHappiness();
                puppy.GetComponent<PuppyCustomer>().addHappiness();
                puppy.GetComponent<PuppyCustomer>().destroyThought();
                puppy.GetComponent<PuppyCustomer>().instantiateCloud();
                changeMove = true;
            }
            // After 2 seconds, it can leave, and unpause happiness
            timer += (Time.deltaTime)%60;
            if(timer >= 2) {
                newCustomer = false;
                if(puppy) {
                    puppy.GetComponent<PuppyDragAndDrop>().setMove();
                    puppy.GetComponent<PuppyCustomer>().pauseHappiness();
                    puppy.GetComponent<PuppyCustomer>().instantiateThought();
                    puppy.GetComponent<PuppyCustomer>().destroyCloud();
                }
                timer = 0f;
            }
        }
    }

    // Setter functions
    public void send(GameObject p) {
        newCustomer = true;
        changeMove = false;
        puppy = p;
        isPuppy = true;
    }

    public void remove(GameObject p) {
        puppy = null;
        isPuppy = false;
    }
}
