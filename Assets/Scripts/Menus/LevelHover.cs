using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Validates whether a level has been reached yet, and if so, displaying regular hover functionality
public class LevelHover : MonoBehaviour
{
    void Start() {
        GetComponent<Renderer>().material.color = Color.black;
    }

    void OnMouseEnter() {
    	if(GetComponent<LevelSelector>().reachedLevel()) {
        	GetComponent<Renderer>().material.color = Color.red;
        }
    }

    void OnMouseExit() {
        GetComponent<Renderer>().material.color = Color.black;
    }
}
