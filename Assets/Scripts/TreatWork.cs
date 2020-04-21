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
    	// If puppy is there and it hasn't already been served, prevent it from moving
        if(isPuppy && newCustomer) {
            if(!changeMove) {
                puppy.GetComponent<PuppyDragAndDrop>().setMove();
                changeMove = true;
            }

            // After 3 seconds, it can leave
            timer += (Time.deltaTime)%60;
            if(timer >= 3) {
                newCustomer = false;
                puppy.GetComponent<PuppyDragAndDrop>().setMove();
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
