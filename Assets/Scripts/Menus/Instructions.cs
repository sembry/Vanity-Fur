using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Instructions : MonoBehaviour {

    public bool isQuit;
    public bool isPlay;

    void OnMouseUp()
    {
      if(isQuit)
      {
        SceneManager.LoadScene("MainMenu");
      }
      if(isPlay)
      {
        SceneManager.LoadScene("LevelSelector");
      }
    }
}
