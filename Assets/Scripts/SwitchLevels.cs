using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles continuing to the next level
public class SwitchLevels : MonoBehaviour
{
	public int currentLevel;
	private float timer;
	private bool menuCreated = false;

    public void onClick() {
    	SceneManager.LoadScene(currentLevel + 1);
    }

    // Keeps track of timer of the level
    void Update() {
    	timer += (Time.deltaTime) % 60;
    	if(timer >= 45 + (currentLevel * 15)) {
    		// bring up the menu
				if(menuCreated == false) {
					menuCreated = true;
					GameObject endMenu = (GameObject)Instantiate(Resources.Load("EndPanel"), new Vector3(0, 0, 0), Quaternion.identity);
					endMenu.GetComponent<EndLevel>().setLevelNumber(currentLevel);
					endMenu.GetComponent<EndLevel>().setEndMoney(GetComponent<PlayerMoney>().getBalance());
					endMenu.GetComponent<EndLevel>().setTargetMoney(10 + 20*currentLevel);
				}
    	}
    }
}
