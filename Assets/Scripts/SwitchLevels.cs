using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles continuing to the next level
public class SwitchLevels : MonoBehaviour
{
	public int currentLevel;
	private float timer;

    public void onClick() {
    	SceneManager.LoadScene(currentLevel + 1);
    }

    // Keeps track of timer of the level
    void Update() {
    	timer += (Time.deltaTime) % 60;
    	if(timer >= 15 + (currentLevel * 15)) {
    		// bring up the menu
    	}
    }
}
