using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
  public bool isPlay;
  public bool isQuit;
  public bool isInstructions;

  void OnMouseUp(){
    if(isInstructions)
    {
      SceneManager.LoadScene(1);
    }
  	if(isPlay)
  	{
  		SceneManager.LoadScene(2);
  	}
  	if(isQuit)
  	{
  		Application.Quit();
  	}
  }
}
