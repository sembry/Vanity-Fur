using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// Handles the levels selection menu
public class LevelSelector : MonoBehaviour
{
    public bool isLevel1;
    public bool isLevel2;
    public bool isLevel3;
    public bool isLevel4;
    public bool isLevel5;
    public bool isBack;

    private int level;

    void Start() {
        level = GameObject.Find("GameManager").GetComponent<GameManager>().getLevel();
    }

    // If the player has reached the level, load the scene
    void OnMouseUp() {
        if(isLevel1) {
            SceneManager.LoadScene("Level1");
        }
    	if(isLevel2) {
            if(level >= 2) {
                SceneManager.LoadScene("Level2");
            }
    	}
        if(isLevel3) {
    		if(level >= 3) {
                SceneManager.LoadScene("Level3");
            }
    	}
        if(isLevel4) {
    		if(level >= 4) {
                SceneManager.LoadScene("Level4");
            }
    	}
        if(isLevel5) {
    		if(level >= 5) {
                SceneManager.LoadScene("Level5");
            }
    	}
        if(isBack) {
        SceneManager.LoadScene("MainMenu");
        }
    }

    public void setLevel(int i) {
        level = i;
    }

    // Returns whether the player has reached this level
    public bool reachedLevel() {
        int checkLevel = 0;
        switch(gameObject.name) {
            case "Level1": checkLevel = 1; break;
            case "Level2": checkLevel = 2; break;
            case "Level3": checkLevel = 3; break;
            case "Level4": checkLevel = 4; break;
            case "Level5": checkLevel = 5; break;
        }
        if(checkLevel <= level) {
            return true;
        }
        return false;
    }
}
