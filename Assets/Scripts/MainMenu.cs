using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
  public bool isPlay;
  public bool isQuit;

  void OnMouseUp(){
  	if(isPlay)
  	{
  		Application.LoadLevel(1);
  	}
  	if(isQuit)
  	{
  		Application.Quit();
  	}
  }
}
