using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

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
}
