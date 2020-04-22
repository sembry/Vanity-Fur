using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Retains level info throughout the scenes
public class GameManager : MonoBehaviour
{
	private int level = 1;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public int getLevel() {
    	return level;
    }
    
    public void updateLevel() {
    	level++;
    }
}
