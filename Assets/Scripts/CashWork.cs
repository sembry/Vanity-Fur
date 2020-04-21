﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cash functionality
public class CashWork : MonoBehaviour
{
    private float timer = 0f;
    private GameObject person;
    private GameObject puppy;
    // Need to reference the ClickManager when the puppy leaves
    private GameObject cm;

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
                changeMove = true;
            }

            // After 2 seconds, they can leave
            timer += (Time.deltaTime)%60;
            if(timer >= 2) {
                newCustomer = false;
                person.GetComponent<PlayerClickToMove>().setMove();
                puppy.GetComponent<PuppyDragAndDrop>().setMove();
                // After paying, alert the script
                puppy.GetComponent<PuppyCustomer>().done(cm);
                timer = 0f;
            }
        }
    }

    // Setter functions
    public void send(GameObject p, GameObject cm_) {
        if(p.tag == "Puppy") {
            newCustomer = true;
            changeMove = false;
            puppy = p;
            isPuppy = true;
            cm = cm_;
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
