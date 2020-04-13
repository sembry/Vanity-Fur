using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 1;
      pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
          // pause if game is running
          if(!pausePanel.activeInHierarchy)
          {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
          }
          // unpause if game is currently paused
          else
          {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
          }
        }
    }
}
