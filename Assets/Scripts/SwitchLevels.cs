using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles continuing to the next level
public class SwitchLevels : MonoBehaviour
{

	public string levelName;

    public void onClick() {
    	SceneManager.LoadScene(levelName);
    }
}
