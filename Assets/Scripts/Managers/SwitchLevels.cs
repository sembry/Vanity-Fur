using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles continuing to the next level
public class SwitchLevels : MonoBehaviour
{
	public int currentLevel;
    private int goal;
	private float timer;
	private bool menuCreated = false;
	private int seconds = 1;

    void Start() {
        switch(currentLevel) {
            case 1: goal = 25; break;
            case 2: goal = 55; break;
            case 3: goal = 80; break;
            case 4: goal = 120; break;
            case 5: goal = 160; break;
        }
    }

    public void onClick() {
    	SceneManager.LoadScene(currentLevel + 1);
    }

    // Keeps track of timer of the level
    void Update() {
    	timer += (Time.deltaTime) % 60;
    	if(timer >= seconds) {
    		GetComponent<HUD>().receiveTime(seconds);
    		seconds++;
    	}
    	if(timer >= 45 + (currentLevel * 15)) {
    		// bring up the menu
				if(menuCreated == false) {
					menuCreated = true;
					GameObject endMenu = (GameObject)Instantiate(Resources.Load("EndPanel"), new Vector3(0, 0, 0), Quaternion.identity);
					endMenu.GetComponent<EndLevel>().setLevelNumber(currentLevel);
					endMenu.GetComponent<EndLevel>().setEndMoney(GetComponent<PlayerMoney>().getBalance());
					endMenu.GetComponent<EndLevel>().setTargetMoney(goal);
				}
    	}
    }

    public int getCurrentLevel() {
    	return currentLevel;
    }
}