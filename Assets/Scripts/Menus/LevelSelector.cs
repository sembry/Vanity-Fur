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

    void OnMouseUp(){
      if(isLevel1)
      {
        SceneManager.LoadScene("Level1");
      }
    	if(isLevel2)
    	{
    		SceneManager.LoadScene("Level2");
    	}
      if(isLevel3)
    	{
    		SceneManager.LoadScene("Level3");
    	}
      if(isLevel4)
    	{
    		SceneManager.LoadScene("Level4");
    	}
      if(isLevel5)
    	{
    		SceneManager.LoadScene("Level5");
    	}
      if(isBack)
      {
        SceneManager.LoadScene("MainMenu");
      }
    }
}
