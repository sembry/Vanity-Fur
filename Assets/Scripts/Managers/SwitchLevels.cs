using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles continuing to the next level
public class SwitchLevels : MonoBehaviour
{
	public int currentLevel;
    private int goal;
    private int seconds = 1;
	private float timer;
	private bool menuCreated = false;
    private bool signDone = false;
    private bool puppiesGone = false;
    private bool started = false;

    private GameObject sign;
    private GameObject signParent;
    private GameObject puppyParent;

    void Start() {
        // Decide the money goal for the level
        switch(currentLevel) {
            case 1: goal = 25; break;
            case 2: goal = 45; break;
            case 3: goal = 80; break;
            case 4: goal = 120; break;
            case 5: goal = 160; break;
        }
        signParent = GameObject.Find("Entrance");
        puppyParent = GameObject.Find("Puppies");
    }

    public void onClick() {
    	SceneManager.LoadScene(currentLevel + 1);
    }

    void Update() {
        // Makes sure that the beginning menu has been closed
        if(started) {
        	timer += (Time.deltaTime) % 60;
        	if(timer >= seconds) {
                // Sends the time to the HUD
        		GetComponent<HUD>().receiveTime(45 + (currentLevel * 15) - seconds);
        		seconds++;
        	}
        	if(timer >= 45 + (currentLevel * 15)) {
                // Put sign up, stop spawning puppies, and check for no more puppies
                if(!signDone) {
                    sign = (GameObject)Instantiate(Resources.Load("Closed"), new Vector3(10.61f, -5.15f, 0), 
                        Quaternion.identity);
                    sign.transform.SetParent(signParent.transform, true);
                    signDone = true;
                    GetComponent<LevelController>().stopCreating();
                    puppyParent.GetComponent<PuppiesLeft>().noTimeLeft();
                }
        		// Bring up the menu and update GameManager w/ the new level
    			if(!menuCreated && puppiesGone) {
    				menuCreated = true;
    				GameObject endMenu = (GameObject)Instantiate(Resources.Load("EndPanel"), new Vector3(0, 0, 0), Quaternion.identity);
    				endMenu.GetComponent<EndLevel>().setLevelNumber(currentLevel);
    				endMenu.GetComponent<EndLevel>().setEndMoney(GetComponent<PlayerMoney>().getBalance());
    				endMenu.GetComponent<EndLevel>().setTargetMoney(goal);
                    GameObject.Find("GameManager").GetComponent<GameManager>().updateLevel();
    			}
        	}
        }
    }

    public void noPuppiesLeft() {
        puppiesGone = true;
    }

    public int getCurrentLevel() {
    	return currentLevel;
    }

    public void startTimer() {
        started = true;
    }
}