using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppiesLeft : MonoBehaviour
{
	private GameObject level;
	private bool lookForPuppies = false;

    void Start()
    {
        level = GameObject.Find("LevelController");
    }

    void Update() {
    	if(lookForPuppies && transform.childCount == 0) {
    		level.GetComponent<SwitchLevels>().noPuppiesLeft();
    	}
    }

    public void noTimeLeft() {
    	lookForPuppies = true;
    } 
}
